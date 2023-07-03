
namespace PacMan {
    interface IMap {
        char GetSymbolToPrint(int x, int y);

        char GetSymbol(int x, int y);

        void SetSymbol(int x, int y, char symbol);

        bool AreSymbolsOnTheMap(List<char> chars);

        int Width { get; set; }
        int Height { get; set; }
    }
}
