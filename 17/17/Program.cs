namespace _17
{
    class Program
    {
        static void Main()
        {
                int n = 0, n1 = 0, a = 1, nol = 0, b;
                Console.WriteLine("Введите натураное число:");
                try
                {
                    n = n1 = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка");
                    Main();
                }
                if (n < 0)
                {
                    Console.WriteLine("Ошибка");
                    Main();
                }
                while (n / 10 != 0)
                {
                    a++;
                    n /= 10;
                }
                n = n1;
                int[] array = new int[a];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = n % 10;
                    n /= 10;
                    if (array[i] == 0)
                        nol++;
                }
                Array.Sort(array);
                if (n1 != 0)
                {
                    b = array[nol];
                    array[nol] = array[0];
                    array[0] = b;
                }
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i]);
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