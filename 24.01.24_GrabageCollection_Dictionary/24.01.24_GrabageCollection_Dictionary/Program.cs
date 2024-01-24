using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _24._01._24_GrabageCollection_Dictionary
{
    internal class Program
    {
        class PhoneBook
        {
            //          <phone, name>
            Dictionary<string, string> people;
            List<string> tempcouple;

            public PhoneBook() { people = new Dictionary<string, string>(); tempcouple = new List<string>(); }

            bool IsExist(string phone)
            {
                if (!people.ContainsKey(phone))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("This person is alredy exist!");
                    return true;
                }
            }
            bool EnterInfo(ref string phone, ref string name)
            {
                Console.WriteLine("Enter new person name: "); string Tname = Console.ReadLine();
                Console.WriteLine("Enter new person phone number (+XXX XXX XXX XXXX): "); string Tphone = Console.ReadLine();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
                {
                    throw new ArgumentNullException();
                }
                if (phone.StartsWith("+"))
                {
                    phone = Tphone; name = Tname;
                    return true;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            bool EnterInfoPhone(ref string phone)
            {
                Console.WriteLine("Enter new person phone number (+XXX XXX XXX XXXX): "); string Tphone = Console.ReadLine();

                if (string.IsNullOrEmpty(phone))
                {
                    throw new ArgumentNullException();
                }
                if (phone.StartsWith("+"))
                {
                    phone = Tphone;
                    return true;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            bool EnterInfoName(ref List<string> name)
            {
                Console.WriteLine("Enter new person name: "); string Tname = Console.ReadLine();

                if (string.IsNullOrEmpty(Tname))
                {
                    throw new ArgumentNullException();
                }
                foreach (KeyValuePair<string, string> item in people)
                {
                    if (true)
                    {


                    }

                }
            }

            public void Add()
            {
                try
                {
                    string phone = "", name = "";

                    EnterInfo(ref phone, ref name);

                    if (!IsExist(phone))
                    {
                        people.Add(phone, name);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public void Add(string phone, string name)
            {
                try
                {
                    if (!IsExist(phone))
                    {
                        people.Add(phone, name);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public string FindByKey()
            {
                try
                {
                    string phone = "", name = "";

                    EnterInfo(ref phone);

                    if (people.ContainsKey(phone))
                    {
                        if (people.ContainsValue(name))
                        {

                        }

                    }


                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public string FindByKey(string phone, string name)
            {

            }
        }
        static void Main(string[] args)
        {
            /*  Завдання 1:
                    Реалізувати клас PhoneBook на базі дженерік колекції 
                    Dictionary <TKey, TValue>, передбачити додавання, зміну, пошук та видалення записів.
            */





        }
    }
}
