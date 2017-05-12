using ShortCircuitLib;

// 11,22,33,31,13,22
namespace ShortCircuit.Levels
{
    class Advanced020 : GameLevel
    {
        public Advanced020()
            : base("Advanced020")
        {
            MapGridSize = 5;
            MinimumMoves = 6;
            MapButtonTypes = new int[,]
            {
                {2,3,3,3,2},
                {3,2,3,2,3},
                {3,3,2,3,3},
                {3,2,3,2,3},
                {2,3,3,3,2}
            };
            MapButtonStates = new int[,]
            {
                {0,1,0,1,0},
                {1,2,1,2,1},
                {0,1,0,1,0},
                {1,2,1,2,1},
                {0,1,0,1,0}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced021(); }
        }
    }
}
