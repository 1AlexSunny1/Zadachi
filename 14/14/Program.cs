namespace _14
{
    struct Date
    {
        int day;
        int mounth;
        int year;

        public Date(int y, int m, int d)
        {
            day = d;
            mounth = m;
            year = y;
        }
        public string Calculate()
        {
            int a = (14 - mounth) / 12;
            int Y = year - a;
            int M = mounth + 12 * a - 2;
            int N = (7000 + day + Y + (Y / 4) - (Y / 100) + (Y / 400) + ((31 * M) / 12)) % 7;
            switch (N)
            {
                case 0: return "Воскресенье";
                case 1: return "Понедельник";
                case 2: return "Вторник";
                case 3: return "Среда";
                case 4: return "Четверг";
                case 5: return "Пятница";
                case 6: return "Суббота";
                default: return "Несуществующий день недели";
            }
        }
    }
    class Program
    {
        static void Main()
        {
            int d = 0, m = 0, y = 0;
            try
            {
                Console.WriteLine("Введите год");
                y = Convert.ToInt32(Console.ReadLine());
                if (y < 1583) throw new ArgumentException("Некорректный ввод");
                Console.WriteLine("Введите месяц");
                m = Convert.ToInt32(Console.ReadLine());
                if (m < 1 || m > 12) throw new ArgumentException("Некорректный ввод");
                Console.WriteLine("Введите день");
                d = Convert.ToInt32(Console.ReadLine());
                if ((m % 7) % 2 != 0 || m == 7)
                {
                    if (d < 1 || d > 31) throw new ArgumentException("Некорректный ввод");
                }
                else if (m == 2)
                {
                    if ((y % 4 == 0 && y % 100 != 0) || y % 400 == 0)
                    {
                        if (d < 1 || d > 29) throw new ArgumentException("Некорректный ввод");
                    }
                    else
                    {
                        if (d < 1 || d > 28) throw new ArgumentException("Некорректный ввод");
                    }
                }
                else
                {
                    if (d < 1 || d > 30) throw new ArgumentException("Некорректный ввод");
                }
                Date date = new Date(y, m, d);
                Console.WriteLine(date.Calculate());
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка. Неверный формат данных");
                Main();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка. {0}", ex.Message);
                Main();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Ошибка. {0}", ex.Message);
                Main();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Ошибка. {0}", ex.Message);
                Main();
            }
            Console.WriteLine();
            Console.WriteLine("Повтор? 1 да, любое другое число нет");
            int repeat = Convert.ToInt32(Console.ReadLine());
            if (repeat == 1)
            {
                Main();
            }
        }
    }
}