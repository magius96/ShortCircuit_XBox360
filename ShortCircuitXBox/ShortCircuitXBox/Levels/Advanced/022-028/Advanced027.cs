using ShortCircuitLib;

// 11,12,13,14,24,34,44,43,42,41,31,21
namespace ShortCircuit.Levels
{
    class Advanced027 : GameLevel
    {
        public Advanced027()
            : base("Advanced027")
        {
            MapGridSize = 6;
            MinimumMoves = 12;
            MapButtonTypes = new int[,]
            {
                {3,3,3,2,2,2},
                {3,2,3,2,2,2},
                {3,3,3,2,2,2},
                {3,3,3,2,2,2},
                {3,3,3,2,3,2},
                {3,3,3,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,1,1,2,2,0},
                {1,2,0,2,2,2},
                {1,0,2,0,2,2},
                {1,0,2,0,2,2},
                {1,0,0,2,0,2},
                {0,1,1,2,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced028(); }
        }
    }
}
