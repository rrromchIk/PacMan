
namespace PacMan {
    static class CatchPacManUtil {
        public static bool GhostSeesPacMan(Ghost ghost, IMap map) {
            PositionOnMap ghostPosition = ghost.PositionOnMap;
            PositionOnMap pacManPosition = PositionOnMap.GetPositionOnMap(map, GameSymbols.PACMAN_SYMBOL);
            bool result = false;

            if (ghostPosition.YPos == pacManPosition.YPos) {
                for (int x = ghostPosition.XPos; map.GetSymbol(x, ghostPosition.YPos) != GameSymbols.PACMAN_SYMBOL;) {
                    if (map.GetSymbol(x, ghostPosition.YPos) == GameSymbols.WALL_SYMBOL) {
                        return false;
                    }
                        
                    x = ghostPosition.XPos < pacManPosition.XPos ? x + 2 : x - 2;
                }
                result = true;
            } else if (ghostPosition.XPos == pacManPosition.XPos) {
                for (int y = ghostPosition.YPos; map.GetSymbol(ghostPosition.XPos, y) != GameSymbols.PACMAN_SYMBOL;) {
                    if (map.GetSymbol(ghostPosition.XPos, y) == GameSymbols.WALL_SYMBOL) {
                        return false;
                    }
                        
                    y = ghostPosition.YPos < pacManPosition.YPos ? ++y : --y;
                }

                result = true;
            }

            return result;
        }

        public static Direction DirectionFromGhostToPacMan(Ghost ghost, IMap map) {
            PositionOnMap ghostPosition = ghost.PositionOnMap;
            PositionOnMap pacManPosition = PositionOnMap.GetPositionOnMap(map, GameSymbols.PACMAN_SYMBOL);
            Direction directionFromGhostToPacMan;

            if (ghostPosition.YPos == pacManPosition.YPos) {
                directionFromGhostToPacMan = ghostPosition.XPos < pacManPosition.XPos ? Direction.Right : Direction.Left;
            } else {
                directionFromGhostToPacMan = ghostPosition.YPos < pacManPosition.YPos ? Direction.Down : Direction.Up;
            }

            return directionFromGhostToPacMan;
        }
    }
}
