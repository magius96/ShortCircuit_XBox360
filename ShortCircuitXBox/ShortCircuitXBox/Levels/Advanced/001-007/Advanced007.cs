using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Advanced007 : GameLevel
    {
        public Advanced007()
            : base("Advanced007")
        {
            MapGridSize = 3;
            MinimumMoves = 5;
            MapButtonTypes = new int[,]
            {
                {3,3,3},
                {2,2,2},
                {3,2,3}
            };
            MapButtonStates = new int[,]
            {
                {1,2,1},
                {0,2,0},
                {2,2,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced008();
            }
        }
    }
}
