using System;
using System.Linq;


namespace GG.CoreEngine.Utility
{
    public class Logger
    {
        public enum Level
        {
            None = 0,

            Fatal = 1,

            Error = 2,

            Info = 3,

            Debug = 4,

            Verb = 5,
        }

        public static void Log(Level level, string tag, FormattableString msg)
        {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.sss} {level:G} {tag} {msg.ToString()}");
        }

        public static void Verbose(string tag, FormattableString msg) => Log(Level.Verb, tag, msg);

        public static void Debug(string tag, FormattableString msg) => Log(Level.Debug, tag, msg);

        public static void Info(string tag, FormattableString msg) => Log(Level.Info, tag, msg);

        public static void Error(string tag, FormattableString msg) => Log(Level.Error, tag, msg);

        public static void Fatal(string tag, FormattableString msg) => Log(Level.Fatal, tag, msg);
    }
}