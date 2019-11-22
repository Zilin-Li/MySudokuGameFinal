﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySudokuGame
{
    public interface IView
    {
        void SetController(Controller controller);
        void GameValueDisplay(string gameDataString);
    }
}
