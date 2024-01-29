using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24._01._10_Inheritance_Indexers
{
    internal class Program
    {
        abstract class Figure
        {
            abstract public double GetArea();
            abstract public double GetPerimetr();
        }

        class Triangle : Figure
        {
            public Triangle() { FirstSide = 3; SecondSide = 4; ThirdSide = 5; }
            public Triangle(double side_a, double side_b, double c) { FirstSide = side_a; SecondSide = side_b; ThirdSide = c; }

            private double _side_A;
            public double FirstSide
            {
                get { return _side_A; }
                set 
                { 
                    if (value <= 0) { throw new ArgumentException(); }
                    _side_A = value; 
                }
            }

            private double _side_B;
            public double SecondSide
            {
                get { return _side_B; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _side_B = value;
                }
            }

            private double _side_C;
            public double ThirdSide
            {
                get { return _side_C; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _side_C = value;
                }
            }

            public override double GetArea()
            {
                // S = sqrt( p(p-a)(p-b)(p-c) )  :  p = (a+b+c)/2

                double p = GetPerimetr() / 2;
                double p_A = p - FirstSide;
                double p_B = p - SecondSide;
                double p_C = p - ThirdSide;
                double number = p * p_A * p_B * p_C;

                return Math.Sqrt(number);
            }
            public override double GetPerimetr()
            {
                return _side_A + _side_B + _side_C;
            }

            public override string ToString()
            {
                return $"Triangle ~ Side A: [{FirstSide}] | Side B: [{SecondSide}] | Side B: [{ThirdSide}]";
            }
        }
        class Square : Figure 
        {
            public Square() { Side = 3; }
            public Square(double side) { Side = side; }

            private double _side;
            public double Side
            {
                get { return _side; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _side = value;
                }
            }

            public override double GetArea()
            {
                return Side * Side;
            }
            public override double GetPerimetr()
            {
                return Side * 4;
            }

            public override string ToString()
            {
                return $"Square ~ Side: [{Side}]";
            }
        }
        class Rhombus : Figure
        {
            public Rhombus() { FirstSide = 3; SecondSide = 4; AngleA = 60; }
            public Rhombus(double side_a, double side_b, double angle) { FirstSide = side_a; SecondSide = side_b; AngleA = angle; }

            private double _side_A;
            public double FirstSide
            {
                get { return _side_A; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _side_A = value;
                }
            }

            private double _side_B;
            public double SecondSide
            {
                get { return _side_B; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _side_B = value;
                }
            }

            private double _angle_A;
            public double AngleA
            {
                get { return _angle_A; }
                set
                {
                    if (value <= 0 || value >= 180){throw new ArgumentException();}
                    _angle_A = value;
                }
            }

            public override double GetArea()
            {
                return (FirstSide * FirstSide) * Math.Sin(AngleA);
            }
            public override double GetPerimetr()
            {
                return 2 * (FirstSide * SecondSide);
            }
            public override string ToString()
            {
                return $"Rhombus ~ Side A: [{FirstSide}] | Side B: [{SecondSide}] | Angle A: [{AngleA}]";
            }
        }
        class Rectangle : Figure
        {
            public Rectangle() { FirstSide = 3; SecondSide = 4; }
            public Rectangle(double side_a, double side_b) { FirstSide = side_a; SecondSide = side_b; }

            private double _side_A;
            public double FirstSide
            {
                get { return _side_A; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _side_A = value;
                }
            }

            private double _side_B;
            public double SecondSide
            {
                get { return _side_B; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _side_B = value;
                }
            }

            public override double GetArea()
            {
                return FirstSide * SecondSide;
            }
            public override double GetPerimetr()
            {
                return 2 * (FirstSide * SecondSide);
            }
            public override string ToString()
            {
                return $"Rectangle ~ Side A: [{FirstSide}] | Side B: [{SecondSide}]";
            }
        }
        class Parallelogram : Figure
        {
            public Parallelogram() { FirstSide = 3; SecondSide = 4; AngleA = 60; }
            public Parallelogram(double side_a, double side_b, double angle) { FirstSide = side_a; SecondSide = side_b; AngleA = angle; }

            private double _side_A;
            public double FirstSide
            {
                get { return _side_A; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _side_A = value;
                }
            }

            private double _side_B;
            public double SecondSide
            {
                get { return _side_B; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _side_B = value;
                }
            }

            private double _angle_A;
            public double AngleA
            {
                get { return _angle_A; }
                set
                {
                    if (value <= 0 || value >= 180){throw new ArgumentException();}
                    _angle_A = value;
                }
            }

            public override double GetArea()
            {
                return (FirstSide * SecondSide) * Math.Sin(AngleA);
            }
            public override double GetPerimetr()
            {
                return 2 * (FirstSide * SecondSide);
            }

            public override string ToString()
            {
                return $"Parallelogram ~ Side A: [{FirstSide}] | Side B: [{SecondSide}] | Angle A: [{AngleA}]";
            }
        }
        class Trapezoid : Figure
        {
            public Trapezoid() { Side_1 = 5; Side_2 = 5; Side_3 = 5; Side_4 = 5; }
            public Trapezoid(double a, double b, double c, double d) { Side_1 = a; Side_2 = b; Side_3 = c; Side_4 = d; }

            private double _side_1;
            public double Side_1
            {
                get { return _side_1; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _side_1 = value;
                }
            }
            private double _side_2;
            public double Side_2
            {
                get { return _side_2; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _side_2 = value;
                }
            }
            private double _side_3;
            public double Side_3
            {
                get { return _side_3; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _side_3 = value;
                }
            }
            private double _side_4;
            public double Side_4
            {
                get { return _side_4; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _side_4 = value;
                }
            }

            public override double GetArea()
            {
                return 0.25 * ((Side_2 + Side_1) / (Side_2 - Side_1)) * Math.Sqrt(((-1 * Side_1) + Side_2 + Side_3 + Side_4) * (Side_1 + (-1 * Side_2) + Side_3 + Side_4) * ((-1 * Side_1) + Side_2 + Side_3 + (-1 * Side_4)) * (Side_1 + (-1 * Side_2) + (-1 * Side_3) + Side_4));
            }
            public override double GetPerimetr() 
            {
                return Side_1 + Side_2 + Side_3 + Side_4;   
            }

            public override string ToString()
            {
                return $"Trapezoid ~ Side A: [{Side_1}] | Side B: [{Side_2}] | Side B: [{Side_3}] |Side B: [{Side_4}]";
            }
        }
        class Circle : Figure
        {
            public Circle() { }

            private double _radius;
            public double Radius
            {
                get { return _radius; }
                set 
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _radius = value; 
                }
            }

            public override double GetArea() 
            {
                return Math.PI * (Radius * Radius);
            }
            public override double GetPerimetr() 
            {
                return Math.PI * (2 * Radius);
            }

            public override string ToString()
            {
                return $"Circle ~ Radius: [{Radius}]";
            }
        }
        class Ellipse : Figure
        {
            public Ellipse() { }

            private double _smaller_radius;
            public double SmallerRadius
            {
                get { return _smaller_radius; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _smaller_radius = value;
                }
            }

            private double _bigger_radius;
            public double BiggerRadius
            {
                get { return _bigger_radius; }
                set
                {
                    if (value <= 0) { throw new ArgumentException(); }
                    _bigger_radius = value;
                }
            }

            public override double GetArea()
            {
                return Math.PI * SmallerRadius * BiggerRadius;
            }
            public override double GetPerimetr()
            {
                return Math.PI * (SmallerRadius + BiggerRadius);
            }

            public override string ToString()
            {
                return $"Elipde ~ Smaller radius: [{SmallerRadius}] | Bigger radius: [{BiggerRadius}]";
            }
        }

        class CompositeFigures
        {
            List<Figure> _figures;

            public CompositeFigures() { _figures = new List<Figure>(); }
            public CompositeFigures(params Figure[] figures) { _figures = new List<Figure>(figures); }

            public void Add(Figure figure)
            {
                _figures.Add(figure);
            }
            public void Print()
            {
                foreach (Figure f in _figures) 
                {
                    Console.WriteLine(f);
                }
            }
        }

        static void Main(string[] args)
        {
            /*                
            Розробити абстрактний клас «Геометрична Фігура» з методами:
                    GetArea - обчислення площі
                    GetPerimeter - обчислення периметра
                
            Описати похідні класи:
                    Трикутник
                    Квадрат
                    Ромб
                    Прямокутник
                    Паралелограм
                    Трапеція
                    Коло
                    Еліпс.            
            Класи повинні містити характеристики певної фігури та конструктори, які їх встановлять.        
            
            Також реалізувати клас «Складена Фігура», який буде складатися з будь-якої кількості 
            «Геометричних фігур» (міститиме масив фігур). Класі повинен містити конструктор, 
            який використовуючи params прийматиме перелік фігур з який він буде складатися. 
            */
        }
    }
}
