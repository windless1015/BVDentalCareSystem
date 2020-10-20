using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Video.FFMPEG;

namespace BVDentalCareSystem.SelfDefinedControls
{
    enum ItemTypeEnum
    {
        IMAGE = 0,
        VIDEO = 1,
    }

    //一个条目的描述器
    class ItemDiscriptor
    {
        public ItemTypeEnum itemType { set; get; } //item类型：avi视频， jpg图片
        public string itemPath { set; get; } //item完整路径
        public DateTime itemCreationTime { set; get; } //item的创建时间
        public Bitmap thumbnail; //缩略图
        public ItemDiscriptor(string _itemPath)
        {
            itemPath = _itemPath;
            CheckItemType(ref _itemPath);
            if (itemType == ItemTypeEnum.IMAGE)
            {
                GetThumbnailFromImage();
            }
            else if (itemType == ItemTypeEnum.VIDEO)
            {
                GetThumbnailFromVideo();
            }
        }

        ~ItemDiscriptor()
        {
            if(thumbnail != null)
                thumbnail.Dispose();
        }

        //根据完整文件路径判断类型
        private void CheckItemType(ref string filePath)
        {
            string fileStrType = filePath.Substring(filePath.LastIndexOf("."));
            if (fileStrType == ".jpg" || fileStrType == ".jpeg")
            {
                itemType = ItemTypeEnum.IMAGE;
            }
            else if (fileStrType == ".avi" || fileStrType == ".mp4")
            {
                itemType = ItemTypeEnum.VIDEO;
            }
        }

        //从图像获取缩略图
        private void GetThumbnailFromImage()
        {
            FileStream fs = File.OpenRead(itemPath); //OpenRead
            int filelength = 0;
            filelength = (int)fs.Length; //获得文件长度 
            Byte[] image = new Byte[filelength]; //建立一个字节数组 
            fs.Read(image, 0, filelength); //按字节流读取 
            Image result = Image.FromStream(fs);
            fs.Close();
            Image myThumbnailImg = result.GetThumbnailImage(128, 72, () => { return false; }, IntPtr.Zero);
            thumbnail = new Bitmap(myThumbnailImg);
            result.Dispose();
            myThumbnailImg.Dispose();
        }

        private void GetThumbnailFromVideo()
        {
            VideoFileReader videoFileReader = new VideoFileReader();
            videoFileReader.Open(itemPath);
            Bitmap videoFrame = videoFileReader.ReadVideoFrame();
            Image myThumbnailImg = videoFrame.GetThumbnailImage(128, 72, () => { return false; }, IntPtr.Zero);
            thumbnail = new Bitmap(myThumbnailImg);
            videoFrame.Dispose();
            myThumbnailImg.Dispose();
            videoFileReader.Dispose();
        }

    }


    public partial class ImageVideoBrowserSideBar : UserControl
    {
        public string dataPath { set; get; } //控件当前需要显示图像和视频的路径

        //根据dataPath进行排序
        public void SortOrder()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dataPath);
            if (!dirInfo.Exists)
                return;
            //只保留avi和jpg后缀的
            var fileArray = Directory.EnumerateFiles(dataPath, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".avi") || s.EndsWith(".jpg"));
            foreach (string currentFile in fileArray)
            {
                ItemDiscriptor a = new ItemDiscriptor(currentFile);
            }
        }





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
