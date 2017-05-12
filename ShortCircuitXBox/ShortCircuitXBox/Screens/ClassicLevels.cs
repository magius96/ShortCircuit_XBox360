using System;
using ShortCircuit.Levels;

namespace ShortCircuit.Screens
{
    class ClassicLevels : LevelSelectScreen
    {
        public ClassicLevels()
        {
            try
            {
                LevelTitle = "Classic Levels";
                GridWidth = 7;
                GridHeight = 5;
                // 35 levels
                AddLevel(new Classic001());
                AddLevel(new Classic002());
                AddLevel(new Classic003());
                AddLevel(new Classic004());
                AddLevel(new Classic005());
                AddLevel(new Classic006());
                AddLevel(new Classic007());

                AddLevel(new Classic008());
                AddLevel(new Classic009());
                AddLevel(new Classic010());
                AddLevel(new Classic011());
                AddLevel(new Classic012());
                AddLevel(new Classic013());
                AddLevel(new Classic014());

                AddLevel(new Classic015());
                AddLevel(new Classic016());
                AddLevel(new Classic017());
                AddLevel(new Classic018());
                AddLevel(new Classic019());
                AddLevel(new Classic020());
                AddLevel(new Classic021());

                AddLevel(new Classic022());
                AddLevel(new Classic023());
                AddLevel(new Classic024());
                AddLevel(new Classic025());
                AddLevel(new Classic026());
                AddLevel(new Classic027());
                AddLevel(new Classic028());

                AddLevel(new Classic029());
                AddLevel(new Classic030());
                AddLevel(new Classic031());
                AddLevel(new Classic032());
                AddLevel(new Classic033());
                AddLevel(new Classic034());
                AddLevel(new Classic035());
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }
}
