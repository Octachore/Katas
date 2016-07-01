using Core.Utils;
using NUnit.Framework;

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
    }
}
