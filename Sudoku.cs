using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    class Sudoku : IGame, ISet, IGet, ISerialize
    {
        protected int _sqWidth;
        protected int _sqHeight;
        protected int _maxNum;
        protected int[] _grid;

        public Sudoku(int newWidth, int newHeight, int newMaxNum)
        {
            _sqWidth = newWidth;
            _sqHeight = newHeight;
            _maxNum = newMaxNum;
            _grid = new int[_maxNum * _maxNum];
        }

        public void Set(int[] cellValues)
        {
            _grid = cellValues;
        }

        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            int offset = rowIndex * _maxNum;
            int cellIndex = offset + columnIndex;

            _grid[cellIndex] = value;
        }

        public int GetByColumn(int columnIndex, int rowIndex)
        {
            int offset = rowIndex * _maxNum;
            int cellIndex = offset + columnIndex;

            return _grid[cellIndex];
        }

        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            SetByColumn(value, columnIndex, rowIndex);
        }

        public void SetBySquare(int value, int squareIndex, int squarePosition)
        {
            int sqInRow = _maxNum / _sqWidth;

            int squareX = squarePosition % _sqWidth;
            int squareY = squarePosition / _sqWidth;

            int gridX = (squareIndex % sqInRow) * _sqWidth;
            int gridY = (squareIndex / sqInRow) * _sqWidth;

            int columnRef = squareX + gridX;
            int rowRef = squareY + gridY;

            SetByRow(value, rowRef, columnRef);
        }

        public bool ValidateBlock(int[] values)
        {
            Console.WriteLine(string.Join(", ", values)); // for testing
            bool result = true;

            // validate length of array?

            var valueCounts = values.GroupBy(n => n).ToDictionary(gr => gr.Key, gr => gr.Count());

            for (int i = 1; i <= _maxNum; i++)
            {
                valueCounts.TryGetValue(i, out int count);
                if (count != 1)
                {
                    result = false;
                    break;
                }
            }

            // do we need to make sure there's no rogue weird values???

            return result;
        }

        public int[] GetValidValuesForCell(int cellNumber)
        {
            List<int> validValues = Enumerable.Range(1, _maxNum).ToList();

            // find the row, col, square
            int rowNum = cellNumber / _maxNum;

            int colNum = cellNumber % _maxNum;
       
            int sqNum = (rowNum / _sqHeight) // which row of squares are we in (eg divide row num by number of rows per square)
                * (_maxNum / _sqWidth) // total amount of squares in row (helps to determine where the row actuall starts)
                + (colNum / _sqWidth); // which square column are we in

            Console.WriteLine(sqNum);

            // get the values
            
            int[] rowVals = GetRow(rowNum);

            int[] colVals = GetColumn(colNum);

            int[] sqVals = GetSquare(sqNum);

            // remove any numbers that already exist in those

            validValues.RemoveAll(rowVals.Contains);
            validValues.RemoveAll(colVals.Contains);
            validValues.RemoveAll(sqVals.Contains);

            return validValues.ToArray();
        }

        public bool RowValid(int rowNumber)
        {
            // get cells
            int[] rowCells = GetRow(rowNumber);

            // validate
            return ValidateBlock(rowCells);
        }

        protected int[] GetRow(int rowNumber)
        {
            int startIndex = rowNumber * _maxNum;

            int[] values = new int[_maxNum];
            Array.Copy(_grid, startIndex, values, 0, _maxNum);

            return values;
        }

        public bool ColumnValid(int columnNumber)
        {
            int[] colCells = GetColumn(columnNumber);

            return ValidateBlock(colCells);
        }

        protected int[] GetColumn(int columnNumber)
        {
            int[] values = new int[_maxNum];

            // int index = 0;
            // int i = 0;

            //while (index < _maxNum)
            //{

            //    if (i % _maxNum == columnNumber)
            //    {
            //        values[index] = _grid[i];
            //        index++;
            //    }

            //    i++;
            //}

            for (int i = 0; i < _maxNum; i++)
            {
                int index = (i * _maxNum) + columnNumber;
                values[i] = _grid[index];
            }
            
            return values;
        }

        public bool SquareValid(int squareNumber)
        {
            int[] squareCells = GetSquare(squareNumber);

            return ValidateBlock(squareCells);
        }

        protected int[] GetSquare(int squareNumber)
        {
            int[] values = new int[_maxNum];

            int sqInRow = _maxNum / _sqWidth;

            int gridX = (squareNumber % sqInRow) * _sqWidth;
            int gridY = (squareNumber / sqInRow) * _sqWidth;

            for (int i = 0; i < _maxNum; i++)
            {
                int squareX = i % _sqWidth;
                int squareY = i / _sqWidth;

                int columnRef = squareX + gridX;
                int rowRef = squareY + gridY;

                values[i] = GetByColumn(columnRef, rowRef);
            }

            return values;
        }

        public void SetMaxValue(int maximum)
        {
            throw new NotImplementedException();
        }

        public int GetMaxValue()
        {
            throw new NotImplementedException();
        }

        public int[] ToArray()
        {
            throw new NotImplementedException();
        }

        public void SetSquareWidth(int squareWidth)
        {
            throw new NotImplementedException();
        }

        public void SetSquareHeight(int squareHeight)
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public int GetByRow(int rowIndex, int columnIndex)
        {
            throw new NotImplementedException();
        }

        public int GetBySquare(int squareIndex, int positionIndex)
        {
            throw new NotImplementedException();
        }

        public void FromCSV(string csv)
        {
            throw new NotImplementedException();
        }

        public string ToCSV()
        {
            throw new NotImplementedException();
        }

        public void SetCell(int value, int gridIndex)
        {
            throw new NotImplementedException();
        }

        public int GetCell(int gridIndex)
        {
            throw new NotImplementedException();
        }

        public string ToPrettyString()
        {
            throw new NotImplementedException();
        }
    }
}
