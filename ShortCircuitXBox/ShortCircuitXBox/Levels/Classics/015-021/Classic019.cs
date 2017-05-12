using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic019 : GameLevel
    {
        public Classic019()
            : base("Classic019")
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
                {2,0,2,0,2},
                {2,0,2,0,2},
                {2,2,2,2,2},
                {2,2,0,2,2},
                {0,2,0,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic020();
            }
        }
    }
}
