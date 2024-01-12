using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _23._12._18_Properties
{
    internal partial class Program
    {
        public partial class Freezer
        {
            static Freezer()
            {
                _canFreez = true;
                _freezerID = 0;
            }
            public Freezer()
            {
                _model = "None";
                _type = "None";
                _manufacturer = "None";
                _minTemperature = 0;
                _manufactureDate = DateTime.MinValue;

                _id = _freezerID;

                _freezerID++;
            }

            public Freezer(string model) : this()
            {
                _model = model;
            }
            public Freezer(DateTime manufactureDate) : this()
            {
                _manufactureDate = manufactureDate;
            }
            public Freezer(int minTemperature)
            {
                _minTemperature = minTemperature;
            }
            public Freezer(string model, string type) : this()
            {
                _model = model;
                _type = type;
            }
            public Freezer(string model, string type, int minTemperature) : this()
            {
                _model = model;
                _type = type;
                _minTemperature = minTemperature;
            }
            public Freezer(string model, string type, int minTemperature, DateTime manufactureDate) : this()
            {
                _model = model;
                _type = type;
                _minTemperature = minTemperature;
                _manufactureDate = manufactureDate;
            }
            public Freezer(string model, string type, string manufacturer) : this()
            {
                _model = model;
                _type = type;
                _manufacturer = manufacturer;
            }
            public Freezer(string model, string type, string manufacturer, DateTime manufactureDate) : this()
            {
                _model = model;
                _type = type;
                _manufacturer = manufacturer;
                _manufactureDate = manufactureDate;
            }
            public Freezer(string model, string type, string manufacturer, int minTemperature) : this()
            {
                _model = model;
                _type = type;
                _manufacturer = manufacturer;
                _minTemperature = minTemperature;
            }
            public Freezer(string model, string type, string manufacturer, int minTemperature, DateTime manufactureDate)
            {
                _model = model;
                _type = type;
                _manufacturer = manufacturer;
                _minTemperature = minTemperature;
                _manufactureDate = manufactureDate;

                _id = _freezerID;

                _freezerID++;
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            public void Print()
            {
                Console.WriteLine($"Model: {_model}");
                Console.WriteLine($"Type: {_type}");
                Console.WriteLine($"Manufacturer: {_manufacturer}");
                Console.WriteLine($"Min temperature: {_minTemperature}");
                Console.WriteLine($"Manufacture year: {_manufactureDate.Year}");
            }
            public static void PrintInfo()
            {
                Console.WriteLine($"Can freez: {_canFreez}");
                Console.WriteLine($"Total counter: {_freezerID}");
            }

            public void SetNewManufactureDate()
            {
                try
                {
                    Console.WriteLine("Year: "); int year = int.Parse(Console.ReadLine());
                    Console.WriteLine("Month: "); int month = int.Parse(Console.ReadLine());
                    Console.WriteLine("Day: "); int day = int.Parse(Console.ReadLine());

                    DateTime date = new DateTime(year, month, day);
                    ManufactureDate = date;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Fill()
            {
                try
                {
                    Console.WriteLine($"Model: "); Model = Console.ReadLine();
                    Console.WriteLine($"Type: "); Type = Console.ReadLine();
                    Console.WriteLine($"Manufacturer: "); Manufacturer = Console.ReadLine();
                    Console.WriteLine($"Min temperature: "); MinTemperature = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Manufacture year: "); SetNewManufactureDate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex}");
                }
            }
            public void SetInfo(ref string model, ref string type, ref string manufacturer, ref int minTemperature, ref DateTime manufactureDate)
            {
                try
                {
                    Model = model;
                    Type = type;
                    Manufacturer = manufacturer;
                    MinTemperature = minTemperature;
                    ManufactureDate = manufactureDate;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex}");
                }
            }
            public override string ToString()
            {
                return $"Freezer: [model] -> {_model} | [type] -> {_type} | [manufacturer] -> {_manufacturer} | [Min temperature] -> {_minTemperature} | [Manufacture date] -> {_manufactureDate} | [Can freez] -> {_canFreez} | [Total freezers counter] -> {_freezerID}";
            }
        }
    }
}
