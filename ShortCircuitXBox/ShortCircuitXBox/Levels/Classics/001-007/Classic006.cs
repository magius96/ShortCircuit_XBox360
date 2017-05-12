using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic006 : GameLevel
    {
        public Classic006()
            : base("Classic006")
        {
            MapGridSize = 3;
            MinimumMoves = 3;
            MapButtonTypes = new int[,]
            {
                {2,2,2},
                {2,2,2},
                {2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,0},
                {2,2,2},
                {2,0,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic007();
            }
        }
    }
}
