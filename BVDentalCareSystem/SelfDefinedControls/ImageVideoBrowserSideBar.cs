using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BVDentalCareSystem.SelfDefinedControls
{
    enum FileTypeEnum
    {
        IMAGE = 0,
        VIDEO = 1,
    }
    public partial class ImageVideoBrowserSideBar : UserControl
    {
        public string dataPath { set; get; } //控件当前需要显示图像和视频的路径

        public ImageVideoBrowserSideBar()
        {
            InitializeComponent();
            //记得要设置ShowGroups属性为true（默认是false），否则显示不出分组 
            listView_showItems.ShowGroups = true;
        }

        //在listview上单击显示右键菜单
        private void listView_showItems_MouseClick(object sender, MouseEventArgs e)
        {
            listView_showItems.MultiSelect = false;
            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point(e.X, e.Y);
                contextMenuStrip_openImg.Show(listView_showItems, p);
            }
        }
    }
}
