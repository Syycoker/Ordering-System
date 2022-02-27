using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Nodes;
using System.Xml;
using TQSSandwichClient;
using TQSSandwichClient.Controls;
using TQSSandwichClient.Enumerations;

namespace TQSSandwichSystem
{
  public partial class ClientForm : Form
  {
    #region Members
    private const string ACKNOWLEDGEMENT = "ack";
    private decimal Total = 0.00m;
    private const int Port = 50001;
    private TcpClient Client = new();
    private bool Connected { get; set; } = false;
    #endregion
    #region Constructor
    /// <summary>
    /// Standard constructor.
    /// </summary>
    public ClientForm()
    {
      try
      {
        InitializeComponent();
        bool connectionResult = ConnectToServer();
        if (Connected == false)
        {
          MessageBox.Show("Unable to connect to server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

          // Continuously retry connection in the background.
          Thread retryConnectionThread = new Thread(TryConnectingToServer) { IsBackground = true };
          retryConnectionThread.Start();
        }

        Text = Connected ? "Connected" : "Not Connected, retrying Connection...";

        // Load the menu items
        LoadMenuItems();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    #endregion
    #region Methods

    /// <summary>
    /// Loads in all the information about all the menu items from the "Windmill Sandwich Bar" Menu.
    /// Must handle excpetion when calling this function.
    /// </summary>
    private void LoadMenuItems()
    {
      var response = InitialiseMenuItems.MenuItemsJson;
      JArray responseJArray = JArray.Parse(response);
      if (responseJArray is null) { throw new ArgumentNullException(); }

      for (int i = 0; i < MenuTable.RowCount; i++)
      {
        MenuItemStrip newStrip = new MenuItemStrip(responseJArray[i]);
        newStrip.MenuItemAdjustment += HandleOrderAdjusted;
        MenuTable.Controls.Add(newStrip);
      }
    }

    /// <summary>
    /// Retry to connect to the server every 10 seconds.
    /// </summary>
    private void TryConnectingToServer()
    {
      while (true)
      {
        bool connectionResult = ConnectToServer();
        
        if (connectionResult)
        {
          BeginInvoke(() =>
          {
            Text = "Connected.";
          });
          return;
        }
        else
        {
          BeginInvoke(()=>
          {
            Text = "Unable to connect to server, retrying connnecting again in 10 seconds...";
          });

          Thread.Sleep(10000);
        }
      }
    }

    /// <summary>
    /// Attempt to connect to the server.
    /// </summary>
    /// <returns></returns>
    private bool ConnectToServer()
    {
      try
      {
        Client.Connect(IPAddress.Loopback, Port);
        Connected = true;

        return true;
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    /// Send a JSON string to the server and wait for a response, *BLOCKING CALL*.
    /// </summary>
    /// <param name="orderRequestObject"></param>
    /// <returns></returns>
    private string SendOrderRequest(OrderRequest orderRequestObject)
    {
      string orderRequestJsonString = JsonConvert.SerializeObject(orderRequestObject);
      byte[] orderRequestByteArr = Encoding.ASCII.GetBytes(orderRequestJsonString);
      
      Stream clientStream = Client.GetStream();
      clientStream.Write(orderRequestByteArr, 0, orderRequestByteArr.Length);

      byte[] acknowledgementResponseArr = new byte[100];
      int k = clientStream.Read(acknowledgementResponseArr, 0, acknowledgementResponseArr.Length);

      StringBuilder sb = new StringBuilder();

      for (int i = 0; i < k; i++)
      {
        sb.Append(Convert.ToChar(acknowledgementResponseArr[i]));
      }

      string response = sb.ToString();

      return response;
    }
    #endregion
    #region Events

    /// <summary>
    /// Adds or remove a menu items from the listbox based on the user's actions via 'MenuItemModified'.
    /// </summary>
    /// <param name="action"></param>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="amount"></param>
    private void HandleOrderAdjusted(MenuItemAction action, string name, decimal price, int amount)
    {
      if (OrderListBox is null) { return; }
      string accessableItemObjectName = name + $" | (x{ amount })";
      switch (action)
      {
        case MenuItemAction.ADD:
          OrderListBox.Items.Add(accessableItemObjectName);
          Total += (price * amount);
          break;

        case MenuItemAction.REMOVE:
          if (OrderListBox.Items.Contains(accessableItemObjectName))
          {
            OrderListBox.Items.Remove(accessableItemObjectName);
            Total -= (price * amount);
          }
          break;

        default:
          return;
      }

      TotalTextBox.Text = "Total: " + Total.ToString("C2");
    }

    /// <summary>
    /// Sends an 'OrderRequest' object to the server and waits for an acknowledgement.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="ArgumentNullException"></exception>
    private void HandleOrderConfirmation(object sender, EventArgs e)
    {
      try
      {
        if (!Connected) { throw new Exception("Not connnected to server."); }

        DialogResult userChoice = MessageBox.Show("Confirm Order?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        if (userChoice != DialogResult.Yes) { return; }

        if (OrderListBox.Items.Count < 1) { throw new Exception("No Items Selected."); }

        List<string> items = new();

        foreach (var item in OrderListBox.Items)
        {
          string? orderItem = item?.ToString();
          if (orderItem is null || string.IsNullOrEmpty(orderItem)) { throw new ArgumentNullException(); }
          items.Add(orderItem);
        }

        OrderRequest orderRequest = new(MenuItemAction.ADD,items, NotesTextBox.Text);

        string response = SendOrderRequest(orderRequest);

        if (!response.Equals(ACKNOWLEDGEMENT)) { throw new Exception("Server did not confirm order request."); }

        MessageBox.Show("Order Sent", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Text = "Order Sent.";
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>
    /// Sends an OrderRequest object to the server and cancels all orders as I could have used an ID so the user can cancel a specific order
    /// ButI assume they don't know it and just "play it safe".
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleCancelOrder(object sender, EventArgs e)
    {
      try
      {
        OrderRequest removeOrderRequest = new(MenuItemAction.REMOVE, null, string.Empty);
        string response = SendOrderRequest(removeOrderRequest);

        if (!response.ToLower().Equals(ACKNOWLEDGEMENT)) { throw new Exception("Unable to cancel order, please speak to server manager."); }

        MessageBox.Show("All Orders Cancelled", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    #endregion
  }
}