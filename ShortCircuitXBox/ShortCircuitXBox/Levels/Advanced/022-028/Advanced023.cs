using ShortCircuitLib;

// 11,00,40,31,23,32,55,44,15,24
namespace ShortCircuit.Levels
{
    class Advanced023 : GameLevel
    {
        public Advanced023()
            : base("Advanced023")
        {
            MapGridSize = 6;
            MinimumMoves = 10;
            MapButtonTypes = new int[,]
            {
                {2,3,2,3,2,2},
                {3,2,2,2,3,2},
                {2,2,3,2,2,2},
                {2,2,2,3,2,2},
                {2,3,2,2,2,3},
                {2,2,3,2,3,2}
            };
            MapButtonStates = new int[,]
            {
                {2,2,0,2,2,2},
                {2,2,0,0,2,0},
                {0,2,2,0,2,0},
                {0,2,0,2,2,0},
                {0,2,0,0,2,2},
                {2,2,2,0,2,2}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced024(); }
        }
    }
}
