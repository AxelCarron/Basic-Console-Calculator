using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ConsoleApplication41
{
    class Program
    {
        static void Main(string[] args)
        {
            string resultante = "resultados.txt";
            decimal numeroA = 0, numeroB = 0, resultado = 0; // Declarando a las variables cpara que soporten decimals
            string op = ""; // idem pero para cadena de texto

            do
            {
                op = Menu();

                Console.Clear();
                if (op == "5")
                {
                    Console.Clear();
                    Console.Write("La última operación realiza fué:\n\n");
                    StreamReader L = new StreamReader("C:\\Resultado.txt");
                    for (;;)
                    {
                        string s = L.ReadLine();
                        if (s == null) break;
                        Console.WriteLine(s);
                    }
                    L.Close();

                    Thread.Sleep(4000);
                    Console.Clear();


                }

                if (op == "6") // Si el contenido de la variable "op" es "5" ejecuta lo que tiene dentro
                {
                    Console.WriteLine("Gracias por utilizar la calculadora");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }

                else if (op == "S" || op == "R" || op == "M" || op == "D")
                {
                    Console.Write("Ingrese primer valor:\t");
                    numeroA = PedirValor();

                    Console.Write("Ingrese segundo valor:\t");
                    numeroB = PedirValor();

                    switch (op)
                    {
                        case "S":
                            resultado = SUMA(numeroA, numeroB, resultante);
                            break;
                        case "R":
                            resultado = RESTA(numeroA, numeroB, resultante);
                            break;
                        case "M":
                            resultado = MULTI(numeroA, numeroB, resultante);
                            break;
                        case "D":
                            resultado = DIV(numeroA, numeroB, resultante);
                            break;
                    }
                    Console.WriteLine("El resultado es: " + resultado);
                }

                Thread.Sleep(3000);
                Console.Clear();

            } while (op == "5" | op == "S" | op == "R" | op == "M" | op == "D");

            Console.Write("Presione cualquier tecla para salir...");
            Console.ReadKey(true);
        }

        public static string Menu()
        {
            Console.WriteLine("==== MI CALCULADORA!! ====\n");
            Console.WriteLine("Elija una opcion:");
            Console.WriteLine("\tS - SUMA");
            Console.WriteLine("\tR - RESTA");
            Console.WriteLine("\tM - MULTIPLICACION");
            Console.WriteLine("\tD - DIVISION");
            Console.WriteLine("\t5 - REGISTRO DE RESULTADOS");
            Console.WriteLine("\t6 - SALIR");
            string op = "";
            do
            {
                Console.Write("Por favor ingrese una opcion válida:");
                op = Console.ReadLine();
                if (op == "Pepe")
                {
                    Console.WriteLine("Estas en la Matrix viteeee!!!");
                    Thread.Sleep(2000);
                    break;
                }
            } while (op != "S" & op != "R" & op != "M" & op != "D" & op != "5" & op !="6");

            return op;
        }

        public static decimal PedirValor()
        {
            decimal numero = 0;
            int valida = 0;
            do
            {
                try
                {
                    numero = Convert.ToDecimal(Console.ReadLine());
                    valida = 1;
                }
                catch
                {
                    Console.Write("Por favor ingrese un valor numérico:\t");
                    valida = 0;
                }
            } while (valida != 1);

            return numero;
        }

        public static decimal SUMA(decimal valor1, decimal valor2, string resultante)
        {
            decimal result = valor1 + valor2;
            StreamWriter S = File.AppendText(resultante);
            S.Write("\n" + DateTime.Now + ";");
            S.Write("SUMA: {0} + {1} = {2}\r\n", valor1, valor2, result);

            S.Close();

            return result;
        }

        public static decimal RESTA(decimal valor1, decimal valor2, string resultante)
        {
            decimal result = valor1 - valor2;
            StreamWriter R = File.AppendText(resultante);
            R.Write("\n" + DateTime.Now + ";");
            R.Write("RESTA: {0} - {1} = {2}\r\n", valor1, valor2, result);
            R.Close();

            return result;
        }

        public static decimal MULTI(decimal valor1, decimal valor2, string resultante)
        {
            decimal result = valor1 * valor2;
            StreamWriter M = File.AppendText(resultante);
            M.Write("\n" + DateTime.Now + ";");
            M.Write("MULTI: {0} * {1} = {2}\r\n", valor1, valor2, result);
            M.Close();
            return result;
        }

        public static decimal DIV(decimal valor1, decimal valor2, string resultante)
        {
            int valida = 0;
            decimal result = 0;
            if (valor2 == 0)
            {
                do
                {
                    Console.Write("Por favor, ingrese un segundo valor que no sea 0:");
                    do
                    {
                        try
                        {
                            valor2 = Convert.ToDecimal(Console.ReadLine());
                            valida = 1;
                        }
                        catch
                        {
                            Console.Write("Por favor ingrese un valor numérico:");
                            valida = 0;
                        }
                    } while (valida != 1);
                } while (valor2 == 0);
                result = valor1 / valor2;
            }
            else
            {
                result = valor1 / valor2;
            }
            StreamWriter D = File.AppendText(resultante);
            D.Write("\n" + DateTime.Now + ";");
            D.Write("DIV: {0} / {1} = {2}\r\n", valor1, valor2, result);
            D.Close();
            return result;
        }

    }
}

