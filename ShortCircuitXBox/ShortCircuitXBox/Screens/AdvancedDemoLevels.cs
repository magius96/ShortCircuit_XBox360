using System;
using ShortCircuit.Levels;

namespace ShortCircuit.Screens
{
    class AdvancedDemoLevels : LevelSelectScreen
    {
        public AdvancedDemoLevels()
        {
            try
            {
                LevelTitle = "Advanced Demo Levels";
                GridWidth = 7;
                GridHeight = 5;
                // 5 levels
                AddLevel(new AdvancedDemo001());
                AddLevel(new AdvancedDemo002());
                AddLevel(new AdvancedDemo003());
                AddLevel(new AdvancedDemo004());
                AddLevel(new AdvancedDemo005());
                AddLevel(new AdvancedDemo006());
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }
}
