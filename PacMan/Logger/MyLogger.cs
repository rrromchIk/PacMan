
namespace PacMan {
    class MyLogger {
        private const string filePath = @"logs/log.txt";
        static MyLogger() {
            if (!File.Exists(filePath)) {
                File.Create(filePath).Dispose();
            }
        }

        private string _className;

        public MyLogger(Type type) {
            _className = type.Name;
        }

        public void Debug(string message) {
            WriteToFile(message, LogLevel.DEBUG);
        }

        public void Warn(string message) {
            WriteToFile(message, LogLevel.WARN);
        }

        public void Info(string message) {
            WriteToFile(message, LogLevel.INFO);
        }

        private void WriteToFile(string message, LogLevel level) {
            using (StreamWriter writer = new StreamWriter(filePath, true)) {
                writer.WriteLine($"[{DateTime.Now}] [{level}] {_className} - {message}");
            }
        }
    }

    enum LogLevel {
        DEBUG,
        INFO,
        WARN
    }
}
