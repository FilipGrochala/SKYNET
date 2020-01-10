using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET
{
    class network
    {
        public double rate = 0.5;
        public double good_enaugh = 0.01;

        public struct input_neuron
        {
            public double value;
            public double[] weights;
        }



        public struct output_neuron
        {
            public double input_sum;
            public double output;
            public double err;
            public double correct_result;
            public string value;
        }


        public int input_size = 0; //wielkość warstwy wejściowej i wyjściowej
        public int output_size = 0;



        public input_neuron[] input_layer = null; // warstwa wejściowa i wyjściowa
        public output_neuron[] output_layer = null;


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



            input_layer = new network.input_neuron[input_size];
            output_layer = new network.output_neuron[output_size];

            Random random = new Random();

            for (int i = 0; i < input_size; i++)

            {

                input_layer[i].weights = new double[output_size]; //neuron wejściowy ma tyle wyjść ile jesst neuronów w warstwie wyjściowej
                {

                    for (int j = 0; j < output_size; j++)
                    {
                        input_layer[i].weights[j] = random.Next(1, 2) / 100; //losowe wagi z zakreu od 0,1 do 0,9
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
                    get_output(output_layer[i].value, input_signals[i]);
                    backpropagation();
                    err += calculate_error();
                }

                error.Add(err);
                iterration++;

            } while (iterration < numeber_of_iterrations && err > good_enaugh);



        }

        public void train(double[][] input_signals, double[][] input_signals2, double[][] output_signalis)
        {
            double err = 0;
            do
            {
                err = 0;

                for (int i = 0; i < input_signals.Length; i++)
                {
                    if (iterration % 2 == 0)
                        get_output(output_layer[i].value, input_signals[i]);
                    else
                        get_output(output_layer[i].value, input_signals2[i]);

                    backpropagation();
                    err += calculate_error();
                }

                error.Add(err);
                iterration++;

            } while (iterration < numeber_of_iterrations && err > good_enaugh);



        }

        public void backpropagation() //wsteczna propagacja błędu /
        {

            for (int i = 0; i < output_layer.Length; i++)
            {
                for (int j = 0; j < input_layer.Length; j++) //zmieniamy wagi 
                {
                    input_layer[j].weights[i] += rate * (output_layer[i].err) * input_layer[j].value; // dostosujemy wagi używajc błędu i  tempa uczenia
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
                input_layer[i].value = signals[i];
            }


            for (int j = 0; j < output_layer.Length; j++)
            {
                double sum = 0;

                for (int k = 0; k < input_layer.Length; k++)
                    sum += input_layer[k].weights[j] * input_layer[k].value; //obliczanie sumy wag i wartości sygnału

                output_layer[j].input_sum = sum;
                output_layer[j].output = 1.0 / (1.0 + Math.Exp(-sum)); // aktywacja neuronu signoidalnego 
                //prościej nie działało porównujemy string zeby nie liczyło się zbyt duże rozwinięcie po przecinku
                output_layer[j].correct_result = output_layer[j].value.CompareTo(value) == 0 ? 1 : 0;
                output_layer[j].err = (output_layer[j].correct_result - output_layer[j].output) * (output_layer[j].output) * (1 - output_layer[j].output); // obliczanie błędu dla pojedynczego neuronu


            }

        }


        public void exam(double[] input_signals)
        {
            for (int i = 0; i < input_layer.Length; i++)
            {
                input_layer[i].value = input_signals[i]; //wprowadzam sygnały na wejście
            }

            for (int i = 0; i < output_layer.Length; i++)
            {
                double sum = 0;

                for (int j = 0; j < input_layer.Length; j++)
                    sum += input_layer[j].weights[i] * input_layer[j].value; //obliczanie sumy wag i wartości sygnału

                output_layer[i].input_sum = sum;
                output_layer[i].output = 1.0 / (1.0 + Math.Exp(-sum)); //aktywacja neuronu sigmoidalnego Sigmoidalna funkcja unipolarna 

            }


        }

    }  
}
