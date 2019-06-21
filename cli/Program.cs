using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GG.CoreEngine.Commands;

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
            while (engine.Running)
            {
                Thread.Sleep(100);
            }
            Console.ReadKey();
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