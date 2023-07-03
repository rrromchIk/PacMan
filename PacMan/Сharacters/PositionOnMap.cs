
namespace PacMan {
    /**
     * Position on map represents x and y coordinate for characters on map.
     */
    class PositionOnMap {
        public int XPos { get; set; }
        public int YPos { get; set; }

        public PositionOnMap(int x, int y) {
            XPos = x;
            YPos = y;
        }

        public static PositionOnMap GetPositionOnMap(IMap map, char characterSymbol) {
            return GetManyPositionsOnMap(map, characterSymbol).First();
        }

        public static IEnumerable<PositionOnMap> GetManyPositionsOnMap(IMap map, char characterSymbol) {
            for (int y = 0; y < map.Height; y++) {
                for (int x = 0; x < map.Width; x++) {
                    if (map.GetSymbol(x, y) == characterSymbol) {
                        yield return new PositionOnMap(x, y);
                    }
                }
            }
        }

        public override bool Equals(object? obj) {
            if (this == obj) {
                return true;
            }

            if(obj == null || obj is not PositionOnMap) {
                return false;
            }

            PositionOnMap anotherPosition = (PositionOnMap)obj;
            return this.XPos == anotherPosition.XPos && this.YPos == anotherPosition.YPos;
        }

        public override string ToString() {
            return $"[X: {XPos}, Y: {YPos}]";
        }

        public PositionOnMap Copy() {
            return (PositionOnMap)this.MemberwiseClone();
        }
    }
}
