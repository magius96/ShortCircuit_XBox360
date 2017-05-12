using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortCircuitLib
{
    public class GameLevel
    {
        public string Id = "";
        protected int MapGridSize = 5;
        public int[,] MapButtonTypes;
        public int[,] MapButtonStates;
        public int MinimumMoves = 0;
        public int Par { get { return (int)Math.Round(MinimumMoves * 1.2, MidpointRounding.AwayFromZero); } }
        public virtual GameLevel NextLevel { get { return null; } }

        public int MapSize
        {
            get
            {
                return MapGridSize;
            }
            set
            {
                if (value > 0 && value < 11)
                {
                    MapGridSize = value;
                    PrepArrays(value);
                }
            }
        }
        
        private void PrepArrays(int gridSize)
        {
            MapButtonTypes = new int[gridSize, gridSize];
            MapButtonStates = new int[gridSize,gridSize];
            for(var x=0;x<gridSize;x++)
            {
                for(var y=0;y<gridSize;y++)
                {
                    MapButtonTypes[x, y] = 2;
                    MapButtonStates[x, y] = 0;
                }
            }
        }

        public GameLevel(string id)
        {
            Id = id;
            MapGridSize = 5;
            PrepArrays(5);
        }

        public ButtonTypes GetType(int x, int y)
        {
            if(MapButtonTypes[y,x] == 2)
                return ButtonTypes.TwoState;
            else
                return ButtonTypes.ThreeState;
        }

        public ButtonStates GetState(int x, int y)
        {
            switch (MapButtonStates[y,x])
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
    }
}
