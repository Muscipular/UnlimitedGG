using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace GG.CoreEngine
{
    public class Engine
    {
        internal const double FrameTime = 1000 / 60f;

        private CommandScheduler commandScheduler;

        private EventManager eventManager;

        private Looper looper;

        private BattleManager battleManager;

        protected object locker = new object();

        private ulong currentFrame = 0;

        public Engine()
        {
            battleManager = new BattleManager(this);
            eventManager = new EventManager(this);
            commandScheduler = new CommandScheduler(this);
            looper = new Looper(OnFrame);
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

        private Entity me = new Entity() { Name = "Me", BaseAttackFrame = 60, Attack = 10 };

        private Entity enemy = new Entity() { Name = "Cat", BaseAttackFrame = 20, Attack = 1 };

        private void ProcessFrame()
        {
            battleManager.Battle(new List<Entity>() { me }, new List<Entity>() { enemy });
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

    internal class BattleManager
    {
        private readonly Engine _engine;

        public BattleManager(Engine engine)
        {
            _engine = engine;
        }

        private Random rnd = new Random();

        public void Battle(List<Entity> left, List<Entity> right)
        {
            if (DoAttack(left, right))
            {
                _engine.PublishEvent("battle.end", true);
                return;
            }
            if (DoAttack(right, left))
            {
                _engine.PublishEvent("battle.end", false);
            }
        }

        private bool DoAttack(List<Entity> lList, List<Entity> rList)
        {
            foreach (var actionOne in lList)
            {
                if (actionOne.FrameToAttack == 0)
                {
                    actionOne.FrameToAttack = (uint)Math.Ceiling(actionOne.BaseAttackFrame * (100d / Math.Max(10, 100d + actionOne.Speed)));

                    var target = rList.Count == 1 ? rList[0] : rList[rnd.Next(rList.Count)];
                    var damage = actionOne.Attack + (actionOne.AttackDelta > 0 ? rnd.Next(0, actionOne.AttackDelta) : 0);
                    target.HP -= damage;
                    _engine.PublishEvent("entity.damage", new { Damage = damage, From = actionOne, To = target });
                    if (target.HP <= 0)
                    {
                        _engine.PublishEvent("entity.die", target);

                        if (rList.TrueForAll(c => c.HP <= 0))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    actionOne.FrameToAttack--;
                }
            }
            return false;
        }
    }

    internal class Entity
    {
        public string Name { get; set; }

        public int HP { get; set; } = 100;

        public int Attack { get; set; } = 1;

        public int AttackDelta { get; set; } = 5;

        public uint BaseAttackFrame { get; set; } = 60;

        public int Speed { get; set; } = 0;

        public uint FrameToAttack { get; set; }
    }
}