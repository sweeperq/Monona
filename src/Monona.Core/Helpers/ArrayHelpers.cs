using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Monona.Core.Helpers
{
    public static class ArrayHelpers
    {
        public static int[] StringToIntArray(string value)
        {
            if (value.IsEmpty() || !Regex.IsMatch(value, @"^[\s,0-9]+$"))
                return null;
            return value.Split(',').Select(s => int.Parse(s.Trim())).ToArray();
        }

        public static string IntArrayToString(int[] array)
        {
            if (array == null)
                return string.Empty;
            return string.Join(",", array);
        }
    }
}
