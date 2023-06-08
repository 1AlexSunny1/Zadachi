namespace _16
{
    using System;
    class Program
    {
        static void Main()
        {
            Random random = new Random();
            int[] array = new int[1000];
            int e1 = 0, length = 0, vl = 0, number = 1;
            array[0] = random.Next(1, 7);
            for (int i = 1; i < array.Length; i++)
            {
                array[i] = random.Next(1, 7);
                if (array[i] == array[i - 1] || i == array.Length - 1)
                {
                    number++;
                    if (i == array.Length - 1 && number >= length)
                    {
                        length = number;
                        e1 = i + 1;
                        vl = array[i - 1];
                    }
                }
                else
                {
                    if (number >= length)
                    {
                        length = number;
                        e1 = i;
                        vl = array[i - 1];
                    }
                    number = 1;
                }
            }
            Console.WriteLine("Длина цепочки: {0}", length);
            Console.WriteLine("Индекс начального элемента : {0}", e1 - length);
            Console.WriteLine("Значение: {0}", vl);
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