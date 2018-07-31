using System;
using Newtonsoft.Json;
using UGG.Core.Utilities;
using UGG.Core.Utilities.Platform;

namespace UGG.DX
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new GoodGameCore())
            {
                game.Run();
            }
        }
    }

#endif
}