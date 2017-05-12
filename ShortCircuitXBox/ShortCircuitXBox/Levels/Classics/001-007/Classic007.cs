using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic007 : GameLevel
    {
        public Classic007()
            : base("Classic007")
        {
            MapGridSize = 3;
            MinimumMoves = 4;
            MapButtonTypes = new int[,]
            {
                {2,2,2},
                {2,2,2},
                {2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,0,0},
                {0,0,2},
                {0,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic008();
            }
        }
    }
}
