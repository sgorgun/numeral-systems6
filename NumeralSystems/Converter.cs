using System;
using System.Diagnostics;
using System.Text;

namespace NumeralSystems
{
    public static class Converter
    {
        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the octal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the octal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveOctal(this int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Number is less than zero.", nameof(number));
            }

            return Convert((uint)number, 8);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the decimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the decimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveDecimal(this int number)
                {
                    if (number <= 0)
                    {
                        throw new ArgumentException("Number is less than zero.", nameof(number));
                    }

                    return Convert((uint)number, 10);
                }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the hexadecimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the hexadecimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveHex(this int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Number is less than zero.", nameof(number));
            }

            return Convert((uint)number, 16);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveRadix(this int number, int radix)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Number is less than zero.", nameof(number));
            }

            if (radix == 8 || radix == 10 || radix == 16)
            {
                return Convert((uint)number, (uint)radix);
            }

            throw new ArgumentException($"{nameof(radix)} is 8, 10 and 16 only.");
        }

        /// <summary>
        /// Gets the value of a signed integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        public static string GetRadix(this int number, int radix)
        {
            if (radix == 10 || radix == 8 || radix == 16)
            {
                return Convert((uint)number, (uint)radix);
            }

            throw new ArgumentException($"{nameof(radix)} is 8, 10 and 16 only.");
        }

        private static string Convert(uint number, uint radix)
        {
            StringBuilder resultUnreversed = new StringBuilder();
            for (; number > 0; number /= radix)
            {
                uint term = number % radix;

                if (term >= 10)
                {
                    char hex = term switch
                    {
                        10 => 'A',
                        11 => 'B',
                        12 => 'C',
                        13 => 'D',
                        14 => 'E',
                        _ => 'F'
                    };
                    resultUnreversed.Append(hex);
                }
                else
                {
                    resultUnreversed.Append(term);
                }
            }

            StringBuilder result = new StringBuilder();

            for (int i = resultUnreversed.Length - 1; i != -1; i--)
            {
                result.Append(resultUnreversed[i]);
            }

            return result.ToString();
        }
    }
}
