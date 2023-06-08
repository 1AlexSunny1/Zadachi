
namespace _6
{

    internal class Program
    {
        static public int[] SortNegativ(int[] arr)
        {
            for (int i = 19; i > 0; i--)
            {
                if (arr[i] < 0)
                {
                    int a = i;
                    for (int index = i - 1; index >= 0; index--)
                    {
                        if (arr[index] >= 0)
                        {
                            int c = arr[index];
                            arr[index] = arr[a];
                            arr[a] = c;
                        }
                        else break;
                        a--;
                    }
                }
            }
            return arr;
        }

        static public int[] SortNull(int[] arr, int negative)
        {
            for (int i = 19; i >= negative - 1; i--)
            {
                if (arr[i] == 0)
                {
                    int a = i;
                    for (int index = i - 1; index >= negative - 1; index--)
                    {
                        if (arr[index] != 0)
                        {
                            int c = arr[index];
                            arr[index] = arr[a];
                            arr[a] = c;
                        }
                        else break;
                        a--;
                    }
                }
            }
            return arr;
        }
        static void Main()
        {
            Random random = new Random();
            int n = 20;
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(-3, 4);
            }
            Console.WriteLine("Массив");
            foreach (int i in array)
            {
                Console.Write("{0} ",i);
            }
            Console.WriteLine();
            int negative = 0;
            int nul = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0) nul++;
                if (array[i] < 0) negative++;
            }
            bool status = true;
            while (status)
            {
                SortNegativ(array);
                int check = 0;
                for (int i = 0; i < negative; i++)
                {
                    if (array[i] < 0) check++;
                }
                if (check == negative) status = false;
            }

            status = true;
            while (status)
            {
                SortNull(array, negative);
                int check = 0;
                for (int i = negative - 1; i < negative - 1 + nul; i++)
                {
                    if (array[i] == 0) check++;
                }
                if (check == nul) status = false;
            }
            status = true;
            while (status)
            {
                SortNegativ(array);
                int check = 0;
                for (int i = 0; i < negative; i++)
                {
                    if (array[i] < 0) check++;
                }
                if (check == negative) status = false;
            }
            foreach (int i in array)
            {
                Console.Write("{0} ", i);
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