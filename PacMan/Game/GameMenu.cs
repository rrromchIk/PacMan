
namespace PacMan {
    static class GameMenu {
        private const string WelcomeText = "\r\n░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗  ████████╗░█████╗░" +
                                        "  \r\n░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝  ╚══██╔══╝██╔══██╗" +
                                        "  \r\n░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░  ░░░██║░░░██║░░██║" +
                                        "  \r\n░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░  ░░░██║░░░██║░░██║ " +
                                         " \r\n░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗  ░░░██║░░░╚█████╔╝" +
                                         " \r\n░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝  ░░░╚═╝░░░░╚════╝░ " +
                                          " \r\n\r\n██████╗░░█████╗░░█████╗░███╗░░░███╗░█████╗░███╗░░██╗" +
                                                "\r\n██╔══██╗██╔══██╗██╔══██╗████╗░████║██╔══██╗████╗░██║" +
                                                "\r\n██████╔╝███████║██║░░╚═╝██╔████╔██║███████║██╔██╗██║" +
                                                "\r\n██╔═══╝░██╔══██║██║░░██╗██║╚██╔╝██║██╔══██║██║╚████║" +
                                                "\r\n██║░░░░░██║░░██║╚█████╔╝██║░╚═╝░██║██║░░██║██║░╚███║" +
                                                "\r\n╚═╝░░░░░╚═╝░░╚═╝░╚════╝░╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝";

        private const string ChooseLevelText = "\r\n█▀▀ █░█ █▀█ █▀█ █▀ █▀▀   █░░ █▀▀ █░█ █▀▀ █░░   ▄█ ▄▄ █▀█" +
                                                "\r\n█▄▄ █▀█ █▄█ █▄█ ▄█ ██▄   █▄▄ ██▄ ▀▄▀ ██▄ █▄▄   ░█ ░░ ▀▀█";

        private const string ChooseDifficultyText = "\r\n█▀▀ █░█ █▀█ █▀█ █▀ █▀▀   █▀▄ █ █▀▀ █▀▀ █ █▀▀ █░█ █░░ ▀█▀ █▄█  " +
                                                     "\r\n█▄▄ █▀█ █▄█ █▄█ ▄█ ██▄   █▄▀ █ █▀░ █▀░ █ █▄▄ █▄█ █▄▄ ░█░ ░█░  " +
                                                    "\r\n\r\n▄▀ █▀▀ ▄▀█ █▀ █▄█ ░   █▀▄▀█ █▀▀ █▀▄ █ █░█ █▀▄▀█ ░   █░█ ▄▀█ █▀█ █▀▄ ▀▄" +
                                                        "\r\n▀▄ ██▄ █▀█ ▄█ ░█░ █   █░▀░█ ██▄ █▄▀ █ █▄█ █░▀░█ █   █▀█ █▀█ █▀▄ █▄▀ ▄▀";



        private const string LevelsLocation = "LevelDesigns/level{0}/";
        private static readonly MyLogger logger = new MyLogger(typeof(GameMenu));

        public static void Main(string[] args) {
            logger.Info("Main method invoked");
            Game game = Game.GetInstance();
            
            while (true) {
                Level level = DisplayMenuAndGetLevel();
                logger.Debug($"Level from user input: {level}");

                //---------------------------- Facade pattern implemented -----------------------------
                game.Start(level);
            }
        }

        public static Level DisplayMenuAndGetLevel() {
            Console.Clear();
            Console.CursorVisible = true;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(WelcomeText);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(ChooseLevelText);
            Console.ResetColor();

            int levelNumber = GetValidLevelNumber(Console.ReadLine(), 9);

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(ChooseDifficultyText);
            Console.ResetColor();

            string difficulty = Console.ReadLine();

            return new Level(levelNumber,
                                GetValidDifficulty(difficulty),
                                new Map(string.Format(LevelsLocation, levelNumber) + "Map.txt"),
                                //new Map(string.Format(LevelsLocation, levelNumber) + "Points.txt")
                                new HeartPointMap(new Map(string.Format(LevelsLocation, levelNumber) + "Points.txt"))
                             );
        }

        private static int GetValidLevelNumber(string strLevelNumber, int maxLevelNumber) {
            _ = int.TryParse(strLevelNumber, out int levelNumber);         //!!!!!!!!!!!!!!!!!!!!!

            return levelNumber > 0 && levelNumber < maxLevelNumber ? levelNumber : 1;
        }

        private static Difficulty GetValidDifficulty(string strDifficulty) {
            return strDifficulty switch {
                "easy" => Difficulty.Eazy,
                "medium" => Difficulty.Medium,
                "hard" => Difficulty.Hard,
                _ => Difficulty.Medium,
            };
        }
    }
}
