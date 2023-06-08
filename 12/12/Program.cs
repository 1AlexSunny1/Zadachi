namespace _12
{
    internal class Program
    {
        static void Main()
        {
            Random random = new Random();
            int n = 20;
            bool flag = true;
            int[] array = new int[n];
            int min = 0, m = 0, k = array.Length, b = 0;
            Console.Write("{0} ", array[0] = random.Next(0, 10));
            for (int i = 1; i < k; i++)
            {
                array[i] = random.Next(0, 10);
                Console.Write("{0} ", array[i]);
                if (array[i] < array[min])
                    min = i;
            }
            Console.WriteLine();
            while (true)
            {
                if (flag == true)
                {
                    b = array[min];
                    array[min] = array[m];
                    array[m] = b;
                    m++;
                    flag = false;
                }
                else
                {
                    b = array[min];
                    array[min] = array[k - 1];
                    array[k - 1] = b;
                    k--;
                    flag = true;
                }
                if (m >= k)
                    break;
                min = m;
                for (int i = m; i < k; i++)
                    if (array[i] < array[min])
                        min = i;
            }
            for (int i = 0; i < array.Length; i++)
            {
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