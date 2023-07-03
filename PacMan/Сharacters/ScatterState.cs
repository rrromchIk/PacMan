
namespace PacMan {
    class ScatterState : GhostState {
        private Direction direction = Direction.None;

        public ScatterState(Ghost ghost) : base(ghost) { }

        public override Direction ExecuteMovementLogic(IMap map) {
            direction = RandomDirectionGenerator.GetRandomDirection(_ghost, map, direction);
            return direction;
        }
    }
}
