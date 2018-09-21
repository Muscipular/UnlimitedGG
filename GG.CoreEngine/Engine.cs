using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.Data.Config;
using GG.CoreEngine.States;
using GG.CoreEngine.SubSystems;
using Newtonsoft.Json;

namespace GG.CoreEngine
{
    public class Engine
    {
        internal const double FrameTime = 1000 / 60f;

        private CommandScheduler commandScheduler;

        private EventManager eventManager;

        private Looper looper;

        private Dictionary<Type, ISubSystem> subSystems;

        protected object locker = new object();

        private ulong currentFrame = 0;

        public StateContainer State = new StateContainer(new IState[]
        {
            new BattleState(),
            new PlayerState(),
            new LogState(),
            new MapState(),
        });


        public Engine()
        {
            Config<EnemyData>.Load(File.OpenRead("Data/Config/enemy.json"));
            Config<EncounterSet>.Load(File.OpenRead("Data/Config/encounter.json"));
            Config<MapData>.Load(File.OpenRead("Data/Config/map.json"));
            subSystems = new Dictionary<Type, ISubSystem>()
            {
                { typeof(EncounterSystem), new EncounterSystem(this) },
                { typeof(BattleSystem), new BattleSystem(this) },
                { typeof(LootSystem), new LootSystem(this) },
            };
            eventManager = new EventManager(this);
            commandScheduler = new CommandScheduler(this);
            looper = new Looper(OnFrame);
        }

        public T GetSubSystem<T>() where T : ISubSystem
        {
            if (subSystems.TryGetValue(typeof(T), out var subSystem))
            {
                return (T)subSystem;
            }
            return default(T);
        }

        public bool Running => looper.Running;

        public void Start()
        {
            looper.Start();
        }

        public void Stop()
        {
            looper.Stop();
        }

        private void OnFrame(DateTime time)
        {
            // Console.WriteLine($"OnFrame: {currentFrame} {time.Ticks}");
            lock (locker)
            {
                OnBeforeFrame();
                ProcessFrame();
                OnAfterFrame();
            }
        }

        private void ProcessFrame()
        {
            foreach (var (type, subSystem) in subSystems)
            {
                subSystem.Process(currentFrame);
            }
        }

        private void OnAfterFrame()
        {
            currentFrame++;
        }

        private void OnBeforeFrame()
        {
            commandScheduler.Process(currentFrame);
        }

        public void ScheduleCommand(ICommand command, TimeSpan? delay = null)
        {
            lock (locker)
            {
                commandScheduler.ScheduleCommand(command, delay == null ? 0 : Math.Max(0, (uint)Math.Ceiling((delay.Value.TotalMilliseconds / FrameTime))));
            }
        }

        public void ScheduleCommand(ICommand command, uint frame)
        {
            lock (locker)
            {
                Console.WriteLine($"ScheduleCommand: {command}#{frame} @{currentFrame}");
                commandScheduler.ScheduleCommand(command, Math.Max(frame, 0));
            }
        }

        public void RegisterEvent(string eventName, IEventHandler handler)
        {
            eventManager.RegisterEvent(eventName, handler);
        }

        public void PublishEvent(string eventName, object args)
        {
            Console.WriteLine($"{eventName}: {JsonConvert.SerializeObject(args)}");
            eventManager.PublishEvent(eventName, args);
        }
    }
}