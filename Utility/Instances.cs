using HarmonyLib;

namespace MoreSkills.Utility
{
    public class MoreSkills_Instances
    {
        public static Vagon _cart;
        public static Player _player;
        public static Inventory _inventory;
        public static ItemDrop _itemDrop;
        public static ObjectDB _objectDB;
        public static InventoryGui _inventoryGui;
        public static ZNetView _zNetView;
        public static MineRock5 _mineRock5;
        public static Character _CDamage;
        public static ZDOID _CDAttacker;
        public static Destructible _DDamage;
        public static ZDOID _DDAttacker;

        [HarmonyPatch(typeof(Vagon), "UpdateMass")]
        public static class SI_Vagon
        {
            public static void Postfix(ref Vagon __instance)
            {
                if (__instance != null)
                    _cart = __instance;
            }
        }

        [HarmonyPatch(typeof(Player), "UpdateStats")]
        public static class SI_Player
        {
            public static void Postfix(ref Player __instance)
            {
                if (__instance != null)
                    _player = __instance;
            }
        }

        [HarmonyPatch(typeof(Inventory), "UpdateTotalWeight")]
        public static class SI_Inventory
        {
            public static void Postfix(ref Inventory __instance)
            {
                if (__instance != null)
                    _inventory = __instance;
            }
        }

        [HarmonyPatch(typeof(ItemDrop), "SlowUpdate")]
        public static class SI_ItemDrop
        {
            public static void Postfix(ref ItemDrop __instance)
            {
                if (__instance != null)
                    _itemDrop = __instance;
            }
        }

        [HarmonyPatch(typeof(ObjectDB), "Awake")]
        public static class SI_ObjectDB
        {
            public static void Postfix(ref ObjectDB __instance)
            {
                if (__instance != null)
                    _objectDB = __instance;
            }
        }

        [HarmonyPatch(typeof(InventoryGui), "Awake")]
        public static class SI_InventoryGui
        {
            public static void Postfix(ref InventoryGui __instance)
            {
                if (__instance != null)
                    _inventoryGui = __instance;
            }
        }

        [HarmonyPatch(typeof(ZNetView), "Awake")]
        public static class SI_ZNetView
        {
            public static void Postfix(ref ZNetView __instance)
            {
                if (__instance != null)
                    _zNetView = __instance;
            }
        }

        [HarmonyPatch(typeof(MineRock5), "Start")]
        public static class SI_MineRock5
        {
            public static void Postfix(ref MineRock5 __instance)
            {
                _mineRock5 = __instance;
            }
        }

        [HarmonyPatch(typeof(Character), "Damage")]
        public static class SI_CDamage
        {
            public static void Postfix(ref Character __instance, HitData hit)
            {
                if (MoreSkills_Instances._player != null)
                {
                    _CDamage = __instance;

                    _CDAttacker = hit.m_attacker;
                }
            }
        }

        [HarmonyPatch(typeof(Destructible), "Damage")]
        public static class Si_DDamage
        {
            public static void Postfix(ref Destructible __instance, HitData hit)
            {
                if (MoreSkills_Instances._player != null)
                {
                    _DDamage = __instance;

                    _DDAttacker = hit.m_attacker;
                }
            }
        }
    }
}
