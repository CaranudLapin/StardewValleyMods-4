﻿using BattleRoyale.Utils;
using Netcode;
using StardewValley;
using StardewValley.Projectiles;
using System;

namespace BattleRoyale.Patches
{
    class SlingshotPatch4 : Patch
    {
        protected override PatchDescriptor GetPatchDescriptor() => new(typeof(BasicProjectile), "behaviorOnCollisionWithPlayer");

        public static bool Prefix(BasicProjectile __instance, GameLocation location, Farmer player)
        {
            bool damagesMonsters = ModEntry.BRGame.Helper.Reflection.GetField<NetBool>(__instance, "damagesMonsters").GetValue().Value;

            if (SlingshotPatch5.GetFarmerBounds(player).Intersects(__instance.getBoundingBox()))
            {
                //TODO: modify slingshot damage here?
                int damage = __instance.damageToFarmer.Value;

                Console.WriteLine("sending slingshot damage to other player");
                FarmerUtils.TakeDamage(player, DamageSource.PLAYER, damage, Game1.player.UniqueMultiplayerID);

                try
                {
                    if (!HitShaker.IsPlayerFlashing(player.UniqueMultiplayerID))
                    {
                        var r = ModEntry.BRGame.Helper.Reflection;
                        r.GetMethod(__instance, "explosionAnimation", false)?.Invoke(location);
                    }
                }
                catch (Exception) { }
            }
            return false;
        }
    }
}
