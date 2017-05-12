using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic015 : GameLevel
    {
        public Classic015()
            : base("Classic015")
        {
            MapGridSize = 5;
            MinimumMoves = 5;
            UseInDemo = true;
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
                {0,2,0,2,0},
                {2,2,2,2,2},
                {0,2,2,2,0},
                {2,2,2,2,2},
                {0,2,0,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic016();
            }
        }
    }
}
