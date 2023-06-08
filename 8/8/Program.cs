using System.Diagnostics;

namespace _8
{
    internal class Program
    {
        static void Main()
        {
            Random r = new Random();
            int a = 10000;
            int[] array = new int[a];
            int[] array1 = new int[a];
            int b, k = 0;
            for (int i = 0; i < a; i++)
            {
                array1[i] = r.Next(-9, 10);
                array[i] = array1[i];
            }
            Stopwatch btime = new Stopwatch();
            btime.Start();
            while (k == 0)
            {
                for (int i = 0; i < a - 1; i++)
                    if (array[i] > array[i + 1])
                    {
                        b = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = b;
                    }
                for (int i = 0; i < a - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        k = 0;
                        break;
                    }
                    k = 1;
                }
            }
            btime.Stop();
            Console.WriteLine("Сортировка пузырьком:{0}", btime.Elapsed);
            for (int i = 0; i < a; i++)
                array[i] = array1[i];
            Stopwatch pertime = new Stopwatch();
            pertime.Start();
            int j, x;
            k = 0;
            while (k == 0)
            {
                for (int i = 1; i < a; i++)
                {
                    x = array[i];
                    j = i;
                    while (j > 0 && array[j - 1] > x)
                    {
                        b = array[j];
                        array[j] = array[j - 1];
                        array[i - 1] = b;
                        j--;
                    }
                    array[j] = x;
                }
                for (int i = 0; i < a - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        k = 0;
                        break;
                    }
                    k = 1;
                }
            }
            pertime.Stop();
            Console.WriteLine("Сортировка перестановкой: {0}", pertime.Elapsed);
            Stopwatch stime = new Stopwatch();
            stime.Start();
            Array.Sort(array1);
            stime.Stop();
            Console.WriteLine("Сортировка Array.Sort():{0}", stime.Elapsed);
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
