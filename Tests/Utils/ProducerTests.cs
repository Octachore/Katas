using Core.Utils;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests.Utils
{
    internal class ProducerTests
    {
        [Test]
        [Category("Dummy")]
        [Category("Unitary")]
        [TestCase(-3, -1, new[] { -3, -2, -1 })]
        [TestCase(-3, 0, new[] { -3, -2, -1, 0 })]
        [TestCase(-3, 1, new[] { -3, -2, -1, 0, 1 })]
        [TestCase(1, 3, new[] { 1, 2, 3 })]
        [TestCase(3, 1, new int[] { })]
        public void Producer_can_produce_integers(int minValue, int maxValue, IEnumerable<int> expectedOutput)
        {
            IEnumerable<int> output = Producer.ProduceIntegers(minValue, maxValue);

            Assert.That(output, Is.EquivalentTo(expectedOutput));
        }
    }
}