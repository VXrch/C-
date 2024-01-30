using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _24._01._12_Interfaces
{
    internal class Program
    {
        interface ISort
        {
            void SortAsc();
            void SortDesc();
            void SortByParam(bool isAsc);
        }
        interface IMath
        {
            int Max();
            int Min();
            float Avg();
            bool Search(int valueToSearch);
        }
        interface IOutput 
        {
            void Show();
            void Show(string info);
        }
        class Array : IOutput, IMath, ISort
        {
            List<int> _array;
            public Array() { _array = new List<int>(); }
            public Array(params int[] elements) { _array = new List<int>(elements); }

            void Swap(int index1, int index2)
            {
                int temp = _array[index1];
                _array[index1] = _array[index2];
                _array[index2] = temp;
            }

            public void Fill()
            {
                Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int randomValue = rand.Next(1, 20);
                    _array.Add(randomValue);
                }
            }

            public void Show()
            {
                Console.WriteLine("Array: ");

                foreach (var element in _array)
                {
                    Console.Write($"[{element}] ");
                }

                Console.WriteLine();
            }
            public void Show(string info)
            {
                Console.WriteLine($"|:|  {info}  |:|");

                foreach (var element in _array)
                {
                    Console.Write($"[{element}] ");
                }

                Console.WriteLine();
            }

            public int Max()
            {
                // return _array.Max();
                int max = int.MinValue;
                foreach (var element in _array)
                {
                    if (element > max) { max = element; }
                }
                return max;
            }
            public int Min()
            {
                //return _array.Min();
                int min = int.MaxValue;
                foreach (var element in _array)
                {
                    if (element < min) { min = element; }
                }
                return min;
            }

            public float Avg()
            {
                // return (float)_array.Average();
                float avrg = 0;
                foreach (var element in _array)
                {
                    avrg += element;
                }
                return avrg / _array.Count;
            }
            public bool Search(int valueToSearch)
            {
                // return _array.Contains(valueToSearch);
                foreach (var element in _array)
                {
                    if (element == valueToSearch) { return true; }
                }
                return false;
            }

            public void SortAsc()
            {
                //_array.Sort();
                                
                for (int i = 0; i < _array.Count; i++)
                {
                    for (int j = 0; j < _array.Count - 1; j++)
                    {
                        if (_array[j] > _array[j + 1]) { Swap(j, j + 1); }
                    }
                }
            }
            public void SortDesc()
            {
                //_array.Sort();
                //_array.Reverse();

                for (int i = 0; i < _array.Count; i++)
                {
                    for (int j = 0; j < _array.Count - 1; j++)
                    {
                        if (_array[j] < _array[j + 1]) { Swap(j, j + 1); }
                    }
                }
            }
            public void SortByParam(bool isAsc)
            {
                if (isAsc) { SortAsc(); }
                else { SortDesc(); }
            }
        }

        static void Main(string[] args)
        {
            bool first = true;
            bool first2 = true;

            string line = "Info";
            int search = 0;

            Array array = new Array();
            array.Fill();

            while (true)
            {
                try
                {
                    Console.Clear();
                    /*
                        Створіть інтерфейс IOutput. У ньому мають бути два
                            методи:
                                ■ void Show() — відображає інформацію;
                                ■ void Show(string info) — відображає інформацію та інформаційне повідомлення, 
                                                           зазначене у параметрі info.

                        Створіть клас Array (масив цілого типу) із необхідними методами. 
                        Цей клас має імплементувати інтерфейс IOutput.
                            ■ Метод Show() — відображає на екран елементи масиву.
                            ■ Метод Show(string info) — відображає на екрані елементи масиву та 
                                                        інформаційне повідомлення, зазначене у параметрі info.
                        Напишіть код для тестування отриманої функціональності.
                    */                                     

                    Console.WriteLine("=====   Show()   =====");
                    array.Show();
                    Console.WriteLine();
                    
                    if (first) { Console.WriteLine("Enter your info: "); line = Console.ReadLine(); Console.WriteLine(); first = false; }
                    
                    Console.WriteLine("=====   Show(string info)   =====");
                    array.Show(line);
                    Console.WriteLine();

                    /*
                        Створіть інтерфейс IMath. 
                        У ньому мають бути чотири методи:
                            ■ int Max() — повертає максимум;
                            ■ int Min() — повертає мінімум;
                            ■ float Avg() — повертає середньоарифметичне;
                            ■ bool Search(int valueToSearch) — шукає valueSearch всередині контейнера даних. 
                                                               Повертає true, якщо значення знайдено. 
                                                               Повертає false, якщо значення не знайдено.

                        Клас, створений у першому завданні Array, має імплементувати інтерфейс IMath.
                            Метод Max — повертає максимум серед елементів масиву.
                            Метод Min — повертає мінімум серед елементів масиву.
                            Метод Avg — повертає середньоарифметичне серед елементів масиву.
                            Метод Search — шукає значення всередині масиву.
                                           Повертає true, якщо значення знайдено. 
                                           Повертає false, якщо значення не знайдено.
                            Напишіть код для тестування отриманої функціональності             
                    */

                    Console.WriteLine("=====   Max()   =====");
                    Console.WriteLine(array.Max());
                    Console.WriteLine();

                    Console.WriteLine("=====   Min()   =====");
                    Console.WriteLine(array.Min());
                    Console.WriteLine();

                    Console.WriteLine("=====   Avg()   =====");
                    Console.WriteLine(array.Avg());
                    Console.WriteLine();
                                        
                    if (first2) { Console.WriteLine("Enter your number (int): "); search = int.Parse(Console.ReadLine()); Console.WriteLine(); first2 = false; }
                    
                    Console.WriteLine("=====   Search(int valueToSearch)   =====");
                    Console.WriteLine(array.Search(search));
                    Console.WriteLine();

                    /*
                        Створіть інтерфейс ISort.У ньому мають бути три методи:
                            ■ void SortAsc() — сортування за зростанням;
                            ■ void SortDesc() — сортування за зменшенням;
                            ■ void SortByParam(bool isAsc) — сортування залежно від переданого параметра.
                                                             Якщо isAsc дорівнює true, сортуємо за зростанням.
                                                             Якщо isAsc дорівнює false, сортуємо за зменшенням.
                            
                        Клас, створений у першому завданні Array, має імплементувати інтерфейс ISort.
                            Метод SortAsc — сортує масив за зростанням.
                            Метод SortDesc — сортує масив за спаданням.
                            Спосіб SortByParam — сортує масив залежно від переданого параметра. 
                                                 Якщо isAsc дорівнює true, сортуємо за зростанням.
                                                 Якщо isAsc дорівнює false, сортуємо за зменшенням.

                        Напишіть код для тестування отриманої функціональності.
                    */

                    array.SortAsc();
                    Console.WriteLine("=====   SortAsc()   =====");
                    array.Show();
                    Console.WriteLine();

                    array.SortDesc();
                    Console.WriteLine("=====   SortDesc()   =====");
                    array.Show();
                    Console.WriteLine();

                    array.SortByParam(true);
                    Console.WriteLine("=====   SortByParam(true)   =====");
                    array.Show();
                    Console.WriteLine();

                    array.SortByParam(false);
                    Console.WriteLine("=====   SortByParam(false)   =====");
                    array.Show();
                    Console.WriteLine();

                    break;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
    }
}