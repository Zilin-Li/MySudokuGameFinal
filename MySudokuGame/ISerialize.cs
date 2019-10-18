using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySudokuGame
{
    interface ISerialize
    {
        void FromCSV(string csv);
        string ToCSV();
        void SetCell(int value, int gridIndex);
        int GetCell(int gridIndex);

        void ToPrettyBoard();
        //string ToPrettyString();
    }
}
