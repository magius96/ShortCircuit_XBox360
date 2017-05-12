using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic008 : GameLevel
    {
        public Classic008()
            : base("Classic008")
        {
            MapGridSize = 4;
            MinimumMoves = 4;
            UseInDemo = true;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,2,0},
                {2,2,2,2},
                {2,2,2,2},
                {0,2,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic009();
            }
        }
    }
}
