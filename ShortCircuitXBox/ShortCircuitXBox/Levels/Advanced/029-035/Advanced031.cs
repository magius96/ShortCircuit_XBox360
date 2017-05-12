using ShortCircuitLib;

// 21,32,42,51,62,53,54,65,56,45,35,26,15,24,23,12
namespace ShortCircuit.Levels
{
    class Advanced031 : GameLevel
    {
        public Advanced031()
            : base("Advanced031")
        {
            MapGridSize = 8;
            MinimumMoves = 16;
            MapButtonTypes = new int[,]
            {
                {2,2,3,2,2,3,2,2},
                {2,2,2,3,3,2,2,2},
                {3,2,3,2,2,3,2,3},
                {2,3,2,2,2,2,3,2},
                {2,3,2,2,2,2,3,2},
                {3,2,3,2,2,3,2,3},
                {2,2,2,3,3,2,2,2},
                {2,2,3,2,2,3,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,0,1,0,0,1,0,0},
                {0,0,2,2,2,2,0,0},
                {1,2,1,0,0,1,2,1},
                {0,2,0,0,0,0,2,0},
                {0,2,0,0,0,0,2,0},
                {1,2,1,0,0,1,2,1},
                {0,0,2,2,2,2,0,0},
                {0,0,1,0,0,1,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced032(); }
        }
    }
}
