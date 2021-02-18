using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //\n is Unix, \r is Mac, \r\n is Windows
            //* '\n' or '0x0A' (10 in decimal) -> This character is called "Line Feed" (LF).
            //* '\r' or '0x0D' (13 in decimal) -> This one is called "Carriage return" (CR).

            Console.WriteLine("Josef Novák\nJindrišská 16\n111 50, Praha 1");

            string[] @for = { "John", "James", "Joan", "Jamie" };
            for (int ctr = 0; ctr < @for.Length; ctr++)
            {
                Console.WriteLine($"Here is your gift, {@for[ctr]}!");
            }

            string s1 = "He said, \"This is the last \u0063hance\x0021\"";
            string s2 = @"He said, ""This is the last \u0063hance\x0021""";

            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }
    }
}
