using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BVDentalCareSystem.SelfDefinedControls
{
    public partial class ImageBrowser : Form
    {
        public string curImageAbsPath = null; //初始化当前的的图片的地址
        public string curDataAbsPath = null; //当前数据文件地址
        private bool beginMove = false;
        int currentXPosition;
        int currentYPosition;

        List<FileInfo> imgFileList = null;

        public delegate void CloseThisFormHandle();
        //关闭窗口
        public event CloseThisFormHandle CloseFormNotify;
        public ImageBrowser()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            btnImgBrwExit.BringToFront();
            btnImgBrsBack.BringToFront();
            btnImgBrsGoHead.BringToFront();
        }

        private void btnImgBrwExit_Click(object sender, EventArgs e)
        {
            Close();
            //CloseFormNotify();
        }

        private void btnImgBrsGoHead_Click(object sender, EventArgs e)
        {
            ShowCurImage(true);
        }

        private void btnImgBrsBack_Click(object sender, EventArgs e)
        {
            ShowCurImage(false);
        }

        private void ImageBrowser_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(curDataAbsPath))
            {
                DirectoryInfo ImgDirectory = new DirectoryInfo(curDataAbsPath);//过滤avi和mp4的视频文件
                FileInfo[] ImgFiles = ImgDirectory.GetFiles().Where(s => s.Extension == ".jpg" || s.Extension == ".jpeg").ToArray();

                //根据创建时间排序
                imgFileList = new List<FileInfo>(ImgFiles);
                imgFileList.Sort(new Comparison<FileInfo>(delegate (FileInfo a, FileInfo b)
                {
                    return a.CreationTime.CompareTo(b.CreationTime);
                }));
            }
            //加载当前图片
            if (curImageAbsPath != null)
            {
                //获取当前牙齿的大小
                Image curImg = Image.FromFile(curImageAbsPath);
                if (System.Math.Abs(curImg.Width - curImg.Height) < 20) //正方形
                {
                    pictureBox.ClientSize = new Size(1080, 1080);
                }
                else
                {
                    pictureBox.Location = new Point(0, 0);
                    pictureBox.ClientSize = new Size(1920, 1080);
                }
                pictureBox.Image = curImg;
            }
        }

        private void ShowCurImage(bool isNext)
        {
            //寻找比当前文件创建时间早的第一个文件
            string prevPath = FindNeighborhoodImage(ref curImageAbsPath, isNext);
            curImageAbsPath = prevPath;

            Image curImg = Image.FromFile(curImageAbsPath);
            if (System.Math.Abs(curImg.Width - curImg.Height) < 20) //正方形
            {
                pictureBox.Location = new Point(1920 / 2, 0);
                pictureBox.ClientSize = new Size(1080, 1080);
            }
            else
            {
                pictureBox.Location = new Point(0, 0);
                pictureBox.ClientSize = new Size(1920, 1080);
            }
            pictureBox.Image = curImg;
        }

        private string FindNeighborhoodImage(ref string curFilePath, bool isNext)
        {
            FileInfo curFileInfo = new FileInfo(curFilePath);
            int curIdx = 1;
            for (int i = 0; i < imgFileList.Count; i++)
            {
                if (curFileInfo.Name == imgFileList[i].Name)
                {
                    curIdx = i;
                    break;
                }
            }
            string path;
            if (isNext)
            {
                curIdx = (curIdx == imgFileList.Count - 1) ? imgFileList.Count - 2 : curIdx;
                path = imgFileList[curIdx + 1].FullName;
            }
            else
            {
                curIdx = (curIdx == 0) ? 1 : curIdx;
                path = imgFileList[curIdx - 1].FullName;
            }
            return path;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            return;
            if (beginMove)
            {
                this.Left += MousePosition.X - currentXPosition;//根据鼠标x坐标确定窗体的左边坐标x
                this.Top += MousePosition.Y - currentYPosition;//根据鼠标的y坐标窗体的顶部，即Y坐标
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //设置初始状态
                currentYPosition = 0;
                beginMove = false;
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X;//鼠标的x坐标为当前窗体左上角x坐标
                currentYPosition = MousePosition.Y;//鼠标的y坐标为当前窗体左上角y坐标
            }
        }

        private void ImageBrowser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
