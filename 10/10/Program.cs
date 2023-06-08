namespace _10
{
    internal class Program
    {
        static void Main()
        {
            Random random = new Random();
            int n = 20, k = 0;
            int[] array = new int[n];
            array[0] = random.Next(0, 20);
            Console.Write("{0} ", array[0]);
            for (int i = 1; i < n; i++)
            {
                bool flag = true;
                while (flag)
                {
                    array[i] = random.Next(0, 20);
                    k = 0;
                    for (int j = 0; j < i; j++)
                        if (array[j] == array[i])
                            k++;
                    if (k == 0)
                        flag = false;
                }
                Console.Write("{0} ", array[i]);
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