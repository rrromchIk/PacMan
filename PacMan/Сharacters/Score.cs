
namespace PacMan {
    class Score {
        public const int NORMAL_POINT_VALUE = 2;
        public const int BIG_POINT_VALUE = 10;

        public int AmountOfPoints { get; private set; } = 0;

        public void Update(int amountOfPoints) {
            AmountOfPoints += amountOfPoints;
        }
    }
}
