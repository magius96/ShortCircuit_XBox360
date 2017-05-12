using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShortCircuitEditor
{
    public partial class Form1 : Form
    {
        private GameLevel level = new GameLevel("");
        private LightButton[,] buttons;
        private string steps = "";

        public Form1()
        {
            InitializeComponent();
            level = new GameLevel("") {MapSize = 10};
            gridSizer1.Value = 10;
            ResetGrid();
        }

        private void ResetGrid()
        {
            GridPanel.Controls.Clear();
            steps = "";
            level.MinimumMoves = 0;
            buttons = new LightButton[level.MapSize, level.MapSize];
            for(var x=0;x<level.MapSize;x++)
            {
                for(var y=0;y<level.MapSize;y++)
                {
                    var btn = new LightButton()
                    {
                        Left = x * (470 / level.MapSize) + 5,
                        Top = y * (470 / level.MapSize) + 5,
                        Height = (470 / level.MapSize) - 5,
                        Width = (470 / level.MapSize) - 5,
                        X = x,
                        Y = y,
                        ButtonType = ButtonTypes.TwoState, 
                        ButtonState = ButtonStates.Off
                    };
                    btn.Clicked += BtnClicked;
                    btn.Changed += BtnChanged;
                    btn.UpdateButton();
                    buttons[x, y] = btn;
                    GridPanel.Controls.Add(btn);
                }
            }
        }

        void BtnClicked(int x, int y)
        {
            level.MinimumMoves += 1;
            if (steps.Length > 0) steps += ",";
            steps += string.Format("{0}{1}", x, y);
            ToggleLevelButton(x, y);
            if (x > 0) ToggleLevelButton(x - 1, y);
            if (y > 0) ToggleLevelButton(x, y - 1);
            if (x < level.MapSize - 1) ToggleLevelButton(x + 1, y);
            if (y < level.MapSize - 1) ToggleLevelButton(x, y + 1);
        }

        private void ToggleLevelButton(int x, int y)
        {
            buttons[x,y].Toggle();
            switch (level.MapButtonStates[x,y])
            {
                case 0:
                    if (level.MapButtonTypes[x, y] == 2) level.MapButtonStates[x, y] = 2;
                    else level.MapButtonStates[x, y] = 1;
                    break;
                case 1:
                    level.MapButtonStates[x, y] = 2;
                    break;
                case 2:
                    level.MapButtonStates[x, y] = 0;
                    break;
                default:
                    level.MapButtonStates[x, y] = 0;
                    break;
            }
        }

        void BtnChanged(int x, int y)
        {
            if (level.MapButtonTypes[x, y] == 2)
                level.MapButtonTypes[x, y] = 3;
            else level.MapButtonTypes[x, y] = 2;
        }

        private void Button1Click(object sender, EventArgs e)
        {
            CodeView codeView = new CodeView(level, steps);
            codeView.Show();
        }

        private void GridSizer1GridSizeChanged(int value)
        {
            level.MapSize = value;
            ResetGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetGrid();
        }
    }
}
