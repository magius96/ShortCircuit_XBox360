using ShortCircuitLib;

// 50,41,50,00,00,11,05,05,14,55,55,44,33,33,22,22,32,32,23,23
namespace ShortCircuit.Levels
{
    class Advanced024 : GameLevel
    {
        public Advanced024()
            : base("Advanced024")
        {
            MapGridSize = 6;
            MinimumMoves = 20;
            MapButtonTypes = new int[,]
            {
                {3,3,2,2,3,3},
                {3,3,2,2,3,3},
                {2,2,3,3,2,2},
                {2,2,3,3,2,2},
                {3,3,2,2,3,3},
                {3,3,2,2,3,3}
            };
            MapButtonStates = new int[,]
            {
                {2,0,0,0,0,2},
                {0,1,2,2,1,0},
                {0,2,0,0,2,0},
                {0,2,0,0,2,0},
                {0,1,2,2,1,0},
                {2,0,0,0,0,2}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced025(); }
        }
    }
}
