using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic005 : GameLevel
    {
        public Classic005()
            : base("Classic005")
        {
            MapGridSize = 3;
            MinimumMoves = 3;
            MapButtonTypes = new int[,]
            {
                {2,2,2},
                {2,2,2},
                {2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {2,0,2},
                {0,0,2},
                {2,0,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic006();
            }
        }
    }
}
