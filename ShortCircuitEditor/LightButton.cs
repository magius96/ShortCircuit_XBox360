using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShortCircuitEditor
{
    public delegate void LightButtonClick(int x, int y);

    public delegate void TypeChange(int x, int y);

    public partial class LightButton : UserControl
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ButtonTypes ButtonType { get; set; }
        public ButtonStates ButtonState { get; set; }

        public event LightButtonClick Clicked;
        public event TypeChange Changed;

        public LightButton()
        {
            InitializeComponent();
        }

        private void Button1MouseClick(object sender, MouseEventArgs e)
        {
            // Change State
            if(e.Button == MouseButtons.Left)
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    ButtonType = ButtonType == ButtonTypes.TwoState ? ButtonTypes.ThreeState : ButtonTypes.TwoState;
                    if (Changed != null) Changed(X, Y);
                }
                else if(Clicked != null) Clicked(X, Y);
            }
            UpdateButton();
        }

        public void UpdateButton()
        {
            switch (ButtonState)
            {
                case ButtonStates.On:
                    button1.BackColor = ButtonType == ButtonTypes.TwoState ? Color.White : Color.Green;
                    break;
                case ButtonStates.Dim:
                    button1.BackColor = Color.Yellow;
                    break;
                case ButtonStates.Off:
                    button1.BackColor = ButtonType == ButtonTypes.TwoState ? Color.Gray : Color.Red;
                    break;
            }
        }

        public void Toggle()
        {
            switch (ButtonState)
            {
                case ButtonStates.Off:
                    ButtonState = ButtonType == ButtonTypes.TwoState ? ButtonStates.On : ButtonStates.Dim;
                    break;
                case ButtonStates.On:
                    ButtonState = ButtonStates.Off;
                    break;
                case ButtonStates.Dim:
                    ButtonState = ButtonStates.On;
                    break;
            }
            UpdateButton();
        }
    }
}
