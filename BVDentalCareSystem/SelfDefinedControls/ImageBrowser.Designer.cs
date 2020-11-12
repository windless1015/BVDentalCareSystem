using System.Windows.Forms;

namespace BVDentalCareSystem.SelfDefinedControls
{
    partial class ImageBrowser
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
            this.btnImgBrsBack = new System.Windows.Forms.Button();
            this.btnImgBrsGoHead = new System.Windows.Forms.Button();
            this.btnImgBrwExit = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImgBrsBack
            // 
            this.btnImgBrsBack.BackColor = System.Drawing.Color.Transparent;
            this.btnImgBrsBack.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.backWard;
            this.btnImgBrsBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImgBrsBack.FlatAppearance.BorderSize = 0;
            this.btnImgBrsBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImgBrsBack.Location = new System.Drawing.Point(1781, 947);
            this.btnImgBrsBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnImgBrsBack.Name = "btnImgBrsBack";
            this.btnImgBrsBack.Size = new System.Drawing.Size(80, 80);
            this.btnImgBrsBack.TabIndex = 3;
            this.btnImgBrsBack.UseVisualStyleBackColor = false;
            this.btnImgBrsBack.Click += new System.EventHandler(this.btnImgBrsBack_Click);
            // 
            // btnImgBrsGoHead
            // 
            this.btnImgBrsGoHead.BackColor = System.Drawing.Color.Transparent;
            this.btnImgBrsGoHead.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.forward;
            this.btnImgBrsGoHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImgBrsGoHead.FlatAppearance.BorderSize = 0;
            this.btnImgBrsGoHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImgBrsGoHead.Location = new System.Drawing.Point(50, 947);
            this.btnImgBrsGoHead.Margin = new System.Windows.Forms.Padding(2);
            this.btnImgBrsGoHead.Name = "btnImgBrsGoHead";
            this.btnImgBrsGoHead.Size = new System.Drawing.Size(80, 80);
            this.btnImgBrsGoHead.TabIndex = 2;
            this.btnImgBrsGoHead.UseVisualStyleBackColor = false;
            this.btnImgBrsGoHead.Click += new System.EventHandler(this.btnImgBrsGoHead_Click);
            // 
            // btnImgBrwExit
            // 
            this.btnImgBrwExit.BackColor = System.Drawing.Color.Transparent;
            this.btnImgBrwExit.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.quit;
            this.btnImgBrwExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImgBrwExit.FlatAppearance.BorderSize = 0;
            this.btnImgBrwExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImgBrwExit.Location = new System.Drawing.Point(50, 50);
            this.btnImgBrwExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnImgBrwExit.Name = "btnImgBrwExit";
            this.btnImgBrwExit.Size = new System.Drawing.Size(80, 80);
            this.btnImgBrwExit.TabIndex = 1;
            this.btnImgBrwExit.UseVisualStyleBackColor = false;
            this.btnImgBrwExit.Click += new System.EventHandler(this.btnImgBrwExit_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(420, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1080, 1080);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // ImageBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnImgBrsBack);
            this.Controls.Add(this.btnImgBrsGoHead);
            this.Controls.Add(this.btnImgBrwExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImageBrowser";
            this.Text = "ImageBrowser";
            this.Load += new System.EventHandler(this.ImageBrowser_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ImageBrowser_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImgBrwExit;
        private System.Windows.Forms.Button btnImgBrsGoHead;
        private System.Windows.Forms.Button btnImgBrsBack;
        private PictureBox pictureBox;
    }
}