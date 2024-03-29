﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sudoku.Tests
{
    class TestIntegration
    {
        private SudokuManager goodSudoku;
        private SudokuManager badSudoku;

        [SetUp]
        protected void SetUp()
        {
            string binDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(binDirectory).Parent.Parent.FullName;
            string basePath = Path.Combine(projectDirectory, "Levels");

            goodSudoku = Loader.LoadLevel($@"{basePath}\test1.txt");
            badSudoku = Loader.LoadLevel($@"{basePath}\test2.txt");
        }

        // test the Row(index).IsValid() etc combinations
        [Test]
        public void FirstRow_IsValid_ReturnsTrue()
        {
            bool expected = true;

            bool actual = goodSudoku.Row(0).IsValid();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void LastRow_IsValid_ReturnsFalse()
        {
            bool expected = false;

            bool actual = badSudoku.Row(3).IsValid();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FirstSection_IsComplete_ReturnsFalse()
        {
            bool expected = false;

            bool actual = goodSudoku.Section(0).IsComplete();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MiddleSection_IsComplete_ReturnsTrue()
        {
            bool expected = true;

            bool actual = badSudoku.Section(2).IsComplete();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MiddleColumn_IsCorrect_ReturnsTrue()
        {
            bool expected = true;

            bool actual = goodSudoku.Column(2).IsCorrect();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FirstColumn_IsCorrect_ReturnsFalse()
        {
            bool expected = false;

            bool actual = badSudoku.Column(0).IsCorrect();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MiddleRow_GetValidValues_ReturnsExpectedValues()
        {
            List<int> expected = new List<int>() { 1, 2, 4 };

            List<int> actual = goodSudoku.Row(1).GetValidValues();

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void LastSection_GetInvalidValues_ReturnsExpectedValues()
        {
            List<int> expected = new List<int>() { 2, 3, 4 };

            List<int> actual = goodSudoku.Section(3).GetInvalidValues();

            Assert.That(actual, Is.EquivalentTo(expected));
        }
    }
}
