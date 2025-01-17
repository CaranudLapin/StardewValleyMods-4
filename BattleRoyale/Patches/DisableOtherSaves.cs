﻿using StardewValley;
using StardewValley.Menus;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace BattleRoyale.Patches
{
    class DisableOtherSaves : Patch
    {
        protected override PatchDescriptor GetPatchDescriptor() => new(typeof(LoadGameMenu), "FindSaveGames");

        public static bool Prefix(ref List<Farmer> __result)
        {
            __result = new List<Farmer>();

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"assets/Saves/{ModEntry.SaveFile}/SaveGameInfo");
            FileStream stream = File.OpenRead(path);

            Farmer f = (Farmer)SaveGame.farmerSerializer.Deserialize(stream);
            SaveGame.loadDataToFarmer(f);
            f.slotName = ModEntry.SaveFile;
            __result.Add(f);

            stream.Close();

            return false;
        }
    }
    class DisableOtherSaves2 : Patch
    {
        protected override PatchDescriptor GetPatchDescriptor() => new(typeof(SaveGame), "Load");

        public static bool Prefix()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"assets/Saves/{ModEntry.SaveFile}/{ModEntry.SaveFile}");

            Game1.gameMode = 6;
            Game1.loadingMessage = Game1.content.LoadString("Strings\\StringsFromCSFiles:SaveGame.cs.4690");
            Game1.currentLoader = SaveGame.getLoadEnumerator(path);

            return false;
        }
    }
}
