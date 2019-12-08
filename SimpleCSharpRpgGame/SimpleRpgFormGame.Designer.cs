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
            // SimpleRpgFormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 651);
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
    }
}

