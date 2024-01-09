using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._12._22_Exceptions_Namespaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;

            Console.WriteLine("Enter task number (1-3 or 0 to print all)");
            choice = int.Parse(Console.ReadLine());

            Console.WriteLine(); Console.WriteLine();

            switch (choice)
            {
                case 0:
                    WriteLine("1"); Task1(); Console.WriteLine(); Console.Clear();
                    WriteLine("2"); Task2(); Console.WriteLine(); Console.Clear();
                    WriteLine("3"); Task3(); Console.WriteLine(); Console.Clear();
                    break;
                case 1: WriteLine("1"); Task1(); break;
                case 2: WriteLine("2"); Task2(); break;
                case 3: WriteLine("3"); Task3(); break;
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
            /*Завдання 1
                Користувач вводить до рядка з клавіатури набір сим-
                волів від 0-9. Необхідно перетворити рядок на число ціло-
                го типу. Передбачити випадок виходу за межі діапазону,
                який визначається типом int. Використовуйте механізм
                виключень.*/

            try
            {
                Console.Write("Enter line: ");
                string line = Console.ReadLine();

                int number = Convert.ToInt32(line);

                Console.WriteLine($"Your number: {number}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown exception: {ex.Message}");
            }
        }

        #region Task2

        class IncorrectCardLength : Exception
        {
            public override string Message
            {
                get
                {
                    return "Incorrect card length! The card can be 16 characters long!";
                }
            }
        }
        class IncorrectCVCLength : Exception
        {
            public override string Message
            {
                get
                {
                    return "Incorrect CVC code length! The CVC length must be 3 characters long!";
                }
            }
        }
        class IncorrectExpirationDate : Exception
        {
            public override string Message
            {
                get
                {
                    return "Incorrect expiration date! The expiration date must be in the future!";
                }
            }
        }
        class CreditCard
        {

            string _cardNumber;
            public string CardNumber
            { 
                get { return _cardNumber; } 
                set 
                {
                    string svalue = value.Trim();
                    if (svalue.Length == 16)
                    {
                        _cardNumber = svalue;
                    }
                    else
                    {
                        throw new IncorrectCardLength();
                    }
                } 
            }

            string _name;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value.ToString();
                }
            }

            int _cvc;
            public int CVC
            {
                get { return _cvc; }
                set
                {
                    if (value.ToString().Length == 3) 
                    { 
                        _cvc = value;
                    }
                    else
                    {
                        throw new IncorrectCVCLength();
                    }
                }
            }

            DateTime _expirationDate;
            public DateTime ExpirationDate
            {
                get { return _expirationDate; }
                set 
                {
                    if (DateTime.Now > value)
                    {
                        _expirationDate = value;
                    }
                    else
                    {
                        throw new IncorrectExpirationDate();
                    }
                }
            }

            public CreditCard()
            {
                _cardNumber = "0000000000000000";
                _name = "EMPTY";
                _cvc = 0;
                _expirationDate = DateTime.MinValue;
            }
        }

        static void Task2()
        {
            /*Завдання 2
                Створіть клас «Кредитна картка». Вам необхідно зберіга-
                ти інформацію про номер картки, ПІБ власника, CVC, дату
                завершення роботи картки і т.д. Передбачити механізми
                ініціалізації полів класу. Якщо значення для ініціалізації
                неправильне, генеруйте виняток.*/

            CreditCard creditCard = new CreditCard();
            bool ext = false;

            while (!ext)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(" ~ | Welcome to card menu | ~ ");
                    Console.WriteLine();
                    Console.WriteLine($"[1] - Set card number");
                    Console.WriteLine($"[2] - Set owner's name");
                    Console.WriteLine($"[3] - Set CVC code");
                    Console.WriteLine($"[4] - Set expiration date");
                    Console.WriteLine();
                    Console.WriteLine($"[5] - Get card number");
                    Console.WriteLine($"[6] - Get owner's name");
                    Console.WriteLine($"[7] - Get CVC code");
                    Console.WriteLine($"[8] - Get expiration date");
                    Console.WriteLine();
                    Console.WriteLine($"[0] - Exit");
                    Console.WriteLine();
                    Console.Write("(/@_@)/ ~>  "); int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: Console.Write("Card number: "); creditCard.CardNumber = Console.ReadLine(); break;
                        case 2: Console.Write("Card owner's name: "); creditCard.Name = Console.ReadLine(); break;
                        case 3: Console.Write("Card CVC code: "); creditCard.CVC = int.Parse(Console.ReadLine()); break;
                        case 4: Console.Write("Card expiration date: "); creditCard.ExpirationDate = MadeNewDate(); break;
                        case 5: Console.WriteLine($"Card number: {creditCard.CardNumber}"); break;
                        case 6: Console.WriteLine($"Card owner's name: {creditCard.Name}"); break;
                        case 7: Console.WriteLine($"Card CVC code: {creditCard.CVC}"); break;
                        case 8: Console.WriteLine($"Card expiration date: {creditCard.ExpirationDate}"); break;
                        case 0: Console.WriteLine($"Bye-bye!"); ext = true; break;
                    }
                }
                catch (IncorrectCardLength ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (IncorrectCVCLength ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (IncorrectExpirationDate ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("\n ~  Press any key to continue  ~ ");
                Console.ReadKey();
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
        #endregion

        static void Task3()
        {
            /*Завдання 3
                Користувач вводить до рядка з клавіатури математич-
                ний вираз. Наприклад, 3*2*1*4. Програма має підрахувати
                результат введеного виразу. У рядку можуть бути лише
                цілі числа і оператор*. Для обробки помилок введення
                використовуйте механізм виключень.*/

            try
            {
                Console.WriteLine("Enter a math expression (for example: 3*2:1*4 or 3-6+10): ");
                string inputExpression = Console.ReadLine();

                string[] elements = inputExpression.Split(new char[] { '+', '-', '*', '/', ':' });
                int result = int.Parse(elements[0]);

                for (int i = 1; i < elements.Length; i++)
                {
                    char operation = inputExpression[(i * 2) - 1];
                    int operand = int.Parse(elements[i]);
                    
                    switch (operation)
                    {
                        case '+':
                            result += operand;
                            break;
                        case '-':
                            result -= operand;
                            break;
                        case '*':
                            result *= operand;
                            break;
                        case '/':
                            result /= operand;
                            break;
                        case ':':
                            result /= operand;
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                }

                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine (ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown error! -> {ex.Message}");
            }
        }
    }
}
