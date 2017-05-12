using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic031 : GameLevel
    {
        public Classic031()
            : base("Classic031")
        {
            MapGridSize = 8;
            MinimumMoves = 16;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,2,0,0,0,0,2},
                {0,0,0,2,0,0,2,0},
                {0,0,0,0,2,2,0,0},
                {0,0,0,2,2,2,0,0},
                {0,0,2,0,2,0,2,0},
                {0,0,2,2,0,0,0,2},
                {0,2,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic032();
            }
        }
    }
}
