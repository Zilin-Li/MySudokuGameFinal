using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySudokuGame
{
    public interface IView
    {
  
        void SetModel(SudokuGame theGame);
        void SetController(Controller controller);
    }
}
