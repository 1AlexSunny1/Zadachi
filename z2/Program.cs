
namespace Program
{
    class Programm
    {
        static void Main()
        {
            
            Random rnd = new();
            List<Figure> figures = new();
            for (int i = 0; i < 10; i++)
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

            foreach (var el in figures)
            {
                el.Info();
            }
            Console.ReadLine();
        }
    }
    abstract class Figure
    {
        public abstract double Perimeter();
        public abstract double Square();
        public abstract void Info();
    }
    class Rectangle : Figure
    {
        public double width, height;

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
            Console.WriteLine("{0,15} Стороны: a = {1}, b = {2} Периметр = {3} Площадь = {4}", width == height ? "Квадрат" : "Прямоугольник", width, height, Perimeter(), Square());
        }
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
    }
    class Elipse : Figure
    {
        public double radius1, radius2;

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

            Console.WriteLine("{0,15} Радиус №1 = {1} Радиус №2 = {2} Периметр = {3} Площадь = {4}", radius1 == radius2 ? "Окружность" : "Элипс", radius1, radius2, Perimeter(), Square());


        }
        public Elipse(double radius1, double radius2)
        {
            this.radius1 = radius1;
            this.radius2 = radius2;
        }
    }
    class Triangle : Figure
    {
        public double a, b, c;
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
            string sidesResult = a == b && b == c ? "Треугольник равносторонний" : (a == b || a == c || b == c ? "Треугольник равнобедренный" : "Треугольник разносторонний");
            Console.WriteLine("{0,15} Стороны: a = {1}, b = {2}, c = {3} {4}  Периметр = {5} Площадь = {6}", "Треугольник", a, b, c, sidesResult, Perimeter(), Square());
        }
    }
}
