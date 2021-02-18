using System;

namespace Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej rodné číslo");
            string pid = Console.ReadLine();
            ManOrWomanId(pid);
        }

        public static void ManOrWomanId(string pid)
        {
            if(int.Parse(pid[2].ToString()) <= 1)
            {
                Console.WriteLine("Jedna se o může\n");

            }
            else
            {
                Console.WriteLine("Jedna se o ženu!\n");
            }
        }
    }
}
