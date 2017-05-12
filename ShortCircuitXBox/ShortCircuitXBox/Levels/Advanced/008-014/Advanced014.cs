using ShortCircuitLib;

// 20,21,11,01,12,13,22,32
namespace ShortCircuit.Levels
{
    class Advanced014 : GameLevel
    {
        public Advanced014()
            : base("Advanced014")
        {
            MapGridSize = 4;
            MinimumMoves = 8;
            MapButtonTypes = new int[,]
            {
                {2,3,2,2},
                {2,3,3,3},
                {3,3,3,2},
                {2,2,3,2}
            };
            MapButtonStates = new int[,]
            {
                {2,2,0,2},
                {0,1,1,2},
                {2,1,1,0},
                {2,0,2,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced015();
            }
        }
    }
}
