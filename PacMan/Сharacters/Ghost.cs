
namespace PacMan {
    class Ghost : ICharacter {
        public PositionOnMap PreviousPositionOnMap { get; set; }
        public PositionOnMap PositionOnMap { get; set; }
        public char CharacterSymbol { get; set; }

        private GhostState _scatterState;
        private GhostState _chaseState;

        private GhostState _activeState;

        public Ghost(PositionOnMap positionOnMap, char characterSymbol) {
            PositionOnMap = positionOnMap;
            PreviousPositionOnMap = positionOnMap;
            CharacterSymbol = characterSymbol;
            _scatterState = new ScatterState(this);
            _chaseState = new ChaseState(this);
            _activeState = _scatterState;
        }

        public void Move(IMap map) {
            if(CatchPacManUtil.GhostSeesPacMan(this, map)) {
                _activeState = _chaseState;
            } else {
                _activeState = _scatterState;
            }

            PreviousPositionOnMap = PositionOnMap.Copy();
            Direction direction = _activeState.ExecuteMovementLogic(map);

            switch (direction) {
                case Direction.Left:
                    PositionOnMap.XPos -= 2;
                    break;
                case Direction.Right:
                    PositionOnMap.XPos += 2;
                    break;
                case Direction.Up:
                    PositionOnMap.YPos -= 1;
                    break;
                case Direction.Down:
                    PositionOnMap.YPos += 1;
                    break;
            }
        }

        public override string ToString() {
            return $"[Ghost with position: {PositionOnMap}, and symbol: {CharacterSymbol}]";
        }

        public Ghost Copy() {
            return new Ghost(PositionOnMap.Copy(), CharacterSymbol);
        }
    }
}
