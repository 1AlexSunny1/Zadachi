namespace _19
{
    using System;
    class Program
    {
        static void Main()
        {
            int n = 7, l = n - 1;
            int[,] array = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    if (i == j)
                        Console.Write("{0,2}", array[i, j] = i);
                    else
                        if (j == l)
                        Console.Write("{0,2}", array[i, j] = j);
                    else
                        Console.Write("{0,2}", array[i, j]);
                l--;
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