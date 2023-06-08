namespace _15
{
    internal class Program
    {
        static void Main()
        {
            int[] arr = new int[20];
            Random rnd = new Random();

            static bool Check(int[] arr, int index)
            {
                for (int i = 0; i < index; i++)
                {
                    if (arr[i] == arr[index]) return false;
                }
                return true;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 10);
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
            while (true)
            {
                int count = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!Check(arr, i))
                    {
                        arr[i] *= i;
                        count++;
                    }
                }
                if (count == 0) break;
            }
            Console.WriteLine();
            arr[0] = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
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

