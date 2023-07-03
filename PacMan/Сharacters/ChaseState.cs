
namespace PacMan {
    class ChaseState : GhostState {
        public ChaseState(Ghost ghost) : base(ghost) { }

        public override Direction ExecuteMovementLogic(IMap map) {
            return CatchPacManUtil.DirectionFromGhostToPacMan(_ghost, map);
        }
    }
}
