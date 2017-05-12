using ShortCircuitLib;

// 01,11,21,31,41,51,61,71,76,66,56,46,36,26,06,16,04,03,13,14,24,23,33,34,44,43,53,54,64,63,73,74
namespace ShortCircuit.Levels
{
    class Advanced032 : GameLevel
    {
        public Advanced032()
            : base("Advanced032")
        {
            MapGridSize = 8;
            MinimumMoves = 32;
            MapButtonTypes = new int[,]
            {
                {2,3,2,3,3,2,3,2},
                {2,3,2,3,3,2,3,2},
                {2,3,2,3,3,2,3,2},
                {2,3,2,3,3,2,3,2},
                {2,3,2,3,3,2,3,2},
                {2,3,2,3,3,2,3,2},
                {2,3,2,3,3,2,3,2},
                {2,3,2,3,3,2,3,2}
            };
            MapButtonStates = new int[,]
            {
                {2,1,2,1,1,2,1,2},
                {0,0,2,0,0,2,0,0},
                {0,2,0,2,2,0,2,0},
                {2,1,0,1,1,0,1,2},
                {2,1,0,1,1,0,1,2},
                {0,2,0,2,2,0,2,0},
                {0,0,2,0,0,2,0,0},
                {2,1,2,1,1,2,1,2}
            };
        }
        public override GameLevel NextLevel
        {
            get { return new Advanced033(); }
        }
    }
}
