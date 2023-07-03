using SharpDX.XInput;

namespace PacMan {
    class UserInputConfig {
        private static IUserInput _activeUserInput;
        private static MyLogger _logger = new MyLogger(typeof(UserInputConfig));

        static UserInputConfig() {
            if (IsGamepadAvailable()) {
                _activeUserInput = new UserInputFromGamepad();
                _logger.Debug("Active user input is set to Gamepad");
            } else {
                _logger.Debug("Active user input is set to Keyboard");
                _activeUserInput = new UserInputFromKeyBoard();
            }
        }

        private static bool IsGamepadAvailable() {
            Controller _controller = new Controller(UserIndex.One);
            return _controller.IsConnected;
        }

        public static IUserInput GetUserInput() {
            return _activeUserInput;
        }
    }
}
