using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic027 : GameLevel
    {
        public Classic027()
            : base("Classic027")
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
                {0,0,0,2,2,0},
                {0,0,0,0,0,0},
                {0,0,2,0,0,0},
                {2,0,0,2,0,0},
                {2,0,0,0,2,0},
                {0,0,0,0,0,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic028();
            }
        }
    }
}
