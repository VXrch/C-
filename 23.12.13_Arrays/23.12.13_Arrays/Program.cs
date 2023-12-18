using System;
using System.Runtime.InteropServices;

namespace _23._12._13_Array_Enum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;

            Console.WriteLine("Enter task number (1-5 or 0 to print all)");
            choice = int.Parse(Console.ReadLine());

            Console.WriteLine(); Console.WriteLine();

            switch (choice)
            {
                case 0:
                    Console.WriteLine(" ================| TASK 1 |================"); Task1(); Console.WriteLine();
                    Console.WriteLine(" ================| TASK 2 |================"); Task2(); Console.WriteLine();
                    Console.WriteLine(" ================| TASK 3 |================"); Task3(); Console.WriteLine();
                    Console.WriteLine(" ================| TASK 4 |================"); Task4(); Console.WriteLine();
                    Console.WriteLine(" ================| TASK 5 |================"); Task5(); Console.WriteLine();
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
                default:
                    Console.WriteLine("Wrong number!");
                    break;
            }

            Console.WriteLine(); Console.WriteLine();
        }

        #region Task 5
        static void Task5()
        {
            Random random = new Random();
            int numb;

            int size = 10;
            int[] array = new int[size];

            Console.WriteLine("Enter value: ");
            numb = int.Parse(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(21);
                Console.Write(array[i] + " | ");
            }

            Console.WriteLine();
            Console.WriteLine("-------");

            for (int i = 0; i < size; i++)
            {
                if (array[i] < numb - 5 || array[i] > numb + 5)
                {
                    Console.Write(array[i] + " | ");
                }
            }
        }
        #endregion

        #region Task 4
        static void Task4()
        {
            float[,] array = new float[5, 5];
            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = (float)(random.Next(-100, 100) + random.NextDouble());
                    array[i, j] = (float)Math.Round(array[i, j], 1);

                    Console.Write($"[{i}][{j}] = [{array[i, j]}]     ");
                }
                Console.WriteLine();
            }

            float min = float.MaxValue, max = float.MinValue;
            int minX = 0, minY = 0, maxX = 0, maxY = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        maxX = i; maxY = j;
                    }
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        minX = i; minY = j;
                    }
                }
            }

            Console.WriteLine($"MAX value = {max}, MinValue = {min}");
            Console.WriteLine($"MAX [{minX},{minY}]");
            Console.WriteLine($"MinY [{maxX},{maxY}]");

            float sum = 0;

            if (maxX > minX)
            {
                for (int i = minX; i < maxX; i++)
                {
                    for (int j = minY; j < maxY; j++)
                    {
                        sum += array[i, j];
                    }
                }
            }
            else if (maxX == minX)
            {
                if (maxY > minY)
                {
                    for (int j = minY; j < maxY; j++)
                    {
                        sum += array[minX, j];
                    }
                }
                else if (maxY < minY)
                {
                    for (int j = maxY; j < minY; j--)
                    {
                        sum += array[minX, j];
                    }
                }
            }
            else // maxX < minX
            {
                for (int i = maxX; i < minX; i--)
                {
                    for (int j = maxY; j < minY; j--)
                    {
                        sum += array[i, j];
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");
        }
        #endregion

        #region Task 3
        static void Task3()
        {
            Console.WriteLine("----- A -----");

            int sizeA = 5;
            int[] A = new int[sizeA];

            Console.WriteLine("Enter numbers for A: ");
            for (int i = 0; i < sizeA; i++)
            {
                A[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < A.GetLength(0); i++)
            {
                Console.Write("[" + A[i] + "]\t");
            }

            Console.WriteLine();
            Console.WriteLine("----- B -----");

            Random random = new Random();
            int sizeB = 5;
            float[,] B = new float[sizeB, sizeB];
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = (float)(random.Next(10) + random.NextDouble());
                    B[i, j] = (float)Math.Round(B[i, j], 1);

                    Console.Write("[" + B[i, j] + "]\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine($"Max value: {FindMax(A, B)}");
            Console.WriteLine($"Min value: {FindMin(A, B)}");
            Console.WriteLine($"Sum: {FindSum(A, B)}");
            Console.WriteLine($"Product: {FindProduct(A, B)}");

            Console.WriteLine();
            Console.WriteLine("----- TEST -----");

            float sum = 0;
            for (int i = 0; i < B.GetLength(0); i++)
            {
                if (A[i] % 2 == 0)
                {
                    sum += A[i];
                }
            }
            Console.WriteLine($"Sum of A (eaven numbers): {sum}");

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (j % 2 == 0)
                    {
                        sum += B[i, j];
                    }
                }
            }
            Console.WriteLine($"Sum of B (non eaven columns): {sum}");
        }
        static double FindProduct(int[] A, float[,] B)
        {
            double product = 1;

            for (int i = 0; i < A.GetLength(0); i++)
            {
                product *= A[i];
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    product *= B[i, j];
                }
            }
            return product;
        }
        static float FindSum(int[] A, float[,] B)
        {
            float sum = 0;

            for (int i = 0; i < A.GetLength(0); i++)
            {
                sum += A[i];
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    sum += B[i, j];
                }
            }
            return sum;
        }
        static float FindMin(int[] A, float[,] B)
        {
            float min = int.MaxValue;

            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (A[i] < min)
                {
                    min = A[i];
                }
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (B[i, j] < min)
                    {
                        min = B[i, j];
                    }
                }
            }
            return min;
        }
        static float FindMax(int[] A, float[,] B)
        {
            float max = int.MinValue;

            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (A[i] > max)
                {
                    max = A[i + 1];
                }
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (B[i, j] > max)
                    {
                        max = B[i, j];
                    }
                }
            }
            return max;
        }
        #endregion

        #region Task 2
        static void Task2()
        {
            Random rand = new Random();

            int[] array = new int[5];

            for (int i = 0; i < 5; i++)
            {
                array[i] = rand.Next(33);
                Console.WriteLine(array[i]);
            }

            Console.WriteLine("Enter numbers: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine($"Numbers less than {number}: ");

            bool find = false;
            for (int i = 0; i < 5; i++)
            {
                if (array[i] < number)
                {
                    Console.WriteLine(array[i]);
                    find = true;
                }
            }
            if (find == false)
            {
                Console.WriteLine("None");
            }
        }
        #endregion

        #region Task 1
        static void Task1()
        {
            Console.WriteLine("Enter 5 numbers: ");

            int[] array = new int[5];

            for (int i = 0; i < 5; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Eaven numbers: {Eaven(array)}");
            Console.WriteLine($"No eaven numbers: {NonEaven(array)}");
            Console.WriteLine($"Unique numbers: {UniqueElements(array)}");
        }
        static int Eaven(int[] array)
        {
            int res = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    res++;
                }
            }
            return res;
        }
        static int NonEaven(int[] array)
        {
            int res = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 1)
                {
                    res++;
                }
            }
            return res;
        }
        static int UniqueElements(int[] array)
        {
            int res = 0;
            bool unique;

            for (int i = 0; i < array.Length; i++)
            {
                unique = true;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        unique = false;
                    }
                }
                if (unique == true)
                {
                    res++;
                }
            }
            return res - 1;
        }
        #endregion
    }
}