namespace SimpleCSharpRpgGame
{
    partial class TradingScreen
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
            this.lbl_MyInventory = new System.Windows.Forms.Label();
            this.lbl_VendorInventory = new System.Windows.Forms.Label();
            this.dgv_MyItems = new System.Windows.Forms.DataGridView();
            this.dgv_VendorItems = new System.Windows.Forms.DataGridView();
            this.btn_Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MyItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VendorItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_MyInventory
            // 
            this.lbl_MyInventory.AutoSize = true;
            this.lbl_MyInventory.Location = new System.Drawing.Point(99, 13);
            this.lbl_MyInventory.Name = "lbl_MyInventory";
            this.lbl_MyInventory.Size = new System.Drawing.Size(68, 13);
            this.lbl_MyInventory.TabIndex = 0;
            this.lbl_MyInventory.Text = "My Inventory";
            // 
            // lbl_VendorInventory
            // 
            this.lbl_VendorInventory.AutoSize = true;
            this.lbl_VendorInventory.Location = new System.Drawing.Point(349, 13);
            this.lbl_VendorInventory.Name = "lbl_VendorInventory";
            this.lbl_VendorInventory.Size = new System.Drawing.Size(95, 13);
            this.lbl_VendorInventory.TabIndex = 1;
            this.lbl_VendorInventory.Text = "Vendor\'s Inventory";
            // 
            // dgv_MyItems
            // 
            this.dgv_MyItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MyItems.Location = new System.Drawing.Point(13, 43);
            this.dgv_MyItems.Name = "dgv_MyItems";
            this.dgv_MyItems.Size = new System.Drawing.Size(240, 216);
            this.dgv_MyItems.TabIndex = 2;
            this.dgv_MyItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_MyItems_CellClick);
            // 
            // dgv_VendorItems
            // 
            this.dgv_VendorItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_VendorItems.Location = new System.Drawing.Point(276, 43);
            this.dgv_VendorItems.Name = "dgv_VendorItems";
            this.dgv_VendorItems.Size = new System.Drawing.Size(240, 216);
            this.dgv_VendorItems.TabIndex = 3;
            this.dgv_VendorItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_VendorItems_CellClick);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(441, 274);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // TradingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 310);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.dgv_VendorItems);
            this.Controls.Add(this.dgv_MyItems);
            this.Controls.Add(this.lbl_VendorInventory);
            this.Controls.Add(this.lbl_MyInventory);
            this.Name = "TradingScreen";
            this.Text = "Trade";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MyItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VendorItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_MyInventory;
        private System.Windows.Forms.Label lbl_VendorInventory;
        private System.Windows.Forms.DataGridView dgv_MyItems;
        private System.Windows.Forms.DataGridView dgv_VendorItems;
        private System.Windows.Forms.Button btn_Close;
    }
}