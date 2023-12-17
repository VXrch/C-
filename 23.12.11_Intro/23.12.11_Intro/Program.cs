using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._12._11_Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        static void Task4()
        {
            int r;
            int n1 = 0, n2 = 1;

            Console.WriteLine("Enter diapazon (0 - X)");
            r = int.Parse(Console.ReadLine());

            for (int i = 0; i < r; i++)
            {
                Console.Write(n1 + " ");

                int res = n1 + n2;
                n1 = n2;
                n2 = res;
            }
        }
        static void Task3()
        {
            string str;

            Console.WriteLine("Enter 6 numbers in one line: ");
            str = Console.ReadLine();

            Console.WriteLine($"{str[5]}{str[4]}{str[3]}{str[2]}{str[1]}{str[0]}");
        }
        static void Task2()
        {
            int n1, n2, n3, n4, n5;

            Console.WriteLine("Enter 5 numbers: ");
            n1 = int.Parse(Console.ReadLine());
            n2 = int.Parse(Console.ReadLine());
            n3 = int.Parse(Console.ReadLine());
            n4 = int.Parse(Console.ReadLine());
            n5 = int.Parse(Console.ReadLine());

            if (n1 > n2 && n1 > n3 && n1 > n4 && n1 > n5)
            {
                Console.WriteLine($"Max number: {n1}");
            }
            else if (n2 > n1 && n2 > n3 && n2 > n4 && n2 > n5)
            {
                Console.WriteLine($"Max number: {n2}");
            }
            else if (n3 > n1 && n3 > n2 && n3 > n4 && n3 > n5)
            {
                Console.WriteLine($"Max number: {n3}");
            }
            else if (n4 > n1 && n4 > n2 && n4 > n3 && n3 > n5)
            {
                Console.WriteLine($"Max number: {n4}");
            }
            else if (n5 > n1 && n5 > n2 && n5 > n3 && n5 > n4)
            {
                Console.WriteLine($"Max number: {n5}");
            }

            if (n1 < n2 && n1 < n3 && n1 < n4 && n1 < n5)
            {
                Console.WriteLine($"Min number: {n1}");
            }
            else if (n2 < n1 && n2 < n3 && n2 < n4 && n2 < n5)
            {
                Console.WriteLine($"Min number: {n2}");
            }
            else if (n3 < n1 && n3 < n2 && n3 < n4 && n3 < n5)
            {
                Console.WriteLine($"Min number: {n3}");
            }
            else if (n4 < n1 && n4 < n2 && n4 < n3 && n3 < n5)
            {
                Console.WriteLine($"Min number: {n4}");
            }
            else if (n5 < n1 && n5 < n2 && n5 < n3 && n5 < n4)
            {
                Console.WriteLine($"Min number: {n5}");
            }

            Console.WriteLine($"Sum: {n1 + n2 + n3 + n4 + n5}");
            Console.WriteLine($"Product: {n1 * n2 * n3 * n4 * n5}");
        }
        static void Task1()
        {
            Console.WriteLine("It's easy to win forgiveness for being wrong;");
            Console.WriteLine("being right is what gets you into real trouble.");
            Console.WriteLine("Bjarne Stroustrup");
        }
    }
}
