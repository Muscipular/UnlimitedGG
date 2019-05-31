using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using GG.CoreEngine.Data;
using GG.CoreEngine.Data.Skills;
using GG.CoreEngine.States;
using GG.CoreEngine.SubSystems.Battle;

namespace GG.CoreEngine.SubSystems
{
    class BattleSystem : ISubSystem
    {
        private readonly Engine _engine;

        public BattleSystem(Engine engine)
        {
            _engine = engine;
            _engine.RegisterEvent<EncounterEvent>(new InitBattleHandler());
        }

        private Random rnd = new Random();

        public (bool End, bool Win) Battle(List<IEntity> left, List<IEntity> right)
        {
            if (DoAttack(left, right))
            {
                _engine.PublishEvent(new BattleEndEvent()
                {
                    State = BattleEndState.Win
                });
                return (true, true);
            }
            if (DoAttack(right, left))
            {
                _engine.PublishEvent(new BattleEndEvent()
                {
                    State = BattleEndState.Lose
                });
                return (true, false);
            }
            return (false, false);
        }

        private bool DoAttack(List<IEntity> lList, List<IEntity> rList)
        {
            foreach (var actionOne in lList)
            {
                if (actionOne.FrameToAction == 0)
                {
                    actionOne.FrameToAction = CalcFrameToAction(actionOne);

                    var target = rList.Count == 1 ? rList[0] : rList[rnd.Next(rList.Count)];
                    var damage = CalcDamage(actionOne, target);
                    target.HP -= damage;
                    _engine.PublishEvent(new DamagedEvent(damage, actionOne, target));
                    if (target.HP <= 0)
                    {
                        _engine.PublishEvent(new EntityDieEvent() { Entity = target });

                        if (rList.TrueForAll(c => c.HP <= 0))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    actionOne.FrameToAction--;
                }
            }
            return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int CalcDamage(IEntity actionOne, IEntity target)
        {
            var damage = actionOne.Attack + (actionOne.AttackDelta > 0 ? rnd.Next(0, actionOne.AttackDelta) : 0);
            damage = Math.Max(0, (int)Math.Ceiling(damage * (1 - target.CalcDefenceReduceRate())) - target.ReduceDamage);
            return damage;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint CalcFrameToAction(IEntity actionOne)
        {
            return (uint)Math.Ceiling(actionOne.BaseActionFrame * (100d / Math.Max(10, 100d + actionOne.Speed)));
        }

        public void Process(ulong frame)
        {
            var battleState = _engine.State.Get<BattleState>();
            if (battleState.StateMode != BattleStateMode.InBattle)
            {
                return;
            }
            if (battleState.WaitFrame > 0)
            {
                battleState.WaitFrame--;
                return;
            }
            var (end, win) = Battle(battleState.PlayerTeam, battleState.EnemyTeam);
            if (end)
            {
                battleState.StateMode = win ? BattleStateMode.Loot : BattleStateMode.Encounter;
            }
        }
    }
}