namespace Preview.Views
{
    partial class PlayBack
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayBack));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label10 = new System.Windows.Forms.Label();
            this.PlaybackprogressBar = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.timerplayback = new System.Windows.Forms.Timer(this.components);
            this.listViewFile1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label9 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.timerDownload = new System.Windows.Forms.Timer(this.components);
            this.listViewFile2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label11 = new System.Windows.Forms.Label();
            this.labelpause = new System.Windows.Forms.Label();
            this.buttonpause = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonnormal = new System.Windows.Forms.Button();
            this.buttonfast = new System.Windows.Forms.Button();
            this.buttonslow = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Starting Time";
            this.columnHeader2.Width = 137;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1136, 602);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 78;
            this.label10.Text = "回放进度";
            // 
            // PlaybackprogressBar
            // 
            this.PlaybackprogressBar.Location = new System.Drawing.Point(1136, 624);
            this.PlaybackprogressBar.Name = "PlaybackprogressBar";
            this.PlaybackprogressBar.Size = new System.Drawing.Size(385, 23);
            this.PlaybackprogressBar.TabIndex = 77;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1133, 690);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 76;
            this.label8.Text = "下载进度";
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Location = new System.Drawing.Point(1136, 712);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(385, 23);
            this.DownloadProgressBar.TabIndex = 75;
            // 
            // timerplayback
            // 
            this.timerplayback.Interval = 1000;
            // 
            // listViewFile1
            // 
            this.listViewFile1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewFile1.FullRowSelect = true;
            this.listViewFile1.GridLines = true;
            this.listViewFile1.Location = new System.Drawing.Point(1124, 285);
            this.listViewFile1.Margin = new System.Windows.Forms.Padding(4);
            this.listViewFile1.Name = "listViewFile1";
            this.listViewFile1.Size = new System.Drawing.Size(239, 228);
            this.listViewFile1.TabIndex = 79;
            this.listViewFile1.UseCompatibleStateImageBehavior = false;
            this.listViewFile1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "File Name";
            this.columnHeader3.Width = 139;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Starting Time";
            this.columnHeader4.Width = 137;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ending Time";
            this.columnHeader5.Width = 221;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1133, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 81;
            this.label9.Text = "搜索结果1";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(1136, 215);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(124, 34);
            this.buttonSearch.TabIndex = 80;
            this.buttonSearch.Text = "搜索文件";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // timerDownload
            // 
            this.timerDownload.Interval = 1000;
            // 
            // listViewFile2
            // 
            this.listViewFile2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6});
            this.listViewFile2.FullRowSelect = true;
            this.listViewFile2.GridLines = true;
            this.listViewFile2.Location = new System.Drawing.Point(1373, 285);
            this.listViewFile2.Margin = new System.Windows.Forms.Padding(4);
            this.listViewFile2.Name = "listViewFile2";
            this.listViewFile2.Size = new System.Drawing.Size(239, 228);
            this.listViewFile2.TabIndex = 83;
            this.listViewFile2.UseCompatibleStateImageBehavior = false;
            this.listViewFile2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Name";
            this.columnHeader1.Width = 139;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ending Time";
            this.columnHeader6.Width = 221;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1370, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 82;
            this.label11.Text = "搜索结果2";
            // 
            // labelpause
            // 
            this.labelpause.AutoSize = true;
            this.labelpause.Location = new System.Drawing.Point(718, 738);
            this.labelpause.Name = "labelpause";
            this.labelpause.Size = new System.Drawing.Size(37, 15);
            this.labelpause.TabIndex = 74;
            this.labelpause.Text = "暂停";
            // 
            // buttonpause
            // 
            this.buttonpause.Location = new System.Drawing.Point(702, 690);
            this.buttonpause.Name = "buttonpause";
            this.buttonpause.Size = new System.Drawing.Size(75, 45);
            this.buttonpause.TabIndex = 73;
            this.buttonpause.Text = "||";
            this.buttonpause.UseVisualStyleBackColor = true;
            this.buttonpause.Click += new System.EventHandler(this.buttonpause_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(864, 738);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 72;
            this.label7.Text = "常速";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1008, 738);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 71;
            this.label6.Text = "快速";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(590, 738);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 70;
            this.label5.Text = "慢速";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(863, 572);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(202, 75);
            this.button4.TabIndex = 69;
            this.button4.Text = "回放下载";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonnormal
            // 
            this.buttonnormal.Location = new System.Drawing.Point(823, 690);
            this.buttonnormal.Name = "buttonnormal";
            this.buttonnormal.Size = new System.Drawing.Size(127, 45);
            this.buttonnormal.TabIndex = 68;
            this.buttonnormal.Text = "Normal Speed";
            this.buttonnormal.UseVisualStyleBackColor = true;
            this.buttonnormal.Click += new System.EventHandler(this.buttonnormal_Click);
            // 
            // buttonfast
            // 
            this.buttonfast.Location = new System.Drawing.Point(990, 690);
            this.buttonfast.Name = "buttonfast";
            this.buttonfast.Size = new System.Drawing.Size(75, 45);
            this.buttonfast.TabIndex = 67;
            this.buttonfast.Text = ">>";
            this.buttonfast.UseVisualStyleBackColor = true;
            this.buttonfast.Click += new System.EventHandler(this.buttonfast_Click);
            // 
            // buttonslow
            // 
            this.buttonslow.Location = new System.Drawing.Point(572, 690);
            this.buttonslow.Name = "buttonslow";
            this.buttonslow.Size = new System.Drawing.Size(75, 45);
            this.buttonslow.TabIndex = 66;
            this.buttonslow.Text = "<<";
            this.buttonslow.UseVisualStyleBackColor = true;
            this.buttonslow.Click += new System.EventHandler(this.buttonslow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1133, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 65;
            this.label4.Text = "录像文件结束时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1133, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 64;
            this.label3.Text = "录像文件开始时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(568, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 63;
            this.label2.Text = "右摄像头";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 62;
            this.label1.Text = "左摄像头";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(499, 434);
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 572);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(499, 75);
            this.button1.TabIndex = 60;
            this.button1.Text = "开启预览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(1136, 168);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(230, 25);
            this.dateTimeEnd.TabIndex = 59;
            this.dateTimeEnd.UseWaitCursor = true;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStart.Location = new System.Drawing.Point(1133, 96);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(230, 25);
            this.dateTimeStart.TabIndex = 58;
            this.dateTimeStart.UseWaitCursor = true;
            this.dateTimeStart.Value = new System.DateTime(2018, 6, 4, 20, 12, 5, 0);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(572, 572);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(202, 75);
            this.button2.TabIndex = 57;
            this.button2.Text = "开启回放";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(572, 79);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(493, 434);
            this.pictureBox2.TabIndex = 56;
            this.pictureBox2.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 678);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(499, 75);
            this.button3.TabIndex = 55;
            this.button3.Text = "开启录像";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PlayBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1648, 758);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PlaybackprogressBar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DownloadProgressBar);
            this.Controls.Add(this.listViewFile1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.listViewFile2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelpause);
            this.Controls.Add(this.buttonpause);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.buttonnormal);
            this.Controls.Add(this.buttonfast);
            this.Controls.Add(this.buttonslow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimeEnd);
            this.Controls.Add(this.dateTimeStart);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button3);
            this.Name = "PlayBack";
            this.Text = "PlayBack";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar PlaybackprogressBar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.Timer timerplayback;
        private System.Windows.Forms.ListView listViewFile1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Timer timerDownload;
        private System.Windows.Forms.ListView listViewFile2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelpause;
        private System.Windows.Forms.Button buttonpause;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonnormal;
        private System.Windows.Forms.Button buttonfast;
        private System.Windows.Forms.Button buttonslow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button3;
    }
}