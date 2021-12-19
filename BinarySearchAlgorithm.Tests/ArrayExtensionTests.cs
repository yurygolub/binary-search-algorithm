using System;
using System.Collections.Generic;
using NUnit.Framework;
using static BinarySearchTask.ArrayExtension;

#pragma warning disable CA1707

namespace BinarySearchAlgorithm.Tests
{
    public class ArrayExtensionTests
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(
                    new Person[] { new Person("qwe") },
                    new Person("qwe"))
                    .Returns(0);

                yield return new TestCaseData(
                    new Person[] { new Person("asd"), new Person("qwe"), new Person("zxc") },
                    new Person("zxc"))
                    .Returns(2);

                yield return new TestCaseData(
                    new Person[] { new Person("asd"), new Person("qwe"), new Person("zxc") },
                    new Person("qwerty"))
                    .Returns(null);

                yield return new TestCaseData(
                    new Person[] { new Person("a"), new Person("b"), new Person("d"), new Person("f"), new Person("g") },
                    new Person("f"))
                    .Returns(3);
            }
        }

        [TestCase(new[] { 6 }, 6, ExpectedResult = 0)]
        [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 6, ExpectedResult = 3)]
        [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 1, ExpectedResult = 0)]
        [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 11, ExpectedResult = 6)]
        [TestCase(new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 634 }, 144, ExpectedResult = 9)]
        [TestCase(new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377 }, 21, ExpectedResult = 5)]
        public int BinarySearch_ReturnIndexOfValueInArray(int[] source, int value)
        {
            return BinarySearch(source, value).Value;
        }

        [TestCase(new[] { 6 }, 7, ExpectedResult = null)]
        [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 0, ExpectedResult = null)]
        [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 14, ExpectedResult = null)]
        [TestCase(new[] { 1, 3, 4, 6, 8, 9, 11 }, 11, ExpectedResult = 6)]
        [TestCase(new int[] { }, 144, ExpectedResult = null)]
        [TestCase(new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377 }, 21, ExpectedResult = 5)]
        public int? BinarySearch_ReturnNull(int[] source, int value)
        {
            return BinarySearch(source, value);
        }

        [Test]
        public void BinarySearch_SourceArrayIsNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => BinarySearch(null, 1), "Source array cannot be null.");

        [TestCaseSource(nameof(TestCases))]
        public int? BinarySearch_WithComparer_ReturnIndexOfValueInArray(Person[] source, Person value)
        {
            return BinarySearch(source, value, new PersonComparer());
        }

        [Test]
        public void BinarySearch_ComparerIsNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => BinarySearch(Array.Empty<int>(), 1, null), "Comparer cannot be null.");
    }
}
