namespace BVDentalCareSystem.SelfDefinedControls
{
    partial class VideoPlayerForm
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
            this.btnVideoPlayerExit = new System.Windows.Forms.Button();
            this.btnVideoPlayOrResume = new System.Windows.Forms.Button();
            this.playPanel = new System.Windows.Forms.Panel();
            this.playPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVideoPlayerExit
            // 
            this.btnVideoPlayerExit.BackColor = System.Drawing.Color.Transparent;
            this.btnVideoPlayerExit.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.quit;
            this.btnVideoPlayerExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVideoPlayerExit.FlatAppearance.BorderSize = 0;
            this.btnVideoPlayerExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVideoPlayerExit.ForeColor = System.Drawing.Color.Transparent;
            this.btnVideoPlayerExit.Location = new System.Drawing.Point(53, 47);
            this.btnVideoPlayerExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnVideoPlayerExit.Name = "btnVideoPlayerExit";
            this.btnVideoPlayerExit.Size = new System.Drawing.Size(80, 80);
            this.btnVideoPlayerExit.TabIndex = 2;
            this.btnVideoPlayerExit.UseVisualStyleBackColor = false;
            this.btnVideoPlayerExit.Click += new System.EventHandler(this.btnVideoPlayerExit_Click);
            // 
            // btnVideoPlayOrResume
            // 
            this.btnVideoPlayOrResume.BackColor = System.Drawing.Color.Transparent;
            this.btnVideoPlayOrResume.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.playVideoPause;
            this.btnVideoPlayOrResume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVideoPlayOrResume.FlatAppearance.BorderSize = 0;
            this.btnVideoPlayOrResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVideoPlayOrResume.Location = new System.Drawing.Point(842, 940);
            this.btnVideoPlayOrResume.Margin = new System.Windows.Forms.Padding(2);
            this.btnVideoPlayOrResume.Name = "btnVideoPlayOrResume";
            this.btnVideoPlayOrResume.Size = new System.Drawing.Size(80, 80);
            this.btnVideoPlayOrResume.TabIndex = 3;
            this.btnVideoPlayOrResume.UseVisualStyleBackColor = false;
            this.btnVideoPlayOrResume.Click += new System.EventHandler(this.btnVideoPlayOrResume_Click);
            // 
            // playPanel
            // 
            this.playPanel.Controls.Add(this.btnVideoPlayOrResume);
            this.playPanel.Controls.Add(this.btnVideoPlayerExit);
            this.playPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playPanel.Location = new System.Drawing.Point(0, 0);
            this.playPanel.Name = "playPanel";
            this.playPanel.Size = new System.Drawing.Size(1920, 1080);
            this.playPanel.TabIndex = 4;
            // 
            // VideoPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.playPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VideoPlayerForm";
            this.Text = "VideoPlayerForm";
            this.Load += new System.EventHandler(this.VideoPlayerForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VideoPlayerForm_KeyPress);
            this.playPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVideoPlayerExit;
        private System.Windows.Forms.Button btnVideoPlayOrResume;
        private System.Windows.Forms.Panel playPanel;
    }
}