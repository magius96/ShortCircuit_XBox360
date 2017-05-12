using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Advanced016 : GameLevel
    {
        public Advanced016()
            : base("Advanced016")
        {
            MapGridSize = 5;
            MinimumMoves = 13;
            MapButtonTypes = new int[,]
            {
                {2,3,3,3,2},
                {3,3,2,3,3},
                {3,2,3,2,3},
                {3,3,2,3,3},
                {2,3,3,3,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,2,2,0},
                {2,0,2,0,2},
                {2,2,1,2,2},
                {2,0,2,0,2},
                {0,2,2,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced017();
            }
        }
    }
}
