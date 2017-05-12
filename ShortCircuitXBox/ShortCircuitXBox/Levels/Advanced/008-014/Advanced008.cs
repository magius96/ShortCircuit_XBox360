using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Advanced008 : GameLevel
    {
        public Advanced008()
            : base("Advanced008")
        {
            MapGridSize = 4;
            MinimumMoves = 4;
            UseInDemo = true;
            MapButtonTypes = new int[,]
            {
                {2,3,3,2},
                {3,2,2,3},
                {3,2,2,3},
                {2,3,3,2}
            };
            MapButtonStates = new int[,]
            {
                {0,1,1,0},
                {1,2,2,1},
                {1,2,2,1},
                {0,1,1,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced009();
            }
        }
    }
}
