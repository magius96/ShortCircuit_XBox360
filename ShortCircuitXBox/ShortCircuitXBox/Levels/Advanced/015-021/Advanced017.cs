using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Advanced017 : GameLevel
    {
        public Advanced017()
            : base("Advanced017")
        {
            MapGridSize = 5;
            MinimumMoves = 8;
            MapButtonTypes = new int[,]
            {
                {2,2,3,2,2},
                {2,3,2,3,2},
                {2,3,2,3,2},
                {2,3,2,3,2},
                {2,2,3,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,1,2,0},
                {0,2,2,2,0},
                {2,0,0,0,2},
                {0,2,2,2,0},
                {0,2,1,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced018();
            }
        }
    }
}
