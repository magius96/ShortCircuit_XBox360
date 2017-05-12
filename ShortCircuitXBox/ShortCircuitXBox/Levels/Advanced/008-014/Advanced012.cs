using ShortCircuitLib;

// 03,12,21,30,21,21,12,12
namespace ShortCircuit.Levels
{
    class Advanced012 : GameLevel
    {
        public Advanced012()
            : base("Advanced012")
        {
            MapGridSize = 4;
            MinimumMoves = 8;
            MapButtonTypes = new int[,]
            {
                {2,2,2,3},
                {2,3,2,2},
                {2,2,3,2},
                {3,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,0,0,1},
                {0,0,2,0},
                {0,2,0,0},
                {1,0,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced013();
            }
        }
    }
}
