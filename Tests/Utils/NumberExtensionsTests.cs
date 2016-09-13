using Core.Utils;
using NUnit.Framework;
using System.Linq;

namespace Tests.Utils
{
    internal class NumberExtensionsTests
    {
        [Test]
        [Category("Dummy")]
        [Category("Unitary")]
        [Category("Transversal")]
        [TestCase(0, 0, true)]
        [TestCase(1, 0, false)]
        [TestCase(0, 1, false)]
        [TestCase(10, 3, false)]
        [TestCase(10, -3, false)]
        [TestCase(10, 5, true)]
        [TestCase(-10, 5, true)]
        [TestCase(-10, -5, true)]
        [TestCase(10, -5, true)]
        [TestCase(5, 10, false)]
        [TestCase(5, -10, false)]
        [TestCase(-5, -10, false)]
        [TestCase(-5, 10, false)]
        public void NumberExtensions_can_check_if_an_integer_is_a_multiple_of_another(int potentialMultiple, int anotherInteger, bool expectedResult)
        {
            bool result = potentialMultiple.IsMultipleOf(anotherInteger);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [Category("Dummy")]
        [Category("Unitary")]
        [TestCase(0, 0, true)]
        [TestCase(1, 0, false)]
        [TestCase(0, 1, false)]
        [TestCase(3, 10, false)]
        [TestCase(-3, 10, false)]
        [TestCase(10, 5, false)]
        [TestCase(-10, 5, false)]
        [TestCase(-10, -5, false)]
        [TestCase(10, -5, false)]
        [TestCase(5, 10, true)]
        [TestCase(5, -10, true)]
        [TestCase(-5, -10, true)]
        [TestCase(-5, 10, true)]
        public void NumberExtensions_can_check_if_an_integer_is_a_divider_of_another(int potentialDivider, int anotherInteger, bool expectedResult)
        {
            bool result = potentialDivider.IsDividerOf(anotherInteger);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [Category("Dummy")]
        [Category("Unitary")]
        public void NumberExtensions_can_check_if_an_integer_is_a_prime_number()
        {
            int[] integers = { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19 };
            int[] notPrimes = integers.Except(primes).ToArray();

            foreach (int number in primes)
            {
                Assert.That(number.IsPrime(), Is.True);
            }
            foreach (int number in notPrimes)
            {
                Assert.That(number.IsPrime(), Is.False);
            }
        }

        [Test]
        [Category("Dummy")]
        [Category("Unitary")]
        public void NumberExtensions_can_get_prime_numbers()
        {
            int[] integers = { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19 };

            Assert.That(integers.GetPrimes(), Is.EquivalentTo(primes));
        }
    }
}