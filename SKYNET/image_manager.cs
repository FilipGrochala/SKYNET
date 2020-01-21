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
        int img_size = 6;

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
        public List<string> GetImageFileNames(string directory)
        {
            
            return Directory.GetFiles(directory)
                .ToList();
        }

        

        public void LoadPicture()
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.bmp)|*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {

  
                url_of_loaded =  open.FileName;
            }
           
        }
        

        public Bitmap resize(Bitmap image)
        {
            Bitmap bitmap = new Bitmap(image, new Size(100, 100));
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(image, 0, 0, 100, 100);
            }

            return bitmap;

        }
        public double[][] get_signals(string dir)
        {
            List<string> img_list = GetImageFileNames(dir);
            double[][] signals = new double[img_list.Count][];
            for (int i = 0; i < img_list.Count; i++)
            {
                signals[i] = new double[img_size * img_size]; //zagnieżdżona tablice krórej rozmiary odzwierciedlają ilość pikseli
                Bitmap bitmap = new Bitmap(img_list[i]);

                for (int j = 0; j < img_size; j++)
                {
                    for (int k = 0; k < img_size; k++)
                    {
                        Color pixel = bitmap.GetPixel(j, k);
                        signals[i][j * img_size + k] = (1.0 - (pixel.R / 255.0 + pixel.G / 255.0 + pixel.B / 255.0) / 3.0) < 0.5 ? 0.0 : 1.0;

                    } // przygotowanie sygnałów na podstawie obrazka

                }

            }
            return signals;

        }
        public double[] get_signals(Bitmap bitmap)
        {

            double[] signals = new double[img_size * img_size];
           

                for (int j = 0; j < img_size; j++)
                {
                    for (int k = 0; k < img_size; k++)
                    {
                    try
                    {
                        Color pixel = bitmap.GetPixel(j, k);
                        signals[j * img_size + k] = (1.0 - (pixel.R / 255.0 + pixel.G / 255.0 + pixel.B / 255.0) / 3.0) < 0.5 ? 0.0 : 1.0;

                    }
                    catch
                    {
                        MessageBox.Show("Obrazek jest błędnie przygotowany, obrazki muszą być czarno-białe!");
                        break;
                    }

                } // przygotowanie sygnałów na podstawie obrazka

                }
            
            return signals;

        }





    }
}
