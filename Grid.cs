using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Grid : IGame, ISerialize
    {
        protected int maxValue;
        protected int sectionHeight;
        protected int sectionWidth;
        protected int[] cellValues;

        public Grid() => Restart();

        public Grid(int newMaxValue, int newSectionHeight, int newSectionWidth)
        {
            maxValue = newMaxValue;
            sectionHeight = newSectionHeight;
            sectionWidth = newSectionWidth;
            cellValues = new int[maxValue * maxValue];
        }

        public void Restart()
        {
            maxValue = 0;
            sectionHeight = 0;
            sectionWidth = 0;
            cellValues = new int[0];
        }

        public void Set(int[] values) => cellValues = values;

        public void SetMaxValue(int newMaxValue) => maxValue = newMaxValue;

        public int GetMaxValue() => maxValue;

        public void SetSquareWidth(int newWidth) => sectionWidth = newWidth;

        public void SetSquareHeight(int newHeight) => sectionHeight = newHeight;

        public int[] ToArray() => cellValues;
        
        public int GetCell(int gridIndex) => cellValues[gridIndex];

        public void SetCell(int value, int gridIndex)
        {
            if (IsValidInput(value))
            {
                cellValues[gridIndex] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Value must be between 0 and {maxValue}");
            }
        }

        private bool IsValidInput(int value) => 0 <= value && value <= maxValue;

        public int[] GetRow(int rowIndex)
        {
            int startIndex = rowIndex * maxValue;

            int[] values = new int[maxValue];
            Array.Copy(cellValues, startIndex, values, 0, maxValue);

            return values;
        }

        public int[] GetColumn(int columnIndex)
        {
            int[] values = new int[maxValue];

            for (int i = 0; i < maxValue; i++)
            {
                int index = (i * maxValue) + columnIndex;
                values[i] = cellValues[index];
            }

            return values;
        }

        public int[] GetSection(int sectionIndex)
        {
            int[] values = new int[maxValue];

            int sectionsInRow = maxValue / sectionWidth;

            int sectionX = (sectionIndex % sectionsInRow) * sectionWidth;
            int sectionY = (sectionIndex / sectionsInRow) * sectionWidth;

            for (int i = 0; i < maxValue; i++)
            {
                int cellX = i % sectionWidth;
                int cellY = i / sectionWidth;

                int columnIndex = cellX + sectionX;
                int rowIndex = cellY + sectionY;
                
                int gridIndex = rowIndex * maxValue + columnIndex;

                values[i] = cellValues[gridIndex];
            }

            return values;
        }

        public void FromCSV(string csv)
        {
            // this code currently presumes that the incoming data is going to match the expected format
            // to do - make it a bit more sensible?

            string[] lines = csv.Split('\n');

            int[] gridInfo = lines[0].Split(',').Select(Int32.Parse).ToArray();
            maxValue = gridInfo[0];
            sectionHeight = gridInfo[1];
            sectionWidth = gridInfo[2];

            cellValues = lines[1].Split(',').Select(Int32.Parse).ToArray();
        }

        public string ToCSV() => $"{maxValue},{sectionHeight},{sectionWidth}\n{String.Join(",", cellValues)}";

        public string ToPrettyString()
        {
            throw new NotImplementedException();
        }
    }
}
