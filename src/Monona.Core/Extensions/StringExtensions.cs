using System.Linq;
using System.Text.RegularExpressions;

namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// Check to see if the string is empty
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if empty (null, empty, or white-space)</returns>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Throw an exception if the string is empty
        /// </summary>
        /// <param name="value">String to check for empty</param>
        /// <param name="paramName">Name of parameter containing the value</param>
        /// <exception cref="ArgumentEmptyException">Thrown if value is empty</exception>
        public static void ThrowIfEmpty(this string value, string paramName)
        {
            if (value.IsEmpty())
            {
                throw new ArgumentEmptyException(paramName);
            }
        }
    }
}
