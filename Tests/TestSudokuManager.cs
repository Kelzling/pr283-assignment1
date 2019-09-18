﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sudoku.Tests
{
    class TestSudokuManager
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

        [Test]
        public void FirstColumnFirstCell_GetByColumn_IsFirstColumnFirstCell()
        {
            int expected = 2;

            int actual = goodSudoku.GetByColumn(0, 0);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FirstColumnSecondCell_GetByColumn_IsFirstColumnSecondCell()
        {
            int expected = 0;

            int actual = goodSudoku.GetByColumn(0, 1);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SecondColumnFirstCell_GetByColumn_IsSecondColumnFirstCell()
        {
            int expected = 3;

            int actual = goodSudoku.GetByColumn(1, 0);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void LastColumnLastCell_GetByColumn_IsLastColumnLastCell()
        {
            int expected = 3;

            int actual = goodSudoku.GetByColumn(3, 3);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FirstColumnFirstCell_GetByRow_IsFirstColumnFirstCell()
        {
            int expected = 2;

            int actual = goodSudoku.GetByRow(0, 0);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FirstColumnSecondCell_GetByRow_IsFirstColumnSecondCell()
        {
            int expected = 0;

            int actual = goodSudoku.GetByRow(1, 0);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SecondColumnFirstCell_GetByRow_IsSecondColumnFirstCell()
        {
            int expected = 3;

            int actual = goodSudoku.GetByRow(0, 1);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void LastColumnLastCell_GetByRow_IsLastColumnLastCell()
        {
            int expected = 3;

            int actual = goodSudoku.GetByRow(3, 3);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FirstColumnFirstCell_GetBySquare_IsFirstColumnFirstCell()
        {
            int expected = 2;

            int actual = goodSudoku.GetBySquare(0, 0);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FirstColumnSecondCell_GetBySquare_IsFirstColumnSecondCell()
        {
            int expected = 0;

            int actual = goodSudoku.GetBySquare(0, 2);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SecondColumnFirstCell_GetBySquare_IsSecondColumnFirstCell()
        {
            int expected = 3;

            int actual = goodSudoku.GetBySquare(0, 1);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void LastColumnLastCell_GetBySquare_IsLastColumnLastCell()
        {
            int expected = 3;

            int actual = goodSudoku.GetBySquare(3, 3);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
