using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic018 : GameLevel
    {
        public Classic018()
            : base("Classic018")
        {
            MapGridSize = 5;
            MinimumMoves = 5;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2},
                {2,2,2,2,2},
                {2,2,2,2,2},
                {2,2,2,2,2},
                {2,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,0,0,2,0},
                {2,2,0,2,2},
                {0,2,0,2,0},
                {2,2,0,2,2},
                {0,0,0,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic019();
            }
        }
    }
}
