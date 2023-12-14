using System.Runtime.InteropServices;

namespace _23._12._13_Array_Enum
{
    internal class Program
    {
        static void Main(string[] args)
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
            Console.WriteLine("----- RESULTS -----");

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
                for(int j = 0; j < B.GetLength(1); j++)
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
            float min = 0;

            for (int i = 0; i < A.GetUpperBound(0); i++)
            {
                if (A[i] < A[i + 1])
                {
                    min = A[i];
                }
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetUpperBound(1); j++)
                {
                    if (B[i, j] < B[i, j + 1])
                    {
                        if (min > B[i, j])
                        {
                            min = B[i, j];
                        }
                    }
                }
            }
            return min;
        }
        static float FindMax(int[] A, float[,] B)
        {
            float max = 0;

            for (int i = 0; i < A.GetUpperBound(0); i++)
            {
                if (A[i + 1] > A[i])
                {
                    max = A[i + 1];
                }
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetUpperBound(1); j++)
                {
                    if (B[i, j + 1] > B[i, j])
                    {
                        if (max < B[i, j + 1])
                        {
                            max = B[i, j + 1];
                        }
                    }
                }
            }
            return max;
        }

        #region Task 2
        static void TaksNumberTwo()
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
        static void TaskNumberOne()
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