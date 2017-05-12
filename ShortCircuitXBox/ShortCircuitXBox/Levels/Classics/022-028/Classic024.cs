using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic024 : GameLevel
    {
        public Classic024()
            : base("Classic024")
        {
            MapGridSize = 6;
            MinimumMoves = 10;
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
                {2,2,0,0,2,2},
                {0,0,2,2,0,0},
                {0,0,2,2,0,0},
                {2,0,0,0,0,2},
                {2,0,2,2,0,2},
                {0,2,0,0,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic025();
            }
        }
    }
}
