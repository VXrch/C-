using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _24._01._22_Extensions
{
    static class StringExtensions
    {
        public static bool IsPalindrome(this string line)
        {
            bool the_same = true;

            for (int i = 0; i < line.Length; i++)
            {
                for (int j = line.Length; j > i; j--)
                {
                    if (line[i] != line[j])
                    {
                        the_same = false; break;
                    }
                }
                if (!the_same) { break; }
            }

            return the_same;
        }
    }
    internal class Program
    {
        

        static void Main(string[] args)
        {
            /*            
            Завдання 1:
                Створити метод розширення для класу String, який буде перевіряти чи рядок є паліндром.
            Завдання 2:
                Створити метод розширення для класу String, який буде шифрувати рядок використовуючи ключ (передається в параметри). Шифрування відбувається шляхом здвигу символа по в таблиці ASCII.
                Привіт – 3
                Сткдкф
            Завдання 3:
                Створити метод розширення для класу Array, який буде знаходити кількість однакових елементів в масиві.
            */

            try
            {
                int choice;

                Console.WriteLine("Enter task number (1-3 or 0 to print all)");
                choice = int.Parse(Console.ReadLine());

                Console.WriteLine(); Console.WriteLine();

                switch (choice)
                {
                    case 0:
                        WriteLine("1"); Task1(); Console.WriteLine();
                        WriteLine("2"); Task2(); Console.WriteLine();
                        WriteLine("3"); Task3(); Console.WriteLine();
                        break;
                    case 1: WriteLine("1"); Task1(); break;
                    case 2: WriteLine("2"); Task2(); break;
                    case 3: WriteLine("3"); Task3(); break;
                    default: Console.WriteLine("Wrong number!"); break;
                }
                Console.WriteLine(); Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }            
        }
        static void WriteLine(string number)
        {
            Console.WriteLine($" ================| TASK {number} |================");
        }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void Task1()
        {
            /*  
                Завдання 1:
                    Створити метод розширення для класу String, який буде перевіряти чи рядок є паліндром.
            */

            Console.WriteLine("Enter polindrom line: "); 
            string line = Console.ReadLine();

            bool polindrome = line.IsPalindrome();
            Console.WriteLine($"Is polindrome: {polindrome}");
        }
        static void Task2()
        {
            /*
                Завдання 2:
                    Створити метод розширення для класу String, який буде шифрувати рядок використовуючи ключ (передається в параметри). 
                    Шифрування відбувається шляхом здвигу символа по в таблиці ASCII.
                        Привіт – 3
                        Сткдкф
            */

            Console.WriteLine("Enter line: ");
            string line = Console.ReadLine();

            Console.WriteLine("Enter key: ");
            int key = int.Parse(Console.ReadLine());

            StringBuilder encryptedText = new StringBuilder();

            foreach (char character in line)
            {
                if (char.IsLetter(character))
                {
                    char encryptedChar = (char)(character + key);

                    if (char.IsLower(character) && encryptedChar > 'z') { encryptedChar = (char)(encryptedChar - 26); }
                    else if (char.IsUpper(character) && encryptedChar > 'Z') { encryptedChar = (char)(encryptedChar - 26); }

                    encryptedText.Append(encryptedChar);
                }
                else { encryptedText.Append(character); }
            }
        }
        static void Task3()
        {
            /*
                Завдання 3:
                    Створити метод розширення для класу Array, 
                    який буде знаходити кількість однакових елементів в масиві.
            */

        }
    }
}
