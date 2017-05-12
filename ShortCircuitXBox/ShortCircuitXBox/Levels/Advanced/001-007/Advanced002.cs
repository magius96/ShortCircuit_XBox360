using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Advanced002 : GameLevel
    {
        public Advanced002()
            : base("Advanced002")
        {
            MapGridSize = 3;
            MinimumMoves = 2;
            MapButtonTypes = new int[,]
            {
                {2,2,3},
                {2,3,2},
                {3,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,1},
                {2,2,0},
                {0,2,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced003();
            }
        }
    }
}
