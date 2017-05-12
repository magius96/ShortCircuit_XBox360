using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic003 : GameLevel
    {
        public Classic003()
            : base("Classic003")
        {
            MapGridSize = 3;
            MinimumMoves = 2;
            MapButtonTypes = new int[,]
            {
                {2,2,2},
                {2,2,2},
                {2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,2},
                {2,0,2},
                {2,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic004();
            }
        }
    }
}
