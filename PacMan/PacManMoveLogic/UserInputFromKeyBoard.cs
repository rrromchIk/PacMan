
namespace PacMan {
    class UserInputFromKeyBoard : IUserInput {
        private static Direction directionMove = Direction.None;

        public Direction GetDirection() {
            if (Console.KeyAvailable) {
                directionMove = KeyHandler(Console.ReadKey(true).Key);
            }

            return directionMove;
        }

        public static Direction KeyHandler(ConsoleKey key) {
            return key switch {
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
                _ => Direction.None
            };
        }
    }
}
