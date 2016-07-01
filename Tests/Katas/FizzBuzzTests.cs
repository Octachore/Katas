using System.Collections.Generic;
using System.Linq;
using Core.Katas.FizzBuzz;
using Core.Utils;
using NUnit.Framework;

namespace Tests.Katas
{
    internal class FizzBuzzTests
    {
        [Test]
        [Category("Playground")]
        [Category("Dummy")]
        [Category("Transversal")]
        public void FizzBuzzTest()
        {
            var constraints = new List<Constraint<int, string>>()
            {
                new Constraint<int, string>((i) => i.IsMultipleOf(3), "fizz"),
                new Constraint<int, string>((i) => i.IsMultipleOf(5), "buzz")
            };

            var replacer = new Replacer<int, string>((strings) => string.Join(string.Empty, strings), constraints.ToArray());

            var output = replacer.Replace(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            var expectedOutput = new string[] { "0", "1", "2", "fizz", "4", "buzz", "fizz", "7", "8", "fizz", "buzz", "11", "fizz", "13", "14", "fizzbuzz" };
            Assert.That(output, Is.EquivalentTo(expectedOutput));
        }

        [Test]
        [Category("Playground")]
        [Category("Dummy")]
        [Category("Transversal")]
        public void FizzBuzzTest2()
        {
            var constraints = new List<Constraint<int, int>>()
            {
                new Constraint<int, int>((i) => i.IsMultipleOf(3), -7),
                new Constraint<int, int>((i) => i.IsMultipleOf(5), 8)
            };

            var replacer = new Replacer<int, int>((integers) => integers.Sum(), constraints.ToArray());

            var output = replacer.Replace(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            var expectedOutput = new int[] { 0, 1, 2, -7, 4, 8, -7, 7, 8, -7, 8, 11, -7, 13, 14, 1 };
            Assert.That(output, Is.EquivalentTo(expectedOutput));
        }


        [Test]
        [Category("Playground")]
        [Category("Dummy")]
        [Category("Transversal")]
        public void FizzBuzzTest3()
        {
            var constraints = new List<Constraint<int, int>>()
            {
                new Constraint<int, int>((i) => i.IsPrime(), 0),
                new Constraint<int, int>((i) => i.IsMultipleOf(3), -1),
                new Constraint<int, int>((i) => i.IsMultipleOf(5), 2)
            };

            var replacer = new Replacer<int, int>((integers) => integers.Sum(), constraints.ToArray());

            var output = replacer.Replace(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            var expectedOutput = new int[] { 0, 1, 0, -1, 4, 2, -1, 0, 8, -1, 2, 0, -1, 0, 14, 1 };
            Assert.That(output, Is.EquivalentTo(expectedOutput));
        }
    }
}
