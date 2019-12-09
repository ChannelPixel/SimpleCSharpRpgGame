namespace SimpleCSharpRpgGame
{
    partial class SimpleRpgFormGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Level = new System.Windows.Forms.Label();
            this.lbl_Experience = new System.Windows.Forms.Label();
            this.lbl_Gold = new System.Windows.Forms.Label();
            this.lbl_HitPoints = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_Weapons = new System.Windows.Forms.ComboBox();
            this.cbo_Potions = new System.Windows.Forms.ComboBox();
            this.btn_UseWeapon = new System.Windows.Forms.Button();
            this.btn_UsePotion = new System.Windows.Forms.Button();
            this.btn_North = new System.Windows.Forms.Button();
            this.btn_East = new System.Windows.Forms.Button();
            this.btn_South = new System.Windows.Forms.Button();
            this.btn_West = new System.Windows.Forms.Button();
            this.rtb_Location = new System.Windows.Forms.RichTextBox();
            this.rtb_Messages = new System.Windows.Forms.RichTextBox();
            this.dgv_Inventory = new System.Windows.Forms.DataGridView();
            this.dgv_Quests = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Quests)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hit Points:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gold:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Experience:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Level:";
            // 
            // lbl_Level
            // 
            this.lbl_Level.AutoSize = true;
            this.lbl_Level.Location = new System.Drawing.Point(110, 99);
            this.lbl_Level.Name = "lbl_Level";
            this.lbl_Level.Size = new System.Drawing.Size(35, 13);
            this.lbl_Level.TabIndex = 7;
            this.lbl_Level.Text = "label5";
            // 
            // lbl_Experience
            // 
            this.lbl_Experience.AutoSize = true;
            this.lbl_Experience.Location = new System.Drawing.Point(110, 73);
            this.lbl_Experience.Name = "lbl_Experience";
            this.lbl_Experience.Size = new System.Drawing.Size(35, 13);
            this.lbl_Experience.TabIndex = 6;
            this.lbl_Experience.Text = "label6";
            // 
            // lbl_Gold
            // 
            this.lbl_Gold.AutoSize = true;
            this.lbl_Gold.Location = new System.Drawing.Point(110, 45);
            this.lbl_Gold.Name = "lbl_Gold";
            this.lbl_Gold.Size = new System.Drawing.Size(35, 13);
            this.lbl_Gold.TabIndex = 5;
            this.lbl_Gold.Text = "label7";
            // 
            // lbl_HitPoints
            // 
            this.lbl_HitPoints.AutoSize = true;
            this.lbl_HitPoints.Location = new System.Drawing.Point(110, 19);
            this.lbl_HitPoints.Name = "lbl_HitPoints";
            this.lbl_HitPoints.Size = new System.Drawing.Size(35, 13);
            this.lbl_HitPoints.TabIndex = 4;
            this.lbl_HitPoints.Text = "label8";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(617, 531);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Select action";
            // 
            // cbo_Weapons
            // 
            this.cbo_Weapons.FormattingEnabled = true;
            this.cbo_Weapons.Location = new System.Drawing.Point(369, 559);
            this.cbo_Weapons.Name = "cbo_Weapons";
            this.cbo_Weapons.Size = new System.Drawing.Size(121, 21);
            this.cbo_Weapons.TabIndex = 9;
            // 
            // cbo_Potions
            // 
            this.cbo_Potions.FormattingEnabled = true;
            this.cbo_Potions.Location = new System.Drawing.Point(369, 593);
            this.cbo_Potions.Name = "cbo_Potions";
            this.cbo_Potions.Size = new System.Drawing.Size(121, 21);
            this.cbo_Potions.TabIndex = 10;
            // 
            // btn_UseWeapon
            // 
            this.btn_UseWeapon.Location = new System.Drawing.Point(620, 559);
            this.btn_UseWeapon.Name = "btn_UseWeapon";
            this.btn_UseWeapon.Size = new System.Drawing.Size(75, 23);
            this.btn_UseWeapon.TabIndex = 11;
            this.btn_UseWeapon.Text = "Use";
            this.btn_UseWeapon.UseVisualStyleBackColor = true;
            this.btn_UseWeapon.Click += new System.EventHandler(this.btn_UseWeapon_Click);
            // 
            // btn_UsePotion
            // 
            this.btn_UsePotion.Location = new System.Drawing.Point(620, 593);
            this.btn_UsePotion.Name = "btn_UsePotion";
            this.btn_UsePotion.Size = new System.Drawing.Size(75, 23);
            this.btn_UsePotion.TabIndex = 12;
            this.btn_UsePotion.Text = "Use";
            this.btn_UsePotion.UseVisualStyleBackColor = true;
            this.btn_UsePotion.Click += new System.EventHandler(this.btn_UsePotion_Click);
            // 
            // btn_North
            // 
            this.btn_North.Location = new System.Drawing.Point(493, 433);
            this.btn_North.Name = "btn_North";
            this.btn_North.Size = new System.Drawing.Size(75, 23);
            this.btn_North.TabIndex = 13;
            this.btn_North.Text = "North";
            this.btn_North.UseVisualStyleBackColor = true;
            this.btn_North.Click += new System.EventHandler(this.btn_North_Click);
            // 
            // btn_East
            // 
            this.btn_East.Location = new System.Drawing.Point(573, 457);
            this.btn_East.Name = "btn_East";
            this.btn_East.Size = new System.Drawing.Size(75, 23);
            this.btn_East.TabIndex = 14;
            this.btn_East.Text = "East";
            this.btn_East.UseVisualStyleBackColor = true;
            this.btn_East.Click += new System.EventHandler(this.btn_East_Click);
            // 
            // btn_South
            // 
            this.btn_South.Location = new System.Drawing.Point(493, 487);
            this.btn_South.Name = "btn_South";
            this.btn_South.Size = new System.Drawing.Size(75, 23);
            this.btn_South.TabIndex = 15;
            this.btn_South.Text = "South";
            this.btn_South.UseVisualStyleBackColor = true;
            this.btn_South.Click += new System.EventHandler(this.btn_South_Click);
            // 
            // btn_West
            // 
            this.btn_West.Location = new System.Drawing.Point(412, 457);
            this.btn_West.Name = "btn_West";
            this.btn_West.Size = new System.Drawing.Size(75, 23);
            this.btn_West.TabIndex = 16;
            this.btn_West.Text = "West";
            this.btn_West.UseVisualStyleBackColor = true;
            this.btn_West.Click += new System.EventHandler(this.btn_West_Click);
            // 
            // rtb_Location
            // 
            this.rtb_Location.Location = new System.Drawing.Point(347, 19);
            this.rtb_Location.Name = "rtb_Location";
            this.rtb_Location.ReadOnly = true;
            this.rtb_Location.Size = new System.Drawing.Size(360, 105);
            this.rtb_Location.TabIndex = 17;
            this.rtb_Location.Text = "";
            // 
            // rtb_Messages
            // 
            this.rtb_Messages.Location = new System.Drawing.Point(347, 130);
            this.rtb_Messages.Name = "rtb_Messages";
            this.rtb_Messages.Size = new System.Drawing.Size(360, 286);
            this.rtb_Messages.TabIndex = 18;
            this.rtb_Messages.Text = "";
            // 
            // dgv_Inventory
            // 
            this.dgv_Inventory.AllowUserToAddRows = false;
            this.dgv_Inventory.AllowUserToDeleteRows = false;
            this.dgv_Inventory.AllowUserToResizeColumns = false;
            this.dgv_Inventory.AllowUserToResizeRows = false;
            this.dgv_Inventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Inventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Inventory.Enabled = false;
            this.dgv_Inventory.Location = new System.Drawing.Point(16, 130);
            this.dgv_Inventory.MultiSelect = false;
            this.dgv_Inventory.Name = "dgv_Inventory";
            this.dgv_Inventory.ReadOnly = true;
            this.dgv_Inventory.RowHeadersVisible = false;
            this.dgv_Inventory.Size = new System.Drawing.Size(312, 309);
            this.dgv_Inventory.TabIndex = 19;
            // 
            // dgv_Quests
            // 
            this.dgv_Quests.AllowUserToAddRows = false;
            this.dgv_Quests.AllowUserToDeleteRows = false;
            this.dgv_Quests.AllowUserToResizeColumns = false;
            this.dgv_Quests.AllowUserToResizeRows = false;
            this.dgv_Quests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Quests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Quests.Enabled = false;
            this.dgv_Quests.Location = new System.Drawing.Point(16, 446);
            this.dgv_Quests.MultiSelect = false;
            this.dgv_Quests.Name = "dgv_Quests";
            this.dgv_Quests.ReadOnly = true;
            this.dgv_Quests.RowHeadersVisible = false;
            this.dgv_Quests.Size = new System.Drawing.Size(312, 189);
            this.dgv_Quests.TabIndex = 20;
            // 
            // SimpleRpgFormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 651);
            this.Controls.Add(this.dgv_Quests);
            this.Controls.Add(this.dgv_Inventory);
            this.Controls.Add(this.rtb_Messages);
            this.Controls.Add(this.rtb_Location);
            this.Controls.Add(this.btn_West);
            this.Controls.Add(this.btn_South);
            this.Controls.Add(this.btn_East);
            this.Controls.Add(this.btn_North);
            this.Controls.Add(this.btn_UsePotion);
            this.Controls.Add(this.btn_UseWeapon);
            this.Controls.Add(this.cbo_Potions);
            this.Controls.Add(this.cbo_Weapons);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_Level);
            this.Controls.Add(this.lbl_Experience);
            this.Controls.Add(this.lbl_Gold);
            this.Controls.Add(this.lbl_HitPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SimpleRpgFormGame";
            this.Text = "SimpleCSharpRpgGame";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Quests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Level;
        private System.Windows.Forms.Label lbl_Experience;
        private System.Windows.Forms.Label lbl_Gold;
        private System.Windows.Forms.Label lbl_HitPoints;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_Weapons;
        private System.Windows.Forms.ComboBox cbo_Potions;
        private System.Windows.Forms.Button btn_UseWeapon;
        private System.Windows.Forms.Button btn_UsePotion;
        private System.Windows.Forms.Button btn_North;
        private System.Windows.Forms.Button btn_East;
        private System.Windows.Forms.Button btn_South;
        private System.Windows.Forms.Button btn_West;
        private System.Windows.Forms.RichTextBox rtb_Location;
        private System.Windows.Forms.RichTextBox rtb_Messages;
        private System.Windows.Forms.DataGridView dgv_Inventory;
        private System.Windows.Forms.DataGridView dgv_Quests;
    }
}

