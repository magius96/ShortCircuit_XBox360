using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Advanced006 : GameLevel
    {
        public Advanced006()
            : base("Advanced006")
        {
            MapGridSize = 3;
            MinimumMoves = 5;
            MapButtonTypes = new int[,]
            {
                {3,3,3},
                {3,2,3},
                {3,3,3}
            };
            MapButtonStates = new int[,]
            {
                {0,1,2},
                {1,0,0},
                {2,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced007();
            }
        }
    }
}
