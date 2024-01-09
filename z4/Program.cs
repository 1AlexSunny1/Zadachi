using System.Diagnostics;

namespace Program
{
    class Programm
    {
        static void Main()
        {
            object[] ob100 = new object[100];
            object[] ob1000 = new object[1000];
            object[] ob10000 = new object[10000];
            Pack(ob100);
            Pack(ob1000);
            Pack(ob10000);
            Console.WriteLine();
            Unpack(ob100);
            Unpack(ob1000);
            Unpack(ob10000);
            Console.WriteLine();
            End();
        }
        static void Pack(object[] objs)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i] = i;
            }
            sw.Stop();
            Console.WriteLine("Массив размером {0} запакован за {1} тиков", objs.Length, sw.ElapsedTicks);
        }
        static int[] Unpack(object[] objs)
        {
            int[] ints = new int[objs.Length];
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < objs.Length; i++)
            {
                ints[i] = (int)objs[i];
            }
            sw.Stop();
            Console.WriteLine("Массив размером {0} распакован за {1} тиков", objs.Length, sw.ElapsedTicks);
            return ints;
        }
        static void End()
        {
            Console.WriteLine("Чтобы перезапустить программу - Enter");
            Console.WriteLine("Чтобы выйти - любую другую клавишу");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {

                Main();
                return;
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
