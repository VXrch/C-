using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _23._12._15_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;

            Console.WriteLine("Enter task number (1-7 or 0 to print all)");
            choice = int.Parse(Console.ReadLine());

            Console.WriteLine(); Console.WriteLine();

            switch (choice)
            {
                case 0:
                    WriteLine("1"); Task1(); Console.WriteLine();
                    WriteLine("2"); Task2(); Console.WriteLine();
                    WriteLine("3"); Task3(); Console.WriteLine();
                    WriteLine("4"); Task4(); Console.WriteLine();
                    WriteLine("5"); Task5(); Console.WriteLine();
                    WriteLine("6"); Task6(); Console.WriteLine();
                    WriteLine("7"); Task7(); Console.WriteLine();
                    break;
                case 1: WriteLine("1"); Task1(); break;
                case 2: WriteLine("2"); Task2(); break;
                case 3: WriteLine("3"); Task3(); break;
                case 4: WriteLine("4"); Task4(); break;
                case 5: WriteLine("5"); Task5(); break;
                case 6: WriteLine("6"); Task6(); break;
                case 7: WriteLine("7"); Task7(); break;
                default: Console.WriteLine("Wrong number!"); break;
            }
            Console.WriteLine(); Console.WriteLine();
        }
        static void WriteLine(string number)
        {
            Console.WriteLine($" ================| TASK {number} |================");
        }

        static void Task1()
        {
            /*Task 1:
                Вставити в задану позицію рядка інший рядок.*/

            Console.WriteLine("Enter original line: ");
            string original_str = Console.ReadLine();

            Console.WriteLine("Enter line to insert: ");
            string to_insert_str = Console.ReadLine();

            Console.WriteLine("Enter line to insert: ");
            int position = int.Parse(Console.ReadLine());

            if (position < 0 || position > original_str.Length)
            {
                Console.WriteLine("Invalid position!");
                return;
            }

            string result_str = original_str.Insert(position, to_insert_str);

            Console.WriteLine($"Result :  {result_str}");
        }
        static void Task2()
        {
            /*Task 2:
                Визначити, чи є рядок паліндромом. 
                Паліндром – це число, слово або фраза, яка однаково 
                читається в обох напрямках.*/

            Console.WriteLine("Enter line: ");
            string line = Console.ReadLine();

            bool the_same = true;
            for (int i = 0; i < line.Length; i++)
            {
                for (int j = line.Length - 1; j > i; j--)
                {
                    if (line[i] != line[j])
                    {
                        the_same = false; break;
                    }
                }
                if (!the_same) { break; }
            }

            Console.WriteLine($"Line is polindrom: {the_same}");
        }
        static void Task3()
        {
            /*Task 3:
                Дано текст. Визначте відсоткове відношення малих і великих літер 
                до загальної кількості символів в ньому.*/

            Console.WriteLine("Enter line: ");
            string line = Console.ReadLine();

            int low = 0, up = 0;
            char this_char;

            for (int i = 0; i < line.Length; i++)
            {
                this_char = line[i];

                if (char.IsLower(this_char))
                {
                    low++;
                }
                else if (char.IsUpper(this_char))
                {
                    up++;
                }
            }
            double lowercasePercent = (double)low / line.Length * 100;
            double uppercasePercent = (double)up / line.Length * 100;

            Console.WriteLine($"Percentage of lowercase letters: {lowercasePercent}%");
            Console.WriteLine($"Percentage of uppercase letters: {uppercasePercent}%");
        }
        static void Task4()
        {
            /*Task 4:
                Дано масив слів. Замінити останні три символи слів, 
                що мають обрану довжину, на символ "$".*/

            Console.WriteLine("Enter words (separated by space): ");
            string[] words = Console.ReadLine().Split(' ');

            Console.WriteLine("Enter the length: ");
            int need_length = int.Parse(Console.ReadLine());

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == need_length)
                {
                    if (words[i].Length >= 3)
                    {
                        words[i] = words[i].Substring(0, words[i].Length - 3) + "$";
                    }
                    else
                    {
                        words[i] = "$";
                    }
                }
            }

            Console.WriteLine("Result: ");
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i] + " ");
            }
        }
        static void Task5()
        {
            /*Task 5:
                Знайти слово, що стоїть в тексті під певним номером, і вивести його першу букву.*/

            Console.WriteLine("Enter line: ");
            string line = Console.ReadLine();

            Console.WriteLine("Enter position: ");
            int position = int.Parse(Console.ReadLine());

            string[] words = line.Split(' ');

            if (position >= 1 && position <= words.Length)
            {
                string word = words[position - 1];

                if (!string.IsNullOrEmpty(word))
                {
                    char firstLetter = word[0];
                    Console.WriteLine($"The first letter of the word at position {position} is: {firstLetter}");
                }
                else
                {
                    Console.WriteLine($"The word at position {position} is empty");
                }
            }
            else
            {
                Console.WriteLine($"No word found at position {position}");
            }
        }
        static void Task6()
        {
            /*Task 6:
                Дано рядок слів, розділених пробілами. Між словами може бути кілька пробілів, 
                на початку і вкінці рядка також можуть бути пробіли. Ви повинні змінити рядок так, 
                щоб на початку і вкінці пробілів не було, а слова були розділені поодиноким 
                символом "*" (зірочка).*/

            Console.WriteLine("Enter line (separated by space): ");
            string line = Console.ReadLine();

            string result = line.Trim();

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == ' ')
                {
                    result = SetStarByIndex(result, i);
                }
            }

            Console.WriteLine($"Result: [{result}]");
        }
        static string SetStarByIndex(string line, int index)
        {
            StringBuilder sb = new StringBuilder(line);
            sb[index] = '*';

            return sb.ToString();
        }
        static void Task7()
        {
            /*Task 7:
                Користувач вводить слова, поки не буде введено слово з символом крапки вкінці. 
                Сформувати з введених слів рядок, розділивши їх комою з пробілом. 
                Застосувати StringBuilder.*/


            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine("Enter words, and enter[.] to stop: ");

            char word;
            int wordsCounter = 0;

            do
            {
                word = Console.ReadKey().KeyChar;

                if (word == ' ')
                {
                    stringBuilder.Append(", ");
                }
                else
                {
                    stringBuilder.Append(word);
                }

            } while (word != '.');


            Console.WriteLine("\nResult: " + stringBuilder.ToString());
        }
    }
}
