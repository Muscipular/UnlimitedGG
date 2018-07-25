using System;
using UGG.Core.Utilities;
using UGG.Core.Utilities.Platform;
using UGG.DX.Platform;

namespace UGG
{
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
                game.Services.AddService<IPlatformTool>(new PlatformTool());
                game.Run();
            }
        }
    }
}
