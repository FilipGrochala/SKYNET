using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{




    public partial class Form1 : Form
    {

        image_manager bmp_manager;
        network network;
        string[] correct_symbols = {"A","B","C","D","E","F","G","H","I","J"};
        List<string> images;
        int img_size = 6;
        

        public Form1()
        {
            InitializeComponent();
            
            bmp_manager = new image_manager(flowLayoutPanel1);
            network = new network();
            images = new List<string>();
            
            network.generate_network(img_size * img_size,correct_symbols.Length);
            textBox_iterrations.Text = network.numeber_of_iterrations.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //first tab

        private void button_refresh_Click(object sender, EventArgs e)
        {
           
            flowLayoutPanel1.Controls.Clear();
            listView1.Items.Clear();
            images.Clear();
            images = bmp_manager.GetImageFileNames(false);
            bmp_manager.ShowImages(images);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            listView1.Items.Clear();
            images.Clear();
            images = bmp_manager.GetImageFileNames(true);
            bmp_manager.ShowImages(images);
        }


        private void button_commit_Click(object sender, EventArgs e)

        {
            network.numeber_of_iterrations = int.Parse(textBox_iterrations.Text);

        }
        //second tab

        public void button_trening_Click(object sender, EventArgs e)
        {
            List<string> img_list = bmp_manager.GetImageFileNames(false); //pobieram adresy obrazków
            List<string> img_list2 = bmp_manager.GetImageFileNames(true); //drugi zestaw danych uczących

            


            //tworzę sieć, ilość wejść jest uzależniona jest od wielkości obrazka (obrazek musi być kwadratem)
            //ilość wyjść od ilości cyfr jakie mogą wystąpić

            //network.generate_network(img_size * img_size, img_list.Count);


            double[][] input_signals = new double[img_list.Count][]; //reprezentacja sygnałów we/wy
            double[][] input_signals2 = new double[img_list.Count][];
            double[][] output_signals = new double[img_list.Count][]; //rozmiar "pierwszej tablicy" równy jest ilości testowych danych

            for(int i = 0; i<img_list.Count; i++)
            {

                input_signals[i] =new double[img_size * img_size]; //zagnieżdżona tablice krórej rozmiary odzwierciedlają ilość pikseli
                input_signals2[i] = new double[img_size * img_size];
               
                Bitmap bitmap = new Bitmap(img_list[i]);
                Bitmap bitmap2 = new Bitmap(img_list2[i]);




                for(int j=0; j < img_size; j++)
                {
                    for (int k=0; k < img_size; k++)
                    {
                        
                          Color pixel = bitmap.GetPixel(j, k);

                          input_signals[i][j * img_size + k] = (1.0 - (pixel.R / 255.0 + pixel.G / 255.0 + pixel.B / 255.0) / 3.0) < 0.5 ? 0.0 : 1.0;

                          Color pixel2 = bitmap2.GetPixel(j, k);

                          input_signals2[i][j * img_size + k] = (1.0 - (pixel2.R / 255.0 + pixel2.G / 255.0 + pixel2.B / 255.0) / 3.0) < 0.5 ? 0.0 : 1.0;

                    

                    } // przygotowanie sygnałów na podstawie obrazka

                }

                output_signals[i] = new double[img_list.Count];

                for(int l=0;l<img_list.Count;l++)
                {

                    output_signals[i][l]= i == l ? 1.0 : 0.0; 
                }

                network.output_layer[i].value = correct_symbols[i];
                
            }

            network.train(input_signals,input_signals2, output_signals);
            

            for(int i =0; i < network.iterration;i++)
                listView1.Items.Add(network.error[i].ToString("#0.0000"));


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            //pobieramy próbkę
            

        }

        private void button_exam_Click(object sender, EventArgs e)
        {

            double[] signals = new double[img_size * img_size];

            Bitmap sample = new Bitmap(bmp_manager.url_of_loaded);

            for (int i = 0; i < img_size; i++)
            {
                for (int j = 0; j < img_size; j++)
                {
                    try
                    {
                        Color pixel = sample.GetPixel(i, j);
                        signals[i * img_size + j] = (1.0 - (pixel.R / 255.0 + pixel.G / 255.0 + pixel.B / 255.0) / 3.0) < 0.5 ? 0.0 : 1.0;

                    }
                    catch
                    {
                        MessageBox.Show("Obrazek o numerze: " + i.ToString() + ". jest błędnie przygotowany, obrazki muszą być czarno-białe!");
                        break;
                    }
                }

            } // przygotowanie sygnałów na podstawie obrazka

            network.exam(signals);

            listView2.Items.Clear();


            for (int i = 0; i < network.output_layer.Length; i++)
            {
                ListViewItem item = listView2.Items.Add(network.output_layer[i].value);
                
                listView2.Items.Add(network.output_layer[i].output.ToString("#0.0000"));

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmp_manager.LoadPicture(pictureBox1);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
