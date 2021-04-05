using System.IO;
using UnityEngine;
using HarmonyLib;

namespace MoreSkills.Utility
{
    static class Helper
    {
        public static Texture2D LoadPng(Stream fileStream)
        {
            Texture2D texture = null;
            if (fileStream != null)
            {
                using (var memoStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoStream);
                    texture = new Texture2D(2, 2);
                    texture.LoadImage(memoStream.ToArray()); //This will auto-resize the texture dimensions.
                }
            }
            return texture;
        }

        public struct HuntingDrops
        {
            public string CreaturePrefab { get; }
            public int Max { get; }
            public int Min { get; }
            public float Chance { get; }

            public HuntingDrops(string creatureprefab, int max, int min, float chance)
            {
                CreaturePrefab = creatureprefab;
                Max = max;
                Min = min;
                Chance = chance;
            }
        }
        public struct TamingSaves
        {
            public string CreatureZDOID { get; }
            public ZDOID TamerID { get; }
            public float TameTime { get; }
            public float EatTime { get; }
            public float Master { get; }
            public float Tamer { get; }
            public float Unlock { get; }

            public TamingSaves(string creaturezdoid, ZDOID tamerid, float tametime, float eattime, float master, float tamer, float unlock)
            {
                CreatureZDOID = creaturezdoid;
                TamerID = tamerid;
                TameTime = tametime;
                EatTime = eattime;
                Master = master;
                Tamer = tamer;
                Unlock = unlock;
            }
        }
        public struct TamingLevels
        {
            public string Creature { get; }
            public float Master { get; }
            public float Tamer { get; }
            public float Unlock { get; }
            public float TameTime { get; }

            public TamingLevels(string creature, float master, float tamer, float unlock, float tametime)
            {
                Creature = creature;
                Master = master;
                Tamer = tamer;
                Unlock = unlock;
                TameTime = tametime;
            }
        }
        public struct TamingFix
        {
            public string CreatureZDOID { get; }
            public bool Fixed { get; }

            public TamingFix(string creaturezdoid, bool tfixed)
            {
                CreatureZDOID = creaturezdoid;

                Fixed = tfixed;
            }
        }
        public struct TamingGotFar
        {
            public string CreatureZDOID { get; }
            public bool GotFar { get; }

            public TamingGotFar(string creaturezdoid, bool gotfar)
            {
                CreatureZDOID = creaturezdoid;

                GotFar = gotfar;
            }
        }
        public struct TamingDoubleCheck
        {
            public string CreatureZDOID { get; }
            public int DoubleCheck { get; }

            public TamingDoubleCheck(string creaturezdoid, int doublecheck)
            {
                CreatureZDOID = creaturezdoid;

                DoubleCheck = doublecheck;
            }
        }
        public struct CraftingSaves
        {
            public string ObjNumItem { get; }
            public float ObjNum { get; }
            public float ItemCNum { get; }
            public float ItemUNum { get; }

            public CraftingSaves(string objnumitem, float objnum, float itemcnum, float itemunum)
            {
                ObjNumItem = objnumitem;
                ObjNum = objnum;
                ItemCNum = itemcnum;
                ItemUNum = itemunum;
            }
        }
    }
}
