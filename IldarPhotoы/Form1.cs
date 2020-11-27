using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace IldarPhotoы
{
    public partial class Form1 : MetroForm
    {
        private string path = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (openFile = new OpenFileDialog())
            {
                if(openFile.ShowDialog() == DialogResult.OK)
                {
                    path = openFile.FileName;
                    SetImage(path);
                }
                
            }
        }

        private void SetImage(string path)
        {
            var image = new Bitmap(path);
            pictureBox1.Image = image;
        }

        private void btnRotate90Left_Click(object sender, EventArgs e)
        {
            if(path != "")
            {
                pictureBox1.Image = RotateImage90deg(pictureBox1.Image, 90f);
            }
            else
            {
                MessageBox.Show("You did not chose the picture from file", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //private Bitmap RotateImage90degRight(Image image,  float deg)
        //{
        //    Bitmap bitmap = new Bitmap(image.Height, image.Width);
        //    bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        //    using (Graphics g = Graphics.FromImage(bitmap))
        //    {
        //        g.TranslateTransform(2*image.Width,-image.Height );
        //        g.RotateTransform(deg);
        //        g.DrawImage(image, image.Width,image.Height);
        //    }
        //    return bitmap;
        //}

        private Bitmap RotateImage90deg(Image image, float deg)
        {
            Bitmap bitmap = new Bitmap(image.Height, image.Width);
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.TranslateTransform(image.Width/2, image.Height/2);
                g.RotateTransform(deg);
                g.DrawImage(image,-image.Width/2,-image.Height/2);
            }
            return bitmap;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (path != "")
            {
                pictureBox1.Image = RotateImage90deg(pictureBox1.Image, -90f);
            }
            else
            {
                MessageBox.Show("You did not chose the picture from file", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (path != "")
            {
                pictureBox1.Image = RotateImage90deg(pictureBox1.Image, 180f);
            }
            else
            {
                MessageBox.Show("You did not chose the picture from file", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
