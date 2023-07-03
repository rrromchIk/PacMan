
namespace PacMan {
    class Level {
        public int LevelNumber { get; }
        public IMap LevelMap { get; }
        public IMap LevelPointsMap { get; }
        public Difficulty Difficulty { get; }

        public Level(int levelNumber, Difficulty difficulty, IMap map, IMap pointsMap) {
            LevelNumber = levelNumber;
            Difficulty = difficulty;
            LevelMap = map;
            LevelPointsMap = pointsMap;
        }

        public override string ToString() {
            return $"[Level: {LevelNumber}, difficulty: {Difficulty}]";
        }
    }
}
