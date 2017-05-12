using ShortCircuitLib;

// 11,12,13,14,24,34,44,43,42,41,31,21
namespace ShortCircuit.Levels
{
    class Advanced022 : GameLevel
    {
        public Advanced022()
            : base("Advanced022")
        {
            MapGridSize = 6;
            MinimumMoves = 12;
            UseInDemo = true;
            MapButtonTypes = new int[,]
            {
                {3,2,3,2,3,2},
                {2,3,2,3,2,3},
                {3,2,3,2,3,2},
                {2,3,2,3,2,3},
                {3,2,3,2,3,2},
                {2,3,2,3,2,3}
            };
            MapButtonStates = new int[,]
            {
                {0,2,1,2,1,0},
                {2,0,2,0,2,1},
                {1,2,2,0,0,2},
                {2,0,0,2,2,1},
                {1,2,0,2,0,2},
                {0,1,2,1,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced023(); }
        }
    }
}
