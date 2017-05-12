using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic032 : GameLevel
    {
        public Classic032()
            : base("Classic032")
        {
            MapGridSize = 8;
            MinimumMoves = 14;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {2,2,2,0,2,0,2,2},
                {0,0,2,0,2,0,0,2},
                {2,0,0,2,0,2,0,2},
                {0,2,2,0,0,2,0,0},
                {2,0,0,0,0,2,2,0},
                {2,0,0,0,2,2,0,0},
                {0,2,0,2,2,0,2,2},
                {0,2,0,2,2,0,0,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic033();
            }
        }
    }
}
