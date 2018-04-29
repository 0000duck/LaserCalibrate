namespace Preview
{
    partial class PowerModeWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerModeWindow));
            this.logo = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.LowPowerMode = new System.Windows.Forms.Button();
            this.MediumPowerMode = new System.Windows.Forms.Button();
            this.HighPowerMode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(391, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(567, 379);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(407, 470);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功率模式";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.LowPowerMode);
            this.flowLayoutPanel1.Controls.Add(this.MediumPowerMode);
            this.flowLayoutPanel1.Controls.Add(this.HighPowerMode);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(522, 70);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // LowPowerMode
            // 
            this.LowPowerMode.Location = new System.Drawing.Point(30, 3);
            this.LowPowerMode.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.LowPowerMode.Name = "LowPowerMode";
            this.LowPowerMode.Size = new System.Drawing.Size(109, 59);
            this.LowPowerMode.TabIndex = 0;
            this.LowPowerMode.Text = "低功率";
            this.LowPowerMode.UseVisualStyleBackColor = true;
            this.LowPowerMode.Click += new System.EventHandler(this.LowPowerMode_Click);
            // 
            // MediumPowerMode
            // 
            this.MediumPowerMode.Location = new System.Drawing.Point(199, 3);
            this.MediumPowerMode.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.MediumPowerMode.Name = "MediumPowerMode";
            this.MediumPowerMode.Size = new System.Drawing.Size(109, 59);
            this.MediumPowerMode.TabIndex = 1;
            this.MediumPowerMode.Text = "中功率";
            this.MediumPowerMode.UseVisualStyleBackColor = true;
            this.MediumPowerMode.Click += new System.EventHandler(this.MediumPowerMode_Click);
            // 
            // HighPowerMode
            // 
            this.HighPowerMode.Location = new System.Drawing.Point(368, 3);
            this.HighPowerMode.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.HighPowerMode.Name = "HighPowerMode";
            this.HighPowerMode.Size = new System.Drawing.Size(109, 59);
            this.HighPowerMode.TabIndex = 2;
            this.HighPowerMode.Text = "高功率";
            this.HighPowerMode.UseVisualStyleBackColor = true;
            this.HighPowerMode.Click += new System.EventHandler(this.HighPowerMode_Click);
            // 
            // PowerModeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.logo);
            this.Name = "PowerModeWindow";
            this.Text = "PowerModeWindow";
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button LowPowerMode;
        private System.Windows.Forms.Button MediumPowerMode;
        private System.Windows.Forms.Button HighPowerMode;
    }
}