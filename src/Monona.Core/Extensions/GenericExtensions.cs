using System.Collections.Generic;

namespace System
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Throw an exception if the value is null
        /// </summary>
        /// <typeparam name="T">Type of value (class)</typeparam>
        /// <param name="value">Value to check for null</param>
        /// <param name="paramName">Name of parameter containing the value</param>
        /// <exception cref="ArgumentNullException">Thrown if value is null</exception>
        public static void ThrowIfNull<T>(this T value, string paramName)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Throw an exception if the value is null
        /// </summary>
        /// <typeparam name="T">Type of value (nullable struct)</typeparam>
        /// <param name="value">Value to check for null</param>
        /// <param name="paramName">Name of parameter containing the value</param>
        /// <exception cref="ArgumentNullException">Thrown if value is null</exception>
        public static void ThrowIfNull<T>(this T? value, string paramName)
            where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Perform an action for each item in a collection
        /// </summary>
        /// <typeparam name="T">Type of items in collection</typeparam>
        /// <param name="collection">Collection of items</param>
        /// <param name="action">Action to perform for each item</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection != null)
            {
                foreach (T item in collection)
                {
                    action(item);
                }
            }
        }
    }
}
