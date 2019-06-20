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
            playerState.Bag.TryGetValue(ItemId, out var item);
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
            if (count >= n)
            {
                var (id, value) = equips.First(e => e.Value.Category == item.Category);
                equips.Remove(id);
                playerState.Bag.Add(id, value);
            }
            equips.Add(item.Id, item);
            playerState.Bag.Remove(item.Id);
        }
    }
}