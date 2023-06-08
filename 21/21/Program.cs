namespace _21
{
    internal class Program
    {
        static void Main()
        {
            Random rnd = new Random();


            int m = 0, n = 0;
            try
            {
                m = Convert.ToInt32(Console.ReadLine());
                n = Convert.ToInt32(Console.ReadLine());
                if (m < 3 || n < 3) throw new Exception("Оба числа должны быть больше двух");
            }
            catch
            {
                Console.WriteLine("Ошибка");
                Main();
            }
            int[,] arr = new int[m, n];
            int count = 0, spiralCount = 0;
            bool t = true;

            while (t)
            {

                for (int i = spiralCount; i < m - spiralCount; i++)
                {
                    if (spiralCount < m && arr[i, spiralCount] == 0) arr[i, spiralCount] = count++;
                    else
                    {
                        t = false;
                        break;
                    }
                }
                for (int i = spiralCount + 1; i < n - spiralCount; i++)
                {
                    if (spiralCount < m && arr[m - 1 - spiralCount, i] == 0) arr[m - 1 - spiralCount, i] = count++;
                    else
                    {
                        t = false;
                        break;
                    }
                }
                for (int i = spiralCount + 1; i < m - spiralCount; i++)
                {
                    if (spiralCount < n && arr[m - i - 1, n - 1 - spiralCount] == 0) arr[m - i - 1, n - 1 - spiralCount] = count++;
                    else
                    {
                        t = false;
                        break;
                    }
                }
                for (int i = spiralCount + 1; i < n - spiralCount - 1; i++)
                {
                    if (spiralCount < n && arr[spiralCount, n - i - 1] == 0) arr[spiralCount, n - i - 1] = count++;
                    else
                    {
                        t = false;
                        break;
                    }
                }
                spiralCount++;

            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,5}", arr[j, i]);
                }
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

