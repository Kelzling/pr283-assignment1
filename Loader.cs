using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    static class Loader
    {
        static public SudokuManager LoadLevel(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileContents = reader.ReadToEnd();
                return new SudokuManager(fileContents);
            }
        }
    }
}
