namespace vlc.net
{
    partial class Form1
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
            this.panel_player = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_fastBackward = new System.Windows.Forms.Button();
            this.btn_fastForward = new System.Windows.Forms.Button();
            this.btnPauseOrResume = new System.Windows.Forms.Button();
            this.tbVideoTime = new System.Windows.Forms.TextBox();
            this.trackBar_playProgress = new System.Windows.Forms.TrackBar();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.videoList = new System.Windows.Forms.ListBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_playProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_player
            // 
            this.panel_player.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_player.BackColor = System.Drawing.Color.Black;
            this.panel_player.Location = new System.Drawing.Point(227, 10);
            this.panel_player.Name = "panel_player";
            this.panel_player.Size = new System.Drawing.Size(902, 552);
            this.panel_player.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.tbVideoTime);
            this.panel2.Controls.Add(this.trackBar_playProgress);
            this.panel2.Controls.Add(this.btn_fastBackward);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Controls.Add(this.btnPauseOrResume);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btn_fastForward);
            this.panel2.Location = new System.Drawing.Point(224, 568);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(945, 81);
            this.panel2.TabIndex = 1;
            // 
            // btn_fastBackward
            // 
            this.btn_fastBackward.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_fastBackward.Location = new System.Drawing.Point(446, 29);
            this.btn_fastBackward.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_fastBackward.Name = "btn_fastBackward";
            this.btn_fastBackward.Size = new System.Drawing.Size(75, 34);
            this.btn_fastBackward.TabIndex = 21;
            this.btn_fastBackward.Text = "快退";
            this.btn_fastBackward.UseVisualStyleBackColor = true;
            this.btn_fastBackward.Click += new System.EventHandler(this.btn_fastBackward_Click);
            // 
            // btn_fastForward
            // 
            this.btn_fastForward.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_fastForward.Location = new System.Drawing.Point(339, 29);
            this.btn_fastForward.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_fastForward.Name = "btn_fastForward";
            this.btn_fastForward.Size = new System.Drawing.Size(75, 34);
            this.btn_fastForward.TabIndex = 20;
            this.btn_fastForward.Text = "快进";
            this.btn_fastForward.UseVisualStyleBackColor = true;
            this.btn_fastForward.Click += new System.EventHandler(this.btn_fastForward_Click);
            // 
            // btnPauseOrResume
            // 
            this.btnPauseOrResume.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPauseOrResume.Location = new System.Drawing.Point(125, 29);
            this.btnPauseOrResume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPauseOrResume.Name = "btnPauseOrResume";
            this.btnPauseOrResume.Size = new System.Drawing.Size(75, 34);
            this.btnPauseOrResume.TabIndex = 18;
            this.btnPauseOrResume.Text = "暂停/继续";
            this.btnPauseOrResume.UseVisualStyleBackColor = true;
            this.btnPauseOrResume.Click += new System.EventHandler(this.btnPauseOrResume_Click_1);
            // 
            // tbVideoTime
            // 
            this.tbVideoTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVideoTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbVideoTime.Location = new System.Drawing.Point(797, 12);
            this.tbVideoTime.Name = "tbVideoTime";
            this.tbVideoTime.ReadOnly = true;
            this.tbVideoTime.Size = new System.Drawing.Size(108, 14);
            this.tbVideoTime.TabIndex = 6;
            this.tbVideoTime.Text = "00:00:00/00:00:00";
            // 
            // trackBar_playProgress
            // 
            this.trackBar_playProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_playProgress.AutoSize = false;
            this.trackBar_playProgress.Location = new System.Drawing.Point(563, 32);
            this.trackBar_playProgress.Name = "trackBar_playProgress";
            this.trackBar_playProgress.Size = new System.Drawing.Size(342, 33);
            this.trackBar_playProgress.TabIndex = 3;
            this.trackBar_playProgress.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_playProgress.Scroll += new System.EventHandler(this.trackBar_playProgress_Scroll);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(232, 29);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 34);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "停止";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(18, 29);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 34);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // videoList
            // 
            this.videoList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.videoList.FormattingEnabled = true;
            this.videoList.ItemHeight = 12;
            this.videoList.Location = new System.Drawing.Point(9, 10);
            this.videoList.Name = "videoList";
            this.videoList.Size = new System.Drawing.Size(198, 688);
            this.videoList.TabIndex = 13;
            this.videoList.SelectedIndexChanged += new System.EventHandler(this.videoList_SelectedIndexChanged);
            this.videoList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.videoList_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 661);
            this.Controls.Add(this.videoList);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_player);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_playProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_player;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TrackBar trackBar_playProgress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbVideoTime;
        private System.Windows.Forms.Button btn_fastBackward;
        private System.Windows.Forms.Button btn_fastForward;
        private System.Windows.Forms.Button btnPauseOrResume;
        private System.Windows.Forms.ListBox videoList;
    }
}

