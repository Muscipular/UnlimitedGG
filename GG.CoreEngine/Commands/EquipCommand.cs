using System;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.States;


namespace GG.CoreEngine.Commands
{
    public class EquipCommand : ICommand
    {
        public string ItemId { get; set; }

        public EquipCommand(string itemId)
        {
            ItemId = itemId;
        }

        public void Execute(Engine engine)
        {
            var playerState = engine.State.Get<PlayerState>();
            var bagState = engine.State.Get<BagState>();
            var item = bagState[ItemId];
            if (item == null || item.Type != ItemType.Equip)
            {
                return;
            }
            var equipSlot = playerState.PlayerInfo.EquipSlot;
            var equips = playerState.PlayerInfo.Equips;
            var count = equips.Count(e => e.Value.Category == item.Category);
            if (!equipSlot.TryGetValue((EquipCategory)item.Category, out var n))
            {
                return;
            }
            bagState.Remove(item);
            if (count >= n)
            {
                var (id, value) = equips.First(e => e.Value.Category == item.Category);
                equips.Remove(id);
                bagState.Add(value);
            }
            equips.Add(item.Id, item);
        }
    }
}