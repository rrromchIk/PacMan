
namespace PacMan {
    static class RandomDirectionGenerator {
        public static Direction GetRandomDirection(Ghost ghost, IMap map, Direction previousMoveDirection) {
            List<Direction> availableDirections = GetAvailableDirections(ghost, map);
            int amountOfAvailableDirections = availableDirections.Count;

            Direction nextMoveDirection = Direction.None;
            if (amountOfAvailableDirections != 0) {
                nextMoveDirection = availableDirections[new Random(DateTime.Now.Millisecond).Next(0, amountOfAvailableDirections)];
            }

            bool ghostIsGoingBack = CheckIfGhostIsGoingBack(previousMoveDirection, nextMoveDirection);

            if (ghostIsGoingBack && availableDirections.Count > 1) {
                availableDirections.Remove(nextMoveDirection);
                nextMoveDirection = availableDirections[new Random(DateTime.Now.Millisecond).Next(0, availableDirections.Count)];
            }

            return nextMoveDirection;
        }
        private static List<Direction> GetAvailableDirections(Ghost ghost, IMap map) {
            List<Direction> directions = new List<Direction>();

            if (map.GetSymbol(ghost.PositionOnMap.XPos - 2, ghost.PositionOnMap.YPos) != GameSymbols.WALL_SYMBOL && 
                map.GetSymbol(ghost.PositionOnMap.XPos - 2, ghost.PositionOnMap.YPos) != GameSymbols.GHOST_SYMBOL)
                directions.Add(Direction.Left);
            if (map.GetSymbol(ghost.PositionOnMap.XPos + 2, ghost.PositionOnMap.YPos) != GameSymbols.WALL_SYMBOL &&
                map.GetSymbol(ghost.PositionOnMap.XPos + 2, ghost.PositionOnMap.YPos) != GameSymbols.GHOST_SYMBOL)
                directions.Add(Direction.Right);
            if (map.GetSymbol(ghost.PositionOnMap.XPos, ghost.PositionOnMap.YPos - 1) != GameSymbols.WALL_SYMBOL &&
                 map.GetSymbol(ghost.PositionOnMap.XPos, ghost.PositionOnMap.YPos - 1) != GameSymbols.GHOST_SYMBOL)
                directions.Add(Direction.Up);
            if (map.GetSymbol(ghost.PositionOnMap.XPos, ghost.PositionOnMap.YPos + 1) != GameSymbols.WALL_SYMBOL &&
                map.GetSymbol(ghost.PositionOnMap.XPos, ghost.PositionOnMap.YPos + 1) != GameSymbols.GHOST_SYMBOL)
                directions.Add(Direction.Down);

            return directions;
        }

        private static bool CheckIfGhostIsGoingBack(Direction previousMoveDirection, Direction nextMovedirection) {
            bool result = false;
            switch (nextMovedirection) {
                case Direction.Left:
                if (previousMoveDirection == Direction.Right)
                    result = true;
                break;
                case Direction.Right:
                if (previousMoveDirection == Direction.Left)
                    result = true;
                break;
                case Direction.Up:
                if (previousMoveDirection == Direction.Down)
                    result = true;
                break;
                case Direction.Down:
                if (previousMoveDirection == Direction.Up)
                    result = true;
                break;
            }

            return result;
        }
    }
}
