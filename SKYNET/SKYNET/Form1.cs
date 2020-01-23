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
            
            bmp_manager = new image_manager();
            network = new network();
            images = new List<string>();
            
            network.generate_network(img_size * img_size,correct_symbols.Length);
            textBox_iterrations.Text = network.number_of_iterrations.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //first tab

        private void button_refresh_Click(object sender, EventArgs e)
        {
           
           
            listView1.Items.Clear();
            images.Clear();
            images = bmp_manager.GetImageFileNames("imgs");
            bmp_manager.ShowImages(images);

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            listView1.Items.Clear();
            images.Clear();
            images = bmp_manager.GetImageFileNames("imgs");
            bmp_manager.ShowImages(images);
        }


        private void button_commit_Click(object sender, EventArgs e)

        {
            network.number_of_iterrations = int.Parse(textBox_iterrations.Text);

        }
        //second tab

        public void button_trening_Click(object sender, EventArgs e)
        {


            //tworzę sieć, ilość wejść jest uzależniona jest od wielkości obrazka (obrazek musi być kwadratem)
            //ilość wyjść od ilości cyfr jakie mogą wystąpić

            //network.generate_network(img_size * img_size, img_list.Count);

            List<double[][]> sets = new List<double[][]>();
            sets.Add(bmp_manager.get_signals("imgs")); //reprezentacja sygnałów we/wy
            sets.Add(bmp_manager.get_signals("imgs2"));
            sets.Add(bmp_manager.get_signals("imgs3"));
            sets.Add(bmp_manager.get_signals("imgs4"));



            double[][] output_signals = new double[correct_symbols.Length][]; //rozmiar "pierwszej tablicy" równy jest ilości testowych danych

            for(int i = 0; i< correct_symbols.Length; i++)
            {
                output_signals[i] = new double[correct_symbols.Length];

                for(int l=0;l< correct_symbols.Length; l++)
                {

                    output_signals[i][l]= i == l ? 1.0 : 0.0; 
                }

                network.output_layer[i].symbol = correct_symbols[i];
                
            }
            network.train(sets, output_signals);
            for(int i =0; i < network.iterration;i++)
                listView1.Items.Add(network.error[i].ToString("#0.000"));
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


            Bitmap sample = new Bitmap(bmp_manager.url_of_loaded);
            double[] signals = bmp_manager.get_signals(sample);
            network.exam(signals);
            listView2.Items.Clear();

            for (int i = 0; i < network.output_layer.Length; i++)
            {
                ListViewItem item = listView2.Items.Add(correct_symbols[i]);
                
                listView2.Items.Add(network.output_layer[i].output.ToString("#0.0000"));

            }

        }

        private void button1_Click(object sender, EventArgs e)

        {
            
            bmp_manager.LoadPicture();
            Bitmap image = bmp_manager.resize(new Bitmap(bmp_manager.url_of_loaded));
            pictureBox1.Image = image;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button_save_Click(object sender, EventArgs e)
        {
           network.write_weights();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            Reader reader = new Reader();
            string weights = reader.read();
            network.load_weights(weights);
        }
       
    }
}
