using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;


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
            var ss = $"[{level:G}]{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} {tag} {msg.ToString()}";
            s.Add(ss);
        }

        static System.Collections.Concurrent.BlockingCollection<string> s = new BlockingCollection<string>();

        static Logger()
        {
            var thread = new Thread(() =>
            {
                foreach (var s1 in s.GetConsumingEnumerable())
                {
                    Console.WriteLine(s1);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public static void Verbose(string tag, FormattableString msg) => Log(Level.Verb, tag, msg);

        public static void Debug(string tag, FormattableString msg) => Log(Level.Debug, tag, msg);

        public static void Info(string tag, FormattableString msg) => Log(Level.Info, tag, msg);

        public static void Error(string tag, FormattableString msg) => Log(Level.Error, tag, msg);

        public static void Fatal(string tag, FormattableString msg) => Log(Level.Fatal, tag, msg);
    }
}