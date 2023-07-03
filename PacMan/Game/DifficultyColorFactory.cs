
namespace PacMan {
    class DifficultyColorFactory : ColorFactory {
        private static Dictionary<Difficulty, ConsoleColor> _difficultyColor = new Dictionary<Difficulty, ConsoleColor>();

        static DifficultyColorFactory() {
            _difficultyColor.Add(Difficulty.Eazy, ConsoleColor.Green);
            _difficultyColor.Add(Difficulty.Medium, ConsoleColor.Yellow);
            _difficultyColor.Add(Difficulty.Hard, ConsoleColor.Red);
        }

        public ConsoleColor GetColor(object obj) {
            Difficulty difficulty = (Difficulty)obj;
            return _difficultyColor[difficulty];
        }
    }
}
