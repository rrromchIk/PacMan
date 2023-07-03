
namespace PacMan {
    /**
     * Util class to Render view in console.
     */
    class FrameRendering {
        private ColorFactory _mapSymbolsColorFactory = new MapSymbolsColorFactory();
        private ColorFactory _difficultyColorFactory = new DifficultyColorFactory();

        public FrameRendering() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }
   
        public void RenderMap(Level level) {
            Console.Clear();
            Console.CursorVisible = false;

            RenderLevelMap(level.LevelMap);
            RenderLevelMap(level.LevelPointsMap);
            RenderLevelDifficulty(level.Difficulty);
        }


        public void RenderCharacters(ICharacter[] characters,
                                                IMap pointsMap,
                                                IMap map) {
            foreach (var character in characters) {
                Console.SetCursorPosition(character.PreviousPositionOnMap.XPos, character.PreviousPositionOnMap.YPos);

                if (character is PacMan) {
                    Console.Write(GameSymbols.SPACE_SYMBOL);
                    pointsMap.SetSymbol(character.PreviousPositionOnMap.XPos, character.PreviousPositionOnMap.YPos, GameSymbols.SPACE_SYMBOL); 
                    pointsMap.SetSymbol(character.PositionOnMap.XPos, character.PositionOnMap.YPos, GameSymbols.SPACE_SYMBOL); 
                } else {
                    Console.Write(pointsMap.GetSymbolToPrint(character.PreviousPositionOnMap.XPos, character.PreviousPositionOnMap.YPos));
                }

                map.SetSymbol(character.PreviousPositionOnMap.XPos, character.PreviousPositionOnMap.YPos, GameSymbols.SPACE_SYMBOL);
                map.SetSymbol(character.PositionOnMap.XPos, character.PositionOnMap.YPos, character.CharacterSymbol);

                Console.SetCursorPosition(character.PositionOnMap.XPos, character.PositionOnMap.YPos);
                Console.ForegroundColor = _mapSymbolsColorFactory.GetColor(character.CharacterSymbol);
                Console.Write(character.CharacterSymbol);
                Console.ResetColor();
            }
        }

        public void RenderCharacter(ICharacter character,
                                                IMap pointsMap,
                                                IMap map) {
            RenderCharacters(new ICharacter[] { character }, pointsMap, map);
        }

        public void RenderScore(int amountOfPoints) {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 3, Console.WindowHeight / 2 - 1);
            Console.Write($"Score: {amountOfPoints} {GameSymbols.BIG_POINT_SYMBOL}");
        }

        public void RenderGameOver(string text) {
            Console.Clear();
            Console.CursorVisible = true;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 1);
            Console.ForegroundColor = ConsoleColor.Red;

            for(int i = 0; i < text.Length; i++) {
                Console.Write(text[i]);
                Thread.Sleep(100);
            }
            Thread.Sleep(1000);
        }

        private void RenderLevelDifficulty(Difficulty difficulty) {
            Console.WriteLine("\n\nDifficulty: ");

            Console.ForegroundColor = _difficultyColorFactory.GetColor(difficulty);
            Console.WriteLine(difficulty);
            Console.ResetColor();
        }

        private void RenderLevelMap(IMap map) {
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < map.Height; y++) {
                for (int x = 0; x < map.Width; x++) {
                    Console.SetCursorPosition(x, y);

                    if (map.GetSymbol(x, y) == GameSymbols.SPACE_SYMBOL) {
                        Console.SetCursorPosition(x + 1, y);
                    } else {
                        Console.ForegroundColor = _mapSymbolsColorFactory.GetColor(map.GetSymbol(x, y));
                        Console.Write(map.GetSymbolToPrint(x, y));
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
