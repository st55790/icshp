using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fei.BaseLib
{
    public class MathConvertor
    {
        /// <summary>
        ///  Method convert decimal number to binary.
        /// </summary>
        /// <param name="number">Decimal number as integer</param>
        /// <returns>Return binary number as string</returns>
        public static string DecimalToBinary(int number) {
            return Convert.ToString(number, 2);
        }

        /// <summary>
        /// Method convert binary number to decimal number.
        /// </summary>
        /// <param name="number">Binary number as interger</param>
        /// <returns>Return decimal number as string</returns>
        public static string BinaryToDecimal(int number) {
            return Convert.ToInt32(number.ToString(), 2).ToString();
        }

        /// <summary>
        /// Method return decimal number as rome number. This method is from stackoverflow.
        /// Uses recursion.
        /// https://stackoverflow.com/questions/7040289/converting-integers-to-roman-numerals
        /// /// </summary>
        /// <param name="number">Decimal number as integer.</param>
        /// <returns>Return rome number as string.</returns>
        public static string DecimalToRome(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + DecimalToRome(number - 1000);
            if (number >= 900) return "CM" + DecimalToRome(number - 900);
            if (number >= 500) return "D" + DecimalToRome(number - 500);
            if (number >= 400) return "CD" + DecimalToRome(number - 400);
            if (number >= 100) return "C" + DecimalToRome(number - 100);
            if (number >= 90) return "XC" + DecimalToRome(number - 90);
            if (number >= 50) return "L" + DecimalToRome(number - 50);
            if (number >= 40) return "XL" + DecimalToRome(number - 40);
            if (number >= 10) return "X" + DecimalToRome(number - 10);
            if (number >= 9) return "IX" + DecimalToRome(number - 9);
            if (number >= 5) return "V" + DecimalToRome(number - 5);
            if (number >= 4) return "IV" + DecimalToRome(number - 4);
            if (number >= 1) return "I" + DecimalToRome(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }

        /// <summary>
        /// Method return rome number as decimal number. This method is from stackoverflow.
        /// Uses Dictionary RomanMap.
        /// https://stackoverflow.com/questions/14900228/roman-numerals-to-integers
        /// </summary>
        /// <param name="roman">Rome number as string.</param>
        /// <returns>Return decimal number as integer.</returns>
        public static string RomeToDecimal(string roman) {
            int number = 0;
            char previousChar = roman[0];
            foreach (char currentChar in roman)
            {
                number += RomanMap[currentChar];
                if (RomanMap[previousChar] < RomanMap[currentChar])
                {
                    number -= RomanMap[previousChar] * 2;
                }
                previousChar = currentChar;
            }
            return number.ToString();
        }

        /// <summary>
        /// Dictionary Roman char and numbers. Used for method RomeToDecimal.
        /// </summary>
        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
    }
}
