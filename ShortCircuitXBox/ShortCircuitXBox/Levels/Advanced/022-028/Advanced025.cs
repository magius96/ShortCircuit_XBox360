using ShortCircuitLib;

// 05,04,03,02,11,20,30,41,52,53,54,55,43,33,23,13
namespace ShortCircuit.Levels
{
    class Advanced025 : GameLevel
    {
        public Advanced025()
            : base("Advanced025")
        {
            MapGridSize = 6;
            MinimumMoves = 16;
            MapButtonTypes = new int[,]
            {
                {3,2,2,2,2,3},
                {2,3,2,2,3,2},
                {2,2,3,3,2,2},
                {2,2,3,3,2,2},
                {2,2,3,3,2,2},
                {2,2,3,3,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,0,0,0,0,0},
                {0,1,0,0,1,0},
                {0,2,1,1,2,0},
                {0,2,0,0,2,0},
                {2,0,1,1,0,2},
                {0,2,0,0,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced026(); }
        }
    }
}
