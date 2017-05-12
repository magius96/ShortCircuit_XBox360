using ShortCircuitLib;

// 03,12,21,30,00,11,22,33
namespace ShortCircuit.Levels
{
    class Advanced011 : GameLevel
    {
        public Advanced011() : base("Advanced011")
        {
            MapGridSize = 4;
            MinimumMoves = 8;
            MapButtonTypes = new int[,]
            {
                {2,3,2,2},
                {2,2,3,2},
                {3,2,2,3},
                {2,3,2,2}
            };
            MapButtonStates = new int[,]
            {
                {2,2,0,2},
                {0,2,0,0},
                {2,2,2,2},
                {2,2,0,2}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Advanced012();
            }
        }
    }
}
