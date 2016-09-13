using Core.Utils;
using NUnit.Framework;

namespace Tests.Utils
{
    public class StringExtensionsTests
    {
        [Test]
        [TestCase("-", 1)]
        [TestCase("-", 2)]
        [TestCase("-", 5)]
        [TestCase("-", 100)]
        [TestCase("abc", 1)]
        [TestCase("abc", 2)]
        [TestCase("abc", 5)]
        [TestCase("abc", 100)]
        public void Repeat_Repeats_Pattern(string pattern, int times)
        {
            string str = pattern.Repeat(times);

            Assert.That(str.Length, Is.EqualTo(pattern.Length * times));
            Assert.That(str, Does.Match($"(?:{pattern}){{{times}}}"));
        }
    }
}