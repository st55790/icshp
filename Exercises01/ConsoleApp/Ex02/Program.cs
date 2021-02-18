using System;

namespace Ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Print alphabetic");

            for (char i = 'a'; i <= 'z'; i++) {
            //    Console.WriteLine(i);
            }

            char actual = 'a';
            while (actual <= 'z') {
                //Console.WriteLine(actual);
                actual++;
            }

            actual = 'A';
            do
            {
                Console.WriteLine(actual);
                actual++;
            } while (actual <= 'Z');
        }
    }
}
