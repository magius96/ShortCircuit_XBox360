using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic022 : GameLevel
    {
        public Classic022()
            : base("Classic022")
        {
            MapGridSize = 6;
            MinimumMoves = 6;
            UseInDemo = true;
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
                {2,2,2,2,2,2},
                {0,0,0,0,0,0},
                {2,2,0,0,2,2},
                {0,0,0,0,0,0},
                {0,0,2,2,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic023();
            }
        }
    }
}
