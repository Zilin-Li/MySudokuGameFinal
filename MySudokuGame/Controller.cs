﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySudokuGame
{
    public class Controller
    {
        protected IView view;
        protected SudokuGame game;
        protected FormMain form;

        protected int maxValue, SquareHeight, SquareWidth;
        protected string vaildValue;
        

        public Controller(IView theView, SudokuGame theGame)
        {
            view = theView;
            view.SetController(this);
            game = theGame;
            view.SetModel(theGame);
        }



        public void InitGameData() {

            string CSVFile = "";
            // 2 by 2 file
            CSVFile = "4,2,2" + '\n';
            CSVFile += ("1,0,3,4,2,3,0,1,0,4,1,2,0,1,2,0" + '\n');

            // section 2 high by 3 wide file
            //CSVFile = "6,2,3" + '\n';
            //CSVFile += ("0,0,3,4,5,6,0,3,4,5,6,1,0,4,5,6,1,2,0,5,6,1,2,3,5,0,1,2,3,4,6,1,2,3,0,0" + '\n');

            // section 3 high by 2 wide file
            //CSVFile = "6,3,2" + '\n';
            //CSVFile += ("0,0,3,4,5,6,0,3,4,5,6,1,0,4,5,6,1,2,0,5,6,1,2,3,5,0,1,2,3,4,6,1,2,3,0,0" + '\n');

            // 3 by 3 file
            //CSVFile = "9,3,3" + '\n';
            //CSVFile += ("0,0,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,1,3,4,5,6,7,8,9,1,2,4,5,6,7,8,9,1,2,3,5,6,7,8,9,1,2,3,4,6,7,8,9,1,2,3,4,5,7,8,9,1,2,3,4,5,6,8,9,1,2,3,4,5,6,7,9,1,2,3,4,5,6,7,8" + '\n');

            game.FromCSV(CSVFile);
            game.ToArray();
           
            maxValue = game.GetMaxValue();
            SquareHeight = game.GetSquareHeight();
            SquareWidth = game.GetSquareWidth();

            game.SetMaxValue(maxValue); 
            game.SetSquareHeight(SquareHeight);
            game.SetSquareWidth(SquareWidth); 
            game.Set(game.ToArray());
           
            /*缺：
             *1,文档读取方法
             *2,四种类型游戏如何同时调用该功能时区分打开不同的CSV 文档。
             *3，按键命名
             * 4，按键替换
             * 5，如何设置默认数字无法更改
             */
        }


        public void Go()
        {
            
        }
    }
}
