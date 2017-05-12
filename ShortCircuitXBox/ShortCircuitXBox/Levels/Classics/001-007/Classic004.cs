using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic004 : GameLevel
    {
        public Classic004()
            : base("Classic004")
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
                {2,0,2},
                {0,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic005();
            }
        }
    }
}
