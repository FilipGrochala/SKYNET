using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    class image_manager
    {

        private FlowLayoutPanel panel;
        public string url_of_loaded = "";

        public image_manager() { }
        public image_manager(FlowLayoutPanel _panel)
        {
            panel = _panel;
        }

        public void ShowImages(List<string> images)
        {
            int x = 0;
            int y = 0;
            int index = 0;
            foreach (var item in images)
            {
                PictureBox pb = new PictureBox();
                pb.Size = new System.Drawing.Size(60, 60);
                pb.Location = new Point(x, y);

                if (index % 3 == 0)
                {
                    x = 0;
                    y += 110;
                }
               
                pb.Load(item);
                
                panel.Controls.Add(pb);
                index++;
                x += 110;
            }
        }
        public List<string> GetImageFileNames(bool set)
        {

            
            if (set==true)
            return Directory.GetFiles("imgs2")
                .ToList();
            else return Directory.GetFiles("imgs")
               .ToList();
        }

        

        public void LoadPicture(PictureBox pictureBox)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.bmp)|*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {

                pictureBox.Image = new Bitmap(open.FileName);
                url_of_loaded =  open.FileName;
            }
           
        }


       

    }
}
