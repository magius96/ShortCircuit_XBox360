using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic014 : GameLevel
    {
        public Classic014()
            : base("Classic014")
        {
            MapGridSize = 4;
            MinimumMoves = 8;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {2,0,0,2},
                {2,0,0,2},
                {2,2,2,2},
                {0,0,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic015();
            }
        }
    }
}
