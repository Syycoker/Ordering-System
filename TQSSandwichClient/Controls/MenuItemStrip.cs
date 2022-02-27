using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TQSSandwichClient.Delegates;
using TQSSandwichClient.Enumerations;

namespace TQSSandwichClient.Controls
{
  public class MenuItemStrip : MenuStrip
  {
    #region Constructors
    public MenuItemStrip()
    {

    }

    public MenuItemStrip(params object[] parameters)
    {
      try
      {
        switch (parameters.Length)
        {
          default:
          case 0:
            break;

          case 1:
            JObject? paramObject = parameters[0] as JObject;
            if (paramObject is null) { throw new ArgumentNullException(); }

            List<ToolStripItem> controls = new();

            RemoveButton = new() { Text = "Remove", Size = new Size(50, 22), Enabled = false };
            RemoveButton.Click += HandleRemoveMenuItems;
            controls.Add(RemoveButton);

            AddButton = new() { Text = "Add", Size = new Size(50, 22), Enabled = false };
            AddButton.Click += HandleAddMenuItems;
            controls.Add(AddButton);

            PriceTextBox = new() { Text = "£0.00", Size = new Size(100, 22), ReadOnly = true };
            controls.Add(PriceTextBox);

            AmountTextBox = new() { Text = "1", Size = new Size(100, 22) };
            AmountTextBox.TextChanged += HandleAmountChanged;
            controls.Add(AmountTextBox);

            MenuItemComboBox = new() { Text = GetCategoryName(paramObject), Size = new Size(140, 22) };
            SetMenuItems(paramObject, MenuItemComboBox);
            MenuItemComboBox.SelectedIndexChanged += HandleMenuItemChanged;
            controls.Add(MenuItemComboBox);

            AddComponents(controls);
            break;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw;
      }
    }
    #endregion
    #region Members
    private Dictionary<string, JObject> MenuItemDictionary = new();
    #endregion
    #region Private
    private void AddComponents(IEnumerable<ToolStripItem> controls)
    {
      if (!DesignMode)
      {
        Items.AddRange(controls.Reverse().ToArray());
      }
    }

    private string GetCategoryName(JObject obj)
    {
      if (obj["Category"] is null) { throw new ArgumentNullException(); }
      string category = obj["Category"]?.Value<string>() ?? "";
      if (string.IsNullOrEmpty(category)) { throw new ArgumentNullException(); }
      return category;
    }

    private void SetMenuItems(JObject obj, ToolStripComboBox comboBox)
    {
      if (!DesignMode)
      {
        var items = obj["Items"]?.Value<JArray>();
        if (items is null) { throw new ArgumentNullException(); }

        comboBox.Items.Add(GetCategoryName(obj));

        foreach (JObject item in items)
        {
          if (item is null) { throw new ArgumentNullException(); }
          string itemName = $"{ item["Name"]?.Value<string>() }";
          comboBox.Items.Add(itemName);
          MenuItemDictionary.Add(itemName, item);
        }
      }
    }
    #region Events
    public event MenuItemModified? MenuItemAdjustment;

    private void HandleMenuItemChanged(object? sender, EventArgs e)
    {
      if (!DesignMode)
      {
        ToolStripComboBox? menuItemComboBox = (ToolStripComboBox?)sender;
        if (menuItemComboBox is null) { throw new ArgumentNullException(); }
        string itemName = menuItemComboBox.SelectedItem?.ToString() ?? "";
        if (string.IsNullOrEmpty(itemName)) { throw new ArgumentNullException(); }

        if (AddButton is null || RemoveButton is null) { return; }

        if (!MenuItemDictionary.ContainsKey(itemName))
        {
          AddButton.Enabled = false;
          RemoveButton.Enabled = false;
          return;
        }
        else
        {
          AddButton.Enabled = true;
          RemoveButton.Enabled = true;
        }

        decimal? priceOfProbableItem = MenuItemDictionary[itemName]?["Price"]?.Value<decimal>();
        decimal priceOfItem = 0.00m;
        if (priceOfProbableItem is null || !priceOfProbableItem.HasValue) { throw new ArgumentNullException(); }
        else { priceOfItem = priceOfProbableItem.Value; }

        if (AmountTextBox is null) { return; }

        int amount = 0;
        int.TryParse(AmountTextBox.Text, out amount);

        if (string.IsNullOrEmpty(AmountTextBox.Text))
        {
          amount = 1;
          AmountTextBox.Text = $"{amount}";
        }

        int amountOfItem = int.Parse(AmountTextBox.Text);

        if (PriceTextBox is null) { throw new ArgumentNullException(); }
        decimal price = priceOfItem * amountOfItem;
        PriceTextBox.Text = price.ToString("C2");
      }
    }

    private void HandleAmountChanged(object? sender, EventArgs e)
    {
      ToolStripTextBox? amountTextBox = (ToolStripTextBox?)sender;
      if (amountTextBox is null) { throw new ArgumentNullException(); }
      int amount = 0;
      int.TryParse(amountTextBox.Text, out amount);

      if (amount == 0)
      {
        amount = 1;
      }

      if (MenuItemComboBox is null || MenuItemComboBox.SelectedItem is null) { return; }
      decimal? priceOfProbableItem = MenuItemDictionary[MenuItemComboBox.SelectedItem.ToString() ?? ""]?["Price"]?.Value<decimal>();
      decimal priceOfItem = 0.00m;
      if (priceOfProbableItem is null || !priceOfProbableItem.HasValue) { throw new ArgumentNullException(); }
      else { priceOfItem = priceOfProbableItem.Value; }

      if (PriceTextBox is null) { throw new ArgumentNullException(); }
      decimal price = priceOfItem * amount;
      PriceTextBox.Text = price.ToString("C2");
    }

    private void HandleAddMenuItems(object? sender, EventArgs e)
    {
      try
      {
        if (MenuItemDictionary is null || MenuItemComboBox is null || MenuItemComboBox.SelectedItem is null) { throw new Exception("No item selected."); }
        string item = MenuItemComboBox.SelectedItem.ToString() ?? "";
        if (!MenuItemDictionary.ContainsKey(item)) { throw new Exception("No item to add."); }
        if (AmountTextBox is null) { throw new Exception($"Invalid amount for '{MenuItemDictionary[item]?["Name"]?.Value<string>()}'."); }

        JObject itemObject = MenuItemDictionary[item];
        string itemName = itemObject?["Name"]?.Value<string>() ?? "";

        decimal? priceOfProbableItem = itemObject?["Price"]?.Value<decimal>();
        decimal priceOfItem = 0.00m;

        if (priceOfProbableItem is null || !priceOfProbableItem.HasValue) { throw new Exception("Invalid price."); }
        else { priceOfItem = priceOfProbableItem.Value; }

        int amount = int.Parse(AmountTextBox.Text);

        if (amount == 0) { throw new Exception("Invalid amount."); }

        MenuItemAdjustment?.Invoke(MenuItemAction.ADD, itemName, priceOfItem, amount);
      }
      catch (Exception eX)
      {
        MessageBox.Show(eX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void HandleRemoveMenuItems(object? sender, EventArgs e)
    {
      try
      {
        if (MenuItemDictionary is null || MenuItemComboBox is null || MenuItemComboBox.SelectedItem is null) { throw new Exception("No item selected."); }
        string item = MenuItemComboBox.SelectedItem.ToString() ?? "";
        if (!MenuItemDictionary.ContainsKey(item)) { throw new Exception("No item to remove."); }
        if (AmountTextBox is null) { throw new Exception($"Invalid amount for '{MenuItemDictionary[item]?["Name"]?.Value<string>()}'."); }

        JObject itemObject = MenuItemDictionary[item];
        string itemName = itemObject?["Name"]?.Value<string>() ?? "";

        decimal? priceOfProbableItem = itemObject?["Price"]?.Value<decimal>();
        decimal priceOfItem = 0.00m;

        if (priceOfProbableItem is null || !priceOfProbableItem.HasValue) { throw new Exception("Invalid price."); }
        else { priceOfItem = priceOfProbableItem.Value; }

        int amount = int.Parse(AmountTextBox.Text);

        if (amount == 0) { throw new Exception("Invalid amount."); }

        MenuItemAdjustment?.Invoke(MenuItemAction.REMOVE, itemName, priceOfItem, amount);
      }
      catch (Exception eX)
      {
        MessageBox.Show(eX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    #endregion
    #endregion
    #region User Controls
    public ToolStripComboBox? MenuItemComboBox { get; set; }
    public ToolStripTextBox? PriceTextBox { get; set; }
    public ToolStripTextBox? AmountTextBox { get; set; }
    public ToolStripMenuItem? AddButton { get; set; }
    public ToolStripMenuItem? RemoveButton { get; set; }
    #endregion
  }
}
