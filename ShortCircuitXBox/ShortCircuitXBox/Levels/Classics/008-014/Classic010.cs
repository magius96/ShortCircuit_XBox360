using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic010 : GameLevel
    {
        public Classic010()
            : base("Classic010")
        {
            MapGridSize = 4;
            MinimumMoves = 5;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,2,2},
                {2,2,0,2},
                {0,2,2,0},
                {2,2,2,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic011();
            }
        }
    }
}
