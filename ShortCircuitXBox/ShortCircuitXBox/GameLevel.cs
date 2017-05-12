using System;
using ShortCircuit;

namespace ShortCircuitLib
{
    public class GameLevel
    {
        public string Id = "";
        public bool UseInDemo = false;
        protected int MapGridSize = 5;
        public int[,] MapButtonTypes;
        public int[,] MapButtonStates;
        public int MinimumMoves = 0;
        public int Par { get { return (int)Math.Round(MinimumMoves * 1.2, 0); } }
        public virtual GameLevel NextLevel { get { return null; } }

        public int MapSize
        {
            get
            {
                return MapGridSize;
            }
            set
            {
                try
                {
                    if (value > 0 && value < 11)
                    {
                        MapGridSize = value;
                        PrepArrays(value);
                    }
                }
                catch(Exception exception)
                {
                    ErrorLog.Add(exception);
                }
            }
        }
        
        private void PrepArrays(int gridSize)
        {
            try
            {
                MapButtonTypes = new int[gridSize,gridSize];
                MapButtonStates = new int[gridSize,gridSize];
                for (var x = 0; x < gridSize; x++)
                {
                    for (var y = 0; y < gridSize; y++)
                    {
                        MapButtonTypes[x, y] = 2;
                        MapButtonStates[x, y] = 0;
                    }
                }
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public GameLevel(string id)
        {
            try
            {
                Id = id;
                MapGridSize = 5;
                PrepArrays(5);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public ButtonTypes GetType(int x, int y)
        {
            try
            {
                if (MapButtonTypes[y, x] == 2)
                    return ButtonTypes.TwoState;
                else
                    return ButtonTypes.ThreeState;
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return ButtonTypes.TwoState;
            }
        }

        public ButtonStates GetState(int x, int y)
        {
            try
            {
                switch (MapButtonStates[y, x])
                {
                    case 0:
                        return ButtonStates.Off;
                    case 1:
                        return ButtonStates.Dim;
                    case 2:
                        return ButtonStates.On;
                    default:
                        return ButtonStates.Off;
                }
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return ButtonStates.Off;
            }
        }
    }
}
