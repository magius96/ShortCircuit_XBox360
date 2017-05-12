using ShortCircuitLib;

// 11,43,06,37,56,74,61,30,21,64,45,26,72,34,27
namespace ShortCircuit.Levels
{
    class Classic033 : GameLevel
    {
        public Classic033()
            : base("Classic033")
        {
            MapGridSize = 9;
            MinimumMoves = 15;
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
                {0,2,0,2,2,0,2,0,0},
                {2,0,0,0,0,2,2,0,0},
                {0,2,2,0,2,0,0,2,2},
                {0,0,0,0,2,2,2,0,0},
                {0,0,2,2,2,2,0,0,2},
                {2,0,2,0,2,0,2,2,0},
                {2,0,0,0,0,2,2,0,0},
                {2,2,2,0,2,2,0,0,0},
                {0,0,2,2,0,0,0,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic034();
            }
        }
    }
}
