using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic023 : GameLevel
    {
        public Classic023()
            : base("Classic023")
        {
            MapGridSize = 6;
            MinimumMoves = 8;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2,2},
                {2,2,2,2,2,2},
                {2,2,2,2,2,2},
                {2,2,2,2,2,2},
                {2,2,2,2,2,2},
                {2,2,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,0,0,2,0},
                {2,2,0,0,2,2},
                {0,0,2,2,0,0},
                {0,0,2,2,0,0},
                {2,2,0,0,2,2},
                {0,2,0,0,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic024();
            }
        }
    }
}
