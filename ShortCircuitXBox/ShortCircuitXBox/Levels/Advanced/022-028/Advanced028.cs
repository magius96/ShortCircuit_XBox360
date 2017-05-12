using ShortCircuitLib;

// 41,31,21,11,12,13,14,25,35,44
namespace ShortCircuit.Levels
{
    class Advanced028 : GameLevel
    {
        public Advanced028()
            : base("Advanced028")
        {
            MapGridSize = 6;
            MinimumMoves = 10;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2,2},
                {2,3,3,3,3,2},
                {2,2,2,2,3,2},
                {2,2,2,2,3,2},
                {2,3,2,2,3,2},
                {2,2,3,3,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,2,2,2,0},
                {2,0,0,0,2,2},
                {2,2,0,2,1,0},
                {2,2,2,0,1,0},
                {2,2,0,0,1,2},
                {0,0,2,2,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced029(); }
        }
    }
}
