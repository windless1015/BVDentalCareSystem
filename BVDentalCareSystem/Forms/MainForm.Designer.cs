
namespace BVDentalCareSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_oralView = new System.Windows.Forms.Button();
            this.btn_periodontal = new System.Windows.Forms.Button();
            this.btn_patientInfo = new System.Windows.Forms.Button();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.panel_seperate = new System.Windows.Forms.Panel();
            this.imageVideoBrowserSideBar = new BVDentalCareSystem.SelfDefinedControls.ImageVideoBrowserSideBar();
            this.panel_head = new System.Windows.Forms.Panel();
            this.panel_about = new System.Windows.Forms.Panel();
            this.panel_help = new System.Windows.Forms.Panel();
            this.panel_platformName = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.panel_head.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer.Panel1.Controls.Add(this.button2);
            this.splitContainer.Panel1.Controls.Add(this.button1);
            this.splitContainer.Panel1.Controls.Add(this.pictureBox_logo);
            this.splitContainer.Panel1.Controls.Add(this.btn_exit);
            this.splitContainer.Panel1.Controls.Add(this.btn_oralView);
            this.splitContainer.Panel1.Controls.Add(this.btn_periodontal);
            this.splitContainer.Panel1.Controls.Add(this.btn_patientInfo);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer.Panel2.Controls.Add(this.panel_bottom);
            this.splitContainer.Panel2.Controls.Add(this.panel_seperate);
            this.splitContainer.Panel2.Controls.Add(this.imageVideoBrowserSideBar);
            this.splitContainer.Panel2.Controls.Add(this.panel_head);
            this.splitContainer.Size = new System.Drawing.Size(1920, 1080);
            this.splitContainer.SplitterDistance = 262;
            this.splitContainer.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 758);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 67;
            this.button1.Text = "录像";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_logo.Image")));
            this.pictureBox_logo.Location = new System.Drawing.Point(58, 32);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(135, 37);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_logo.TabIndex = 66;
            this.pictureBox_logo.TabStop = false;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.exitButton;
            this.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Location = new System.Drawing.Point(92, 867);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(78, 79);
            this.btn_exit.TabIndex = 65;
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_oralView
            // 
            this.btn_oralView.BackColor = System.Drawing.Color.Transparent;
            this.btn_oralView.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.oralView_unselected;
            this.btn_oralView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_oralView.FlatAppearance.BorderSize = 0;
            this.btn_oralView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_oralView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_oralView.Location = new System.Drawing.Point(26, 530);
            this.btn_oralView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_oralView.Name = "btn_oralView";
            this.btn_oralView.Size = new System.Drawing.Size(212, 153);
            this.btn_oralView.TabIndex = 64;
            this.btn_oralView.UseVisualStyleBackColor = false;
            this.btn_oralView.Click += new System.EventHandler(this.btn_oralView_Click);
            // 
            // btn_periodontal
            // 
            this.btn_periodontal.BackColor = System.Drawing.Color.Transparent;
            this.btn_periodontal.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.periodontal_unselected;
            this.btn_periodontal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_periodontal.FlatAppearance.BorderSize = 0;
            this.btn_periodontal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_periodontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_periodontal.Location = new System.Drawing.Point(26, 326);
            this.btn_periodontal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_periodontal.Name = "btn_periodontal";
            this.btn_periodontal.Size = new System.Drawing.Size(212, 153);
            this.btn_periodontal.TabIndex = 61;
            this.btn_periodontal.UseVisualStyleBackColor = false;
            this.btn_periodontal.Click += new System.EventHandler(this.btn_periodontal_Click);
            // 
            // btn_patientInfo
            // 
            this.btn_patientInfo.BackColor = System.Drawing.Color.Transparent;
            this.btn_patientInfo.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.patientInfo_unselected;
            this.btn_patientInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_patientInfo.FlatAppearance.BorderSize = 0;
            this.btn_patientInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_patientInfo.Location = new System.Drawing.Point(26, 123);
            this.btn_patientInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_patientInfo.Name = "btn_patientInfo";
            this.btn_patientInfo.Size = new System.Drawing.Size(212, 153);
            this.btn_patientInfo.TabIndex = 60;
            this.btn_patientInfo.UseVisualStyleBackColor = false;
            this.btn_patientInfo.Click += new System.EventHandler(this.btn_patientInfo_Click);
            // 
            // panel_bottom
            // 
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 1045);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(1290, 35);
            this.panel_bottom.TabIndex = 5;
            // 
            // panel_seperate
            // 
            this.panel_seperate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_seperate.Location = new System.Drawing.Point(0, 96);
            this.panel_seperate.Name = "panel_seperate";
            this.panel_seperate.Size = new System.Drawing.Size(1290, 30);
            this.panel_seperate.TabIndex = 4;
            // 
            // imageVideoBrowserSideBar
            // 
            this.imageVideoBrowserSideBar.BackColor = System.Drawing.Color.White;
            this.imageVideoBrowserSideBar.dataPath = null;
            this.imageVideoBrowserSideBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.imageVideoBrowserSideBar.Location = new System.Drawing.Point(1290, 96);
            this.imageVideoBrowserSideBar.Name = "imageVideoBrowserSideBar";
            this.imageVideoBrowserSideBar.Size = new System.Drawing.Size(364, 984);
            this.imageVideoBrowserSideBar.TabIndex = 3;
            // 
            // panel_head
            // 
            this.panel_head.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.headBackgroundBar;
            this.panel_head.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_head.Controls.Add(this.panel_about);
            this.panel_head.Controls.Add(this.panel_help);
            this.panel_head.Controls.Add(this.panel_platformName);
            this.panel_head.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_head.Location = new System.Drawing.Point(0, 0);
            this.panel_head.Name = "panel_head";
            this.panel_head.Size = new System.Drawing.Size(1654, 96);
            this.panel_head.TabIndex = 2;
            // 
            // panel_about
            // 
            this.panel_about.BackColor = System.Drawing.Color.Transparent;
            this.panel_about.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.about;
            this.panel_about.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_about.Location = new System.Drawing.Point(1525, 12);
            this.panel_about.Name = "panel_about";
            this.panel_about.Size = new System.Drawing.Size(71, 71);
            this.panel_about.TabIndex = 5;
            this.panel_about.Click += new System.EventHandler(this.panel_about_Click);
            // 
            // panel_help
            // 
            this.panel_help.BackColor = System.Drawing.Color.Transparent;
            this.panel_help.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.help;
            this.panel_help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_help.Location = new System.Drawing.Point(1391, 12);
            this.panel_help.Name = "panel_help";
            this.panel_help.Size = new System.Drawing.Size(71, 71);
            this.panel_help.TabIndex = 3;
            this.panel_help.Click += new System.EventHandler(this.panel_help_Click);
            // 
            // panel_platformName
            // 
            this.panel_platformName.BackColor = System.Drawing.Color.Transparent;
            this.panel_platformName.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.platform_name;
            this.panel_platformName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_platformName.Location = new System.Drawing.Point(83, 28);
            this.panel_platformName.Name = "panel_platformName";
            this.panel_platformName.Size = new System.Drawing.Size(475, 36);
            this.panel_platformName.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(92, 800);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 68;
            this.button2.Text = "截图";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.panel_head.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btn_patientInfo;
        private System.Windows.Forms.Button btn_oralView;
        private System.Windows.Forms.Button btn_periodontal;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.Panel panel_head;
        private System.Windows.Forms.Panel panel_platformName;
        private System.Windows.Forms.Panel panel_about;
        private System.Windows.Forms.Panel panel_help;
        private SelfDefinedControls.ImageVideoBrowserSideBar imageVideoBrowserSideBar;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Panel panel_seperate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

