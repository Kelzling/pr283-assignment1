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

        public Grid()
        {
            Restart();
        }

        public Grid(int newMaxValue, int newSectionHeight, int newSectionWidth)
        {
            maxValue = newMaxValue;
            sectionHeight = newSectionHeight;
            sectionWidth = newSectionWidth;
            cellValues = new int[maxValue * maxValue];
        }

        public void Set(int[] values) => cellValues = values;

        public void SetMaxValue(int newMaxValue) => maxValue = newMaxValue;

        public int GetMaxValue() => maxValue;

        public void SetSquareWidth(int newWidth) => sectionWidth = newWidth;

        public void SetSquareHeight(int newHeight) => sectionHeight = newHeight;

        public int[] ToArray() => cellValues;

        public void Restart()
        {
            maxValue = 0;
            sectionHeight = 0;
            sectionWidth = 0;
            cellValues = new int[0];
        }
    }
}
