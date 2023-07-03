

namespace PacMan {
    class Map : IMap {
        protected char[,] _symbolMatrix;
        public int Width { get; set; }
        public int Height { get; set; }

        public Map(string levelMapLocation) {
            LoadMapFromFile(levelMapLocation);
        }

        //Loading to char matrix all symbols from file to render this in console later.
        private void LoadMapFromFile(string levelMapLocation) {
            string[] lines = File.ReadAllLines(levelMapLocation);
            Width = lines[0].Length;
            Height = lines.Length;

            _symbolMatrix = new char[Width, Height];

            for (int y = 0; y < Height; y++) {
                for (int x = 0; x < Width; x++) {
                    _symbolMatrix[x, y] = lines[y][x];
                }
            }
        }

        public bool AreSymbolsOnTheMap(List<char> chars) {
            for (int y = 0; y < Height; y++) {
                for (int x = 0; x < Width; x++) {
                    foreach (char point in chars) {
                        if (point == _symbolMatrix[x, y]) {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public char GetSymbol(int x, int y) {
            return _symbolMatrix[x, y];
        }

        public void SetSymbol(int x, int y, char symbol) {
            _symbolMatrix[x, y] = symbol;
        }

        public char GetSymbolToPrint(int x, int y) {
            return _symbolMatrix[x, y];
        }
    }
}
