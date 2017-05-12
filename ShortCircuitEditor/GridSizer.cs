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
    public delegate void GridSizeChange(int value);
    public partial class GridSizer : UserControl
    {
        public int Value { get; set; }

        public event GridSizeChange GridSizeChanged;

        public GridSizer()
        {
            InitializeComponent();
        }

        public GridSizer(int val)
        {
            Value = val;
            InitializeComponent();
        }

        private void NumericUpDown1ValueChanged(object sender, EventArgs e)
        {
            Value = (int)numericUpDown1.Value;
            if (Value < 3) 
            {
                Value = 3;
                numericUpDown1.Value = 3;
            } else if (Value > 10)
            {
                Value = 10;
                numericUpDown1.Value = 10;
            } else
            {
                GridSizeChanged(Value);
            }
        }

        private void GridSizerLoad(object sender, EventArgs e) { numericUpDown1.Value = Value; }
    }
}
