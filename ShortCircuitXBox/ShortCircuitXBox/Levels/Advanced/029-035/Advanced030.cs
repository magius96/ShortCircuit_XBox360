using ShortCircuitLib;

// 36,25,35,45,44,34,24,23,33,43,42,32,22,21,31,41,30
namespace ShortCircuit.Levels
{
    class Advanced030 : GameLevel
    {
        public Advanced030()
            : base("Advanced030")
        {
            MapGridSize = 7;
            MinimumMoves = 17;
            MapButtonTypes = new int[,]
            {
                {2,2,2,3,2,2,2},
                {2,2,2,2,3,2,2},
                {2,3,3,3,3,2,2},
                {3,2,3,2,3,2,3},
                {2,2,3,3,3,3,2},
                {2,2,3,2,2,2,2},
                {2,2,2,3,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,0,0,2,0,0,0},
                {0,2,2,2,0,2,0},
                {0,1,1,2,1,2,0},
                {0,2,1,2,1,2,0},
                {0,2,1,2,1,1,0},
                {0,2,0,2,2,2,0},
                {0,0,0,2,0,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced031(); }
        }
    }
}
