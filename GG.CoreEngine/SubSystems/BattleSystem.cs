using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using GG.CoreEngine.Data;
using GG.CoreEngine.States;

namespace GG.CoreEngine.SubSystems
{
    class BattleSystem : ISubSystem
    {
        private readonly Engine _engine;

        public BattleSystem(Engine engine)
        {
            _engine = engine;
        }

        private Random rnd = new Random();

        public (bool End, bool Win) Battle(List<IEntity> left, List<IEntity> right)
        {
            if (DoAttack(left, right))
            {
                _engine.PublishEvent("battle.end", true);
                return (true, true);
            }
            if (DoAttack(right, left))
            {
                _engine.PublishEvent("battle.end", false);
                return (true, false);
            }
            return (false, false);
        }

        private bool DoAttack(List<IEntity> lList, List<IEntity> rList)
        {
            foreach (var actionOne in lList)
            {
                if (actionOne.FrameToAttack == 0)
                {
                    actionOne.FrameToAttack = CalcFrameToAttack(actionOne);

                    var target = rList.Count == 1 ? rList[0] : rList[rnd.Next(rList.Count)];
                    var damage = CalcDamage(actionOne, target);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private double CalcDefenceReduceRate(IEntity target)
        {
            var x = (double)target.Defence;
            return x / (Math.Abs(x) + Math.Pow(Math.Abs(x), 0.25F) * 3 + 30);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int CalcDamage(IEntity actionOne, IEntity target)
        {
            var damage = actionOne.Attack + (actionOne.AttackDelta > 0 ? rnd.Next(0, actionOne.AttackDelta) : 0);
            damage = Math.Max(0, (int)Math.Ceiling(damage * (1 - CalcDefenceReduceRate(target))) - target.ReduceDamage);
            return damage;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint CalcFrameToAttack(IEntity actionOne)
        {
            return (uint)Math.Ceiling(actionOne.BaseAttackFrame * (100d / Math.Max(10, 100d + actionOne.Speed)));
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