using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic029 : GameLevel
    {
        public Classic029()
            : base("Classic029")
        {
            MapGridSize = 7;
            MinimumMoves = 13;
            UseInDemo = true;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,2,2,2,0,0},
                {2,2,2,2,0,2,0},
                {0,0,0,0,0,0,2},
                {0,0,0,2,0,0,0},
                {0,0,0,0,0,2,0},
                {0,0,2,0,0,0,0},
                {0,0,2,0,2,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic030();
            }
        }
    }
}
