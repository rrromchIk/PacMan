
namespace PacMan {
    class MapSymbolsColorFactory : ColorFactory {
        private static Dictionary<char, ConsoleColor> _symbolsColor = new Dictionary<char, ConsoleColor>();

        static MapSymbolsColorFactory() {
            _symbolsColor.Add(GameSymbols.WALL_SYMBOL, ConsoleColor.DarkCyan);
            _symbolsColor.Add(GameSymbols.GHOST_SYMBOL, ConsoleColor.DarkRed);
            _symbolsColor.Add(GameSymbols.PACMAN_SYMBOL, ConsoleColor.Yellow);
            _symbolsColor.Add(GameSymbols.POINT_SYMBOL, ConsoleColor.White);
            _symbolsColor.Add(GameSymbols.BIG_POINT_SYMBOL, ConsoleColor.White);
        }

        

        public ConsoleColor GetColor(object obj) { 
            char symbol = (char)obj;
            ConsoleColor defaultColor = ConsoleColor.Green;

            return _symbolsColor.ContainsKey(symbol) ? _symbolsColor[symbol] : defaultColor;
        }
    }
}
