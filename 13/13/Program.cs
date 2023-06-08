namespace _13
{
    internal class Program
    {
        static void Main()
        {
            Random random = new Random();
            int a1 = 10, a2 = 17, min = 0, min2 = 0, max = 0, jj = 0;
            int[] array1 = new int[a1];
            int[] array2 = new int[a2];
            int[] array3 = new int[a1 + a2];
            for (int i = 0; i < array1.Length; i++)
                array1[i] = random.Next(-9, 10);
            Array.Sort(array1);
            for (int i = 0; i < array1.Length; i++)
                Console.Write("{0} ", array1[i]);
            Console.WriteLine();
            for (int i = 0; i < array2.Length; i++)
                array2[i] = random.Next(-9, 10);
            Array.Reverse(array2);
            for (int i = 0; i < array2.Length; i++)
                Console.Write("{0} ", array2[i]);
            Console.WriteLine();
            min = max = array1[0];
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] < min)
                    min = array1[i];
                if (array1[i] > max)
                    max = array1[i];
            }
            for (int i = 0; i < array2.Length; i++)
            {
                if (array2[i] < min)
                    min = array2[i];
                if (array2[i] > max)
                    max = array2[i];
            }
            array3[0] = min;
            min2 = min;
            for (int j = 1; j < array3.Length; j++)
            {
                for (int i = 0; i < array1.Length; i++)
                    if (array1[i] > min2)
                    {
                        min = array1[i];
                        break;
                    }
                for (int i = 0; i < array2.Length; i++)
                    if (array2[i] > min2)
                    {
                        min = array2[i];
                        break;
                    }
                for (int i = 0; i < array1.Length; i++)
                    if (array1[i] < min && array1[i] > min2)
                        min = array1[i];
                for (int i = 0; i < array2.Length; i++)
                    if (array2[i] < min && array2[i] > min2)
                        min = array2[i];
                array3[j] = min;
                min2 = min;
                if (min == max)
                {
                    jj = j;
                    break;
                }
            }
            for (int i = 0; i <= jj; i++)
            {
                Console.Write("{0} ", array3[i]);
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