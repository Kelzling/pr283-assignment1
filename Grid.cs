using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void SetMaxValue(int newMaxValue)
        {
            maxValue = newMaxValue;
            cellValues = new int[maxValue * maxValue];
        }

        public int GetMaxValue() => maxValue;

        public void SetSquareWidth(int newWidth) => sectionWidth = newWidth;

        public int GetSquareWidth() => sectionWidth;

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

        private bool IsValidIndex(int index) => 0 <= index && index <= maxValue - 1;

        public int[] GetRow(int rowIndex)
        {
            if (!IsValidIndex(rowIndex)) throw new ArgumentOutOfRangeException();

            int startIndex = rowIndex * maxValue;

            int[] values = new int[maxValue];
            Array.Copy(cellValues, startIndex, values, 0, maxValue);

            return values;
        }

        public int[] GetColumn(int columnIndex)
        {
            if (!IsValidIndex(columnIndex)) throw new ArgumentOutOfRangeException();

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
            if (!IsValidIndex(sectionIndex)) throw new ArgumentOutOfRangeException();

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
            // decision - not going to allow user uploading of files. Naive implementation with assertions is ok for this use case.

            string[] lines = csv.Split('\n');

            int[] gridInfo = lines[0].Split(',').Select(Int32.Parse).ToArray();
            maxValue = gridInfo[0];
            sectionHeight = gridInfo[1];
            sectionWidth = gridInfo[2];

            cellValues = lines[1].Split(',').Select(Int32.Parse).ToArray();

            // post conditions for a valid game set up
            Trace.Assert(maxValue == sectionHeight * sectionWidth);
            Trace.Assert(cellValues.Length == maxValue * maxValue);
        }

        public string ToCSV() => $"{maxValue},{sectionHeight},{sectionWidth}\n{String.Join(",", cellValues)}";

        public string ToPrettyString()
        {
            List<string> prettyRows = new List<string>();
            for (int i = 0; i < maxValue; i++) prettyRows.Add(RowAsPrettyString(i));

            for (int i = maxValue - 2; i > 0; i--) if (i % sectionHeight == 0) prettyRows.Insert(i, GetPrettyRowSeparator());

            return String.Join("\n", prettyRows.ToArray());
        }

        private string RowAsPrettyString(int rowIndex)
        {
            int[] rowValues = GetRow(rowIndex);
            
            List<string> row = new List<string>();
            foreach (int aValue in rowValues) row.Add(PadPrettyString(aValue.ToString()));

            for (int i = maxValue - 2; i > 0; i--) if (i % sectionWidth == 0) row.Insert(i, "|");

            return String.Join(" ", row.ToArray());
        }

        private string PadPrettyString(string input)
        {
            // ToDo: possible error handling here? assumes no input value is greater than 2 characters in length

            switch (input.Length)
            {
                case 1:
                    return $" {input}";
                default:
                    return input;
            }
        }

        private string GetPrettyRowSeparator()
        {
            List<string> rowSeparator = new List<string>();
            for (int i = 0; i < maxValue; i++) rowSeparator.Add("--");

            for (int i = maxValue - 2; i > 0; i--) if (i % sectionHeight == 0) rowSeparator.Insert(i, "+");

            return String.Join("-", rowSeparator.ToArray());
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Grid grid = (Grid)obj;
                return grid.maxValue == maxValue &&
                    grid.sectionHeight == sectionHeight &&
                    grid.sectionWidth == sectionWidth &&
                    grid.cellValues.SequenceEqual(cellValues);
            }
        }

        public override int GetHashCode()
        {
            // auto implemented
            var hashCode = -1453776904;
            hashCode = hashCode * -1521134295 + maxValue.GetHashCode();
            hashCode = hashCode * -1521134295 + sectionHeight.GetHashCode();
            hashCode = hashCode * -1521134295 + sectionWidth.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(cellValues);
            return hashCode;
        }
    }
}
