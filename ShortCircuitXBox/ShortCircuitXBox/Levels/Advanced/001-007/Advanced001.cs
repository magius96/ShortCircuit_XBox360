using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Advanced001 : GameLevel
    {
        public Advanced001()
            : base("Advanced001")
        {
            MapGridSize = 3;
            MinimumMoves = 1;
            UseInDemo = true;
            MapButtonTypes = new int[,]
            {
                {3,2,2},
                {2,3,2},
                {2,2,3}
            };
            MapButtonStates = new int[,]
            {
                {0,2,0},
                {2,1,2},
                {0,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced002(); }
        }
    }
}
