﻿using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic035 : GameLevel
    {
        public Classic035()
            : base("Classic035")
        {
            MapGridSize = 10;
            MinimumMoves = 20;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,2,0,0,0,0,2,2,0},
                {2,2,0,2,0,0,2,0,2,2},
                {2,0,0,2,0,0,2,0,0,2},
                {0,2,2,2,0,0,2,2,2,0},
                {0,0,0,0,2,2,0,0,0,0},
                {0,0,0,0,2,2,0,0,0,0},
                {0,2,2,2,0,0,2,2,2,0},
                {2,0,0,2,0,0,2,0,0,2},
                {2,2,0,2,0,0,2,0,2,2},
                {0,2,2,0,0,0,0,2,2,0}
            };
        }
    }
}
