namespace _23._12._20_Class_Struct
{
    internal class Program
    {
        class Worker
        {
            private string _name;
            public string Name
            {
                get { return _name; }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        _name = value;
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                }
            }

            private int _age;
            public int Age
            {
                get { return _age; }
                set
                {
                    if (value >= 18 && value <= 70)
                    {
                        _age = value;
                    }
                    else
                    {
                        throw new Exception("Incorrect age! Age must be 18-70!");
                    }
                }
            }

            private float _salary;
            public float Salary
            {
                get { return _salary; }
                set
                {
                    if (value > 7000 && value < 100000)
                    {
                        _salary = value;
                    }
                    else
                    {
                        throw new Exception("Incorrect salary! Salary must be bigger than 7.000!");
                    }
                }
            }

            private DateOnly _hire_date;
            public DateOnly Hire_date
            {
                get { return _hire_date; }
                set
                {
                    if (value <= DateOnly.FromDateTime(DateTime.Now))
                    {
                        _hire_date = value;
                    }
                    else
                    {
                        throw new Exception("Incorrect date! The hire date can't be in the future!");
                    }
                }
            }

            public Worker()
            {
                _name = "Noname";
                _age = 18;
                _salary = 5000;
                Hire_date = DateOnly.MinValue;
            }

            bool CheckDate(int year, int month, int day)
            {
                if (year.ToString().Length != 4 || month < 0 || month > 12 || day < 0 || day > 31)
                {
                    return false;
                }
                if (year.ToString().Length == 4 && DateTime.Now.Year > year)
                {
                    return true;
                }
                else if (DateTime.Now.Year == year)
                {
                    if (DateTime.Now.Month > month)
                    {
                        return true;
                    }
                    else if (DateTime.Now.Month == month)
                    {
                        if (DateTime.Now.Day > day || DateTime.Now.Day == day)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            void SetHireDate()
            {
                try
                {
                    Console.Write("Year: "); int year = int.Parse(Console.ReadLine());
                    Console.Write("Month: "); int month = int.Parse(Console.ReadLine());
                    Console.Write("Day: "); int day = int.Parse(Console.ReadLine());

                    if (CheckDate(year, month, day))
                    {
                        DateOnly date = new DateOnly(year, month, day);
                        Hire_date = date;
                    }
                    else { throw new Exception("Wrong date! Hire date can't be in the future!"); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception! {ex}"); Console.ReadKey();
                    throw ex;
                }
            }
            public override string ToString()
            {
                return $"Worker info -> Name: {Name} |~| Age: {Age} |~| Salary: {Salary} |~| Hire date: {Hire_date}";
            }
            public bool Fill()
            {
                try
                {
                    Console.Write("Name : "); Name = Console.ReadLine();
                    Console.Write("Age : "); Age = int.Parse(Console.ReadLine());
                    Console.WriteLine("! Enter hire date !"); SetHireDate();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        static void Main(string[] args)
        {
            /*  
                Завдання 1:
                    Описати клас з ім'ям Worker, що містить наступні поля:
                        прізвище та ініціали працівника;
                        вік працівника;
                        ЗП працівника;
                        дата прийняття на роботу.

                    Написати програму, що виконує наступні дії:
                        введення з клавіатури даних в масив, що складається з п'яти елементів типу Worker (записи повинні бути впорядковані за алфавітом);
                        якщо значення якогось параметру введено не в відповідному форматі - згенерувати відповідний exception.
                        вивід на екран прізвища працівника, стаж роботи якого перевищує введене з клавіатури значення.
                    
            Рекомендація: перевірку формата даних та генерацію винятку виконуйте в блоці set{} для кожної властивості класа Worker.
            */

            List<Worker> workers = new List<Worker>();
            
            bool ext = false;
            while (!ext)
            {
                try
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Worker worker = new Worker();

                        Console.Clear();
                        Console.WriteLine($"Fill worker number {i + 1}");

                        if (worker.Fill())
                        {
                            workers.Add(worker);
                        }
                        else
                        {
                            i--;
                        }                       
                    }
                    ext = true;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); Console.ReadKey(); }
            }

            Console.Clear();
            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine(workers[i]);
            }
            Console.ReadKey();

            ext = false;
            while (!ext)
            { 
                try
                {
                    Console.Clear();
                    Console.WriteLine("! Enter length of service in months !"); 
                    
                    int total_months = int.Parse(Console.ReadLine());
                    int total_days = total_months * 31;

                    DateTime date = DateTime.Now;
                    int now_days = (date.Year * 365) + (date.Month * 31) + date.Day;
                    int search = now_days - total_days;
                    int service = 0;

                    for (int i = 0; i < workers.Count; i++)
                    {
                        service = (workers[i].Hire_date.Year * 365) + (workers[i].Hire_date.Month * 31) + workers[i].Hire_date.Day;
                        if (service < search) 
                        {
                            Console.WriteLine(workers[i]);
                        }
                    }
                    Console.ReadKey();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
    }
}