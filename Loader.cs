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
        static SudokuManager LoadLevel(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string fileContents = reader.ReadToEnd();
                return new SudokuManager(fileContents);
            }
        }
    }
}
