using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic025 : GameLevel
    {
        public Classic025()
            : base("Classic025")
        {
            MapGridSize = 6;
            MinimumMoves = 13;
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
                {2,2,2,2,2,2},
                {0,0,2,2,0,0},
                {2,2,0,0,2,0},
                {0,2,2,0,2,2},
                {2,2,2,0,2,2},
                {0,0,0,2,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic026();
            }
        }
    }
}
