using System.Linq;
using Xunit;
using RandomPermutationApp;

namespace RandomPermutationApp.Tests
{
    public class PermutationTests
    {
        [Fact]
        public void GeneratesCorrectLength()
        {
            var result = PermutationGenerator.Generate(10000);
            Assert.Equal(10000, result.Count);
        }

        [Fact]
        public void AllNumbersUnique()
        {
            var result = PermutationGenerator.Generate(10000);
            Assert.Equal(result.Count, result.Distinct().Count());
        }

        [Fact]
        public void RangeIsCorrect()
        {
            var result = PermutationGenerator.Generate(10000);
            Assert.Equal(1, result.Min());
            Assert.Equal(10000, result.Max());
        }
    }
}