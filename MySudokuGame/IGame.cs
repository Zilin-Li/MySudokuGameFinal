using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySudokuGame
{
    interface IGame
    {
        void SetMaxValue(int maximum);
        int GetMaxValue();
        int[] ToArray();
        void Set(int[] cellValues);
        void SetSquareWidth(int squareWidth);
        void SetSquareHeight(int squareHeight);
        void Restart();
    }
}
