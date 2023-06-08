namespace _18
{
    using System;
    class Program
    {
        static void Main()
        {
            Random random = new Random();
            int n = 7, m = 7;
            int[,] array = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write("{0,3}", array[i, j] = random.Next(0, 10));
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    if (i == 0 || i == n - 1 || j == 0 || j == m - 1)
                        Console.Write("{0,3}", array[i, j]);
                    else
                        Console.Write("{0,3}", "");
                Console.WriteLine();
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