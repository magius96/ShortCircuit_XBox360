using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic030 : GameLevel
    {
        public Classic030()
            : base("Classic030")
        {
            MapGridSize = 7;
            MinimumMoves = 11;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,0,2,0,2,0,0},
                {0,2,2,0,2,2,0},
                {2,2,0,2,0,2,2},
                {0,0,2,2,2,0,0},
                {0,2,0,2,0,2,0},
                {2,2,0,2,0,2,2},
                {0,0,2,0,2,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic031();
            }
        }
    }
}
