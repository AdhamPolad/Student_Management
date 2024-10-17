using ConsoleApp1.Enum;

namespace ConsoleApp1.Logger
{
    public class Loggers
    {
        private readonly string _filePath;
        private string _path;

        public Loggers(string filePath)
        {
            _filePath = filePath;

            Initialize();
        }

        private void Initialize()
        {
             _path = Path.Combine(_filePath, "Log.txt");
            if (!File.Exists(_path))
            {
                using (File.Create(_path)) ;
                
            }


        }

        public void LogError(Exception exp)
        {
            using( StreamWriter writer = new StreamWriter(_path, true))
            {
                writer.WriteLine($"{DateTime.Now} - {LogType.ERROR} - {exp.StackTrace} - {exp.Message}");
            }
        }
        public void LogInfo(string message)
        {
            using (StreamWriter writer = new StreamWriter(_path, true))
            {
                writer.WriteLine($"{DateTime.Now} - {LogType.INFO} - {message}");
            }
        }

    }
}
