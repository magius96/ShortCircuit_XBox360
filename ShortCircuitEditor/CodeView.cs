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
    public partial class CodeView : Form
    {
        private string _displayText = "";

        public CodeView(GameLevel level, string steps)
        {
            InitializeComponent();
            WriteCode(level, steps);
        }

        private void CodeDisplayTextClick(object sender, EventArgs e)
        {
            CodeDisplayText.SelectAll();
            CodeDisplayText.Copy();
        }

        private void WriteCode(GameLevel level, string steps)
        {
            _displayText = "";
            AddLine("using ShortCircuitLib;");
            AddLine("");
            AddLine(string.Format("// {0}", steps));
            AddLine("namespace ShortCircuit.Levels");
            AddLine("{");
            AddLine("    class MapLevel : GameLevel");
            AddLine("    {");
            AddLine("        public MapLevel() : base(\"MapLevel\")");
            AddLine("        {");
            AddLine(string.Format("            MapGridSize = {0};", level.MapSize));
            AddLine(string.Format("            MinimumMoves = {0};", level.MinimumMoves));
            AddLine("            MapButtonTypes = new int[,]");
            AddLine("            {");
            for (var x = 0; x < level.MapSize;x++ )
            {
                var line = "                {";
                for (var y=0;y<level.MapSize;y++)
                {
                    line += level.MapButtonTypes[y, x];
                    if (y < level.MapSize - 1) line += ",";
                }
                if(x < level.MapSize - 1)
                    line += "},";
                else line += "}";
                AddLine(line);
            }
            AddLine("            };");
            AddLine("            MapButtonStates = new int[,]");
            AddLine("            {");
            for (var x = 0; x < level.MapSize; x++)
            {
                var line = "                {";
                for (var y = 0; y < level.MapSize; y++)
                {
                    line += level.MapButtonStates[y, x];
                    if (y < level.MapSize - 1) line += ",";
                }
                if (x < level.MapSize - 1)
                    line += "},";
                else line += "}";
                AddLine(line);
            }
            AddLine("            };");
            AddLine("        }");
            AddLine("    }");
            AddLine("}");

            CodeDisplayText.Text = _displayText;
        }

        private void AddLine(string line) { _displayText += line + "\r\n"; }
    }
}
