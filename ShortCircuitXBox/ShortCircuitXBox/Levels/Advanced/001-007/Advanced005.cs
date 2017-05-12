using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Advanced005 : GameLevel
    {
        public Advanced005()
            : base("Advanced005")
        {
            MapGridSize = 3;
            MinimumMoves = 4;
            MapButtonTypes = new int[,]
            {
                {3,2,3},
                {2,3,2},
                {3,2,3}
            };
            MapButtonStates = new int[,]
            {
                {1,0,1},
                {0,0,0},
                {1,0,1}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced006();
            }
        }
    }
}
