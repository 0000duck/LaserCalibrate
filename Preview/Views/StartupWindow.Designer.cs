namespace Preview
{
    partial class StartupWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupWindow));
            this.logo_panel = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.DebugBtn = new System.Windows.Forms.Button();
            this.PowerModeBtn = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.btn_panel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Replay = new System.Windows.Forms.Button();
            this.logo_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.btn_panel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo_panel
            // 
            this.logo_panel.Controls.Add(this.logo);
            this.logo_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logo_panel.Location = new System.Drawing.Point(0, 0);
            this.logo_panel.Name = "logo_panel";
            this.logo_panel.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.logo_panel.Size = new System.Drawing.Size(1348, 313);
            this.logo_panel.TabIndex = 0;
            // 
            // logo
            // 
            this.logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(0, 20);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(1348, 293);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // DebugBtn
            // 
            this.DebugBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DebugBtn.Location = new System.Drawing.Point(15, 10);
            this.DebugBtn.Margin = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.DebugBtn.Name = "DebugBtn";
            this.DebugBtn.Size = new System.Drawing.Size(125, 57);
            this.DebugBtn.TabIndex = 1;
            this.DebugBtn.Text = "调试";
            this.DebugBtn.UseVisualStyleBackColor = true;
            this.DebugBtn.Click += new System.EventHandler(this.DebugBtn_Click);
            // 
            // PowerModeBtn
            // 
            this.PowerModeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PowerModeBtn.Location = new System.Drawing.Point(170, 10);
            this.PowerModeBtn.Margin = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.PowerModeBtn.Name = "PowerModeBtn";
            this.PowerModeBtn.Size = new System.Drawing.Size(125, 57);
            this.PowerModeBtn.TabIndex = 2;
            this.PowerModeBtn.Text = "工作模式选择";
            this.PowerModeBtn.UseVisualStyleBackColor = true;
            this.PowerModeBtn.Click += new System.EventHandler(this.PowerModeBtn_Click);
            // 
            // Exit
            // 
            this.Exit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Exit.Location = new System.Drawing.Point(480, 10);
            this.Exit.Margin = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(135, 57);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "退出";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // btn_panel
            // 
            this.btn_panel.Controls.Add(this.flowLayoutPanel1);
            this.btn_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_panel.Location = new System.Drawing.Point(0, 313);
            this.btn_panel.Name = "btn_panel";
            this.btn_panel.Size = new System.Drawing.Size(1348, 408);
            this.btn_panel.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.DebugBtn);
            this.flowLayoutPanel1.Controls.Add(this.PowerModeBtn);
            this.flowLayoutPanel1.Controls.Add(this.Replay);
            this.flowLayoutPanel1.Controls.Add(this.Exit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(350, 166);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(649, 77);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // Replay
            // 
            this.Replay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Replay.Location = new System.Drawing.Point(325, 10);
            this.Replay.Margin = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.Replay.Name = "Replay";
            this.Replay.Size = new System.Drawing.Size(125, 57);
            this.Replay.TabIndex = 4;
            this.Replay.Text = "回放";
            this.Replay.UseVisualStyleBackColor = true;
            // 
            // StartupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.btn_panel);
            this.Controls.Add(this.logo_panel);
            this.Name = "StartupWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "启动界面";
            this.logo_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.btn_panel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel logo_panel;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Button DebugBtn;
        private System.Windows.Forms.Button PowerModeBtn;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Panel btn_panel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Replay;
    }
}