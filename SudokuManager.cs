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

        public int GetByColumn(int columnIndex, int rowIndex)
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

        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            throw new NotImplementedException();
        }

        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            throw new NotImplementedException();
        }

        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            throw new NotImplementedException();
        }
    }
}
