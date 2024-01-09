using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;

namespace Program
{
    class Programm
    {
        static void Main()
        {           
            Random rnd = new();
            FigureList1 figures = new();
            for (int i = 0; i < rnd.Next(10,16); i++)
            {

                switch (rnd.Next(3))
                {
                    case 0:
                        Rectangle r = new(rnd.Next(1, 5), rnd.Next(1, 5));
                        figures.Add(r);
                        break;
                    case 1:
                        Elipse e = new(rnd.Next(1, 5), rnd.Next(1, 5));
                        figures.Add(e);
                        break;
                    case 2:
                        int a = rnd.Next(1, 5), b = rnd.Next(1, 5), c = rnd.Next(1, 5);
                        while (!(a < b + c && b < a + c && c < a + b))
                        {
                            a = rnd.Next(1, 5);
                            b = rnd.Next(1, 5);
                            c = rnd.Next(1, 5);
                        }
                        Triangle t = new(a, b, c);
                        figures.Add(t);
                        break;
                }
            }
            Console.WriteLine("Все элементы через foreach:");
            foreach (var el in figures)
            {
                el.Info();
            }
            Console.WriteLine("Все элементы через while:");
            Figure1[] arr = figures.ToArray();
            int index = 0;
            while (index<arr.Length)
            {
                arr[index].Info();
                index++;
            }
            Console.WriteLine("Начинаются на к:");
            if(figures.Any(x => x.Name.StartsWith('К')))
            {
                foreach (var el in figures.Where(x => x.Name.StartsWith('К')))
                {
                    el.Info();
                }
            }
            else
            {
                Console.WriteLine("Таких элементов нет");
            }
            Console.WriteLine("Все элементы отсортированные по периметру:");
            foreach (var el in figures.OrderBy(x=>x.Perimeter()))
            {
                el.Info();
            }
            Console.WriteLine("Все элементы сгруппированные по типу фигуры:");
            foreach (var el in figures.GroupBy(x => x.GetType().Name))
            {
                foreach(var inEl in el)
                {
                    inEl.Info();
                }
                Console.WriteLine();
            }
            if(figures.OfType<Triangle>().Where(x=> x.Type == "Треугольник равносторонний").Any())
            {
                Console.WriteLine("В коллекции есть равносторонние треугольники");
            }
            else
            {
                Console.WriteLine("В коллекции нет равносторонних треугольников");
            }
            
            if(figures.All(x=>x.Perimeter()<10))
            {
                Console.WriteLine("У всех фигур периметр меньше 10");
            }
            else
            {
                Console.WriteLine("Не все периметры фигур являются больше 10");
            }
            Console.WriteLine("Количество элементов: " + figures.Sum(x => 1));
            Console.WriteLine();
            Console.WriteLine("Наибольшая площадь: "+ figures.Max(x => x.Square()));
            Console.WriteLine();
            Console.WriteLine("Наименьшая площадь: " + figures.Min(x => x.Square()));
        }
    }
    class FigureList1 : IEnumerable<Figure1>
    {
        private List<Figure1> figures;
        public FigureList1()
        {
            figures = new();
        }

        
        public void Add(Figure1 fig)
        {
            figures.Add(fig);
        }
        public IEnumerator<Figure1> GetEnumerator()
        {
            return figures.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return figures.GetEnumerator();
        }
    }
    abstract class Figure1 : IComparable<Figure1>
    {
        public abstract string Name { get; }
        public abstract double Perimeter();
        public abstract double Square();
        public abstract void Info();

        public int CompareTo(Figure1? other)
        {
            if (other != null)
            {
                return Perimeter().CompareTo(other.Square());
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
    class Rectangle : Figure1
    {
        public double width, height;
        public override string Name{ get => width == height ? "Квадрат" : "Прямоугольник"; }
        public override double Perimeter()
        {
            return Math.Round(width * 2 + height * 2, 3);
        }
        public override double Square()
        {
            return Math.Round(width * height, 3);
        }
        public override void Info()
        {
            string sides = String.Format("Стороны: a = {0}, b = {1}", width, height);
            Console.WriteLine("{0,-15} {1,-30} {2,-20} {3,-20}",Name, sides, " Периметр = " + Perimeter(), " Площадь = " + Square());
        }
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
    }
    class Elipse : Figure1
    {
        public double radius1, radius2;
        public override string Name { get => radius1 == radius2 ? "Круг" : "Элипс"; }
        public override double Perimeter()
        {
            return Math.Round(4 * (Math.PI * radius1 * radius2 + Math.Pow(radius1 - radius2, 2)) / (radius1 + radius2), 3);
        }
        public override double Square()
        {
            return Math.Round(Math.PI * radius1 * radius2, 3);
        }
        public override void Info()
        {
            string radiuses = String.Format("Радиусы: a = {0}, b = {1}", radius1, radius2);
            Console.WriteLine("{0,-15} {1,-30} {2,-20} {3,-20}", Name, radiuses, " Периметр = " + Perimeter(), " Площадь = " + Square());
        }
        public Elipse(double radius1, double radius2)
        {
            this.radius1 = radius1;
            this.radius2 = radius2;
        }
    }
    class Triangle : Figure1
    {
        public double a, b, c;
        public override string Name { get => "Треугольник"; }
        public string Type { get=> a == b && b == c ? "Треугольник равносторонний" : (a == b || a == c || b == c ? "Треугольник равнобедренный" : "Треугольник разносторонний"); }
        public override double Perimeter()
        {
            return Math.Round(a + b + c, 3);
        }
        public override double Square()
        {
            return Math.Round(Math.Sqrt((a + b + c) / 2 * ((a + b + c) / 2 - a) * ((a + b + c) / 2 - b) * ((a + b + c) / 2 - c)), 3);
        }
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override void Info()
        {
            string sides = String.Format("Стороны: a = {0}, b = {1}, c = {2}", a, b, c);
            Console.WriteLine("{0,-15} {1,-30} {2,-20} {3,-20} {4}", Name, sides, " Периметр = " + Perimeter(), " Площадь = " + Square(), Type);
        }
    }
}