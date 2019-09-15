using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sudoku
{
    class TestGridPart
    {
        private readonly int[] valuesWith0 = { 0, 1, 2, 3, 4, 5 };
        private readonly int[] valuesWithDuplicate = { 1, 1, 2, 3, 4, 5 };
        private readonly int[] valuesWith7 = { 1, 2, 3, 4, 5, 7 };
        private readonly int[] valuesCorrect = { 1, 2, 3, 4, 5, 6 };
        private readonly int[] valuesSparse = { 0, 1, 0, 4, 0, 6 };
        private GridPart thePart;

        [Test]
        public void IsValid_Contains0_ReturnsTrue()
        {
            thePart = new GridPart(valuesWith0);
            bool expected = true;

            bool actual = thePart.IsValid();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsValid_DuplicateValue_ReturnsFalse()
        {
            thePart = new GridPart(valuesWithDuplicate);
            bool expected = false;

            bool actual = thePart.IsValid();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsValid_OutOfRangeValue_ReturnsFalse()
        {
            thePart = new GridPart(valuesWith7);
            bool expected = false;

            bool actual = thePart.IsValid();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsValid_CorrectValues_ReturnsTrue()
        {
            thePart = new GridPart(valuesCorrect);
            bool expected = true;

            bool actual = thePart.IsValid();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsComplete_DuplicateValue_ReturnsTrue()
        {
            thePart = new GridPart(valuesWithDuplicate);
            bool expected = true;

            bool actual = thePart.IsComplete();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsComplete_Contains0_ReturnsFalse()
        {
            thePart = new GridPart(valuesWith0);
            bool expected = false;

            bool actual = thePart.IsComplete();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsComplete_OutOfRangeValue_ReturnsTrue()
        {
            thePart = new GridPart(valuesWith7);
            bool expected = true;

            bool actual = thePart.IsComplete();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsComplete_CorrectValues_ReturnsTrue()
        {
            thePart = new GridPart(valuesCorrect);
            bool expected = true;

            bool actual = thePart.IsComplete();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsCorrect_Contains0_ReturnsFalse()
        {
            thePart = new GridPart(valuesWith0);
            bool expected = false;

            bool actual = thePart.IsCorrect();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsCorrect_DuplicateValues_ReturnsFalse()
        {
            thePart = new GridPart(valuesWithDuplicate);
            bool expected = false;

            bool actual = thePart.IsCorrect();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsCorrect_OutOfRangeValue_ReturnsFalse()
        {
            thePart = new GridPart(valuesWith7);
            bool expected = false;

            bool actual = thePart.IsCorrect();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsCorrect_CorrectValues_ReturnsTrue()
        {
            thePart = new GridPart(valuesCorrect);
            bool expected = true;

            bool actual = thePart.IsCorrect();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetValidValues_ReturnsExpectedValues()
        {
            thePart = new GridPart(valuesSparse);
            List<int> expected = new List<int>() { 2, 3, 5 };

            List<int> actual = thePart.GetValidValues();

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void GetInvalidValues_ReturnsExpectedValues()
        {
            thePart = new GridPart(valuesSparse);
            List<int> expected = new List<int>() { 1, 4, 6 };

            List<int> actual = thePart.GetInvalidValues();

            Assert.That(actual, Is.EquivalentTo(expected));
        }
    }
}
