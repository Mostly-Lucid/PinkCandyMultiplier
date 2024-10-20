using System.Linq;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Scp330;
using InventorySystem.Items.Usables.Scp330;
using UnityEngine;

namespace PinkCandyMultiplier
{
    public static class EventHandler
    {
        public static void OnEatingCandy(EatingScp330EventArgs ev)
        {
            if (ev.Candy.Kind != CandyKindID.Pink) return;
            int pinkCount = ev.Scp330.Candies.Count(candy => candy == CandyKindID.Pink) -1;
            ev.Scp330.RemoveCandy(CandyKindID.Pink, true);
            Vector3 deathPos = ev.Player.Position;
            deathPos.y += 1;
            Log.Debug($"{ev.Player.Nickname} has {pinkCount} other pink candies!");
            if (pinkCount > Plugin.Instance.Config.MaxMultiplier)
            {
                pinkCount = Plugin.Instance.Config.MaxMultiplier;
                Log.Debug($"Clamped pinkCount to {pinkCount}");
            }
            for (int i = 0; i < pinkCount; i++)
            {
                ExplosiveGrenade grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE);
                grenade.FuseTime = 0.1f;
                grenade.SpawnActive(deathPos, ev.Player);
                Log.Debug($"Spawned Grenade {i + 1}/{pinkCount} for {ev.Player.Nickname} at {deathPos} successfully");
            }
        }
    }
}