using Microsoft.Xna.Framework;
using StardewRoguelike.UI;
using StardewValley;
using System;
using System.Collections.Generic;

namespace StardewRoguelike
{
    public class Perks
    {
        public enum PerkRarity
        {
            Common,
            Uncommon,
            Rare
        }

        #pragma warning disable format
        public enum PerkType
        {
            Fighter          = 0,
            Scout            = 1,
            Gemologist       = 2,
            SpecialCharm     = 3,
            Reflect          = 4,
            Swift            = 5,
            Shield           = 6,
            Immunity         = 7,
            Precision        = 8,
            Discount         = 9,
            Miner            = 10,
            Brute            = 11,
            Defender         = 12,
            BarrelEnthusiast = 13,
            Leech            = 14,
            FoodEnjoyer      = 15,
            Acrobat          = 16,
            Desperado        = 17,
            RabbitsFoot      = 18,
            TurtleShell      = 19,
            Geologist        = 20,
            Scavenger        = 21,
            Sturdy           = 22,
            Indecisive       = 23,
            Fisherman        = 24,
            Deconstructor    = 25,
            Gamer            = 26,
            Tiller           = 27
        }
        #pragma warning restore format

        public static readonly List<PerkType> CommonPerks = new()
        {
            PerkType.Fighter, PerkType.Scout, PerkType.Gemologist,
            PerkType.SpecialCharm, PerkType.Reflect, PerkType.Swift,
            PerkType.Shield, PerkType.Immunity, PerkType.Precision,
            PerkType.Discount, PerkType.Gamer, PerkType.Tiller
        };

        public static readonly List<PerkType> UncommonPerks = new()
        {
            PerkType.Miner, PerkType.Brute, PerkType.Defender,
            PerkType.BarrelEnthusiast, PerkType.FoodEnjoyer,
            PerkType.Geologist, PerkType.Scavenger, PerkType.Sturdy,
            PerkType.Indecisive, PerkType.Deconstructor, PerkType.Fisherman
        };

        public static readonly List<PerkType> RarePerks = new()
        {
            PerkType.Acrobat, PerkType.Desperado, PerkType.RabbitsFoot,
            PerkType.TurtleShell, PerkType.Leech
        };

        public static PerkMenu? CurrentMenu = null;

        private static readonly int TotalPerkCount = CommonPerks.Count + UncommonPerks.Count + RarePerks.Count;

        private static readonly float CommonPerkChance = 0.6f;

        private static readonly float UncommonPerkChance = 0.3f;

        private static readonly float RarePerkChance = 0.1f;

        private static readonly HashSet<PerkType> ActivePerks = new();

        public static string GetPerkDisplayName(PerkType perkType)
        {
            return perkType switch
            {
                PerkType.Fighter => I18n.PerkTypeName_Fighter(),
                PerkType.Scout => I18n.PerkTypeName_Scout(),
                PerkType.Gemologist => I18n.PerkTypeName_Gemologist(),
                PerkType.SpecialCharm => I18n.PerkTypeName_SpecialCharm(),
                PerkType.Reflect => I18n.PerkTypeName_Reflect(),
                PerkType.Swift => I18n.PerkTypeName_Swift(),
                PerkType.Shield => I18n.PerkTypeName_Shield(),
                PerkType.Immunity => I18n.PerkTypeName_Immunity(),
                PerkType.Precision => I18n.PerkTypeName_Precision(),
                PerkType.Discount => I18n.PerkTypeName_Discount(),
                PerkType.Miner => I18n.PerkTypeName_Miner(),
                PerkType.Brute => I18n.PerkTypeName_Brute(),
                PerkType.Defender => I18n.PerkTypeName_Defender(),
                PerkType.BarrelEnthusiast => I18n.PerkTypeName_BarrelEnthusiast(),
                PerkType.Leech => I18n.PerkTypeName_Leech(),
                PerkType.FoodEnjoyer => I18n.PerkTypeName_FoodEnjoyer(),
                PerkType.Acrobat => I18n.PerkTypeName_Acrobat(),
                PerkType.Desperado => I18n.PerkTypeName_Desperado(),
                PerkType.RabbitsFoot => I18n.PerkTypeName_RabbitsFoot(),
                PerkType.TurtleShell => I18n.PerkTypeName_TurtleShell(),
                PerkType.Geologist => I18n.PerkTypeName_Geologist(),
                PerkType.Scavenger => I18n.PerkTypeName_Scavenger(),
                PerkType.Sturdy => I18n.PerkTypeName_Sturdy(),
                PerkType.Indecisive => I18n.PerkTypeName_Indecisive(),
                PerkType.Fisherman => I18n.PerkTypeName_Fisherman(),
                PerkType.Deconstructor => I18n.PerkTypeName_Deconstructor(),
                PerkType.Gamer => I18n.PerkTypeName_Gamer(),
                PerkType.Tiller => I18n.PerkTypeName_Tiller(),
                _ => "Not Implemented"
            };
        }

