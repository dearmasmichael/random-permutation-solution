using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomPermutationApp
{
    /// <summary>
    /// Provides functionality to generate random permutations of integers.
    /// Implements the Fisher–Yates shuffle algorithm.
    /// </summary>
    public static class PermutationGenerator
    {
        // Shared Random instance to avoid reseeding bias when Generate is called multiple times quickly
        private static readonly Random rng = new Random();

        /// <summary>
        /// Generates a random permutation of integers from 1 to n (inclusive).
        /// </summary>
        /// <param name="n">The size of the permutation (must be >= 1).</param>
        /// <returns>A list containing a uniformly random permutation of the numbers 1..n.</returns>
        /// <exception cref="ArgumentException">Thrown if n is less than 1.</exception>
        public static List<int> Generate(int n)
        {
            if (n < 1) 
                throw new ArgumentOutOfRangeException(nameof(n), "n must be at least 1.");

            // Start with an ordered list [1, 2, 3, ..., n]
            var arr = Enumerable.Range(1, n).ToList();

            // Perform Fisher–Yates shuffle
            for (int i = n - 1; i > 0; i--)
            {
                // Pick a random index j between 0 and i (inclusive)
                int j = rng.Next(i + 1);

                // Swap arr[i] with arr[j]
                (arr[i], arr[j]) = (arr[j], arr[i]); // swap
            }

            return arr;
        }
    }
}
