namespace _9
{
    internal class Program
    {
        static void Main()
        {
            Random random = new Random();
            int n = 10, k = 0, k1 = 0;
            int[] array = new int[n];
            Console.WriteLine("Массив");
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(-3, 4);
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
                if (array[0] == array[i])
                    k++;
            Console.WriteLine("  {0} встречается {1} раз", array[0], k);
            for (int i = 1; i < n; i++)
            {
                k1 = 0;
                for (int j = 0; j < i; j++)
                {
                    if (array[i] == array[j])
                        k1++;
                }
                if (k1 == 0)
                {
                    k = 0;
                    for (int l = 0; l < n; l++)
                        if (array[i] == array[l])
                            k++;
                    Console.WriteLine("  {0} встречается {1} раз", array[i], k);
                }
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