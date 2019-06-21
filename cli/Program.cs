using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Ceen.Httpd;
using Ceen.Httpd.Handler;
using GG.CoreEngine.Commands;
using GG.CoreEngine.Utility;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Control;
using Microsoft.FSharp.Core;
using Suave;
using Suave.Sockets;

namespace GG.Engine.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new CoreEngine.Engine(new Loader());
            engine.ScheduleCommand(new EnterMapCommand("Map1"));
            engine.ScheduleCommand(new EquipCommand("1"));
            engine.ScheduleCommand(new EquipCommand("2"));
            engine.ScheduleCommand(new EquipCommand("3"));
            // engine.ScheduleCommand(new TestCommand("0"));
            // engine.ScheduleCommand(new TestCommand("1f"), 1);
            // engine.ScheduleCommand(new TestCommand("20f"), 20);
            // engine.ScheduleCommand(new TestCommand("2s"), TimeSpan.FromSeconds(2));
            // engine.RegisterEvent("battle.end", new EndBattleEvent());
            engine.Start();
            Thread.Sleep(1000);
            // engine.ScheduleCommand(new TestCommand("1f-1"), 1);

            var cts = new CancellationTokenSource();
            var server = new Fleck.WebSocketServer("ws://127.0.0.1:8181");
            Fleck.FleckLog.LogAction = (level, s, arg3) => Logger.Log((Logger.Level)(4 - (int)level), "WS", $"{s}");
            server.Start((connection =>
            {
                connection.OnMessage = e =>
                {
                    Logger.Info("WebSocketServer", $"OnMsg: {e}");
                    if (e == "Close")
                    {
                        connection.Close();
                        engine.Stop();
                        cts.Cancel();
                        server.Dispose();
                    }
                };
            }));
            StartUI(cts.Token);
            while (engine.Running)
            {
                Thread.Sleep(100);
            }
            Logger.Debug("Main", $"Exit");
        }

        private static Task StartUI(CancellationToken token)
        {
            var serverConfig = new ServerConfig().AddRoute(new FileHandler(new FileHandler.RemappedVirtualFileSystem(openFile: e =>
            {
                Logger.Debug("Web", $"open {e}");
                return Task.FromResult<Stream>(new MemoryStream());
            })));
            return Ceen.Httpd.HttpServer.ListenAsync(IPEndPoint.Parse("127.0.0.1:8182"), false, serverConfig, token);
        }
    }

    // internal class EndBattleEvent : IEventHandler
    // {
    //     public void OnEvent(CoreEngine.Engine engine, object arg)
    //     {
    //         // engine.Stop();
    //     }
    //
    //     public bool IsOnce { get; } = false;
    //
    //     public bool IsAlive { get; } = true;
    // }
}