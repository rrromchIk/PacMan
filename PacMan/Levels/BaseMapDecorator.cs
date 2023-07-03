
namespace PacMan {
    abstract class BaseMapDecorator : IMap {
        protected IMap _map;

        int IMap.Width { get => _map.Width; set => _map.Width = value; }
        int IMap.Height { get => _map.Height; set => _map.Height = value; }

        public BaseMapDecorator(IMap map) {
            _map = map;
        }

        public char GetSymbol(int x, int y) {
            return _map.GetSymbol(x, y);
        }

        public void SetSymbol(int x, int y, char symbol) {
            _map.SetSymbol(x, y, symbol);
        }

        public bool AreSymbolsOnTheMap(List<char> chars) {
            return _map.AreSymbolsOnTheMap(chars);
        }

        public abstract char GetSymbolToPrint(int x, int y);
    }
}
