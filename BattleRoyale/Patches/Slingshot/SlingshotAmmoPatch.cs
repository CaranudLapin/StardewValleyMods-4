﻿using StardewValley;
using StardewValley.Tools;

namespace BattleRoyale.Patches
{
    //Prevent reducing ammo by 1 when you click on the slingshot (not fire)
    class SlingshotAmmoPatch1 : Patch
    {
        protected override PatchDescriptor GetPatchDescriptor() => new(typeof(Slingshot), "DoFunction");

        private static Object oldObject;
        private static int oldStack = 0;
        private static int oldProjectilesCount = 0;

        public static void Prefix(Slingshot __instance, GameLocation location)
        {
            oldObject = __instance.attachments[0];
            oldStack = oldObject?.Stack ?? 0;
            oldProjectilesCount = location.projectiles?.Count ?? 0;
        }

        public static void Postfix(Slingshot __instance, GameLocation location)
        {
            if ((location.projectiles?.Count ?? 0) == oldProjectilesCount)
            {
                if (__instance.attachments[0] == null)
                    __instance.attachments[0] = oldObject;

                if (oldObject != null)
                    oldObject.Stack = oldStack;
            }
        }
    }
}
