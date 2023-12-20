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
                        throw new ArgumentNullException("value");
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
                    if (value > 7000)
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







        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

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


        }
    }
}