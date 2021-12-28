using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Gupy_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------- Question 1 -----------------------");
            firstActivity();
            Console.WriteLine("");

            Console.WriteLine("----------------------- Question 2 -----------------------");
            secondActivity();
            Console.WriteLine("");

            Console.WriteLine("----------------------- Question 3 -----------------------");
            threeActivity();
            Console.WriteLine("");

            Console.WriteLine("----------------------- Question 4 -----------------------");
            fourActivity();
            Console.WriteLine("");

            Console.WriteLine("----------------------- Question 5 -----------------------");
            fiveActivity();
        }
        static void firstActivity()
        {
            int indice = 13;
            int soma = 0;
            int k = 0;

            while (k < indice)
            {
                k = k + 1;
                soma = soma + k;
            }
            Console.WriteLine("O valor da soma é: " + soma);
        }

        static void secondActivity()

        {
            Console.Write("Digite um número: ");
            int number = int.Parse(Console.ReadLine());

            int n1 = 0;
            int n2 = 1;
            int sequence = 0;

            if (number == 0)
            {
                Console.WriteLine("O número " + number + " pertence a sequência de Fibonacci.");
            }
            else
            {
                while (sequence < number)
                {
                    sequence = n1 + n2;
                    n1 = n2;
                    n2 = sequence;
                }

                if (number == sequence)
                {
                    Console.WriteLine("O número " + number + " pertence a sequência de Fibonacci.");
                }
                else
                {
                    Console.WriteLine("O número " + number + " não pertence a sequência de Fibonacci.");
                }
            }

        }


        class model
        {
            public int dia { get; set; }
            public double valor { get; set; }
        }

        static void threeActivity()
        {
            using (StreamReader r = new StreamReader("assets/dados.json"))
            {
                string json = r.ReadToEnd();
                List<model> items = JsonSerializer.Deserialize<List<model>>(json);

                var values = new List<double>();
                int i = 0;
                foreach (var item in items)
                {
                    if (item.valor != 0)
                    {
                        values.Add(item.valor);
                        i++;
                    }
                }

                double lowerValue = values[0];
                double highestValue = values[0];
                double sum = 0;
                double average = 0;
                int numberOfDays = 0;


                foreach (var value in values)
                {
                    if (lowerValue > value)
                    {
                        lowerValue = value;
                    }
                    else if (highestValue < value)
                    {
                        highestValue = value;
                    }
                }

                foreach (var item in values)
                {
                    sum = sum + item;
                }

                average = sum / values.Count;

                foreach (var item in items)
                {
                    if (item.valor > average)
                    {
                        numberOfDays++;
                    }
                }


                Console.WriteLine("O menor valor de faturamento é: R$" + lowerValue);
                Console.WriteLine("O maior valor de faturamento é: R$" + highestValue);
                Console.WriteLine(numberOfDays + " dias o faturamento diário foi superior à média mensal.");


            }
        }
        static void fourActivity()
        {
            double sum = 0;
            var billingData = new Dictionary<string, double>();
            billingData.Add("SP", 67836.43);
            billingData.Add("RJ", 36678.66);
            billingData.Add("MG", 29229.88);
            billingData.Add("ES", 27165.48);
            billingData.Add("Outros", 19849.53);

            foreach (var item in billingData)
            {
                sum = sum + item.Value;
            }

            var representativeness = new Dictionary<string, double>();

            foreach (var item in billingData)
            {
                representativeness.Add(item.Key, Math.Round(item.Value / sum * 100, 2));
            }

            foreach (var item in representativeness)
            {
                Console.WriteLine("Estado: " + item.Key + " Representatividade: " + item.Value + "%");
            }
        }
        static void fiveActivity()
        {
            Console.Write("Digite algo para que possamos inverter: ");
            string phrase = Console.ReadLine();

            int i = 0;
            char[] arr = phrase.ToCharArray(0, phrase.Length);
            int j = arr.Length - 1;
            char[] reverseSentence = new char[arr.Length];

            while (i < arr.Length)
            {
                reverseSentence[i] = arr[j];
                i++;
                j--;
            }

            Console.Write(reverseSentence);


        }
    }
}
