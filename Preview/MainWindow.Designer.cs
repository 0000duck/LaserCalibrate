namespace Preview
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.RealPlayWnd1 = new System.Windows.Forms.PictureBox();
            this.RealPlayWnd2 = new System.Windows.Forms.PictureBox();
            this.CamLabel = new System.Windows.Forms.Label();
            this.CamLabel2 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.摄像机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.摄像机1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.摄像机2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连接到ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.控制器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连接ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.继电器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AxisGroupBox = new System.Windows.Forms.GroupBox();
            this.rAxis = new System.Windows.Forms.RadioButton();
            this.zAxis = new System.Windows.Forms.RadioButton();
            this.yAxis = new System.Windows.Forms.RadioButton();
            this.xAxis = new System.Windows.Forms.RadioButton();
            this.StartMoveButton = new System.Windows.Forms.Button();
            this.StopMoveButton = new System.Windows.Forms.Button();
            this.PreviewButton = new System.Windows.Forms.Button();
            this.Controller = new System.Windows.Forms.GroupBox();
            this.AutoMove = new System.Windows.Forms.Button();
            this.Camera = new System.Windows.Forms.GroupBox();
            this.StopPreview = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.Relays = new System.Windows.Forms.GroupBox();
            this.RelayBButton = new System.Windows.Forms.Button();
            this.RelayAButton = new System.Windows.Forms.Button();
            this.Angle = new System.Windows.Forms.TextBox();
            this.angle_label = new System.Windows.Forms.Label();
            this.ControlArgs = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.RealPlayWnd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RealPlayWnd2)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.AxisGroupBox.SuspendLayout();
            this.Controller.SuspendLayout();
            this.Camera.SuspendLayout();
            this.Relays.SuspendLayout();
            this.ControlArgs.SuspendLayout();
            this.SuspendLayout();
            // 
            // RealPlayWnd1
            // 
            this.RealPlayWnd1.BackColor = System.Drawing.SystemColors.WindowText;
            this.RealPlayWnd1.Location = new System.Drawing.Point(15, 18);
            this.RealPlayWnd1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RealPlayWnd1.Name = "RealPlayWnd1";
            this.RealPlayWnd1.Size = new System.Drawing.Size(449, 342);
            this.RealPlayWnd1.TabIndex = 5;
            this.RealPlayWnd1.TabStop = false;
            // 
            // RealPlayWnd2
            // 
            this.RealPlayWnd2.BackColor = System.Drawing.SystemColors.WindowText;
            this.RealPlayWnd2.Location = new System.Drawing.Point(16, 18);
            this.RealPlayWnd2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RealPlayWnd2.Name = "RealPlayWnd2";
            this.RealPlayWnd2.Size = new System.Drawing.Size(449, 342);
            this.RealPlayWnd2.TabIndex = 6;
            this.RealPlayWnd2.TabStop = false;
            // 
            // CamLabel
            // 
            this.CamLabel.AutoSize = true;
            this.CamLabel.Location = new System.Drawing.Point(-3, 0);
            this.CamLabel.Name = "CamLabel";
            this.CamLabel.Size = new System.Drawing.Size(60, 15);
            this.CamLabel.TabIndex = 7;
            this.CamLabel.Text = "监视器1";
            // 
            // CamLabel2
            // 
            this.CamLabel2.AutoSize = true;
            this.CamLabel2.Location = new System.Drawing.Point(-3, 0);
            this.CamLabel2.Name = "CamLabel2";
            this.CamLabel2.Size = new System.Drawing.Size(60, 15);
            this.CamLabel2.TabIndex = 8;
            this.CamLabel2.Text = "监视器2";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.摄像机ToolStripMenuItem,
            this.控制器ToolStripMenuItem,
            this.继电器ToolStripMenuItem,
            this.选项ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1007, 28);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 摄像机ToolStripMenuItem
            // 
            this.摄像机ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.摄像机1ToolStripMenuItem,
            this.摄像机2ToolStripMenuItem});
            this.摄像机ToolStripMenuItem.Name = "摄像机ToolStripMenuItem";
            this.摄像机ToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.摄像机ToolStripMenuItem.Text = "摄像机";
            // 
            // 摄像机1ToolStripMenuItem
            // 
            this.摄像机1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接ToolStripMenuItem});
            this.摄像机1ToolStripMenuItem.Name = "摄像机1ToolStripMenuItem";
            this.摄像机1ToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.摄像机1ToolStripMenuItem.Text = "摄像机1";
            // 
            // 连接ToolStripMenuItem
            // 
            this.连接ToolStripMenuItem.Name = "连接ToolStripMenuItem";
            this.连接ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.连接ToolStripMenuItem.Text = "连接";
            // 
            // 摄像机2ToolStripMenuItem
            // 
            this.摄像机2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接到ToolStripMenuItem});
            this.摄像机2ToolStripMenuItem.Name = "摄像机2ToolStripMenuItem";
            this.摄像机2ToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.摄像机2ToolStripMenuItem.Text = "摄像机2";
            // 
            // 连接到ToolStripMenuItem
            // 
            this.连接到ToolStripMenuItem.Name = "连接到ToolStripMenuItem";
            this.连接到ToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.连接到ToolStripMenuItem.Text = "连接到...";
            // 
            // 控制器ToolStripMenuItem
            // 
            this.控制器ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接ToolStripMenuItem1});
            this.控制器ToolStripMenuItem.Name = "控制器ToolStripMenuItem";
            this.控制器ToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.控制器ToolStripMenuItem.Text = "控制器";
            // 
            // 连接ToolStripMenuItem1
            // 
            this.连接ToolStripMenuItem1.Name = "连接ToolStripMenuItem1";
            this.连接ToolStripMenuItem1.Size = new System.Drawing.Size(114, 26);
            this.连接ToolStripMenuItem1.Text = "连接";
            // 
            // 继电器ToolStripMenuItem
            // 
            this.继电器ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.参数ToolStripMenuItem});
            this.继电器ToolStripMenuItem.Name = "继电器ToolStripMenuItem";
            this.继电器ToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.继电器ToolStripMenuItem.Text = "继电器";
            // 
            // 参数ToolStripMenuItem
            // 
            this.参数ToolStripMenuItem.Name = "参数ToolStripMenuItem";
            this.参数ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.参数ToolStripMenuItem.Text = "参数";
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.选项ToolStripMenuItem.Text = "选项";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CamLabel);
            this.panel1.Controls.Add(this.RealPlayWnd1);
            this.panel1.Location = new System.Drawing.Point(12, 48);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 375);
            this.panel1.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CamLabel2);
            this.panel2.Controls.Add(this.RealPlayWnd2);
            this.panel2.Location = new System.Drawing.Point(516, 48);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 375);
            this.panel2.TabIndex = 34;
            // 
            // AxisGroupBox
            // 
            this.AxisGroupBox.Controls.Add(this.rAxis);
            this.AxisGroupBox.Controls.Add(this.zAxis);
            this.AxisGroupBox.Controls.Add(this.yAxis);
            this.AxisGroupBox.Controls.Add(this.xAxis);
            this.AxisGroupBox.Location = new System.Drawing.Point(23, 121);
            this.AxisGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.AxisGroupBox.Name = "AxisGroupBox";
            this.AxisGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.AxisGroupBox.Size = new System.Drawing.Size(201, 99);
            this.AxisGroupBox.TabIndex = 35;
            this.AxisGroupBox.TabStop = false;
            this.AxisGroupBox.Text = "轴选择";
            // 
            // rAxis
            // 
            this.rAxis.AutoSize = true;
            this.rAxis.Location = new System.Drawing.Point(107, 66);
            this.rAxis.Margin = new System.Windows.Forms.Padding(4);
            this.rAxis.Name = "rAxis";
            this.rAxis.Size = new System.Drawing.Size(36, 19);
            this.rAxis.TabIndex = 3;
            this.rAxis.TabStop = true;
            this.rAxis.Text = "R";
            this.rAxis.UseVisualStyleBackColor = true;
            // 
            // zAxis
            // 
            this.zAxis.AutoSize = true;
            this.zAxis.Location = new System.Drawing.Point(23, 66);
            this.zAxis.Margin = new System.Windows.Forms.Padding(4);
            this.zAxis.Name = "zAxis";
            this.zAxis.Size = new System.Drawing.Size(36, 19);
            this.zAxis.TabIndex = 2;
            this.zAxis.TabStop = true;
            this.zAxis.Text = "Z";
            this.zAxis.UseVisualStyleBackColor = true;
            // 
            // yAxis
            // 
            this.yAxis.AutoSize = true;
            this.yAxis.Location = new System.Drawing.Point(107, 28);
            this.yAxis.Margin = new System.Windows.Forms.Padding(4);
            this.yAxis.Name = "yAxis";
            this.yAxis.Size = new System.Drawing.Size(36, 19);
            this.yAxis.TabIndex = 1;
            this.yAxis.TabStop = true;
            this.yAxis.Text = "Y";
            this.yAxis.UseVisualStyleBackColor = true;
            // 
            // xAxis
            // 
            this.xAxis.AutoSize = true;
            this.xAxis.Checked = true;
            this.xAxis.Location = new System.Drawing.Point(23, 28);
            this.xAxis.Margin = new System.Windows.Forms.Padding(4);
            this.xAxis.Name = "xAxis";
            this.xAxis.Size = new System.Drawing.Size(36, 19);
            this.xAxis.TabIndex = 0;
            this.xAxis.TabStop = true;
            this.xAxis.Text = "X";
            this.xAxis.UseVisualStyleBackColor = true;
            // 
            // StartMoveButton
            // 
            this.StartMoveButton.Location = new System.Drawing.Point(16, 38);
            this.StartMoveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartMoveButton.Name = "StartMoveButton";
            this.StartMoveButton.Size = new System.Drawing.Size(100, 38);
            this.StartMoveButton.TabIndex = 37;
            this.StartMoveButton.Text = "运动";
            this.StartMoveButton.UseVisualStyleBackColor = true;
            this.StartMoveButton.Click += new System.EventHandler(this.StartMoveButton_Click);
            // 
            // StopMoveButton
            // 
            this.StopMoveButton.Location = new System.Drawing.Point(16, 105);
            this.StopMoveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StopMoveButton.Name = "StopMoveButton";
            this.StopMoveButton.Size = new System.Drawing.Size(100, 38);
            this.StopMoveButton.TabIndex = 38;
            this.StopMoveButton.Text = "停止";
            this.StopMoveButton.UseVisualStyleBackColor = true;
            this.StopMoveButton.Click += new System.EventHandler(this.StopMoveButton_Click);
            // 
            // PreviewButton
            // 
            this.PreviewButton.Location = new System.Drawing.Point(15, 38);
            this.PreviewButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PreviewButton.Name = "PreviewButton";
            this.PreviewButton.Size = new System.Drawing.Size(100, 38);
            this.PreviewButton.TabIndex = 10;
            this.PreviewButton.Text = "预览";
            this.PreviewButton.UseVisualStyleBackColor = true;
            this.PreviewButton.Click += new System.EventHandler(this.PreviewButton_Click);
            // 
            // Controller
            // 
            this.Controller.Controls.Add(this.AutoMove);
            this.Controller.Controls.Add(this.StopMoveButton);
            this.Controller.Controls.Add(this.StartMoveButton);
            this.Controller.Location = new System.Drawing.Point(12, 446);
            this.Controller.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Controller.Name = "Controller";
            this.Controller.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Controller.Size = new System.Drawing.Size(135, 245);
            this.Controller.TabIndex = 39;
            this.Controller.TabStop = false;
            this.Controller.Text = "控制器";
            // 
            // AutoMove
            // 
            this.AutoMove.Location = new System.Drawing.Point(16, 172);
            this.AutoMove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AutoMove.Name = "AutoMove";
            this.AutoMove.Size = new System.Drawing.Size(100, 36);
            this.AutoMove.TabIndex = 39;
            this.AutoMove.Text = "自动校准";
            this.AutoMove.UseVisualStyleBackColor = true;
            this.AutoMove.Click += new System.EventHandler(this.AutoMove_Click);
            // 
            // Camera
            // 
            this.Camera.Controls.Add(this.StopPreview);
            this.Camera.Controls.Add(this.PreviewButton);
            this.Camera.Location = new System.Drawing.Point(516, 444);
            this.Camera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Camera.Name = "Camera";
            this.Camera.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Camera.Size = new System.Drawing.Size(131, 247);
            this.Camera.TabIndex = 40;
            this.Camera.TabStop = false;
            this.Camera.Text = "摄像机";
            // 
            // StopPreview
            // 
            this.StopPreview.Location = new System.Drawing.Point(15, 104);
            this.StopPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StopPreview.Name = "StopPreview";
            this.StopPreview.Size = new System.Drawing.Size(100, 38);
            this.StopPreview.TabIndex = 11;
            this.StopPreview.Text = "停止预览";
            this.StopPreview.UseVisualStyleBackColor = true;
            this.StopPreview.Click += new System.EventHandler(this.StopPreview_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(881, 653);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 38);
            this.ExitButton.TabIndex = 41;
            this.ExitButton.Text = "退出";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Relays
            // 
            this.Relays.Controls.Add(this.RelayBButton);
            this.Relays.Controls.Add(this.RelayAButton);
            this.Relays.Location = new System.Drawing.Point(678, 446);
            this.Relays.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Relays.Name = "Relays";
            this.Relays.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Relays.Size = new System.Drawing.Size(137, 244);
            this.Relays.TabIndex = 42;
            this.Relays.TabStop = false;
            this.Relays.Text = "继电器";
            // 
            // RelayBButton
            // 
            this.RelayBButton.Location = new System.Drawing.Point(18, 104);
            this.RelayBButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RelayBButton.Name = "RelayBButton";
            this.RelayBButton.Size = new System.Drawing.Size(100, 38);
            this.RelayBButton.TabIndex = 12;
            this.RelayBButton.Text = "开";
            this.RelayBButton.UseVisualStyleBackColor = true;
            this.RelayBButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // RelayAButton
            // 
            this.RelayAButton.Location = new System.Drawing.Point(18, 38);
            this.RelayAButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RelayAButton.Name = "RelayAButton";
            this.RelayAButton.Size = new System.Drawing.Size(100, 38);
            this.RelayAButton.TabIndex = 11;
            this.RelayAButton.Text = "开";
            this.RelayAButton.UseVisualStyleBackColor = true;
            this.RelayAButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // Angle
            // 
            this.Angle.Location = new System.Drawing.Point(23, 75);
            this.Angle.Name = "Angle";
            this.Angle.Size = new System.Drawing.Size(100, 25);
            this.Angle.TabIndex = 43;
            // 
            // angle_label
            // 
            this.angle_label.AutoSize = true;
            this.angle_label.Location = new System.Drawing.Point(23, 54);
            this.angle_label.Name = "angle_label";
            this.angle_label.Size = new System.Drawing.Size(213, 15);
            this.angle_label.TabIndex = 44;
            this.angle_label.Text = "转动角度(+:顺时针 -:逆时针)";
            // 
            // ControlArgs
            // 
            this.ControlArgs.Controls.Add(this.angle_label);
            this.ControlArgs.Controls.Add(this.Angle);
            this.ControlArgs.Controls.Add(this.AxisGroupBox);
            this.ControlArgs.Location = new System.Drawing.Point(162, 446);
            this.ControlArgs.Name = "ControlArgs";
            this.ControlArgs.Size = new System.Drawing.Size(264, 245);
            this.ControlArgs.TabIndex = 45;
            this.ControlArgs.TabStop = false;
            this.ControlArgs.Text = "手动控制参数";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1007, 701);
            this.Controls.Add(this.ControlArgs);
            this.Controls.Add(this.Relays);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.Camera);
            this.Controls.Add(this.Controller);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1025, 748);
            this.Name = "MainWindow";
            this.Text = "主界面";
            ((System.ComponentModel.ISupportInitialize)(this.RealPlayWnd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RealPlayWnd2)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.AxisGroupBox.ResumeLayout(false);
            this.AxisGroupBox.PerformLayout();
            this.Controller.ResumeLayout(false);
            this.Camera.ResumeLayout(false);
            this.Relays.ResumeLayout(false);
            this.ControlArgs.ResumeLayout(false);
            this.ControlArgs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox RealPlayWnd1;
        private System.Windows.Forms.PictureBox RealPlayWnd2;
        private System.Windows.Forms.Label CamLabel;
        private System.Windows.Forms.Label CamLabel2;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 控制器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连接ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox AxisGroupBox;
        private System.Windows.Forms.RadioButton rAxis;
        private System.Windows.Forms.RadioButton zAxis;
        private System.Windows.Forms.RadioButton yAxis;
        private System.Windows.Forms.RadioButton xAxis;
        private System.Windows.Forms.Button StartMoveButton;
        private System.Windows.Forms.Button StopMoveButton;
        private System.Windows.Forms.Button PreviewButton;
        private System.Windows.Forms.GroupBox Controller;
        private System.Windows.Forms.ToolStripMenuItem 摄像机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 摄像机1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 摄像机2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连接到ToolStripMenuItem;
        private System.Windows.Forms.GroupBox Camera;
        private System.Windows.Forms.Button StopPreview;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button AutoMove;
        private System.Windows.Forms.GroupBox Relays;
        private System.Windows.Forms.Button RelayBButton;
        private System.Windows.Forms.Button RelayAButton;
        private System.Windows.Forms.TextBox Angle;
        private System.Windows.Forms.Label angle_label;
        private System.Windows.Forms.GroupBox ControlArgs;
        private System.Windows.Forms.ToolStripMenuItem 继电器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 参数ToolStripMenuItem;
    }
}