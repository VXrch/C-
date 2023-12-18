using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _23._12._11_Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;

            Console.WriteLine("Enter task number (1-6 or 0 to print all)");
            choice = int.Parse(Console.ReadLine());

            Console.WriteLine(); Console.WriteLine();

            switch (choice)
            {
                case 0:
                    Console.WriteLine(" ================| TASK 1 |================"); Task1();
                    Console.WriteLine(" ================| TASK 2 |================"); Task2();
                    Console.WriteLine(" ================| TASK 3 |================"); Task3();
                    Console.WriteLine(" ================| TASK 4 |================"); Task4();
                    Console.WriteLine(" ================| TASK 5 |================"); Task5();
                    Console.WriteLine(" ================| TASK 6 |================"); Task6();
                    break;
                case 1:
                    Console.WriteLine(" ================| TASK 1 |================"); Task1();
                    break;
                case 2:
                    Console.WriteLine(" ================| TASK 2 |================"); Task2();
                    break;
                case 3:
                    Console.WriteLine(" ================| TASK 3 |================"); Task3();
                    break;
                case 4:
                    Console.WriteLine(" ================| TASK 4 |================"); Task4();
                    break;
                case 5:
                    Console.WriteLine(" ================| TASK 5 |================"); Task5();
                    break;
                case 6:
                    Console.WriteLine(" ================| TASK 6 |================"); Task6();
                    break;
                default:
                    Console.WriteLine("Wrong number!");
                    break;
            }

            Console.WriteLine(); Console.WriteLine();
        }
        static void Task6()
        {
            int len;
            int temp;
            bool vertical = false;
            char symbol;

            Console.WriteLine("Enter line lenght: ");
            len = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter symbhol to write: ");
            symbol = char.Parse(Console.ReadLine());

            Console.WriteLine("Do you want a vertical line?:");
            Console.WriteLine("[0] = No, print horizontal line");
            Console.WriteLine("[1] = Yes, print vertical line");
            temp = int.Parse(Console.ReadLine());

            if (temp == 0)
            {
                vertical = true;
            }

            Console.WriteLine(); Console.WriteLine();

            if (vertical)
            {
                for (int i = 0; i < len; i++)
                {
                    Console.Write(symbol);
                }
            }
            else
            {
                for (int i = 0; i < len; i++)
                {
                    Console.WriteLine(symbol);
                }
            }

            Console.WriteLine(); Console.WriteLine();
        }
        static void Task5()
        {
            int r1, r2;

            Console.WriteLine("Enter range (for example: 1-10)");
            r1 = int.Parse(Console.ReadLine());
            r2 = int.Parse(Console.ReadLine());

            if (r2 <= r1)
            {
                Console.WriteLine("Wrong range!");
            }
            else
            {
                for (int i = r2; i >= r1; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write($" {i}");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("------- OR -------");

                for (int i = r1; i <= r2; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write($" {i}");
                    }
                    Console.WriteLine();
                }
            }
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
            Console.WriteLine();
        }
        static void Task3()
        {
            string str;

            Console.WriteLine("Enter 6 numbers in one line: ");
            str = Console.ReadLine();

            // Console.WriteLine($"{str[5]}{str[4]}{str[3]}{str[2]}{str[1]}{str[0]}");

            for (int i = str.Length; i > 0; i--)
            {
                Console.Write(str[i - 1]);
            }
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
