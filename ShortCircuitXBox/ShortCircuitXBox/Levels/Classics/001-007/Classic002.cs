using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic002 : GameLevel
    {
        public Classic002()
            : base("Classic002")
        {
            MapGridSize = 3;
            MinimumMoves = 1;
            MapButtonTypes = new int[,]
            {
                {2,2,2},
                {2,2,2},
                {2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,2},
                {0,0,2},
                {0,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic003();
            }
        }
    }
}
