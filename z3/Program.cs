namespace Program
{
    class Programm
    {
        static void Main()
        {
            List<string> transactions = new();
            bool flag = false;
            do
            {

                try
                {
                    Console.WriteLine("Выберите изначальный тип валюты (1 - рубли, 2 - леи, 3 - гривны, 4 - доллары)");
                    byte prevC = Convert.ToByte(Console.ReadLine());
                    Currency prevCurrency = GCurrency(prevC);

                    Console.WriteLine("Введите сумму перевода");
                    double value = Convert.ToDouble(Console.ReadLine());
                    if (value < 0) throw new Exception("Сумма не может быть отрицательной");

                    Console.WriteLine("Выберите тип валюты (1 - рубли, 2 - леи, 3 - гривны, 4 - доллары)");
                    byte newC = Convert.ToByte(Console.ReadLine());
                    Currency newCurrency = GCurrency(newC);

                    string st = String.Format("Сумма - {0} в валюте - {1} переведены в {2} в валюте - {3}",
                        value, prevCurrency.Name, Currency.ConvertCurrency(prevCurrency, newCurrency, value), newCurrency.Name);
                    transactions.Add(st);
                    Console.WriteLine(st);
                    if (transactions.Count > 3) transactions.RemoveAt(0);
                    Console.WriteLine("Enter - Выполнить еще перевод, Любая другая клавиша - вывести сводку");
                    flag = Console.ReadKey().Key == ConsoleKey.Enter;
                    
                }
                catch (Exception ex)
                {
                    Err(ex.Message);
                }

            }
            while (flag);

            Console.WriteLine("Последние 3 транзакции:");
            foreach (var el in transactions)
            {
                Console.WriteLine(el);
            }

            End();
        }
        static Currency GCurrency(byte type)
        {
            switch (type)
            {
                case 1:
                    return new Rub();
                case 2:
                    return new Lei();
                case 3:
                    return new Uah();
                case 4:
                    return new Dollar();
                default:
                    throw new Exception("Введено неверное значение");

            }
        }
        static void Err(string text)
        {
            Console.WriteLine("Ошибка");
            Console.WriteLine(text);
            Console.WriteLine("Чтобы перезапустить программу нажмите Enter");
            Console.WriteLine("Чтобы выйти нажмите любую другую клавишу");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {

                Main();
                return;
            }
            else
            {
                Environment.Exit(0);
            }

        }
        static void End()
        {
            Console.WriteLine("Чтобы перезапустить программу нажмите Enter");
            Console.WriteLine("Чтобы выйти нажмите любую другую клавишу");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {

                Main();
                return;
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
    abstract class Currency
    {
        public string Name { get; init; }
        public double Curr { get; init; }

        public static double ConvertCurrency(Currency from, Currency to, double value)
        {
            return Math.Round(value / from.Curr * to.Curr,4);
        }

    }
    class Dollar : Currency
    {
        public Dollar()
        {
            Curr = 1;
            Name = "Доллары";
        }
    }
    class Rub : Currency
    {
        public Rub()
        {
            Curr = 0.174;
            Name = "Рубли";
        }
    }
    class Lei : Currency
    {
        public Lei()
        {
            Curr = 0.21;
            Name = "Леи";
        }
    }
    class Uah : Currency
    {
        public Uah()
        {
            Curr = 0.027;
            Name = "Гривны";
        }
    }
}