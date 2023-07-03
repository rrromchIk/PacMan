
namespace PacMan {
    class NewYearPointsMap : BaseMapDecorator {
        private const char NEW_YEAR_POINT_SYMBOL = '❆';
        private const char NEW_YEAR_BIG_POINT_SYMBOL = '☃';

        public NewYearPointsMap(IMap map) : base(map) { }   

        public override char GetSymbolToPrint(int x, int y) {
            char baseSymbol = _map.GetSymbol(x, y);
            char resultSymbol;

            if (baseSymbol == GameSymbols.POINT_SYMBOL) {
                resultSymbol = NEW_YEAR_POINT_SYMBOL;
            } else if(baseSymbol == GameSymbols.BIG_POINT_SYMBOL) {
                resultSymbol = NEW_YEAR_BIG_POINT_SYMBOL;
            } else {
                resultSymbol = baseSymbol;
            }

            return resultSymbol;
        }
    }
}
