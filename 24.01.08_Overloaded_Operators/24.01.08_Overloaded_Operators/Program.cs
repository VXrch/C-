using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _24._01._08_Overloaded_Operators
{
    public class NegativeLengthException : Exception
    {
        public override string Message
        {
            get
            {
                return "The side length of the figure cannot be 0!";
            }
        }
    }

    class Square
    {
        public Square() { _side = 1; }
        public Square(int side) { Side = side; }

        private int _side;
        public int Side
        {
            get { return _side; }
            set
            {
                if (value < 1)
                {
                    throw new NegativeLengthException();
                }
                _side = value;
            }
        }

        public override string ToString()
        {
            return $"Square side = [{Side}]";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.Side == ((Square)obj).Side;
        }

        public override int GetHashCode()
        {
            return Side.GetHashCode();
        }

        public static Square operator ++(Square square)
        {
            return new Square(square.Side + 1);
        }
        public static Square operator --(Square square)
        {
            if (square.Side - 1 <= 0)
            {
                throw new NegativeLengthException();
            }
            return new Square(square.Side - 1);
        }

        public static Square operator +(Square square, int element)
        {
            return new Square(square.Side + element);
        }
        public static Square operator -(Square square, int element)
        {
            if (square.Side - element < 0)
            {
                throw new NegativeLengthException();
            }

            return new Square(square.Side - element);
        }

        public static Square operator *(Square square, int element)
        {
            if (element == 0)
            {
                throw new DivideByZeroException();
            }
            if (element < 0)
            {
                throw new NegativeLengthException();
            }

            return new Square(square.Side * element);
        }
        public static Square operator /(Square square, int element)
        {
            if (element == 0)
            {
                throw new DivideByZeroException();
            }
            else if (element < 0 || square.Side / element < 0)
            {
                throw new NegativeLengthException();
            }

            return new Square(square.Side / element);
        }
        public static bool operator <(Square square1, Square square2)
        {
            return square1.Side < square2.Side;
        }
        public static bool operator >(Square square1, Square square2)
        {
            return square1.Side > square2.Side;
        }
        public static bool operator <=(Square square1, Square square2)
        {
            return square1.Side <= square2.Side;
        }        
        public static bool operator >=(Square square1, Square square2)
        {
            return square1.Side >= square2.Side;
        }
        public static bool operator ==(Square square1, Square square2)
        {
            return square1.Side == square2.Side;
        }
        public static bool operator !=(Square square1, Square square2)
        {
            return square1.Side != square2.Side;
        }

        public static implicit operator Square(Rectangle rect)
        {
            int side = (rect.FirstSide + rect.SecondSide) / 2;
            return new Square(side);
        }
        public static implicit operator int(Square square)
        { 
            return square.Side;
        }
    }

    class Rectangle
    {
        public Rectangle() { FirstSide = SecondSide = 1; }
        public Rectangle(int side) { FirstSide = SecondSide = side; }
        public Rectangle(int first, int second) { FirstSide = first; SecondSide = second; }

        private int _firstSide;
        public int FirstSide
        {
            get { return _firstSide; }
            set
            {
                if (value < 1)
                {
                    throw new NegativeLengthException();
                }
                _firstSide = value;
            }
        }

        private int _secondSide;
        public int SecondSide
        {
            get { return _secondSide; }
            set
            {
                if (value < 1)
                {
                    throw new NegativeLengthException(); ;
                }
                _secondSide = value;
            }
        }

        public int SidesSum { get { return FirstSide + SecondSide; } }

        public override string ToString()
        {
            return $"First side = [{FirstSide}],  Second side = [{SecondSide}]";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return (this.FirstSide == ((Square)obj).Side && this.SecondSide == ((Square)obj).Side);
        }

        public override int GetHashCode()
        {
            return (FirstSide.GetHashCode() + SecondSide.GetHashCode());
        }

        public static Rectangle operator ++(Rectangle rect)
        {
            return new Rectangle(rect.FirstSide + 1, rect.SecondSide + 1);
        }
        public static Rectangle operator --(Rectangle rect)
        {
            if (rect.FirstSide - 1 < 0 || rect.SecondSide - 1 < 0)
            {
                throw new NegativeLengthException();
            }
            return new Rectangle(rect.FirstSide - 1, rect.SecondSide - 1);
        }

        public static Rectangle operator +(Rectangle rect, int element)
        {
            return new Rectangle(rect.FirstSide + element, rect.SecondSide + element);
        }
        public static Rectangle operator -(Rectangle rect, int element)
        {
            if (rect.FirstSide - element < 0 || rect.SecondSide - element < 0)
            {
                throw new NegativeLengthException();
            }
            return new Rectangle(rect.FirstSide - element, rect.SecondSide - element);
        }

        public static Rectangle operator *(Rectangle rect, int element)
        {
            if (element == 0) { throw new DivideByZeroException(); }
            if (element < 0) { throw new NegativeLengthException(); }

            return new Rectangle(rect.FirstSide * element, rect.SecondSide * element);
        }
        public static Rectangle operator /(Rectangle rect, int element)
        {
            if (element == 0) { throw new DivideByZeroException(); }
            if (element < 0) { throw new NegativeLengthException(); }

            return new Rectangle(rect.FirstSide / element, rect.SecondSide / element);
        }

        public static bool operator <(Rectangle rect1, Rectangle rect2)
        {
            return rect1.SidesSum < rect2.SidesSum;
        }
        public static bool operator >(Rectangle rect1, Rectangle rect2)
        {
            return rect1.SidesSum > rect2.SidesSum;
        }
        public static bool operator <=(Rectangle rect1, Rectangle rect2)
        {
            return rect1.SidesSum <= rect2.SidesSum;
        }
        public static bool operator >=(Rectangle rect1, Rectangle rect2)
        {
            return rect1.SidesSum >= rect2.SidesSum;
        }
        public static bool operator ==(Rectangle rect1, Rectangle rect2)
        {
            return rect1.SidesSum == rect2.SidesSum;
        }
        public static bool operator !=(Rectangle rect1, Rectangle rect2)
        {
            return rect1.SidesSum != rect2.SidesSum;
        }

        public static explicit operator Rectangle(Square square)
        {
            return new Rectangle(square.Side);
        }
        public static explicit operator int(Rectangle rect)
        {
            return rect.FirstSide + rect.SecondSide;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Створити два класи, які будуть описувати фігуру:
                Square. 
                    Містить властивість A - довжина сторони квадрату.
                Rectangle. 
                    Містить властивості A, B - довжина сторін прямокутника.
                
                Написати для класів конструктор по замовчуванню та параметризований, 
                перевизначити метод ToString та перевантажити наступні оператори:
                    (++ --) - оператори змінюють розмір кожної з сторін на одиницю відповідно
                    (+ - * /) - оператори створюють нову фігуру зробивши відповідну операцію з кожною зі сторін. 
                                Перевіряйте, щоб сторона не була від'ємною.
                    (< > <= >= == !=) - оператори порівнюють відповідні фігури по розмірам сторін. 
                                        
                Для операторів рівності перевизначте базовий метод Equals в парі з методом GetHashCode.
                    (true false) - умовою істиності фігури є перевірка чи розміри сторін відмінні від нуля.
                
                Також перевизначити оператори приведення типу в наступних варіантах:
                    - неявне приведення (implicit) квадрату до прямокутника
                    - неявне приведення квадрату до типу int
                    - явне приведення (explicit) прямокутника до квадрату
                    - явне приведення прямокутника до типу int
            */

            Square square = new Square(50);
            Console.WriteLine("Square: " + square);
            square++;
            Console.WriteLine("++ : " + square);
            square--;
            Console.WriteLine("-- : " + square);
            square += 10;
            Console.WriteLine("+10 : " + square);
            square -= 10;
            Console.WriteLine("-10 : " + square);
            square *= 2;
            Console.WriteLine("*2 : " + square);
            square /= 2;
            Console.WriteLine("/2 : " + square);

            Console.WriteLine();

            Rectangle rect = new Rectangle(100);
            Console.WriteLine("Rectangle: " + rect);
            rect++;
            Console.WriteLine("++ : " + rect);
            rect--;
            Console.WriteLine("-- : " + rect);
            rect += 10;
            Console.WriteLine("+10 : " + rect);
            rect -= 10;
            Console.WriteLine("-10 : " + rect);
            rect *= 2;
            Console.WriteLine("*2 : " + rect);
            rect /= 2;
            Console.WriteLine("/2 : " + rect);

            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Rectangle: " + rect); 
            Console.WriteLine("Square: " + square);
            Console.WriteLine();

            bool res = rect > square;
            Console.WriteLine("rect > square : " + res);
            res = rect < square;
            Console.WriteLine("rect < square : " + res);
            res = rect >= square;
            Console.WriteLine("rect >= square : " + res);
            res = rect <= square;
            Console.WriteLine("rect <= square : " + res);
            res = rect == square;
            Console.WriteLine("rect == square : " + res);
            res = rect != square;
            Console.WriteLine("rect != square : " + res);
        }
    }
}