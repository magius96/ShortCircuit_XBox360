using ShortCircuitLib;

// 01,12,23,34,22,31,40
namespace ShortCircuit.Levels
{
    class Advanced018 : GameLevel
    {
        public Advanced018()
            : base("Advanced018")
        {
            MapGridSize = 5;
            MinimumMoves = 7;
            MapButtonTypes = new int[,]
            {
                {2,3,2,2,2},
                {2,2,3,2,2},
                {2,2,3,3,2},
                {2,3,2,2,3},
                {3,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {2,0,0,0,2},
                {2,0,2,2,0},
                {0,0,0,2,0},
                {0,2,0,0,0},
                {0,0,0,2,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced019();
            }
        }
    }
}
