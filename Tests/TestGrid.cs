using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sudoku.Tests
{
    class TestGrid
    {
        private Grid smallGrid;
        private readonly int[] testValues = {
                2, 3, 1, 4,
                0, 0, 3, 0,
                3, 0, 4, 0,
                0, 1, 2, 3
            };

        [SetUp]
        protected void SetUp()
        {
            smallGrid = new Grid(4,2,2);
            smallGrid.Set(testValues);
        }

        [Test]
        public void SetCell_ValidValue()
        {
            int testValue = 1;
            int testIndex = 5;

            smallGrid.SetCell(testValue, testIndex);
            int setValue = smallGrid.GetCell(testIndex);

            Assert.That(setValue, Is.EqualTo(testValue));
        }

        [Test]
        public void SetCell_LowerBoundaryValue()
        {
            int testValue = 0;
            int testIndex = 4;
            
            smallGrid.SetCell(testValue, testIndex);
            int setValue = smallGrid.GetCell(testIndex);

            Assert.That(setValue, Is.EqualTo(testValue));
        }

        [Test]
        public void SetCell_UpperBoundaryValue()
        {
            int testValue = 4;
            int testIndex = 5;

            smallGrid.SetCell(testValue, testIndex);
            int setValue = smallGrid.GetCell(testIndex);

            Assert.That(setValue, Is.EqualTo(testValue));
        }

        [Test]
        public void SetCell_InvalidValue()
        {
            int testValue = 6;
            int testIndex = 5;

            Assert.That(() => smallGrid.SetCell(testValue, testIndex), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void GetRow_MiddleRow()
        {
            int[] expected = { 0, 0, 3, 0 };
            int testRow = 1;

            int[] actual = smallGrid.GetRow(testRow);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetRow_LastRow()
        {
            int[] expected = { 0, 1, 2, 3 };
            int testRow = 3;

            int[] actual = smallGrid.GetRow(testRow);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetRow_InvalidRow()
        {
            int testRow = 5;

            Assert.That(() => smallGrid.GetRow(testRow), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void GetColumn_FirstColumn()
        {
            int[] expected = { 2, 0, 3, 0 };
            int testColumn = 0;

            int[] actual = smallGrid.GetColumn(testColumn);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetColumn_MiddleColumn()
        {
            int[] expected = { 1, 3, 4, 2 };
            int testColumn = 2;

            int[] actual = smallGrid.GetColumn(testColumn);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetColumn_InvalidColumn()
        {
            int testColumn = -3;

            Assert.That(() => smallGrid.GetColumn(testColumn), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void GetSection_FirstSection()
        {
            int[] expected = { 2, 3, 0, 0 };
            int testSection = 0;

            int[] actual = smallGrid.GetSection(testSection);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetSection_LastSection()
        {
            int[] expected = { 4, 0, 2, 3 };
            int testSection = 3;

            int[] actual = smallGrid.GetSection(testSection);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetSection_InvalidSection()
        {
            int testSection = 4;

            Assert.That(() => smallGrid.GetSection(testSection), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void FromCSV_MatchesExpectedOutput()
        {
            string csvContents = smallGrid.ToCSV();
            Grid testGrid = new Grid();

            testGrid.FromCSV(csvContents);

            Assert.That(testGrid, Is.EqualTo(smallGrid));
        }
    }
}
