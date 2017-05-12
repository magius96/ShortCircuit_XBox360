using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic028 : GameLevel
    {
        public Classic028()
            : base("Classic028")
        {
            MapGridSize = 6;
            MinimumMoves = 10;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2,2},
                {2,2,2,2,2,2},
                {2,2,2,2,2,2},
                {2,2,2,2,2,2},
                {2,2,2,2,2,2},
                {2,2,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,0,2,2,0,0},
                {0,0,2,0,0,0},
                {2,2,2,0,0,2},
                {2,0,0,2,2,2},
                {0,0,0,2,0,0},
                {0,0,2,2,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic029();
            }
        }
    }
}
