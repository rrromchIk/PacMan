
namespace PacMan {
    class ProcessingUserInput {
        private static Direction previousDirection = Direction.None;
        public static PositionOnMap GetPacManNextPosition(PositionOnMap pacManPosition, IMap map, IUserInput userInput) {
            Direction direction = userInput.GetDirection();
            PositionOnMap result = pacManPosition.Copy();
            
            if (IsMovingAvailableInCertainDirection(pacManPosition, map, direction)) {
                previousDirection = direction;
                MoveInCertainDirection(result, direction);
            } else {
                if (IsMovingAvailableInCertainDirection(pacManPosition, map, previousDirection)) {
                    MoveInCertainDirection(result, previousDirection);
                } else {
                    direction = Direction.None;
                    result = pacManPosition;
                }
            }

            return result;
        }

        private static bool IsMovingAvailableInCertainDirection(PositionOnMap position, IMap map, Direction direction) {
            PositionOnMap nextPosition = position.Copy();
            switch (direction) {
                case Direction.Left:
                nextPosition.XPos -= 2;
                break;
                case Direction.Right:
                nextPosition.XPos += 2;
                break;
                case Direction.Up:
                nextPosition.YPos -= 1;
                break;
                case Direction.Down:
                nextPosition.YPos += 1;
                break;
            }

            return map.GetSymbol(nextPosition.XPos, nextPosition.YPos) != GameSymbols.WALL_SYMBOL;
        }

        private static void MoveInCertainDirection(PositionOnMap position, Direction direction) {
            switch (direction) {
                case Direction.Left:
                position.XPos -= 2;
                break;
                case Direction.Right:
                position.XPos += 2;
                break;
                case Direction.Up:
                position.YPos -= 1;
                break;
                case Direction.Down:
                position.YPos += 1;
                break;
            }
        }
    }
}
