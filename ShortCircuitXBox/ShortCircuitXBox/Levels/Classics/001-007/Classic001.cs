using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic001 : GameLevel
    {
        public Classic001()
            : base("Classic001")
        {
            MapGridSize = 3;
            MinimumMoves = 1;
            UseInDemo = true;
            MapButtonTypes = new int[,]
            {
                {2,2,2},
                {2,2,2},
                {2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,0},
                {2,2,2},
                {0,2,0}
            };
        }

        public override GameLevel NextLevel
        {
            get
            {
                return new Classic002();
            }
        }
    }
}
