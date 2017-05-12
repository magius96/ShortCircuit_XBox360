using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic021 : GameLevel
    {
        public Classic021()
            : base("Classic021")
        {
            MapGridSize = 5;
            MinimumMoves = 5;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2},
                {2,2,2,2,2},
                {2,2,2,2,2},
                {2,2,2,2,2},
                {2,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,0,2,2,2},
                {2,2,2,2,2},
                {2,0,2,0,2},
                {0,2,2,2,2},
                {0,2,0,0,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic022();
            }
        }
    }
}
