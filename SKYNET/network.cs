using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET
{
    class network
    {
        public double momentum = 0.7;
        public double good_enaugh = 0.01;

        public struct input_line
        {
            public double value;
            public double[] weights;
        }

        public struct neuron
        {
            public double input_sum;
            public double output;
            public double err;
            public double correct_result;
            public string symbol;
        }


        public int input_size = 0; //wielkość warstwy wejściowej i wyjściowej
        public int output_size = 0;



        public input_line[] input_lines = null; // warstwa wejściowa i wyjściowa
        public neuron[] output_layer = null;


        //tablica do przechowywania błędów

        public int numeber_of_iterrations = 2000;
        public int iterration = 0;

        public List<double> error = new List<double>();

        public network()
        {

        }

        public void generate_network(int _input_size, int _output_size)
        {
            input_size = _input_size;
            output_size = _output_size;



            input_lines = new network.input_line[input_size];
            output_layer = new network.neuron[output_size];

            Random random = new Random();

            for (int i = 0; i < input_size; i++)

            {

                input_lines[i].weights = new double[output_size]; //neuron wejściowy ma tyle wyjść ile jesst neuronów w warstwie wyjściowej
                {

                    for (int j = 0; j < output_size; j++)
                    {
                        input_lines[i].weights[j] = random.Next(1, 2) / 100; //losowe wagi z zakreu od 0,1 do 0,9
                    }

                }

            }

        }




        public void train(double[][] input_signals, double[][] output_signalis)
        {
            double err = 0;
            do
            {
                err = 0;

                for (int i = 0; i < input_signals.Length; i++)
                {
                    get_output(output_layer[i].symbol, input_signals[i]);
                    backpropagation();
                    err += calculate_error();
                }

                error.Add(err);
                iterration++;

            } while (iterration < numeber_of_iterrations && err > good_enaugh);



        }
        public void train(List<double[][]> signals, double[][] output_signalis)
        {
            double err = 0;
            int counter = 0;
            double[][] current_set;
            do
            {
                err = 0;
                current_set = signals[counter];

                for (int i = 0; i < signals[0].Length; i++)
                {
                    get_output(output_layer[i].symbol, current_set[i]);
                    backpropagation();
                    err += calculate_error();
                }
                if (counter == 3)
                    counter = 0;
                else
                    counter++;
                error.Add(err);
                iterration++;

            } while (iterration < numeber_of_iterrations && err > good_enaugh);



        }


        public void backpropagation() //wsteczna propagacja błędu /
        {

            for (int i = 0; i < output_layer.Length; i++)
            {
                for (int j = 0; j < input_lines.Length; j++) //zmieniamy wagi 
                {
                    input_lines[j].weights[i] += momentum * (output_layer[i].err) * input_lines[j].value; // dostosujemy wagi używajc błędu i  tempa uczenia
                }

            }

        }
        public double calculate_error() //obliczanie błędu dla całej sieci 
        {
            double err = 0;

            for (int i = 0; i < output_layer.Length; i++)
            {
                err += ((output_layer[i].correct_result - output_layer[i].output) * (output_layer[i].correct_result - output_layer[i].output)) / 2;  //https://mattmazur.com/2015/03/17/a-step-by-step-backpropagation-example/           
            }
            return err;

        }

        public void get_output(string value, double[] signals)

        {

            for (int i = 0; i < signals.Length; i++)
            {
                input_lines[i].value = signals[i];
            }


            for (int j = 0; j < output_layer.Length; j++)
            {
                double sum = 0;

                for (int k = 0; k < input_lines.Length; k++)
                    sum += input_lines[k].weights[j] * input_lines[k].value; //obliczanie sumy wag i wartości sygnału

                output_layer[j].input_sum = sum;
                output_layer[j].output = 1.0 / (1.0 + Math.Exp(-sum)); // aktywacja neuronu signoidalnego 

                output_layer[j].correct_result = output_layer[j].symbol.CompareTo(value) == 0 ? 1 : 0;
                output_layer[j].err = (output_layer[j].correct_result - output_layer[j].output) * (output_layer[j].output) * (1 - output_layer[j].output); // obliczanie błędu dla pojedynczego neuronu


            }

        }


        public void exam(double[] input_signals)
        {



            for (int i = 0; i < input_lines.Length; i++)
            {
                input_lines[i].value = input_signals[i]; //wprowadzam sygnały na wejście
            }

            for (int i = 0; i < output_layer.Length; i++)
            {
                double sum = 0;

                for (int j = 0; j < input_lines.Length; j++)
                    sum += input_lines[j].weights[i] * input_lines[j].value; //obliczanie sumy wag i wartości sygnału

                output_layer[i].input_sum = sum;
                output_layer[i].output = 1.0 / (1.0 + Math.Exp(-sum)); //aktywacja neuronu sigmoidalnego Sigmoidalna funkcja unipolarna 

            }


        }

        public void write_weights()
        {
            Reader reader = new Reader();
            string weigts = "";

            for (int i = 0; i < input_size; i++)
            {
                for (int j = 0; j < output_size; j++)
                {
                    string temp = input_lines[i].weights[j].ToString() + "|";
                    weigts += temp;
                    
                }
               

            }

            reader.write(weigts);

        }

        public void load_weights(string text)
        {
            string[] file;
            file = text.Split('|');
            int index = 0;
            
            {
                for (int i = 0; i < input_size; i++)

                {

                    input_lines[i].weights = new double[output_size];
                    {

                        for (int j = 0; j < output_size; j++)
                        {
                            input_lines[i].weights[j] = double.Parse(file[index]);
                            index++;
                        }

                    }


                }

            }
        }

    }  
}
