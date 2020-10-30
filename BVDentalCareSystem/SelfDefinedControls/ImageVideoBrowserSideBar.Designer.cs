namespace BVDentalCareSystem.SelfDefinedControls
{
    partial class ImageVideoBrowserSideBar
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip_openImg = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openImgContainingFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delCurImgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doubleBufferListView = new DoubleBufferListView();
            this.contextMenuStrip_openImg.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip_openImg
            // 
            this.contextMenuStrip_openImg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImgContainingFolderToolStripMenuItem,
            this.openImgToolStripMenuItem,
            this.delCurImgToolStripMenuItem});
            this.contextMenuStrip_openImg.Name = "contextMenuStrip_openImg";
            this.contextMenuStrip_openImg.Size = new System.Drawing.Size(149, 70);
            // 
            // openImgContainingFolderToolStripMenuItem
            // 
            this.openImgContainingFolderToolStripMenuItem.Name = "openImgContainingFolderToolStripMenuItem";
            this.openImgContainingFolderToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openImgContainingFolderToolStripMenuItem.Text = "打开所在目录";
            // 
            // openImgToolStripMenuItem
            // 
            this.openImgToolStripMenuItem.Name = "openImgToolStripMenuItem";
            this.openImgToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openImgToolStripMenuItem.Text = "打开图片";
            // 
            // delCurImgToolStripMenuItem
            // 
            this.delCurImgToolStripMenuItem.Name = "delCurImgToolStripMenuItem";
            this.delCurImgToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.delCurImgToolStripMenuItem.Text = "删除本图片";
            // 
            // doubleBufferListView
            // 
            this.doubleBufferListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferListView.HideSelection = false;
            this.doubleBufferListView.Location = new System.Drawing.Point(0, 0);
            this.doubleBufferListView.Name = "doubleBufferListView";
            this.doubleBufferListView.Size = new System.Drawing.Size(193, 501);
            this.doubleBufferListView.TabIndex = 1;
            this.doubleBufferListView.UseCompatibleStateImageBehavior = false;
            this.doubleBufferListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.doubleBufferListView_MouseClick);
            // 
            // ImageVideoBrowserSideBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.doubleBufferListView);
            this.Name = "ImageVideoBrowserSideBar";
            this.Size = new System.Drawing.Size(193, 501);
            this.contextMenuStrip_openImg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_openImg;
        private System.Windows.Forms.ToolStripMenuItem openImgContainingFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delCurImgToolStripMenuItem;
        DoubleBufferListView doubleBufferListView = new DoubleBufferListView();
    }
}
