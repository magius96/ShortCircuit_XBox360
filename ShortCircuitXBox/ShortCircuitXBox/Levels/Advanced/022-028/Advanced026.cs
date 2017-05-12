using ShortCircuitLib;

// 01,10,30,05,14,23,32,43,52,03,12,21,32,41,50,25,34,45,54
namespace ShortCircuit.Levels
{
    class Advanced026 : GameLevel
    {
        public Advanced026()
            : base("Advanced026")
        {
            MapGridSize = 6;
            MinimumMoves = 19;
            MapButtonTypes = new int[,]
            {
                {2,2,3,2,3,2},
                {2,3,2,3,2,2},
                {3,2,2,2,2,2},
                {2,2,2,3,2,3},
                {2,2,3,2,3,2},
                {2,3,2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {0,2,0,2,0,2},
                {2,1,2,2,2,2},
                {0,2,2,0,2,2},
                {2,0,2,2,2,0},
                {2,2,1,2,1,2},
                {2,0,2,2,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced027(); }
        }
    }
}
