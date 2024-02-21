using System.Drawing;
using System.Dynamic;

namespace SharedUtils
{
    public static class Common
    {
        public const string WarnSign = "⚠";
        public static readonly string CommonDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Puppeteer");
        public static readonly char DirectorySeparator = Path.DirectorySeparatorChar;

        public static void LogRed(string? title = null, Exception? e = null)
        {
            if (title is not null)
                Log($"{title}\n", ConsoleColor.Red);

            if (e is not null)
                Log($"Exception details:\n{e}\n", ConsoleColor.Red);
        }

        public static string FindChromePath(string directory)
        {
            string[] files = Directory.GetFiles(directory, "chrome.exe", SearchOption.AllDirectories);
            return files.FirstOrDefault();
        }

        public static void LogGreen(string logText)
            => Log(logText + "\n", ConsoleColor.Green);

        public static void Log(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void WriteToLogFile(string text)
        {
            try
            {
                string path = $"{CommonDirectory}{DirectorySeparator}log.txt";
                File.AppendAllText(path, text + "\n-------------------------------------\n\n");
            }
            catch (Exception e)
            {
                LogRed("FILE LOG ERROR", e);
            }
        }
    }
}