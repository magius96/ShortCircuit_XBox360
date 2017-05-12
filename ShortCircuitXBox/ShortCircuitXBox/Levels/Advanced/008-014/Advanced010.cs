using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Advanced010 : GameLevel
    {
        public Advanced010()
            : base("Advanced010")
        {
            MapGridSize = 4;
            MinimumMoves = 8;
            MapButtonTypes = new int[,]
            {
                {3,2,2,3},
                {2,3,3,2},
                {2,3,3,2},
                {3,2,2,3}
            };
            MapButtonStates = new int[,]
            {
                {2,0,0,2},
                {0,2,2,0},
                {0,2,2,0},
                {2,0,0,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced011();
            }
        }
    }
}
