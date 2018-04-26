namespace Preview
{
    partial class DebugWindow
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Pulse = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.angle_label = new System.Windows.Forms.Label();
            this.StopMoveButton = new System.Windows.Forms.Button();
            this.Angle = new System.Windows.Forms.TextBox();
            this.StartMove = new System.Windows.Forms.Button();
            this.AxisGroupBox = new System.Windows.Forms.GroupBox();
            this.rAxis = new System.Windows.Forms.RadioButton();
            this.zAxis = new System.Windows.Forms.RadioButton();
            this.yAxis = new System.Windows.Forms.RadioButton();
            this.xAxis = new System.Windows.Forms.RadioButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.AxisGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Location = new System.Drawing.Point(19, 28);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(624, 368);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.07474F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.92526F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.49367F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.50633F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1348, 721);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(663, 417);
            this.panel2.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Location = new System.Drawing.Point(15, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(631, 368);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "平移量图像";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(677, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 417);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "角度图像";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(677, 431);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Back);
            this.splitContainer1.Size = new System.Drawing.Size(663, 282);
            this.splitContainer1.SplitterDistance = 370;
            this.splitContainer1.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.AxisGroupBox);
            this.groupBox2.Location = new System.Drawing.Point(3, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 331);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "电机控制";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.Pulse);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(8, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 79);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "寸动";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "脉冲数";
            // 
            // Pulse
            // 
            this.Pulse.Location = new System.Drawing.Point(89, 43);
            this.Pulse.Name = "Pulse";
            this.Pulse.Size = new System.Drawing.Size(135, 25);
            this.Pulse.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(230, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "顺时针";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "逆时针";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.angle_label);
            this.groupBox1.Controls.Add(this.StopMoveButton);
            this.groupBox1.Controls.Add(this.Angle);
            this.groupBox1.Controls.Add(this.StartMove);
            this.groupBox1.Location = new System.Drawing.Point(7, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 83);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "按角度运动";
            // 
            // angle_label
            // 
            this.angle_label.AutoSize = true;
            this.angle_label.Location = new System.Drawing.Point(11, 21);
            this.angle_label.Name = "angle_label";
            this.angle_label.Size = new System.Drawing.Size(213, 15);
            this.angle_label.TabIndex = 45;
            this.angle_label.Text = "转动角度(+:顺时针 -:逆时针)";
            // 
            // StopMoveButton
            // 
            this.StopMoveButton.Location = new System.Drawing.Point(247, 43);
            this.StopMoveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StopMoveButton.Name = "StopMoveButton";
            this.StopMoveButton.Size = new System.Drawing.Size(78, 23);
            this.StopMoveButton.TabIndex = 49;
            this.StopMoveButton.Text = "停止";
            this.StopMoveButton.UseVisualStyleBackColor = true;
            // 
            // Angle
            // 
            this.Angle.Location = new System.Drawing.Point(14, 39);
            this.Angle.Name = "Angle";
            this.Angle.Size = new System.Drawing.Size(143, 25);
            this.Angle.TabIndex = 46;
            // 
            // StartMove
            // 
            this.StartMove.Location = new System.Drawing.Point(163, 43);
            this.StartMove.Name = "StartMove";
            this.StartMove.Size = new System.Drawing.Size(78, 23);
            this.StartMove.TabIndex = 48;
            this.StartMove.Text = "运动";
            this.StartMove.UseVisualStyleBackColor = true;
            this.StartMove.Click += new System.EventHandler(this.StartMove_Click);
            // 
            // AxisGroupBox
            // 
            this.AxisGroupBox.Controls.Add(this.rAxis);
            this.AxisGroupBox.Controls.Add(this.zAxis);
            this.AxisGroupBox.Controls.Add(this.yAxis);
            this.AxisGroupBox.Controls.Add(this.xAxis);
            this.AxisGroupBox.Location = new System.Drawing.Point(7, 25);
            this.AxisGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.AxisGroupBox.Name = "AxisGroupBox";
            this.AxisGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.AxisGroupBox.Size = new System.Drawing.Size(350, 60);
            this.AxisGroupBox.TabIndex = 47;
            this.AxisGroupBox.TabStop = false;
            this.AxisGroupBox.Text = "轴选择";
            // 
            // rAxis
            // 
            this.rAxis.AutoSize = true;
            this.rAxis.Location = new System.Drawing.Point(278, 28);
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
            this.zAxis.Location = new System.Drawing.Point(195, 28);
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
            this.yAxis.Location = new System.Drawing.Point(114, 28);
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
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(8, 431);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Size = new System.Drawing.Size(663, 282);
            this.splitContainer2.SplitterDistance = 333;
            this.splitContainer2.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "摄像机1参数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "摄像机2参数";
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(13, 136);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(96, 51);
            this.Back.TabIndex = 0;
            this.Back.Text = "返回";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DebugWindow";
            this.Text = "DebugWindow";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.AxisGroupBox.ResumeLayout(false);
            this.AxisGroupBox.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label angle_label;
        private System.Windows.Forms.TextBox Angle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button StartMove;
        private System.Windows.Forms.GroupBox AxisGroupBox;
        private System.Windows.Forms.RadioButton rAxis;
        private System.Windows.Forms.RadioButton zAxis;
        private System.Windows.Forms.RadioButton yAxis;
        private System.Windows.Forms.RadioButton xAxis;
        private System.Windows.Forms.Button StopMoveButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Pulse;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Back;
    }
}