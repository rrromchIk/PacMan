
namespace PacMan {
    class HeartPointMap : BaseMapDecorator {
        private const char HEART_POINT_SYMBOL = '\u2661';
        private const char HEART_BIG_POINT_SYMBOL = '\u2665';
        
        public HeartPointMap(IMap map) : base(map) { }

        public override char GetSymbolToPrint(int x, int y) {
            char baseSymbol = _map.GetSymbol(x, y);
            char resultSymbol;

            if (baseSymbol == GameSymbols.POINT_SYMBOL) {
                resultSymbol = HEART_POINT_SYMBOL;
            } else if (baseSymbol == GameSymbols.BIG_POINT_SYMBOL) {
                resultSymbol = HEART_BIG_POINT_SYMBOL;
            } else {
                resultSymbol = baseSymbol;
            }

            return resultSymbol;
        }
    }
}
