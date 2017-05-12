using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Advanced009 : GameLevel
    {
        public Advanced009()
            : base("Advanced009")
        {
            MapGridSize = 4;
            MinimumMoves = 8;
            MapButtonTypes = new int[,]
            {
                {3,2,2,2},
                {2,3,3,3},
                {2,3,3,3},
                {3,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {1,2,2,0},
                {2,1,1,1},
                {2,1,1,0},
                {2,2,2,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced010();
            }
        }
    }
}
