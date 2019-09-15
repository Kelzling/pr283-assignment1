using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class GridPart
    {
        protected int[] myValues;
        protected int maxValue;

        public GridPart(int[] newValues)
        {
            myValues = newValues;
            maxValue = newValues.Length;
        }

        public bool IsValid()
        {
            // valid = No duplicate values, no values out of range. any number of 0s is valid.

            bool result = true;

            Dictionary<int, int> valueCounts = myValues.GroupBy(n => n).ToDictionary(gr => gr.Key, gr => gr.Count());

            foreach (int i in valueCounts.Keys) {
                if (i < 0 || i > maxValue || (i > 0 && valueCounts[i] > 1))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public bool IsComplete()
        {
            // complete = no 0s

            return !myValues.Contains(0);
        }

        public bool IsCorrect()
        {
            // is both complete and valid

            return IsValid() && IsComplete();
        }

        public List<int> GetValidValues() => Enumerable.Range(1, maxValue).Where(i => !myValues.Contains(i)).ToList();

        public List<int> GetInvalidValues() => Enumerable.Range(1, maxValue).Where(i => myValues.Contains(i)).ToList();
    }
}
