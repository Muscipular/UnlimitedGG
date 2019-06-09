using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.Data.Config;
using GG.CoreEngine.States;
using GG.CoreEngine.SubSystems;
using GG.CoreEngine.SubSystems.Battle;
using GG.CoreEngine.SubSystems.Encounter;
using GG.CoreEngine.Utility;
using Newtonsoft.Json;

namespace GG.CoreEngine
{
    public class Engine
    {
        private IDataLoader _loader;

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


        public Engine(IDataLoader loader)
        {
            LoadData(loader);
            InitComponent();
            InitSubSystem();
        }

        private void InitSubSystem()
        {
            subSystems = new Dictionary<Type, ISubSystem>();
            subSystems.Add(typeof(PlayerStateSystem), new PlayerStateSystem(this));
            subSystems.Add(typeof(EncounterSystem), new EncounterSystem(this));
            subSystems.Add(typeof(BattleSystem), new BattleSystem(this));
            subSystems.Add(typeof(LootSystem), new LootSystem(this));
        }

        private void InitComponent()
        {
            eventManager = new EventManager(this);
            commandScheduler = new CommandScheduler(this);
            looper = new Looper(OnFrame);
        }

        private void LoadData(IDataLoader loader)
        {
            _loader = loader;
            Config<EnemyData>.Load(loader);
            Config<EncounterSet>.Load(loader);
            Config<MapData>.Load(loader);
            Config<ItemData>.Load(loader);
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
                Logger.Verbose("ScheduleCommand", $" {command}#{frame} @{currentFrame}");
                commandScheduler.ScheduleCommand(command, Math.Max(frame, 0));
            }
        }

        public void RegisterEvent<T>(IEventHandler<T> handler) where T : IEvent
        {
            eventManager.RegisterEvent(handler);
        }

        public void PublishEvent<T>(T args) where T : IEvent
        {
            Logger.Verbose(nameof(PublishEvent), $"{typeof(T).Name}: {JsonConvert.SerializeObject(args)}");
            eventManager.PublishEvent(args);
        }
    }
}