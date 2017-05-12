using System;
using ShortCircuit.Levels;

namespace ShortCircuit.Screens
{
    class AdvancedLevels : LevelSelectScreen
    {
        public AdvancedLevels()
        {
            try
            {
                LevelTitle = "Advanced Levels";
                GridWidth = 7;
                GridHeight = 5;
                // 35 levels
                AddLevel(new Advanced001());
                AddLevel(new Advanced002());
                AddLevel(new Advanced003());
                AddLevel(new Advanced004());
                AddLevel(new Advanced005());
                AddLevel(new Advanced006());
                AddLevel(new Advanced007());

                AddLevel(new Advanced008());
                AddLevel(new Advanced009());
                AddLevel(new Advanced010());
                AddLevel(new Advanced011());
                AddLevel(new Advanced012());
                AddLevel(new Advanced013());
                AddLevel(new Advanced014());

                AddLevel(new Advanced015());
                AddLevel(new Advanced016());
                AddLevel(new Advanced017());
                AddLevel(new Advanced018());
                AddLevel(new Advanced019());
                AddLevel(new Advanced020());
                AddLevel(new Advanced021());

                AddLevel(new Advanced022());
                AddLevel(new Advanced023());
                AddLevel(new Advanced024());
                AddLevel(new Advanced025());
                AddLevel(new Advanced026());
                AddLevel(new Advanced027());
                AddLevel(new Advanced028());

                AddLevel(new Advanced029());
                AddLevel(new Advanced030());
                AddLevel(new Advanced031());
                AddLevel(new Advanced032());
                AddLevel(new Advanced033());
                AddLevel(new Advanced034());
                AddLevel(new Advanced035());
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }
}
