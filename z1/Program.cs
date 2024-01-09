
namespace Program
{
    class Programm
    {
        static void Main()
        {
            Random rnd = new();
            List<Animals> animals = new();
            for (int i = 0; i < 10; i++)
            {
                int r = rnd.Next(3);
                switch (r)
                {
                    case 0:
                        Mammal m = new();
                        animals.Add(m);
                        break;
                    case 1:
                        Bug b = new();
                        animals.Add(b);
                        break;
                    case 2:
                        Fish f = new();
                        animals.Add(f);
                        break;
                }
            }

            foreach (var el in animals)
            {
                el.Info();
            }
            Console.ReadLine();
        }
    }
    abstract class Animals
    {
        protected byte limbCount;
        protected string name = "";

        protected Random rnd = new Random();
        protected string[] names = { "" };
        public abstract void Info();
    }
    class Mammal : Animals
    {
        public Mammal()
        {
            limbCount = 4;
            names = new string[5] { "Зебра", "Обезьяна", "Кошка", "Лошадь", "Человек" };
            name = names[rnd.Next(5)];
        }
        public override void Info()
        {
            Console.WriteLine(name + " - млекопитающее, " + limbCount + " лапы");
        }
    }
    class Bug : Animals
    {
        public Bug()
        {
            limbCount = 6;
            names = new string[5] { "Колорадский жук", "Навозный жук", "Майский жук", "Таракан жук", "Жук олень" };
            name = names[rnd.Next(5)];
        }
        public override void Info()
        {
            Console.WriteLine(name + ", " + limbCount + " лап");
        }
    }
    class Fish : Animals
    {
        public Fish()
        {
            limbCount = 0;
            names = new string[5] { "Карась", "Сом", "Щука", "Толстолобик", "Карп" };
            name = names[rnd.Next(5)];
        }
        public override void Info()
        {
            Console.WriteLine(name + " - рыба, " + limbCount + " лап");
        }
    }
}