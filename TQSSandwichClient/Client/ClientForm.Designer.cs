namespace TQSSandwichSystem
{
  partial class ClientForm
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.SplitContainer = new System.Windows.Forms.SplitContainer();
      this.NotesTextBox = new System.Windows.Forms.TextBox();
      this.ConfirmButton = new System.Windows.Forms.Button();
      this.CancelOrderButton = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.TotalTextBox = new System.Windows.Forms.TextBox();
      this.OrderListBox = new System.Windows.Forms.ListBox();
      this.MenuTable = new System.Windows.Forms.TableLayoutPanel();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
      this.SplitContainer.Panel1.SuspendLayout();
      this.SplitContainer.Panel2.SuspendLayout();
      this.SplitContainer.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // SplitContainer
      // 
      this.SplitContainer.Cursor = System.Windows.Forms.Cursors.Default;
      this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SplitContainer.Location = new System.Drawing.Point(0, 0);
      this.SplitContainer.Name = "SplitContainer";
      // 
      // SplitContainer.Panel1
      // 
      this.SplitContainer.Panel1.Controls.Add(this.NotesTextBox);
      this.SplitContainer.Panel1.Controls.Add(this.ConfirmButton);
      this.SplitContainer.Panel1.Controls.Add(this.CancelOrderButton);
      this.SplitContainer.Panel1.Controls.Add(this.panel1);
      // 
      // SplitContainer.Panel2
      // 
      this.SplitContainer.Panel2.Controls.Add(this.MenuTable);
      this.SplitContainer.Size = new System.Drawing.Size(790, 495);
      this.SplitContainer.SplitterDistance = 239;
      this.SplitContainer.TabIndex = 8;
      // 
      // NotesTextBox
      // 
      this.NotesTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.NotesTextBox.Location = new System.Drawing.Point(0, 391);
      this.NotesTextBox.Multiline = true;
      this.NotesTextBox.Name = "NotesTextBox";
      this.NotesTextBox.PlaceholderText = "Notes:";
      this.NotesTextBox.Size = new System.Drawing.Size(239, 58);
      this.NotesTextBox.TabIndex = 2;
      // 
      // ConfirmButton
      // 
      this.ConfirmButton.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.ConfirmButton.Location = new System.Drawing.Point(0, 449);
      this.ConfirmButton.Name = "ConfirmButton";
      this.ConfirmButton.Size = new System.Drawing.Size(239, 23);
      this.ConfirmButton.TabIndex = 1;
      this.ConfirmButton.Text = "Confirm";
      this.ConfirmButton.UseVisualStyleBackColor = true;
      this.ConfirmButton.Click += new System.EventHandler(this.HandleOrderConfirmation);
      // 
      // CancelOrderButton
      // 
      this.CancelOrderButton.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.CancelOrderButton.Location = new System.Drawing.Point(0, 472);
      this.CancelOrderButton.Name = "CancelOrderButton";
      this.CancelOrderButton.Size = new System.Drawing.Size(239, 23);
      this.CancelOrderButton.TabIndex = 3;
      this.CancelOrderButton.Text = "Cancel Order";
      this.CancelOrderButton.UseVisualStyleBackColor = true;
      this.CancelOrderButton.Click += new System.EventHandler(this.HandleCancelOrder);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.TotalTextBox);
      this.panel1.Controls.Add(this.OrderListBox);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(239, 284);
      this.panel1.TabIndex = 0;
      // 
      // TotalTextBox
      // 
      this.TotalTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TotalTextBox.Location = new System.Drawing.Point(0, 259);
      this.TotalTextBox.Name = "TotalTextBox";
      this.TotalTextBox.PlaceholderText = "Total:";
      this.TotalTextBox.ReadOnly = true;
      this.TotalTextBox.Size = new System.Drawing.Size(239, 23);
      this.TotalTextBox.TabIndex = 1;
      // 
      // OrderListBox
      // 
      this.OrderListBox.Dock = System.Windows.Forms.DockStyle.Top;
      this.OrderListBox.FormattingEnabled = true;
      this.OrderListBox.ItemHeight = 15;
      this.OrderListBox.Location = new System.Drawing.Point(0, 0);
      this.OrderListBox.Name = "OrderListBox";
      this.OrderListBox.Size = new System.Drawing.Size(239, 259);
      this.OrderListBox.TabIndex = 0;
      // 
      // MenuTable
      // 
      this.MenuTable.ColumnCount = 1;
      this.MenuTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.MenuTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MenuTable.Location = new System.Drawing.Point(0, 0);
      this.MenuTable.Name = "MenuTable";
      this.MenuTable.RowCount = 19;
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263156F));
      this.MenuTable.Size = new System.Drawing.Size(547, 495);
      this.MenuTable.TabIndex = 0;
      // 
      // ClientForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(790, 495);
      this.Controls.Add(this.SplitContainer);
      this.Name = "ClientForm";
      this.Text = "Order Application";
      this.SplitContainer.Panel1.ResumeLayout(false);
      this.SplitContainer.Panel1.PerformLayout();
      this.SplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
      this.SplitContainer.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private SplitContainer SplitContainer;
    private TableLayoutPanel MenuTable;
    private Panel panel1;
    private Button ConfirmButton;
    private TextBox TotalTextBox;
    private ListBox OrderListBox;
    private TextBox NotesTextBox;
    private Button CancelOrderButton;
  }
}