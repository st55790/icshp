using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fei.BaseLib
{
    public class ExtraMath
    {
        /// <summary>
        /// Method returns true if quadratic equation has a solution in the field of real numbers and
        /// returns false if it hasn't. 
        /// </summary>
        /// <param name="a">The first term in the equation (x^2)</param>
        /// <param name="b">The second term in the equation (x)</param>
        /// <param name="c">The third term in the equation (number)</param>
        /// <returns>true or false</returns>
        public static bool QuadraticEquation(double a, double b, double c)
        {
            if ((Math.Pow(b, 2) - 4 * a * c) == 0)
            {
                return true;
            }
            else if ((Math.Pow(b, 2) - 4 * a * c) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method return random number from range entered by parameters.
        /// </summary>
        /// <param name="min">The lowest number</param>
        /// <param name="max">The highest number</param>
        /// <returns>Random number from range</returns>
        public static double GenerateRandomNumbera(int min, int max)
        {
            Random rnd = new Random();
            return rnd.NextDouble() * (max - min) + min;
        }
    }
}
