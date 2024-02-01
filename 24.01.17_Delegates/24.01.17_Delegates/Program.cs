using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _24._01._17_Delegates
{
    internal class Program
    {
        public delegate double CalculationOperation(object[] array);
        public delegate void ModificationOperation(ref object[] array);

        public class ArrayWork
        {
            void Swap(ref object[] array, int index1, int index2)
            {
                object temp = array[index1];
                array[index1] = array[index2];
                array[index2] = temp;
            }
            bool IsPrime(double number)
            {
                try
                {
                    if (number <= 1 || number % 1 != 0)
                        return false;

                    int intNumber = (int)number;

                    for (int i = 2; i <= Math.Sqrt(intNumber); i++)
                    {
                        if (intNumber % i == 0)
                            return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public static void Show(object[] array)
            {
                Console.WriteLine("Array: ");

                foreach (var element in array)
                {
                    Console.Write($"[{element}] ");
                }

                Console.WriteLine();
            }

            public double NegativeElements(object[] array)
            {
                return array.Count(x => (double)x < 0);
            }
            public double PrimeNumbers(object[] array)
            {
                return array.Count(x => IsPrime((double)x));
            }
            public double SumElements(object[] array)
            {
                return array.Sum(x => (double)x);
            }

            public void ChangeNegativeToZero(ref object[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if ((double)array[i] < 0) array[i] = 0;
                }
            }
            public void Sort(ref object[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        if (IsPrime((double)array[j]) && !IsPrime((double)array[j + i])) { Swap(ref array, j, j + 1); }
                        else if (IsPrime((double)array[j]) == IsPrime((double)array[j + 1]))
                        {
                            if (Convert.ToDouble(array[j]) > Convert.ToDouble(array[j + 1])) { Swap(ref array, j, j + 1); }
                        }
                    }
                }
            }
        }
        static public class Menu
        {
            static public int StartMenu()
            {
                try
                {
                    Console.WriteLine("|=|=|=|   MENU   |=|=|=|");
                    Console.WriteLine("[0] - Exit");
                    Console.WriteLine("[1] - Calculate");
                    Console.WriteLine("[2] - Change");
                    Console.WriteLine();

                    Console.Write("(/^.^)/~  "); int res = int.Parse(Console.ReadLine());
                    return res;
                }
                catch (Exception ex) { throw ex; }
            }
            static public int CalculateMenu()
            {
                Console.WriteLine("|=|=|=|   CALCULATE MENU   |=|=|=|");
                Console.WriteLine("[0] - Exit");
                Console.WriteLine("[1] - Calculate the number of negative elements");
                Console.WriteLine("[2] - Determine the sum of all elements");
                Console.WriteLine("[3] - Calculate the number of primes");
                Console.WriteLine();

                Console.Write("(/^.^)/~  "); int res = int.Parse(Console.ReadLine());
                return res;
            }
            static public int ChangeMenu()
            {
                Console.WriteLine("|=|=|=|   CHANGE MENU   |=|=|=|");
                Console.WriteLine("[0] - Exit");
                Console.WriteLine("[1] - Change all negative elements to 0");
                Console.WriteLine("[2] - Sort the array");
                Console.WriteLine("[3] - Move all even elements to the beginning, respectively, odd elements will be at the end");
                Console.WriteLine();

                Console.Write("(/^.^)/~  "); int res = int.Parse(Console.ReadLine());
                return res;
            }
        }
        static void Main(string[] args)
        {

            /*                
                    Написати програму для виконання операцій з одновимірним масивом за допомогою делегатів.                
                
                    Користувачу надається наступне меню для вибору типа операції з масивом:                    
                        1. обчислення значення                    
                        2. зміна масиву
                    
                    Якщо користувач вибрав 1-й тип, вивести підменю вибору операції:
                            1. Обчислити кількість негативних елементів
                            2. Визначити суму всіх елементів
                            3. *Обрахувати кількість простих чисел

                    Якщо користувач вибрав 2-й тип, вивести підменю вибору операції:
                            1. Змінити всі негативні елементи на 0
                            2. Відсортувати масив
                            3. *Перемістити всі парні елементи на початку, відповідно не парні будуть в кінці.
                    
                    Створити вказані вище методи та реалізувати вибір користувачем операції на виконання 
                    без використання конструкцій if, switch та ?:(тернарного) оператора.
                                
                    Методи першого типу повинні повертати результат обчислення, в той час методи другого типу – void.
                    Реалізувати валідацію вибраного номера операції. 
            */


            ArrayWork aw = new ArrayWork();
            int[] array = { -2, 5, 8, -3, 0, 7, 10, -1 };

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int randomValue = rand.Next(1, 20);
                array.Append(randomValue);
            }

            CalculationOperation co_delegate = aw.NegativeElements;
            co_delegate += aw.PrimeNumbers;
            co_delegate += aw.SumElements;

            ModificationOperation mo_delegate = aw.ChangeNegativeToZero;
            mo_delegate = aw.Sort;
            
        }
    }
}
