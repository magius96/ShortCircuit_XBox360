using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic013 : GameLevel
    {
        public Classic013()
            : base("Classic013")
        {
            MapGridSize = 4;
            MinimumMoves = 8;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {2,0,0,2},
                {0,2,2,0},
                {0,2,2,0},
                {2,0,0,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic014();
            }
        }
    }
}
