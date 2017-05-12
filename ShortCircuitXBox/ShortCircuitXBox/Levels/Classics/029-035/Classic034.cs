using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic034 : GameLevel
    {
        public Classic034()
            : base("Classic034")
        {
            MapGridSize = 9;
            MinimumMoves = 39;
            UseInDemo = true;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {2,2,2,2,2,2,2,0,0},
                {2,2,0,2,0,2,0,2,0},
                {2,0,2,0,2,0,2,0,2},
                {2,2,0,2,0,2,0,2,2},
                {2,0,2,0,2,0,2,0,2},
                {2,2,0,2,0,2,0,2,2},
                {2,0,2,0,2,0,2,0,2},
                {0,2,0,2,0,2,0,2,2},
                {0,0,2,2,2,2,2,2,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic035();
            }
        }
    }
}
