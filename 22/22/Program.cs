using System.Reflection.Emit;
using System.Threading.Channels;

namespace _22
{
    internal class Program
    {
        static void Main()
        {
            Random random = new Random();
            bool g = false;
            int a = 0;
            try
            {
                a = Convert.ToInt32(Console.ReadLine());
                if (a < 3) throw new Exception("Размер должен быть больше двух");
            }
            catch
            {
                Console.WriteLine("Ошибка");
                Main();
            }
            int[,] arr = new int[a, a];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    arr[i, j] = random.Next(1, 10);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    Console.Write("{0,5}", arr[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            g = true;
            if (g)
            {
                try
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < a; j++)
                        {
                            Console.Write("{0,5}", arr[i, j]);
                        }
                        Console.WriteLine();
                    }

                }
                catch
                {
                    Console.WriteLine("Ошибка");
                    Main();
                }
                if (MainDiag(arr) && SecondaryDiag(arr))
                    Console.WriteLine("Матрица симметрична относительно обеих диагоналей");
                else if (MainDiag(arr) && !SecondaryDiag(arr))
                    Console.WriteLine("Матрица симметрична относительно главной диагонали");
                else if (!MainDiag(arr) && !SecondaryDiag(arr))
                    Console.WriteLine("Матрица симметрична относительно побочной диагонали");
                else
                    Console.WriteLine("Матрица не симметрична относительно обеих диагоналей");

                Console.WriteLine();
                Console.WriteLine("Повтор? 1 да, любое другое число нет");
                int repeat = Convert.ToInt32(Console.ReadLine());
                if (repeat == 1)
                {
                    Main();
                }
            }
        }
        static bool MainDiag(int[,] arr)
        {
            int a = arr.GetLength(0);
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    if (arr[a - i - 1, j] != arr[i, a - j - 1] && a - i - 1 != j) return false;
                }
            }
            return true;
        }
        static bool SecondaryDiag(int[,] arr)
        {
            int a = arr.GetLength(0);
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    if (arr[i, j] != arr[a - i - 1, a - j - 1] && i != a - j - 1) return false;
                }
            }
            return true;
        }

    }
}

