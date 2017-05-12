using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Advanced003 : GameLevel
    {
        public Advanced003()
            : base("Advanced003")
        {
            MapGridSize = 3;
            MinimumMoves = 3;
            MapButtonTypes = new int[,]
            {
                {2,2,2},
                {3,3,3},
                {2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {2,0,0},
                {0,1,1},
                {2,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced004();
            }
        }
    }
}
