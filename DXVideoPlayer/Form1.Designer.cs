namespace DXVideoPlayer
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
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblVideoPosition = new System.Windows.Forms.Label();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnFullscreen = new System.Windows.Forms.Button();
            this.lstVideos = new System.Windows.Forms.ListBox();
            this.pnlVideo = new System.Windows.Forms.Panel();
            this.tmrVideo = new System.Windows.Forms.Timer(this.components);
            this.panelbotm = new System.Windows.Forms.Panel();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.panelbotm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(512, 15);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(140, 42);
            this.btnNext.TabIndex = 18;
            this.btnNext.Text = "下一个";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(42, 15);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(140, 42);
            this.btnPrevious.TabIndex = 17;
            this.btnPrevious.Text = "前一个";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblVideoPosition
            // 
            this.lblVideoPosition.AutoSize = true;
            this.lblVideoPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoPosition.Location = new System.Drawing.Point(53, 79);
            this.lblVideoPosition.Name = "lblVideoPosition";
            this.lblVideoPosition.Size = new System.Drawing.Size(114, 16);
            this.lblVideoPosition.TabIndex = 16;
            this.lblVideoPosition.Text = "00:00:00 / 00:00:00";
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Location = new System.Drawing.Point(277, 15);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(140, 42);
            this.btnPlayPause.TabIndex = 15;
            this.btnPlayPause.Text = "播放/暂停";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnFullscreen
            // 
            this.btnFullscreen.Location = new System.Drawing.Point(747, 15);
            this.btnFullscreen.Name = "btnFullscreen";
            this.btnFullscreen.Size = new System.Drawing.Size(140, 42);
            this.btnFullscreen.TabIndex = 14;
            this.btnFullscreen.Text = "全屏";
            this.btnFullscreen.UseVisualStyleBackColor = true;
            this.btnFullscreen.Click += new System.EventHandler(this.btnFullscreen_Click);
            // 
            // lstVideos
            // 
            this.lstVideos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstVideos.FormattingEnabled = true;
            this.lstVideos.ItemHeight = 12;
            this.lstVideos.Location = new System.Drawing.Point(4, 9);
            this.lstVideos.Name = "lstVideos";
            this.lstVideos.Size = new System.Drawing.Size(163, 676);
            this.lstVideos.TabIndex = 12;
            this.lstVideos.SelectedIndexChanged += new System.EventHandler(this.lstVideos_SelectedIndexChanged);
            // 
            // pnlVideo
            // 
            this.pnlVideo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlVideo.BackColor = System.Drawing.SystemColors.GrayText;
            this.pnlVideo.Location = new System.Drawing.Point(178, 12);
            this.pnlVideo.Name = "pnlVideo";
            this.pnlVideo.Size = new System.Drawing.Size(936, 537);
            this.pnlVideo.TabIndex = 11;
            // 
            // tmrVideo
            // 
            this.tmrVideo.Tick += new System.EventHandler(this.tmrVideo_Tick);
            // 
            // panelbotm
            // 
            this.panelbotm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelbotm.Controls.Add(this.trackBar);
            this.panelbotm.Controls.Add(this.btnPlayPause);
            this.panelbotm.Controls.Add(this.btnFullscreen);
            this.panelbotm.Controls.Add(this.btnPrevious);
            this.panelbotm.Controls.Add(this.lblVideoPosition);
            this.panelbotm.Controls.Add(this.btnNext);
            this.panelbotm.Location = new System.Drawing.Point(170, 567);
            this.panelbotm.Name = "panelbotm";
            this.panelbotm.Size = new System.Drawing.Size(944, 118);
            this.panelbotm.TabIndex = 22;
            // 
            // trackBar
            // 
            this.trackBar.AutoSize = false;
            this.trackBar.Location = new System.Drawing.Point(277, 63);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(610, 32);
            this.trackBar.TabIndex = 19;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            this.trackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar_MouseDown);
            this.trackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 690);
            this.Controls.Add(this.lstVideos);
            this.Controls.Add(this.panelbotm);
            this.Controls.Add(this.pnlVideo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panelbotm.ResumeLayout(false);
            this.panelbotm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblVideoPosition;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnFullscreen;
        private System.Windows.Forms.ListBox lstVideos;
        private System.Windows.Forms.Panel pnlVideo;
        private System.Windows.Forms.Timer tmrVideo;
        private System.Windows.Forms.Panel panelbotm;
        private System.Windows.Forms.TrackBar trackBar;
    }
}

