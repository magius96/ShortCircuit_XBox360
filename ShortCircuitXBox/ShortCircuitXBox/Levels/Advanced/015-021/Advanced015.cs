using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Advanced015 : GameLevel
    {
        public Advanced015()
            : base("Advanced015")
        {
            MapGridSize = 5;
            MinimumMoves = 12;
            UseInDemo = true;
            MapButtonTypes = new int[,]
            {
                {2,2,3,2,2},
                {2,3,2,3,2},
                {3,2,3,2,3},
                {2,3,2,3,2},
                {2,2,3,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,0,2,0},
                {2,1,2,1,2},
                {0,2,1,2,0},
                {2,1,2,1,2},
                {0,2,0,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced016();
            }
        }
    }
}
