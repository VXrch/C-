using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _23._12._18_Properties
{
    internal partial class Program
    {
        public partial class Freezer
        {
            readonly int _id;
            public int ID
            {
                get { return _id; }
            }

            string _model;
            public string Model
            {
                get { return _model; }
                set { _model = value; }
            }

            string _type;
            public string Type
            {
                get { return _type; }
                set { _type = value; }
            }

            string _manufacturer;
            public string Manufacturer
            {
                get { return _manufacturer; }
                set { _manufacturer = value; }
            }

            int _minTemperature;
            public int MinTemperature
            {
                get { return _minTemperature; }
                set { _minTemperature = value; }
            }

            DateTime _manufactureDate;
            public DateTime ManufactureDate
            {
                get { return _manufactureDate; }
                set
                {
                    if (DateTime.Now > value)
                    {
                        _manufactureDate = value;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect data! Manufacture date can't be in the future!");
                    }
                }
            }

            
            
            static bool _canFreez;
            static int _freezerID;
        }
        static void Main(string[] args)
        {
            /*
                Розробити клас «Freezer», який описує морозильну камеру з дотриманням наступних вимог:
                    1. Реалізувати не менше п'яти закритих полів (різних типів), що представляють
                        основні характеристики класу.
                    2. Створити не менше трьох методів управління класом і методи доступу до
                        його закритих полів.
                    3. Створити метод, в який передаються аргументи за посиланням.
                    4. Створити не менше двох статичних полів (різних типів), що представляють
                        спільні характеристики об'єктів даного класу.
                    5. Створити статичний конструктор для ініціалізації статичних полів.
                    6. Обов'язковою вимогою є реалізація декількох перевантажених
                        конструкторів, аргументи яких визначаються студентом, виходячи із
                        специфіки реалізованого класу і так само реалізація конструктора за
                        замовчуванням. По можливості застосувати делегування конструкторів.
                    7. Перевизначити алгоритм методу ToString(), який буде повертати інформацію
                        про об’єкт у вигляді рядка.
                    8. Перенести описи всіх методів в інший файл, використовуючи partial class.
                    9. Створити масив (не менше 5 елементів) об'єктів створеного класу та показати
                        інформацію по кожному.
            */

            int choice, workID = 0;

            List<Freezer> freezers_list = new List<Freezer>();
            Freezer first = new Freezer();

            first.Fill();
            freezers_list.Add(first);

            bool ext = false;
            while (!ext)
            {
                Console.WriteLine("Press any key to continue..."); Console.ReadKey(); Console.Clear();
                try
                {
                    PrintMenu();
                    Console.WriteLine("(\\@_@)\\"); choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: // Get model
                            Console.WriteLine($"Model: {freezers_list[workID].Model}");
                            break;
                        case 2: // Get type
                            Console.WriteLine($"Type: {freezers_list[workID].Type}");
                            break;
                        case 3: // Get manufacturer
                            Console.WriteLine($"Manufacturer: {freezers_list[workID].Manufacturer}");
                            break;
                        case 4: //  Get min temperature
                            Console.WriteLine($"Min temperature: {freezers_list[workID].MinTemperature}");
                            break;
                        case 5: //  Get manufacture date
                            Console.WriteLine($"Manufacture date: {freezers_list[workID].ManufactureDate}");
                            break;
                        case 6: //  Get ID
                            Console.WriteLine($"Model: {freezers_list[workID].ID}");
                            break;
                        case 7: //  Set model
                            Console.WriteLine($"Set new model: "); freezers_list[workID].Model = Console.ReadLine();
                            break;
                        case 8: //  Set type
                            Console.WriteLine($"Set new type: "); freezers_list[workID].Type = Console.ReadLine();
                            break;
                        case 9: //  Set manufacturer
                            Console.WriteLine($"Set new manufacturer: "); freezers_list[workID].Manufacturer = Console.ReadLine();
                            break;
                        case 10: // Set min temperature
                            Console.WriteLine($"Set new min temperature: "); freezers_list[workID].MinTemperature = int.Parse(Console.ReadLine());
                            break;
                        case 11: // Set manufacture date
                            Console.WriteLine($"Set new manufacture date: "); freezers_list[workID].ManufactureDate = MadeNewDate();
                            break;
                        case 12: // Print one freezer
                            Console.WriteLine(freezers_list[workID]);
                            break;
                        case 13: // Add new freezer
                            Freezer new_freezer = new Freezer();
                            new_freezer.Fill();
                            freezers_list.Add(new_freezer);
                            break;
                        case 14: // Print all freezers
                            foreach (var item in freezers_list)
                            {
                                Console.WriteLine(item); Console.WriteLine();
                            }
                            break;
                        case 15:
                            if (freezers_list.Count > 1)
                            {
                                ChooseFreezer(ref workID, ref freezers_list);
                            }
                            else
                            {
                                Console.WriteLine("You have only 1 freezer!");
                            }
                            break;
                        case 0: ext = true; break;
                        default: Console.WriteLine("Wrong number!"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error  ~~~>  {ex}");
                }
            }
        }
        static void PrintMenu()
        {
            Console.WriteLine("  ~  | MENU |  ~  ");
            Console.WriteLine();
            Console.WriteLine("[0] - Exit");
            Console.WriteLine();
            Console.WriteLine("[1] - Get model");
            Console.WriteLine("[2] - Get type");
            Console.WriteLine("[3] - Get manufacturer");
            Console.WriteLine("[4] - Get min temperature");
            Console.WriteLine("[5] - Get manufacture date");
            Console.WriteLine("[6] - Get ID");
            Console.WriteLine();
            Console.WriteLine("[7] - Set model");
            Console.WriteLine("[8] - Set type");
            Console.WriteLine("[9] - Set manufacturer");
            Console.WriteLine("10] - Set min temperature");
            Console.WriteLine("[11] - Set manufacture date");
            Console.WriteLine();
            Console.WriteLine("[12] - Print one freezer");
            Console.WriteLine();
            Console.WriteLine("[13] - Add new freezer");
            Console.WriteLine("[14] - Print all freezers");
            Console.WriteLine();
            Console.WriteLine("[15] - Choose another freezer");
            Console.WriteLine();
        }
        static bool ChooseFreezer(ref int workID, ref List<Freezer> list)
        {
            try
            {
                Console.WriteLine("Do you want to choose another freezer?\n[1] - yes\n[else] - no\n(/**)/ ");
                string go = Console.ReadLine();

                if (go == "1")
                {
                    while (true)
                    {
                        Console.WriteLine("Choose freezer (ID) to work with: ");
                        foreach (Freezer freezer in list)
                        {
                            Console.WriteLine(freezer);
                        }

                        Console.WriteLine("(-^.^)-  "); int choice = int.Parse(Console.ReadLine());
                        if (choice >= 0 && choice < list.Count)
                        {
                            workID = choice;
                            return true;
                        }
                        Console.WriteLine("Wrong id! Try again!");
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static DateTime MadeNewDate()
        {
            try
            {
                Console.Write("Year: "); int year = int.Parse(Console.ReadLine());
                Console.Write("Month: "); int month = int.Parse(Console.ReadLine());
                Console.Write("Day: "); int day = int.Parse(Console.ReadLine());

                DateTime date = new DateTime(year, month, day);
                return date;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
