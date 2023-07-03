

namespace PacMan {
    interface ICharacter {
        public PositionOnMap PreviousPositionOnMap { get; protected set; }
        public PositionOnMap PositionOnMap { get; protected set; }

        public char CharacterSymbol { get; protected set; }

        public void Move(IMap map);
    }
}
