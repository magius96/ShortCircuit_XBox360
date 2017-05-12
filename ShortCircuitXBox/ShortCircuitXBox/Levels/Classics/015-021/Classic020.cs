using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic020 : GameLevel
    {
        public Classic020()
            : base("Classic020")
        {
            MapGridSize = 5;
            MinimumMoves = 7;
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
                {2,2,0,2,2},
                {0,0,2,0,0},
                {2,0,2,0,2},
                {0,0,2,0,0},
                {2,2,0,2,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic021();
            }
        }
    }
}
