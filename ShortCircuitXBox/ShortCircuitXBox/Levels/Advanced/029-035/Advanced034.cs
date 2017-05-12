using ShortCircuitLib;

// 21,13,17,56,87,63,44,60,42,26,48,56,72,32,24,35,48,56
namespace ShortCircuit.Levels
{
    class Advanced034 : GameLevel
    {
        public Advanced034()
            : base("Advanced034")
        {
            MapGridSize = 9;
            MinimumMoves = 18;
            UseInDemo = true;
            MapButtonTypes = new int[,]
            {
                {3,2,2,2,2,3,3,3,3},
                {2,3,2,2,2,3,3,3,3},
                {2,2,3,2,2,3,3,3,3},
                {2,2,2,3,2,3,3,3,3},
                {2,2,2,2,3,2,2,2,2},
                {3,3,3,3,2,3,2,2,2},
                {3,3,3,3,2,2,3,2,2},
                {3,3,3,3,2,2,2,3,2},
                {3,3,3,3,2,2,2,2,3}
            };
            MapButtonStates = new int[,]
            {
                {0,0,2,0,0,1,1,1,0},
                {0,1,2,0,2,0,1,1,0},
                {0,2,2,0,0,1,2,1,1},
                {2,2,0,1,0,1,1,2,0},
                {0,0,2,2,1,2,2,0,0},
                {0,0,0,1,0,0,0,0,0},
                {0,2,1,2,2,2,0,0,2},
                {1,1,2,0,0,2,0,1,2},
                {0,1,0,2,0,0,0,0,1}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced035(); }
        }
    }
}
