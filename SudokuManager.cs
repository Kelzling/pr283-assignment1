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
            int gridIndex = rowIndex * myGrid.GetMaxValue();
            gridIndex += columnIndex;
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
            int maxValue = myGrid.GetMaxValue();
            for (int i = 0; i < maxValue; i++)
            {
                if (!Row(i).IsCorrect()) return false;
                if (!Column(i).IsCorrect()) return false;
                if (!Section(i).IsCorrect()) return false;
            }
            return true;
        }

        public bool IsValid()
        {
            int maxValue = myGrid.GetMaxValue();
            for (int i = 0; i < maxValue; i++)
            {
                if (!Row(i).IsValid()) return false;
                if (!Column(i).IsValid()) return false;
                if (!Section(i).IsValid()) return false;
            }
            return true;
        }

        public bool IsComplete()
        {
            int maxValue = myGrid.GetMaxValue();
            for (int i = 0; i < maxValue; i++)
            {
                if (!Row(i).IsComplete()) return false;
                if (!Column(i).IsComplete()) return false;
                if (!Section(i).IsComplete()) return false;
            }
            return true;
        }

        public GridPart Row(int rowIndex) => new GridPart(myGrid.GetRow(rowIndex));

        public GridPart Column(int columnIndex) => new GridPart(myGrid.GetColumn(columnIndex));

        public GridPart Section(int sectionIndex) => new GridPart(myGrid.GetSection(sectionIndex));

        public List<int> GetValidValuesForCell(int gridIndex)
        {
            int maxValue = myGrid.GetMaxValue();
            List<int> myValues = GetInvalidValuesForCell(gridIndex);

            return Enumerable.Range(1, maxValue).Where(i => !myValues.Contains(i)).ToList();
        }

        public List<int> GetInvalidValuesForCell(int gridIndex)
        {
            int maxValue = myGrid.GetMaxValue();
            int sectionWidth = myGrid.GetSquareWidth();
            int sectionHeight = maxValue / sectionWidth;

            int columnIndex = gridIndex % maxValue;
            int rowIndex = gridIndex / maxValue;
            int sectionIndex = (columnIndex / sectionWidth) + (rowIndex / sectionHeight);

            List<int> myValues = new List<int>();
            myValues.AddRange(Row(rowIndex).GetInvalidValues());
            myValues.AddRange(Column(columnIndex).GetInvalidValues());
            myValues.AddRange(Section(sectionIndex).GetInvalidValues());
            /*Row(rowIndex).GetInvalidValues().ForEach((int aValue) => myValues.Add(aValue));
            Column(columnIndex).GetInvalidValues().ForEach((int aValue) => myValues.Add(aValue));
            Section(sectionIndex).GetInvalidValues().ForEach((int aValue) => myValues.Add(aValue));*/

            return Enumerable.Range(1, maxValue).Where(i => myValues.Contains(i)).ToList();
        }

        public void RestartLevel()
        {
            myGrid.Set(levelTemplate);
        }

        protected bool IsLockedCell(int gridIndex) => levelTemplate[gridIndex] > 0;
    }
}