        public static string GetPerkDescription(PerkType perkType)
        {
            return perkType switch
            {
                PerkType.Fighter => I18n.PerkTypeDesc_Fighter(),
                PerkType.Scout => I18n.PerkTypeDesc_Scout(),
                PerkType.Gemologist => I18n.PerkTypeDesc_Gemologist(),
                PerkType.SpecialCharm => I18n.PerkTypeDesc_SpecialCharm(),
                PerkType.Reflect => I18n.PerkTypeDesc_Reflect(),
                PerkType.Swift => I18n.PerkTypeDesc_Swift(),
                PerkType.Shield => I18n.PerkTypeDesc_Shield(),
                PerkType.Immunity => I18n.PerkTypeDesc_Immunity(),
                PerkType.Precision => I18n.PerkTypeDesc_Precision(),
                PerkType.Discount => I18n.PerkTypeDesc_Discount(),
                PerkType.Miner => I18n.PerkTypeDesc_Miner(),
                PerkType.Brute => I18n.PerkTypeDesc_Brute(),
                PerkType.Defender => I18n.PerkTypeDesc_Defender(),
                PerkType.BarrelEnthusiast => I18n.PerkTypeDesc_BarrelEnthusiast(),
                PerkType.Leech => I18n.PerkTypeDesc_Leech(),
                PerkType.FoodEnjoyer => I18n.PerkTypeDesc_FoodEnjoyer(),
                PerkType.Acrobat => I18n.PerkTypeDesc_Acrobat(),
                PerkType.Desperado => I18n.PerkTypeDesc_Desperado(),
                PerkType.RabbitsFoot => I18n.PerkTypeDesc_RabbitsFoot(),
                PerkType.TurtleShell => I18n.PerkTypeDesc_TurtleShell(),
                PerkType.Geologist => I18n.PerkTypeDesc_Geologist(),
                PerkType.Scavenger => I18n.PerkTypeDesc_Scavenger(),
                PerkType.Sturdy => I18n.PerkTypeDesc_Sturdy(),
                PerkType.Indecisive => I18n.PerkTypeDesc_Indecisive(),
                PerkType.Fisherman => I18n.PerkTypeDesc_Fisherman(),
                PerkType.Deconstructor => I18n.PerkTypeDesc_Deconstructor(),
                PerkType.Gamer => I18n.PerkTypeDesc_Gamer(),
                PerkType.Tiller => I18n.PerkTypeDesc_Tiller(),
                _ => "Not Implemented"
            };
        }

        public static Rectangle GetPerkSourceRect(PerkType perkType)
        {
            return new((int)perkType % 6 * 16, 624 + (int)perkType / 6 * 16, 16, 16);
        }

        public static PerkRarity GetPerkRarity(PerkType perkType)
        {
            if (CommonPerks.Contains(perkType))
                return PerkRarity.Common;
            else if (UncommonPerks.Contains(perkType))
                return PerkRarity.Uncommon;
            else
                return PerkRarity.Rare;
        }

        public static HashSet<PerkType> GetActivePerks()
        {
            return ActivePerks;
        }

        public static PerkType GetRandomPerk()
        {
            double roll = Roguelike.FloorRng.NextDouble();
            if (roll < CommonPerkChance)
                return CommonPerks[Roguelike.FloorRng.Next(CommonPerks.Count)];
            else if (roll < CommonPerkChance + UncommonPerkChance)
                return UncommonPerks[Roguelike.FloorRng.Next(UncommonPerks.Count)];
            else if (roll < CommonPerkChance + UncommonPerkChance + RarePerkChance)
                return RarePerks[Roguelike.FloorRng.Next(RarePerks.Count)];

            throw new Exception("doesnt add up to 100");
        }

