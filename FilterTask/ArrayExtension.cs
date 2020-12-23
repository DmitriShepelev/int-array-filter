using System;
using System.Collections.Generic;

namespace FilterTask
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that contain expected digit from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="digit">Expected digit.</param>
        /// <returns>Array of elements that contain expected digit.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when digit value is out of range (0..9).</exception>
        /// <example>
        /// {1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}  => { 7, 70, 17 } for digit = 7.
        /// </example>
        public static int[] FilterByDigit(int[] source, int digit)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"Array can not be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"Array can not be empty.");
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException($"Expected digit can not be less than zero and more than nine.");
            }

            var list = new List<int>();
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == digit)
                {
                    list.Add(source[i]);
                }
                else if (IsContainsDigit(source[i], digit))
                {
                    list.Add(source[i]);
                }
            }

            return list.ToArray();
        }

        private static bool IsContainsDigit(int number, int digit)
        {
            number = Math.Abs(number);
            while (number > 0)
            {
                if (number % 10 == digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
