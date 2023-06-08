namespace _20
{
    internal class Program
    {
        static void Main()
        {
            Random r = new Random();
            int n = 3, l = 0, l1 = 0, c = 0, gd = 0, pd = 0, times = 0;
            int[,] array = new int[n, n];
            while (true)
            {
                times++;
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        array[i, j] = 0;
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        while (true)
                        {
                            array[i, j] = r.Next(1, 10);
                            if (i == 0 && j == 0)
                                break;
                            int k = 0;
                            for (int q = 0; q < n; q++)
                                for (int w = 0; w < n; w++)
                                    if (array[q, w] == array[i, j])
                                        k++;
                            if (k == 1)
                                break;
                        }
                int p = 0;
                l1 = 0;
                for (int j = 0; j < n; j++)
                    l1 += array[0, j];
                gd = 0;
                pd = 0;
                for (int i = 0; i < n; i++)
                {
                    l = 0;
                    c = 0;
                    for (int j = 0; j < n; j++)
                    {
                        l += array[i, j];
                        c += array[j, i];
                    }
                    if (l != l1 || c != l1)
                    {
                        p = 1;
                        break;
                    }
                    gd += array[i, i];
                    pd += array[i, n - 1 - i];
                }
                if (gd != l1 || pd != l1)
                    p = 1;
                if (p == 1)
                    continue;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write("{0} ", array[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("  Магический квадрат был сгенерирован на {0} раз", times);
                break;
            }
            Console.WriteLine();
            Console.WriteLine("Повтор? 1 да, любое другое число нет");
            int repeat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (repeat == 1)
            {
                Main();
            }
        }
    }
}
