using SharpDX.XInput;

namespace PacMan {
    class UserInputFromGamepad : IUserInput {
        private static Direction directionMove = Direction.None;
        private static Controller _controller;

        static UserInputFromGamepad() {
            _controller = new Controller(UserIndex.One);

            Thread myThread = new Thread(UpdateDirection);
            myThread.Start();
        }

        public Direction GetDirection() {
            return directionMove;
        }

        private static void UpdateDirection() {
            double sectorSize = 360.0f / 8;
            double halfSectorSize = sectorSize / 2.0f;
            double angleInRadians, angleInDegrees, convertedAngle, direction;
            State state;
            int X, Y;

            while (true) {
                state = _controller.GetState();
                X = state.Gamepad.LeftThumbX;
                Y = state.Gamepad.LeftThumbY;

                if (X != 0 || Y != 0) {
                    angleInRadians = Math.Atan2(X, Y);

                    if (angleInRadians < 0.0f) {
                        angleInRadians += (2.0f * Math.PI);
                    }

                    angleInDegrees = (180.0f * angleInRadians / Math.PI);
                    convertedAngle = angleInDegrees + halfSectorSize;
                    direction = (int)Math.Floor(convertedAngle / sectorSize);
                } else {
                    direction = -1;
                }

                switch (direction) {
                    case 0:
                    directionMove = Direction.Up;
                    break;
                    case 1:
                    directionMove = Direction.Up;
                    break;
                    case 2:
                    directionMove = Direction.Right;
                    break;
                    case 3:
                    directionMove = Direction.Down;
                    break;
                    case 4:
                    directionMove = Direction.Down;
                    break;
                    case 5:
                    directionMove = Direction.Down;
                    break;
                    case 6:
                    directionMove = Direction.Left;
                    break;
                    case 7:
                    directionMove = Direction.Up;
                    break;
                    default:
                    break;
                }  
            }
        }

        
    }
}
