using System;
using System.Linq;

namespace _24._01._17_Delegates
{
    internal class Program
    {
        public delegate int CalculationOperation();
        public delegate void ModificationOperation();
        public delegate void MenuDelegate();

        public class ArrayWork
        {
            int[] array;
            public ArrayWork()
            {
                array = new int[10] { -100, 23, 98, -4, 54, 15, 7, 0, 7, 34 };
            }

            void Swap(int index1, int index2)
            {
                int temp = array[index1];
                array[index1] = array[index2];
                array[index2] = temp;
            }
            bool IsPrime(int number)
            {
                try
                {
                    if (number <= 1)
                        return false;

                    for (int i = 2; i <= Math.Sqrt(number); i++)
                    {
                        if (number % i == 0)
                            return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public void Show()
            {
                Console.WriteLine("Array: ");

                foreach (var element in array)
                {
                    Console.Write($"[{element}] ");
                }

                Console.WriteLine();
            }

            public int NegativeElements()
            {
                return array.Count(x => x < 0);
            }
            public int PrimeNumbers()
            {
                int count = 0;
                foreach (var item in array)
                {
                    if (IsPrime(item)) count++;
                }
                return count;
            }
            public int SumElements()
            {
                int sum = 0;
                foreach (var item in array)
                {
                    if (IsPrime(item)) sum += item;
                }
                return sum;
            }

            public void ChangeNegativeToZero()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < 0) array[i] = 0;
                }
            }
            public void Sort()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        if (IsPrime(array[j]) && !IsPrime(array[j + i])) { Swap(j, j + 1); }
                        else if (IsPrime(array[j]) == IsPrime(array[j + 1]))
                        {
                            if (array[j] > array[j + 1]) { Swap(j, j + 1); }
                        }
                    }
                }
            }
        }
        public class Menu
        {
            ArrayWork arrayWork = new ArrayWork();
            public void StartMenu()
            {
                bool ext = false;

                while (!ext) 
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine();
                        arrayWork.Show();
                        Console.WriteLine();

                        Console.WriteLine("|=|=|=|   MENU   |=|=|=|");
                        Console.WriteLine("[0] - Exit");
                        Console.WriteLine("[1] - Calculate");
                        Console.WriteLine("[2] - Change");
                        Console.WriteLine();

                        Console.Write("(/^.^)/~  "); int res = int.Parse(Console.ReadLine());

                        MenuDelegate[] md = new MenuDelegate[]
                        {
                            delegate(){ ext = true; }, CalculateMenu, ChangeMenu,
                        };
                        md[res]?.Invoke();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                }                
            }
            public void CalculateMenu()
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine();
                    arrayWork.Show();
                    Console.WriteLine();

                    Console.WriteLine("|=|=|=|   CALCULATE MENU   |=|=|=|");
                    Console.WriteLine("[0] - Exit");
                    Console.WriteLine("[1] - Calculate the number of negative elements");
                    Console.WriteLine("[2] - Determine the sum of all elements");
                    Console.WriteLine("[3] - Calculate the number of primes");
                    Console.WriteLine();

                    CalculationOperation[] co_delegates = new CalculationOperation[]
                    {
                    delegate(){ return 0; }, arrayWork.PrimeNumbers, arrayWork.SumElements, arrayWork.NegativeElements
                    };

                    Console.Write("(/^.^)/~  "); int res = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Result: [ {co_delegates[res]?.Invoke()} ]");
                    Console.ReadKey();
                }
                catch (Exception ex) { throw ex; }
            }
            public void ChangeMenu()
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine();
                    arrayWork.Show();
                    Console.WriteLine();

                    Console.WriteLine("|=|=|=|   CHANGE MENU   |=|=|=|");
                    Console.WriteLine("[0] - Exit");
                    Console.WriteLine("[1] - Change all negative elements to 0");
                    Console.WriteLine("[2] - Sort the array");
                    Console.WriteLine();

                    ModificationOperation[] mo_delegate = new ModificationOperation[]
                    {
                        delegate(){ return; }, arrayWork.ChangeNegativeToZero, arrayWork.Sort,
                    };

                    Console.Write("(/^.^)/~  "); int res = int.Parse(Console.ReadLine());
                    mo_delegate[res]?.Invoke();
                    Console.WriteLine("Completed!");
                    Console.ReadKey();
                }
                catch (Exception ex) { throw ex; }
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

            Menu menu = new Menu();
            menu.StartMenu();
        }
    }
}
