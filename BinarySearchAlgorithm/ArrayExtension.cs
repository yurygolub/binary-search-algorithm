using System;
using System.Collections.Generic;

namespace BinarySearchTask
{
    /// <summary>
    /// Class for basic array operations.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Implements binary search.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="source">Source sorted array.</param>
        /// <param name="value">Value to search.</param>
        /// <param name="comparer">Comparer.</param>
        /// <returns>
        /// The position of an element with a given value in sorted array.
        /// If element is not found returns null.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        public static int? BinarySearch<T>(T[] source, T value, IComparer<T> comparer)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            int left = 0, right = source.Length - 1, middle;
            T guess;
            while (left <= right)
            {
                middle = (left + right) / 2;
                guess = source[middle];

                if (comparer.Compare(guess, value) == 0)
                {
                    return middle;
                }

                if (comparer.Compare(guess, value) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return null;
        }

        /// <summary>
        /// Implements binary search.
        /// </summary>
        /// <typeparam name="T">Comparable type.</typeparam>
        /// <param name="source">Source sorted array.</param>
        /// <param name="value">Value to search.</param>
        /// <returns>
        /// The position of an element with a given value in sorted array.
        /// If element is not found returns null.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        public static int? BinarySearch<T>(T[] source, T value)
            where T : IComparable
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int left = 0, right = source.Length - 1, middle;
            T guess;
            while (left <= right)
            {
                middle = (left + right) / 2;
                guess = source[middle];

                if (guess.CompareTo(value) == 0)
                {
                    return middle;
                }

                if (guess.CompareTo(value) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return null;
        }
    }
}
