namespace TQSSandwichSystem.Server
{
  partial class ServerForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.OrderTable = new System.Windows.Forms.DataGridView();
      this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.OrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.OrderItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CsvButton = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.OrderTable)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.625F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.375F));
      this.tableLayoutPanel1.Controls.Add(this.OrderTable, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.CsvButton, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // OrderTable
      // 
      this.OrderTable.AllowUserToAddRows = false;
      this.OrderTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.OrderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.OrderTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.OrderTime,
            this.OrderItem,
            this.Notes});
      this.OrderTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.OrderTable.Location = new System.Drawing.Point(176, 3);
      this.OrderTable.Name = "OrderTable";
      this.OrderTable.RowTemplate.Height = 25;
      this.OrderTable.Size = new System.Drawing.Size(621, 444);
      this.OrderTable.TabIndex = 0;
      // 
      // UserName
      // 
      this.UserName.HeaderText = "Name";
      this.UserName.Name = "UserName";
      // 
      // OrderTime
      // 
      this.OrderTime.HeaderText = "Time of Order";
      this.OrderTime.Name = "OrderTime";
      // 
      // OrderItem
      // 
      this.OrderItem.HeaderText = "Order Items";
      this.OrderItem.Name = "OrderItem";
      // 
      // Notes
      // 
      this.Notes.HeaderText = "Notes";
      this.Notes.Name = "Notes";
      // 
      // CsvButton
      // 
      this.CsvButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.CsvButton.Location = new System.Drawing.Point(3, 3);
      this.CsvButton.Name = "CsvButton";
      this.CsvButton.Size = new System.Drawing.Size(167, 23);
      this.CsvButton.TabIndex = 1;
      this.CsvButton.Text = "Print To CSV";
      this.CsvButton.UseVisualStyleBackColor = true;
      this.CsvButton.Click += new System.EventHandler(this.HandlePrint);
      // 
      // ServerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "ServerForm";
      this.Text = "ServerForm";
      this.tableLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.OrderTable)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private DataGridView OrderTable;
    private Button CsvButton;
    private DataGridViewTextBoxColumn UserName;
    private DataGridViewTextBoxColumn OrderTime;
    private DataGridViewTextBoxColumn OrderItem;
    private DataGridViewTextBoxColumn Notes;
  }
}