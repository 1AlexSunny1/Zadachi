namespace _25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int[] arr = new int[20];
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {

                Console.Write("{0} ",i);
            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-10, 11);
                Console.Write("{0} ",arr[i]);
            }
            Console.WriteLine();
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (!Existed(arr, i)) count++;

            }
            int[,] arr1 = new int[count, 3];
            int b = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (!Existed(arr, i))
                {
                    arr1[b, 0] = arr[i];
                    arr1[b, 1] = Check(arr, arr[i]);
                    arr1[b, 2] = Action(arr, arr[i], arr[i] < 0);
                    b++;
                }

            }
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0,5}", arr1[i, j]);
                }
                Console.WriteLine();
            }
        }
        static int Check(int[] arr, int a)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == a) count++;
            }
            return count;
        }
        static int Action(int[] arr, int a, bool e)
        {
            int b = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == a)
                {
                    b = i;
                    if (e) break;
                }
            }
            return b;
        }
        static bool Existed(int[] arr, int index)
        {
            if (index >= arr.Length) throw new Exception();
            if (index == 0) return false;
            for (int i = 0; i < index; i++)
            {
                if (arr[i] == arr[index]) return true;
            }
            return false;
        }
    }
}
