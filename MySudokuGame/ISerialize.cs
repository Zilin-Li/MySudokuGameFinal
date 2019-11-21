using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySudokuGame
{
    interface ISerialize
    {
        void FromCSV(string csvFile);
        string ToCSV();
        void SetCell(int value, int gridIndex);
        int GetCell(int gridIndex);
        string ToPrettyString();
    }
}