        public static PerkType? GetRandomUniquePerk()
        {
            if (HasAllPerks())
                return null;

            PerkType perk = GetRandomPerk();
            while (ActivePerks.Contains(perk))
                perk = GetRandomPerk();

            return perk;
        }

        public static (PerkType?, PerkType?) GetTwoRandomUniquePerks()
        {
            if (HasAllPerks())
                return (null, null);
            else if (ActivePerks.Count + 1 == TotalPerkCount)
                return (GetRandomUniquePerk()!.Value, null);

            PerkType perk1 = GetRandomUniquePerk()!.Value;
            PerkType perk2;
            do
            {
                perk2 = GetRandomUniquePerk()!.Value;
            } while (perk2 == perk1);

            return (perk1, perk2);
        }

        public static void AddPerk(PerkType perkType)
        {
            if (HasPerk(perkType))
                return;

            switch (perkType)
            {
                case PerkType.Fighter:
                    Game1.player.professions.Add(24);
                    break;
                case PerkType.Scout:
                    Game1.player.professions.Add(25);
                    break;
                case PerkType.Gemologist:
                    Game1.player.professions.Add(23);
                    break;
                case PerkType.Miner:
                    Game1.player.professions.Add(18);
                    break;
                case PerkType.Brute:
                    Game1.player.professions.Add(26);
                    break;
                case PerkType.Defender:
                    Roguelike.TrueMaxHP += 25;
                    Game1.player.health = Roguelike.TrueMaxHP;
                    break;
                case PerkType.Acrobat:
                    Game1.player.professions.Add(28);
                    break;
                case PerkType.Geologist:
                    Game1.player.professions.Add(19);
                    break;
                case PerkType.SpecialCharm:
                    Game1.player.addedLuckLevel.Value += 1;
                    break;
                case PerkType.Swift:
                    Game1.player.addedSpeed += 1;
                    break;
                case PerkType.Immunity:
                    Game1.player.immunity += 2;
                    break;
                case PerkType.RabbitsFoot:
                    Game1.player.addedLuckLevel.Value += 3;
                    break;
                case PerkType.Tiller:
                    Game1.player.professions.Add(1);
                    break;
            }

            ActivePerks.Add(perkType);
        }

        public static void RemovePerk(PerkType perkType)
        {
            if (!HasPerk(perkType))
                return;

            switch (perkType)
            {
                case PerkType.Fighter:
                    Game1.player.professions.Remove(24);
                    break;
                case PerkType.Scout:
                    Game1.player.professions.Remove(25);
                    break;
                case PerkType.Gemologist:
                    Game1.player.professions.Remove(23);
                    break;
                case PerkType.Miner:
                    Game1.player.professions.Remove(18);
                    break;
                case PerkType.Brute:
                    Game1.player.professions.Remove(26);
                    break;
                case PerkType.Defender:
                    Roguelike.TrueMaxHP = Math.Max(0, Roguelike.TrueMaxHP - 25);
                    if (Curse.HasCurse(CurseType.GlassCannon))
                        Game1.player.health = Math.Min(Roguelike.TrueMaxHP / 2, Game1.player.health);
                    else
                        Game1.player.health = Math.Min(Roguelike.TrueMaxHP, Game1.player.health);
                    break;
                case PerkType.Acrobat:
                    Game1.player.professions.Remove(28);
                    break;
                case PerkType.Geologist:
                    Game1.player.professions.Remove(19);
                    break;
                case PerkType.SpecialCharm:
                    Game1.player.addedLuckLevel.Value -= 1;
                    break;
                case PerkType.Swift:
                    Game1.player.addedSpeed -= 1;
                    break;
                case PerkType.Immunity:
                    Game1.player.immunity -= 2;
                    break;
                case PerkType.RabbitsFoot:
                    Game1.player.addedLuckLevel.Value -= 3;
                    break;
                case PerkType.Tiller:
                    Game1.player.professions.Remove(1);
                    break;
            }

            ActivePerks.Remove(perkType);
        }

        public static bool HasPerk(PerkType perkType)
        {
            return ActivePerks.Contains(perkType);
        }

        public static bool HasAllPerks()
        {
            return ActivePerks.Count == TotalPerkCount;
        }

        public static void RemoveAllPerks()
        {
            foreach (PerkType perkType in Enum.GetValues(typeof(PerkType)))
                RemovePerk(perkType);
        }
    }
}
