using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GG.CoreEngine;
using GG.CoreEngine.Commands;

namespace GG.Engine.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new CoreEngine.Engine();
            engine.ScheduleCommand(new EnterMapCommand("Map1"));
            engine.ScheduleCommand(new TestCommand("0"));
            engine.ScheduleCommand(new TestCommand("1f"), 1);
            engine.ScheduleCommand(new TestCommand("20f"), 20);
            engine.ScheduleCommand(new TestCommand("2s"), TimeSpan.FromSeconds(2));
            // engine.RegisterEvent("battle.end", new EndBattleEvent());
            engine.Start();
            Thread.Sleep(1000);
            engine.ScheduleCommand(new TestCommand("1f-1"), 1);
            while (engine.Running)
            {
                Thread.Sleep(0);
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

    internal class TestCommand : ICommand
    {
        /// <summary>
        ///   初始化 <see cref="T:System.Object" /> 类的新实例。
        /// </summary>
        public TestCommand(string v)
        {
            V = v;
        }

        public void Execute(CoreEngine.Engine engine)
        {
            Console.WriteLine("TestCommand:" + V);
        }

        public string V { get; private set; }

        public override string ToString()
        {
            return V;
        }
    }
}