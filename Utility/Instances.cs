using System;
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

        [HarmonyPatch(typeof(Vagon), "UpdateMass")]
        public static class SI_Vagon
        {
            public static void Postfix(ref Vagon __instance)
            {
                if (__instance != null)
                    _cart = __instance;
            }
        }

        [HarmonyPatch(typeof(Player),"UpdateStats")]
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
    }
}
