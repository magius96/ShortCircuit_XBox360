using ShortCircuitLib;

// 01,12,23,32,41,30,04,15,25,34,43
namespace ShortCircuit.Levels
{
    class Classic026 : GameLevel
    {
        public Classic026()
            : base("Classic026")
        {
            MapGridSize = 6;
            MinimumMoves = 11;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2,2,2},
                {2,2,2,2,2,2},
                {2,2,2,2,2,2},
                {2,2,2,2,2,2},
                {2,2,2,2,2,2},
                {2,2,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {2,0,2,2,0,0},
                {2,0,0,2,2,2},
                {0,2,2,2,2,0},
                {2,0,2,0,2,2},
                {2,0,2,2,0,0},
                {0,0,0,0,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic027();
            }
        }
    }
}
