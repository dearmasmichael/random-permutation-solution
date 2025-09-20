using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomPermutationOOApp
{
    /// <summary>
    /// Generates random permutations of integers from 1..N
    /// using the Fisher–Yates shuffle algorithm.
    /// </summary>
    public class PermutationGenerator
    {
        private readonly int _size;

        // Shared Random instance across all objects.
        // This avoids repeatedly reseeding (which can hurt randomness
        // if multiple instances are created quickly).
        private static readonly Random _rng = new Random();

        /// <summary>
        /// Constructor ensures the permutation size is valid.
        /// </summary>
        /// <param name="size">Number of integers in the permutation (>= 1).</param>
        /// <exception cref="ArgumentException">Thrown if size < 1.</exception>
        public PermutationGenerator(int size)
        {
            if (size < 1)
                throw new ArgumentException("Size must be >= 1", nameof(size));

            _size = size;
        }

        /// <summary>
        /// Generates and returns a random permutation of integers [1..N].
        /// </summary>
        /// <returns>A shuffled list of integers of length N.</returns>
        public List<int> Generate()
        {
            // Start with the ordered list [1, 2, ..., N].
            var arr = Enumerable.Range(1, _size).ToList();

            // Fisher–Yates shuffle:
            // Walk backward through the array; for each position i,
            // choose a random index j <= i and swap arr[i] with arr[j].
            // Guarantees a uniform random permutation in O(N).
            for (int i = _size - 1; i > 0; i--)
            {
                int j = _rng.Next(i + 1);
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }

            return arr;
        }
    }
}
