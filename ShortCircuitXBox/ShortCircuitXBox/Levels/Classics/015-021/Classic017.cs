using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic017 : GameLevel
    {
        public Classic017()
            : base("Classic017")
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
                {2,2,2,2,2},
                {2,2,0,2,2},
                {2,2,0,2,2},
                {0,0,2,2,2},
                {0,0,2,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic018();
            }
        }
    }
}
