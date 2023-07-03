
namespace PacMan {
    class PacMan : ICharacter {
        public PositionOnMap PreviousPositionOnMap { get; set; }
        public PositionOnMap PositionOnMap { get; set; }
        public char CharacterSymbol { get; set; }

        public Score Score { get; set; }

        public PacMan(PositionOnMap positionOnMap, char characterSymbol) {
            PositionOnMap = positionOnMap;
            PreviousPositionOnMap = positionOnMap;
            CharacterSymbol = characterSymbol;
            Score = new Score();
        }

        public void Move(IMap map) {
            PreviousPositionOnMap = PositionOnMap.Copy();
            PositionOnMap = ProcessingUserInput.GetPacManNextPosition(PositionOnMap, map, UserInputConfig.GetUserInput());
        }

        public void Eat(IMap mapPoints) {
            int x = PositionOnMap.XPos;
            int y = PositionOnMap.YPos;

            if (mapPoints.GetSymbol(x, y) == GameSymbols.POINT_SYMBOL) {
                Score.Update(Score.NORMAL_POINT_VALUE);
            } else if (mapPoints.GetSymbol(x, y) == GameSymbols.BIG_POINT_SYMBOL) {
                Score.Update(Score.BIG_POINT_VALUE);
            }
        }

        public bool Die(List<ICharacter> charactersOnTheMap) {
            bool result = false;
            foreach (ICharacter character in charactersOnTheMap) {

                if (character is Ghost) {
                    if (PositionOnMap.Equals(character.PositionOnMap)) {
                        result = true;
                    }
                    if (PositionOnMap.XPos == character.PositionOnMap.XPos
                        && PreviousPositionOnMap.YPos == character.PositionOnMap.YPos) {
                        result = true;
                    }
                    if (PositionOnMap.XPos == character.PositionOnMap.XPos
                        && PositionOnMap.YPos == character.PreviousPositionOnMap.YPos) {
                        result = true;
                    }
                    if (PositionOnMap.YPos == character.PositionOnMap.YPos
                        && PreviousPositionOnMap.XPos == character.PositionOnMap.XPos) {
                        result = true;
                    }
                    if (PositionOnMap.YPos == character.PositionOnMap.YPos
                        && PositionOnMap.XPos == character.PreviousPositionOnMap.XPos) {
                        result = true;
                    }
                }
            }
            return result;
        }

        public override string ToString() {
            return $"[PacMan with position: {PositionOnMap}, and symbol: {CharacterSymbol}]";
        }

    
    }
}
