using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuManager : ISet, IGet
    {
        protected Grid myGrid;
        protected int[] levelTemplate;

        public SudokuManager()
        {
            // just for not crashing things purposes right now
            myGrid = new Grid();
            levelTemplate = new int[0];
        }

        public SudokuManager(string gridContentsCSV)
        {
            myGrid = new Grid();
            myGrid.FromCSV(gridContentsCSV);
            levelTemplate = myGrid.ToArray();
        }

        protected int GetGridIndex(int rowIndex, int columnIndex)
        {
            int gridIndex = columnIndex * myGrid.GetMaxValue();
            gridIndex += rowIndex;
            return gridIndex;
        }

        protected int GetGridIndexBySquare(int squareIndex, int positionIndex)
        {
            int maxNum = myGrid.GetMaxValue();
            int sqWidth = myGrid.GetSquareWidth();
            int sqInRow = maxNum / sqWidth;

            int squareColumnOffset = positionIndex % sqWidth;
            int squareRowOffset = positionIndex / sqWidth;

            int gridColumnOffset = (squareIndex % sqInRow) * sqWidth;
            int gridRowOffset = (squareIndex / sqInRow) * sqWidth;

            int columnIndex = squareColumnOffset + gridColumnOffset;
            int rowIndex = squareRowOffset + gridRowOffset;

            return GetGridIndex(rowIndex, columnIndex);
        }

        public int GetByColumn(int columnIndex, int rowIndex) => myGrid.GetCell(GetGridIndex(rowIndex, columnIndex));

        public int GetByRow(int rowIndex, int columnIndex) => myGrid.GetCell(GetGridIndex(rowIndex, columnIndex));

        public int GetBySquare(int squareIndex, int positionIndex) => myGrid.GetCell(GetGridIndexBySquare(squareIndex, positionIndex));

        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            int gridIndex = GetGridIndex(rowIndex, columnIndex);
            myGrid.SetCell(value, gridIndex);
        }

        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            SetByColumn(value, columnIndex, rowIndex);
        }

        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            int gridIndex = GetGridIndexBySquare(squareIndex, positionIndex);
            myGrid.SetCell(value, gridIndex);
        }

        public bool IsCorrect()
        {
            throw new NotImplementedException();
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public bool IsComplete()
        {
            throw new NotImplementedException();
        }

        public GridPart Row(int rowIndex) => new GridPart(myGrid.GetRow(rowIndex));

        public GridPart Column(int columnIndex) => new GridPart(myGrid.GetColumn(columnIndex));

        public GridPart Section(int sectionIndex) => new GridPart(myGrid.GetSection(sectionIndex));

        public List<int> GetValidValuesForCell(int gridIndex)
        {
            throw new NotImplementedException();
        }

        public List<int> GetInvalidValuesForCell(int gridIndex)
        {
            throw new NotImplementedException();
        }

        public void RestartLevel()
        {
            throw new NotImplementedException();
        }

        protected bool IsLockedCell(int gridIndex)
        {
            throw new NotImplementedException();
        }
    }
}
