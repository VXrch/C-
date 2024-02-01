using System.Text.Json;

namespace _24._01._31_Attributes_Serialization
{
    internal class Program
    {
        [Serializable]
        public class Person
        {
            public Person() {  }
            public Person(int number) { _identNumber = number; }
            
            [NonSerialized]
            const string Planet = "Earth";

            public string Name { get; set; }
            public int Age { get; set; }

            public int _identNumber;            
            public override string ToString()
            {
                return $"Name : [{Name}] | Age: [{Age}] | Identification number : [{_identNumber}] | Planet : [{Planet}]";
            }
        }
        static void Main(string[] args)
        {
            /*            
            1. Реалізувати додаток з наступним функціоналом:
                a)Консольне меню
                b)В якості колекції для даних використати Словник (Dictionary<TKey, TValue>), який реалізує CRUD
                c) Значущими елементами словника є екземпляри класу User

            2. Класс User повинен містити наступні властивості:
                a) Id - int унікальні значення в діапазоні 1000 - 9999
                b) Login - string, лише друємі символи без спец сиволів
                c) Password - string, лише друємі символи без спец сиволів, довжина не менше 8ми сиволів,
                d) ConfirmPassword - string, лише друємі символи без спец сиволів, довжина не менше 8ми сиволів,
                e) E-mail - string, валідація згідно загальних правил стандарту
                f) CreditCard - валідація згідно загальних правил стандарту
                g)Phone - валідація згідно українського формату +38-0**-***-**-**

            3. Всі властивості містять відповідні атрибути валідації, з перевизначиними повідомленнями, 
                згідно яких модель після перевірки записується в словник . 
                Якщо якісь властивості не проходять валідацію - користувач змушений ввести їх повторно.     
            
            4. Після вибору відповідного пункту меню екземпляр словника серіалізується і зберігається у файл. (робиться резервна копія)                
            
            5. Після вибору відповідного пунктуц меню дані з файлу читаються і десеріалізуються переписуючи поточний екземпляр.
                
            Bonus 12: при десеріалізації даних вмісти 2ох словників порівнюються і користувачеві пропонується наступні дії:
                1. Переписати весь вміст
                2. Дописати в пам”ять лише ті дані Користувачів яких там не вистачає ( якщо такі є). 
                    Якщо користувач є в пам”яті в файлі, користувач може вибрати 
                    ячку версію даних прийняти а яку відкинути.
            */
/*
            List<Person> people = new List<Person>()
            {
                 new Person(1000){ Name = "Jack", Age = 25},
                 new Person(2000){ Name = "Bob", Age = 15},
                 new Person(3000){ Name = "Tom", Age = 45}
            };
            foreach (var item in people)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }*/

            try
            {
                //Serialize
                /*string fileName = "Persons.json";
                string jsonString = JsonSerializer.Serialize(people);*/
                //File.WriteAllText(fileName, jsonString);

                string fileName = "Persons.json";
                string jsonString;

                //Deserialize
                jsonString = File.ReadAllText(fileName);

                List<Person> list = JsonSerializer.Deserialize<List<Person>>(jsonString);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}