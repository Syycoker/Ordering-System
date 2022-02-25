using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TQSSandwichSystem.Server
{
  public partial class ServerForm : Form
  {
    #region Members
    private TcpListener? Listener { get; set; } = null;
    private const int PORT = 50001;
    private string IP_ADDRESS = "10.12.192.142";
    private List<TcpClient> Client_Sockets { get; set; } = new();
    #endregion
    #region Constructor
    public ServerForm()
    {
      InitializeComponent();
      EstablishConnection();
    }
    #endregion
    #region Private
    private void EstablishConnection()
    {
      try
      {
        Text = "Attempting to establish server...";

        Listener = new TcpListener(IPAddress.Parse(IP_ADDRESS), PORT);
        Listener.Start();

        Text = "Server Started...";

        Thread listenThread = new Thread(ListenForClients);
        listenThread.Start();

        Text = "Server Listening for connection requests...";
      }
      catch
      {
        MessageBox.Show("Unable to establish a connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Listener?.Stop();
      }
    }

    private void ListenForClients()
    {
      try
      {
        if (Listener is null) { throw new Exception("Listener is not instantiated."); }

        while (true)
        {
          TcpClient newClient = Listener.AcceptTcpClient();

          if (newClient is not null)
          {
            Client_Sockets.Add(newClient);

            Thread clientThread = new Thread(() => { ClientListener(newClient); });
            clientThread.Start();
          }

          BeginInvoke(() => {
            Text = $"Current Clients: '{ Client_Sockets.Count }'.";
          });
        }
      }
      catch
      {
        MessageBox.Show("Unable to establish a connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void ClientListener(TcpClient client)
    {
      try
      {
        // Wasting space but no simpler way to do it...
        byte[] byteArr = new byte[1000];

        while (true)
        {
          client.GetStream().Read(byteArr);
          string orderRequestString = Encoding.UTF8.GetString(byteArr);

          JObject orderRequestJsonObject = JObject.Parse(orderRequestString);
          if (orderRequestJsonObject is null) { throw new Exception("Order Request couldn't be parsed to a valid JSON Object."); }
          if (orderRequestJsonObject["Action"] is null) { throw new Exception("Order Request has an invalid 'Action' Attribute."); }

          int? actionFromOrderRequest = orderRequestJsonObject["Action"]?.Value<int>();
          if (!actionFromOrderRequest.HasValue) { throw new Exception("Action value is invalid."); }
          int action = actionFromOrderRequest.Value;

          switch (action)
          {
            default:
            case 0:
              throw new Exception("Invalid Action.");

            case 1:
              DataGridViewRow newRow = new DataGridViewRow();
              newRow.Cells.Add(new DataGridViewTextBoxCell() { ValueType = typeof(string), Value = orderRequestJsonObject?["User"]?.Value<string>() });
              newRow.Cells.Add(new DataGridViewTextBoxCell() { ValueType = typeof(DateTime), Value = orderRequestJsonObject?["OrderTime"]?.Value<string>() });
              var orderItems = orderRequestJsonObject?["OrderItems"]?.Values<string>().ToArray();
              newRow.Cells.Add(new DataGridViewComboBoxCell() { ValueType = typeof(string)});
              DataGridViewComboBoxCell? comboBox = newRow.Cells[2] as DataGridViewComboBoxCell;
              comboBox?.Items.AddRange(orderItems);

              newRow.Cells.Add(new DataGridViewTextBoxCell() { ValueType = typeof(string), Value = orderRequestJsonObject?["DietaryRequirement"]?.Value<string>() });

              BeginInvoke(()=>
                OrderTable.Rows.Add(newRow)
              );

              break;
            case 2:
              BeginInvoke(() =>
              {
                List<DataGridViewRow> rowsToDelete = new();
                foreach (DataGridViewRow row in OrderTable.Rows)
                {
                  if (row.Cells[0].Value.Equals(orderRequestJsonObject?["User"]?.Value<string>())) { rowsToDelete.Add(row); }
                }

                foreach (var row in rowsToDelete)
                {
                  OrderTable.Rows.Remove(row);
                }
              });
              break;
          }

          const string OK_RESPONSE = "ack";

          byte[] responseArr = Encoding.ASCII.GetBytes(OK_RESPONSE);

          client.GetStream().Write(responseArr);

          // Display order Request.
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        MessageBox.Show("Unknown Error has occured when recievind data from client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        client.Close();
        Client_Sockets.Remove(client);
      }
    }
    #endregion
  }
}
