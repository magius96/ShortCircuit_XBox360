using System;
using ShortCircuit.Levels;

namespace ShortCircuit.Screens
{
    class ClassicDemoLevels : LevelSelectScreen
    {
        public ClassicDemoLevels()
        {
            try
            {
                LevelTitle = "Classic Demo Levels";
                GridWidth = 7;
                GridHeight = 5;
                // 35 levels
                AddLevel(new ClassicDemo001());
                AddLevel(new ClassicDemo002());
                AddLevel(new ClassicDemo003());
                AddLevel(new ClassicDemo004());
                AddLevel(new ClassicDemo005());
                AddLevel(new ClassicDemo006());
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }
}
