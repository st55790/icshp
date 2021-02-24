using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fei.BaseLib
{
    public class Reading
    {

        /// <summary>
        /// Method print message to screen and parse user input to double.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>user input as double</returns>

        public static double ReadDouble(string message)
        {
            Console.Write($"{message}: ");

            if (double.TryParse(Console.ReadLine(), out double parsedValue))
            {
                return parsedValue;
            }

            return double.NaN;
        }

        /// <summary>
        /// Method print message to screen and parse user input to int.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>user input as int</returns>

        public static int ReadInt(string message)
        {
            Console.Write($"{message}: ");

            if (int.TryParse(Console.ReadLine(), out int parsedValue))
            {
                return parsedValue;
            }

            return int.MinValue;
        }

        /// <summary>
        /// Method print message to screen and parse user input to char.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>user input as char</returns>

        public static char ReadChar(string message)
        {
            Console.Write($"{message}: ");
            string userInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userInput))
            {
                return userInput[0];
            }
            throw new InvalidCastException("String was empty or null");

        }

        /// <summary>
        /// Method print message to screen and parse user input to string.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>user input as string</returns>

        public static string ReadString(string message)
        {
            Console.Write($"{message}: ");
            return Console.ReadLine();
        }
    }
}
