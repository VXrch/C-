using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._12._20_Task2
{
    internal class Program
    {
        class Calcul
        {
            public Calcul() { }

            static double Add(double n1, double n2)
            {
                try
                {
                    return n1 + n2;
                }
                catch (Exception ex) { throw ex; }
            }
            static double Sub(double n1, double n2)
            {
                try
                {
                    return n1 - n2;
                }
                catch (Exception ex) { throw ex; }
            }
            static double Mul(double n1, double n2)
            {
                try
                {
                    return n1 * n2;
                }
                catch (Exception ex) { throw ex; }
            }
            static double Div(double n1, double n2)
            {
                try
                {
                    if (n2 != 0) { return n1 / n2; }
                    throw new DivideByZeroException();
                }
                catch (Exception ex) { throw ex; }
            }

            public double Calculate_line(string line)
            {
                try
                {
                    string[] elements = line.Split('+', '-', '*', '/');

                    double n1 = Convert.ToDouble(elements[0].Replace('.', ','));
                    double n2 = Convert.ToDouble(elements[1].Replace('.', ','));

                    if (line.Contains('+'))
                    {
                        return Add(n1, n2);
                    }
                    else if (line.Contains('-'))
                    {
                        return Sub(n1, n2);
                    }
                    else if (line.Contains('*'))
                    {
                        return Mul(n1, n2);
                    }
                    else if (line.Contains('/') || line.Contains(':'))
                    {
                        return Div(n1, n2);
                    }
                    else
                    {
                        Console.WriteLine("ERROR!");
                    }
                    throw new Exception();
                }
                catch (Exception ex) { throw ex; }
            }
        }
        static void Main(string[] args)
        {
            Calcul calculator = new Calcul();

            bool ext = false;
            while (!ext)
            {
                try
                {
                    Console.Write("\n(/'~_~)/' ~  {example --> [23 + 1]} ~  "); string input = Console.ReadLine();

                    double result = calculator.Calculate_line(input);

                    Console.WriteLine($"Result: {result}");
                }
                catch (DivideByZeroException ex) { Console.WriteLine(ex.Message); }
                catch (Exception ex) { Console.WriteLine($"An error occured! {ex.Message}"); }
            }
        }
    }
}
