
namespace PacMan {
    abstract class GhostState {
        protected Ghost _ghost;

        public GhostState(Ghost ghost) {
            _ghost = ghost;
        }

        public abstract Direction ExecuteMovementLogic(IMap map);
    }
}
