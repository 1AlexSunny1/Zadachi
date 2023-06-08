namespace _11
{
    internal class Program
    {
        static void Main()
        {
            Random random = new Random();
            int a = 10, min = 0, max = 0;
            bool flag, t = true;
            int[] array = new int[a];
            array[0] = random.Next(0, 10);
            Console.Write("{0} ", array[0]);
            min = max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                array[i] = random.Next(0, 10);
                Console.Write("{0} ", array[i]);
                if (array[i] < min)
                {
                    min = array[i];
                }
                if (array[i] > max)
                {
                    max = array[i];
                }
                    
            }
            Console.WriteLine();
            Console.WriteLine("Целые числа в интервале[{0},{1}] не входящие в массив:", min, max);
            for (int i = min + 1; i < max; i++)
            {
                flag = true;
                for (int j = 0; j < a; j++)
                    if (i == array[j])
                        flag = false;
                if (flag == true)
                {
                    Console.Write("{0} ", i);
                    t = false;
                }
            }
            if (t == true)
                Console.WriteLine("Отсутвуют");

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