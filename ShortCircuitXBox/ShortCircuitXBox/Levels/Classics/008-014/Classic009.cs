using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic009 : GameLevel
    {
        public Classic009()
            : base("Classic009")
        {
            MapGridSize = 4;
            MinimumMoves = 4;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,2,0},
                {0,0,0,2},
                {0,0,2,0},
                {0,2,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic010();
            }
        }
    }
}
