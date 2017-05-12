using ShortCircuitLib;

namespace ShortCircuit.Levels
{
    class Classic011 : GameLevel
    {
        public Classic011()
            : base("Classic011")
        {
            MapGridSize = 4;
            MinimumMoves = 5;
            MapButtonTypes = new int[,]
            {
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2},
                {2,2,2,2}
            };
            MapButtonStates = new int[,]
            {
                {2,0,0,2},
                {2,2,2,2},
                {2,2,2,0},
                {2,0,2,0}
            };
        }
        public override GameLevel NextLevel
        {
            get
            {
                return new Classic012();
            }
        }
    }
}
