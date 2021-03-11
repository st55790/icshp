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
        /// <param name="x1">root 1</param>
        /// <param name="x2">root 2</param>
        /// <returns>true or false and results int x1 a x2</returns>
        public static bool QuadraticEquation(double a, double b, double c, out double x1, out double x2)
        {
            if ((Math.Pow(b, 2) - 4 * a * c) == 0)
            {
                x1 = -b / 2 * a;
                x2 = x1;
                return true;
            }
            else if ((Math.Pow(b, 2) - 4 * a * c) > 0)
            {
                double diskriminant = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
                x1 = (-b + diskriminant) / 2 * a;
                x2 = (-b - diskriminant) / 2 * a;
                return true;
            }
            x1 = double.NaN;
            x2 = x1;
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
