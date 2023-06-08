namespace _7
{
    internal class Program
    {
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
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            int nul = 0;
            int length = array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0) nul++;
            }
            for (int i = 0; i < length; i++) 
            {
                if (array[i] == 0)
                {
                    int a = i;
                    for (int index = i + 1; index < array.Length; index++)
                    {
                        int c = array[index];
                        array[index] = array[a];
                        array[a] = c;
                        a++;
                    }
                    length--;
                    if (array[i]==0)
                    {
                        i--;
                    }
                }
            }
            for (int i = 0; i < length; i++)
            {
                Console.Write("{0} ",array[i]); 
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