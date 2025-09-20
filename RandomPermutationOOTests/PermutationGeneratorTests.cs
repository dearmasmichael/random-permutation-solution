using System.Linq;
using Xunit;
using RandomPermutationOOApp;

namespace RandomPermutationOOApp.Tests
{
    public class PermutationGeneratorTests
    {
        [Fact]
        public void GeneratesCorrectLength()
        {
            var generator = new PermutationGenerator(10000);
            var result = generator.Generate();
            Assert.Equal(10000, result.Count);
        }

        [Fact]
        public void AllNumbersUnique()
        {
            var generator = new PermutationGenerator(10000);
            var result = generator.Generate();
            Assert.Equal(result.Count, result.Distinct().Count());
        }

        [Fact]
        public void RangeIsCorrect()
        {
            var generator = new PermutationGenerator(10000);
            var result = generator.Generate();
            Assert.Equal(1, result.Min());
            Assert.Equal(10000, result.Max());
        }

        [Fact]
        public void ThrowsOnInvalidSize()
        {
            Assert.Throws<System.ArgumentException>(() => new PermutationGenerator(0));
        }
    }
}
