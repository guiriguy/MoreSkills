using HarmonyLib;
using System.Collections.Generic;
using MoreSkills.Config;
using MoreSkills.Utility;
using UnityEngine;
using System.Linq;

namespace MoreSkills.ModSkills.NewSkills
{
    class MoreSkills_Taming
    {
        [HarmonyPatch(typeof(Tameable), "OnConsumedItem")]
        public static class SetTamer
        {
            public static void Postfix(ref Tameable __instance)
            {
                if (MoreSkills_Instances._player != null)
                {
                    //Debug.LogWarning("ZDOID ANTES: " + Creature1);
                    if (__instance.GetTameness() <= 10 && !__instance.m_character.IsTamed() && !__instance.m_character.IsPlayer())
                    {
                        //Debug.LogWarning("Using Slot 1");
                        Player closestPlayer = Player.GetClosestPlayer(__instance.transform.position, 30f);
                        if (closestPlayer.GetZDOID() == MoreSkills_Instances._player.GetZDOID())
                        {
                            if (MoreSkills_TamingConfig.EnableAllTamableCompatibility.Value)
                            {
                                string sCreature = __instance.name.Replace("(Clone)", "");
                                switch (__instance.name.Replace("(Clone)",""))
                                {
                                    case "Blob":
                                        Masterlvl1 = MoreSkills_TamingConfig.BlobLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.BlobLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.BlobLevelTamer.Value;
                                        break;
                                    case "BlobElite":
                                        Masterlvl1 = MoreSkills_TamingConfig.BlobEliteLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.BlobEliteLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.BlobEliteLevelUnlock.Value;
                                        break;
                                    case "Boar":
                                        Masterlvl1 = MoreSkills_TamingConfig.BoarLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.BoarLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.BoarLevelUnlock.Value;
                                        break;
                                    case "Deathsquito":
                                        Masterlvl1 = MoreSkills_TamingConfig.DeathsquitoLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.DeathsquitoLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.DeathsquitoLevelUnlock.Value;
                                        break;
                                    case "Hatchling":
                                        Masterlvl1 = MoreSkills_TamingConfig.DrakeLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.DrakeLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.DrakeLevelUnlock.Value;
                                        break;
                                    case "Draugr":
                                        Masterlvl1 = MoreSkills_TamingConfig.DraugrLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.DraugrLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.DraugrLevelUnlock.Value;
                                        break;
                                    case "Draugr_Elite":
                                        Masterlvl1 = MoreSkills_TamingConfig.DraugrEliteLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.DraugrEliteLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.DraugrEliteLevelUnlock.Value;
                                        break;
                                    case "Fenring":
                                        Masterlvl1 = MoreSkills_TamingConfig.FenringLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.FenringLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.FenringLevelUnlock.Value;
                                        break;
                                    case "Goblin":
                                        Masterlvl1 = MoreSkills_TamingConfig.GoblinLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.GoblinLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.GoblinLevelUnlock.Value;
                                        break;
                                    case "GoblinBrute":
                                        Masterlvl1 = MoreSkills_TamingConfig.GoblinBruteLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.GoblinBruteLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.GoblinBruteLevelUnlock.Value;
                                        break;
                                    case "GoblinShaman":
                                        Masterlvl1 = MoreSkills_TamingConfig.GoblinShamanLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.GoblinShamanLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.GoblinShamanLevelUnlock.Value;
                                        break;
                                    case "Greydwarf":
                                        Masterlvl1 = MoreSkills_TamingConfig.GreydwarfLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.GreydwarfLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.GreydwarfLevelUnlock.Value;
                                        break;
                                    case "Greydwarf_Elite":
                                        Masterlvl1 = MoreSkills_TamingConfig.GoblinBruteLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.GoblinBruteLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.GoblinBruteLevelUnlock.Value;
                                        break;
                                    case "Greydwarf_Shaman":
                                        Masterlvl1 = MoreSkills_TamingConfig.GoblinShamanLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.GoblinShamanLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.GoblinShamanLevelUnlock.Value;
                                        break;
                                    case "Greyling":
                                        Masterlvl1 = MoreSkills_TamingConfig.GreylingLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.GreylingLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.GreylingLevelUnlock.Value;
                                        break;
                                    case "Leech":
                                        Masterlvl1 = MoreSkills_TamingConfig.LeechLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.LeechLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.LeechLevelUnlock.Value;
                                        break;
                                    case "Lox":
                                        Masterlvl1 = MoreSkills_TamingConfig.LoxLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.LoxLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.LoxLevelUnlock.Value;
                                        break;
                                    case "Neck":
                                        Masterlvl1 = MoreSkills_TamingConfig.NeckLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.NeckLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.NeckLevelUnlock.Value;
                                        break;
                                    case "Serpent":
                                        Masterlvl1 = MoreSkills_TamingConfig.SerpentLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.SerpentLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.SerpentLevelUnlock.Value;
                                        break;
                                    case "Skeleton":
                                        Masterlvl1 = MoreSkills_TamingConfig.SkeletonLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.SkeletonLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.SkeletonLevelUnlock.Value;
                                        break;
                                    case "Skeleton_Poison":
                                        Masterlvl1 = MoreSkills_TamingConfig.SkeletonPoisonLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.SkeletonPoisonLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.SkeletonPoisonLevelUnlock.Value;
                                        break;
                                    case "StoneGolem":
                                        Masterlvl1 = MoreSkills_TamingConfig.StoneGolemLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.StoneGolemLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.StoneGolemLevelUnlock.Value;
                                        break;
                                    case "Surtling":
                                        Masterlvl1 = MoreSkills_TamingConfig.SurtlingLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.SurtlingLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.SurtlingLevelUnlock.Value;
                                        break;
                                    case "Troll":
                                        Masterlvl1 = MoreSkills_TamingConfig.TrollLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.TrollLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.TrollLevelUnlock.Value;
                                        break;
                                    case "Wolf":
                                        Masterlvl1 = MoreSkills_TamingConfig.WolfLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.WolfLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.WolfLevelUnlock.Value;
                                        break;
                                    case "Wraith":
                                        Masterlvl1 = MoreSkills_TamingConfig.WraithLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.WraithLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.WraithLevelUnlock.Value;
                                        break;
                                    case "Eikthyr":
                                        Masterlvl1 = MoreSkills_TamingConfig.EikthyrLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.EikthyrLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.EikthyrLevelUnlock.Value;
                                        break;
                                    case "gd_king":
                                        Masterlvl1 = MoreSkills_TamingConfig.ElderLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.ElderLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.ElderLevelUnlock.Value;
                                        break;
                                    case "Bonemass":
                                        Masterlvl1 = MoreSkills_TamingConfig.BonemassLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.BonemassLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.BonemassLevelUnlock.Value;
                                        break;
                                    case "Dragon":
                                        Masterlvl1 = MoreSkills_TamingConfig.DragonLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.DragonLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.DragonLevelUnlock.Value;
                                        break;
                                    case "GoblinKing":
                                        Masterlvl1 = MoreSkills_TamingConfig.GoblinKingLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.GoblinKingLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.GoblinKingLevelUnlock.Value;
                                        break;
                                    case "RRR_GDThornweaver":
                                        Masterlvl1 = MoreSkills_TamingConfig.RRRGDThornweaverLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.RRRGDThornweaverLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.RRRGDThornweaverLevelUnlock.Value;
                                        break;
                                    case "RRR_GhostVengeful":
                                        Masterlvl1 = MoreSkills_TamingConfig.RRRGhostVengefulLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.RRRGhostVengefulLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.RRRGhostVengefulLevelUnlock.Value;
                                        break;
                                    case "RRR_TrollTosser":
                                        Masterlvl1 = MoreSkills_TamingConfig.RRRTrollTosserLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.RRRTrollTosserLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.RRRTrollTosserLevelUnlock.Value;
                                        break;
                                    case "Ghost":
                                        Masterlvl1 = MoreSkills_TamingConfig.GhostLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.GhostLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.GhostLevelUnlock.Value;
                                        break;
                                    default:
                                        Masterlvl1 = 30f;
                                        Tamerlvl1 = 60f;
                                        Unlocklvl1 = 90f;
                                        if (tLevels.Find(tLevel => tLevel.Creature == sCreature).Creature != sCreature)
                                        {
                                            Debug.LogWarning("[MoreSkills]: Creature Tame Levels Missing: " + __instance.name.Replace("(Clone)", ""));
                                            Debug.LogWarning("[MoreSkills]: Adding Creature to Temp with Default Needed Levels. Unlock 30. Tamer 60. Master 90.");
                                            Debug.LogWarning("[MoreSkills]: Report it if you want custom numbers to the creature, and the levels. Thanks!");
                                            tLevels.Add(new Helper.TamingLevels(
                                                creature: sCreature,
                                                master: Masterlvl1,
                                                tamer: Tamerlvl1,
                                                unlock: Unlocklvl1));
                                        }
                                        break;
                                }
                                if (tLevels.Find(tLevel => tLevel.Creature == sCreature).Creature != sCreature)
                                {
                                    Debug.Log("[MoreSkills]: Saved Taming Levels from : " + __instance.name.Replace("(Clone)", "") + " to the Temporal Database");
                                    tLevels.Add(new Helper.TamingLevels(
                                        creature: sCreature,
                                        master: Masterlvl1,
                                        tamer: Tamerlvl1,
                                        unlock: Unlocklvl1));
                                }
                            }
                            else
                            {
                                string sCreature = __instance.name.Replace("(Clone)", "");
                                switch (__instance.name.Replace("(Clone)", ""))
                                {
                                    case "Boar":
                                        Masterlvl1 = MoreSkills_TamingConfig.BoarLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.BoarLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.BoarLevelUnlock.Value;
                                        break;
                                    case "Wolf":
                                        Masterlvl1 = MoreSkills_TamingConfig.WolfLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.WolfLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.WolfLevelUnlock.Value;
                                        break;
                                    case "Lox":
                                        Masterlvl1 = MoreSkills_TamingConfig.LoxLevelMaster.Value;
                                        Tamerlvl1 = MoreSkills_TamingConfig.LeechLevelTamer.Value;
                                        Unlocklvl1 = MoreSkills_TamingConfig.LeechLevelUnlock.Value;
                                        break;
                                }
                                if (tLevels.Find(tLevel => tLevel.Creature == sCreature).Creature != sCreature)
                                {
                                    Debug.Log("[MoreSkills]: Saved Taming Levels from : " + __instance.name.Replace("(Clone)", "") + " to the Temporal Database");
                                    tLevels.Add(new Helper.TamingLevels(
                                        creature: sCreature,
                                        master: Masterlvl1,
                                        tamer: Tamerlvl1,
                                        unlock: Unlocklvl1));
                                }
                            }
                            //Debug.LogWarning("Nivel Master: " + Masterlvl1);
                            //Debug.LogWarning("Nivel Tamer: " + Tamerlvl1);
                            //Debug.LogWarning("Nivel Unlock: " + Unlocklvl1);
                            string CreatureZDOID = string.Concat(__instance.name + ":" + __instance.m_character.GetZDOID());
                            ZDOID TamerID = closestPlayer.GetZDOID();
                            float tameTime = __instance.m_tamingTime;
                            float eatTime = __instance.m_fedDuration;
                            float Master = Masterlvl1;
                            float Tamer = Tamerlvl1;
                            float Unlock = Unlocklvl1;
                            tSaves.Add(new Helper.TamingSaves(
                                creaturezdoid: CreatureZDOID,
                                tamerid: TamerID,
                                tametime: tameTime,
                                eattime: eatTime,
                                master: Master,
                                tamer: Tamer,
                                unlock: Unlock));
                            Debug.Log("[MoreSkills]: You are now taming a " + (__instance.name.Replace("(Clone)", "")));
                        }
                        else
                        {
                            Debug.LogWarning("You are not the tamer, or was the closest one when he first ate or close enough");
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(Tameable), "TamingUpdate")]
        public static class SetTamingTimes
        {
            public static void Postfix(ref Tameable __instance)
            {
                if (MoreSkills_Instances._player != null)
                {
                    string CreatureZDOID = string.Concat(__instance.name + ":" + __instance.m_character.GetZDOID());
                    float Distance = Vector3.Distance(__instance.transform.position, MoreSkills_Instances._player.transform.position);
                    float level = MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_TamingConfig.TamingSkill_Type);

                    if (CreatureZDOID == tSaves.Find(tsave => tsave.CreatureZDOID == CreatureZDOID).CreatureZDOID && tSaves.Find(tsave => tsave.CreatureZDOID == CreatureZDOID).TamerID == MoreSkills_Instances._player.GetZDOID())
                    {
                        var getSave = tSaves.Find(tsave => tsave.CreatureZDOID == CreatureZDOID);
                        float Master = getSave.Master;
                        float Tamer = getSave.Tamer;
                        float Unlock = getSave.Unlock;
                        float oldTime = getSave.TameTime;
                        float oldEat = getSave.EatTime;
                        var Fixed = tFixed.Find(tfixed => tfixed.CreatureZDOID == CreatureZDOID);
                        var GotFar = tGotFar.Find(tgotfar => tgotfar.CreatureZDOID == CreatureZDOID);
                        var DoubleCheck = tDoubleCheck.Find(tdoublecheck => tdoublecheck.CreatureZDOID == CreatureZDOID);
                        //Debug.LogWarning("CreatureZDOID: " + CreatureZDOID);
                        //Debug.LogWarning("Creature: " + getSave.CreatureZDOID);
                        //Debug.LogWarning("Master: " + Master);
                        //Debug.LogWarning("Tamer: " + Tamer);
                        //Debug.LogWarning("Unlock: " + Unlock);
                        //Debug.LogWarning("Oldtime: " + oldTime);
                        //Debug.LogWarning("OldEat: " + oldEat);
                        //Debug.LogWarning("Fixed: " + Fixed.Fixed);
                        //Debug.LogWarning("GotFar: " + GotFar.GotFar);
                        //Debug.LogWarning("DoubleCheck: " + DoubleCheck.DoubleCheck);
                        if (__instance.GetTameness() < 100)
                        {
                            if (MoreSkills_TamingConfig.EnableTamingUnlocks.Value)
                            {
                                if (MoreSkills_TamingConfig.EnableTamingTimeMod.Value)
                                {
                                    if (tFixed.Find(x => x.CreatureZDOID == CreatureZDOID).CreatureZDOID != CreatureZDOID)
                                    {
                                        tFixed.Add(new Helper.TamingFix(
                                            creaturezdoid: CreatureZDOID,
                                            tfixed: false));
                                        //Debug.LogWarning("Added default value of Fixed");
                                    }
                                    if (tGotFar.Find(x => x.CreatureZDOID == CreatureZDOID).CreatureZDOID != CreatureZDOID)
                                    {
                                        tGotFar.Add(new Helper.TamingGotFar(
                                            creaturezdoid: CreatureZDOID,
                                            gotfar: false));
                                        //Debug.LogWarning("Added default value of GotFar");
                                    }
                                    if (tDoubleCheck.Find(x => x.CreatureZDOID == CreatureZDOID).CreatureZDOID != CreatureZDOID)
                                    {
                                        tDoubleCheck.Add(new Helper.TamingDoubleCheck(
                                            creaturezdoid: CreatureZDOID,
                                            doublecheck: 0));
                                        //Debug.LogWarning("Added default value of Double");
                                    }

                                    if (level >= (Master / 100))
                                    {
                                        //Debug.LogWarning("You are a Master at this my level " + level + " master level " + (Master/100));
                                        float tameTimeMath = ((oldTime / 2) + 120f) - (oldTime / 2);

                                        if (Distance < 75f)
                                        {
                                            __instance.m_tamingTime = tameTimeMath;

                                            //Debug.LogWarning("Math: " + tameTimeMath);

                                            if (Fixed.Fixed == false)
                                            {
                                                //Debug.LogWarning("Fixed es false");
                                                if (__instance.GetRemainingTime() != __instance.m_tamingTime)
                                                {
                                                    __instance.m_nview.GetZDO().Set("TameTimeLeft", __instance.m_tamingTime);
                                                }
                                                //Debug.LogWarning("Fixed b: " + Fixed.Fixed);
                                                tFixed.Remove(Fixed);
                                                tFixed.Add(new Helper.TamingFix(
                                                    creaturezdoid: CreatureZDOID,
                                                    tfixed: true));
                                                //Debug.LogWarning("Fixed a: " + Fixed.Fixed);
                                                
                                            }

                                            if (GotFar.GotFar == true)
                                            {
                                                if (__instance.GetRemainingTime() > __instance.m_tamingTime)
                                                {
                                                    float reset = __instance.m_tamingTime * ((__instance.m_nview.GetZDO().GetFloat("TameTimeLeft") * 100f) / (__instance.m_tamingTime * 2) / 100);
                                                    __instance.m_nview.GetZDO().Set("TameTimeLeft", reset);
                                                }
                                                else
                                                {
                                                    //Debug.LogWarning("GotFar b: " + GotFar.GotFar);
                                                    tGotFar.Remove(GotFar);
                                                    tGotFar.Add(new Helper.TamingGotFar(
                                                        creaturezdoid: CreatureZDOID,
                                                        gotfar: false));
                                                    //Debug.LogWarning("GotFar a: " + GotFar.GotFar);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            __instance.m_tamingTime = (tameTimeMath * 2);

                                            if (GotFar.GotFar == false)
                                            {
                                                float grow = __instance.m_tamingTime * ((__instance.m_nview.GetZDO().GetFloat("TameTimeLeft") * 100) / (__instance.m_tamingTime / 2) / 100);
                                                __instance.m_nview.GetZDO().Set("TameTimeLeft", grow);
                                            }
                                            tGotFar.Remove(GotFar);
                                            tGotFar.Add(new Helper.TamingGotFar(
                                                creaturezdoid: CreatureZDOID,
                                                gotfar: true));
                                        }
                                    }
                                    else if (level >= (Tamer / 100))
                                    {
                                        //Debug.LogWarning("You are a good at this");
                                        float tameTimeMath = ((oldTime / 2) + 120f) - (((oldTime / 2) * ((level - (Tamer / 100)) * (1 / ((Master - Tamer) / 100)))));

                                        if (Distance < 75f)
                                        {
                                            __instance.m_tamingTime = tameTimeMath;

                                            while (Fixed.Fixed == false)
                                            {
                                                if (__instance.GetRemainingTime() != __instance.m_tamingTime)
                                                {
                                                    __instance.m_nview.GetZDO().Set("TameTimeLeft", __instance.m_tamingTime);
                                                }
                                                //Debug.LogWarning("Fixed b: " + Fixed.Fixed);
                                                tFixed.Remove(Fixed);
                                                tFixed.Add(new Helper.TamingFix(
                                                    creaturezdoid: CreatureZDOID,
                                                    tfixed: true));
                                                //Debug.LogWarning("Fixed a: " + Fixed.Fixed);
                                            }

                                            if (GotFar.GotFar == true)
                                            {
                                                if (__instance.GetRemainingTime() > __instance.m_tamingTime)
                                                {
                                                    float reset = __instance.m_tamingTime * ((__instance.m_nview.GetZDO().GetFloat("TameTimeLeft") * 100f) / (__instance.m_tamingTime * 2) / 100);
                                                    __instance.m_nview.GetZDO().Set("TameTimeLeft", reset);
                                                }
                                                else
                                                {
                                                    //Debug.LogWarning("GotFar b: " + GotFar.GotFar);
                                                    tGotFar.Remove(GotFar);
                                                    tGotFar.Add(new Helper.TamingGotFar(
                                                        creaturezdoid: CreatureZDOID,
                                                        gotfar: false));
                                                    //Debug.LogWarning("GotFar a: " + GotFar.GotFar);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            __instance.m_tamingTime = (tameTimeMath * 2);

                                            if (GotFar.GotFar == false)
                                            {
                                                float grow = __instance.m_tamingTime * ((__instance.m_nview.GetZDO().GetFloat("TameTimeLeft") * 100) / (__instance.m_tamingTime / 2) / 100);
                                                __instance.m_nview.GetZDO().Set("TameTimeLeft", grow);
                                            }
                                            tGotFar.Remove(GotFar);
                                            tGotFar.Add(new Helper.TamingGotFar(
                                                creaturezdoid: CreatureZDOID,
                                                gotfar: true));
                                        }
                                    }
                                    else if (level >= (Unlock / 100))
                                    {
                                        //Debug.LogWarning("You are a ok at this");
                                        float tameTimeMath = oldTime - ((oldTime / 2) * ((level - (Unlock / 100)) * (1 / ((Tamer - Unlock) / 100))));

                                        if (Distance < 75f)
                                        {
                                            __instance.m_tamingTime = tameTimeMath;

                                            while (Fixed.Fixed == false)
                                            {
                                                if (__instance.GetRemainingTime() != __instance.m_tamingTime)
                                                {
                                                    __instance.m_nview.GetZDO().Set("TameTimeLeft", __instance.m_tamingTime);
                                                }
                                                else
                                                {
                                                    Debug.LogWarning("Fixed b: " + Fixed.Fixed);
                                                    tFixed.Remove(Fixed);
                                                    tFixed.Add(new Helper.TamingFix(
                                                        creaturezdoid: CreatureZDOID,
                                                        tfixed: true));
                                                    Debug.LogWarning("Fixed a: " + Fixed.Fixed);
                                                }
                                            }

                                            if (GotFar.GotFar == true)
                                            {
                                                if (__instance.GetRemainingTime() > __instance.m_tamingTime)
                                                {
                                                    float reset = __instance.m_tamingTime * ((__instance.m_nview.GetZDO().GetFloat("TameTimeLeft") * 100f) / (__instance.m_tamingTime * 2) / 100);
                                                    __instance.m_nview.GetZDO().Set("TameTimeLeft", reset);
                                                }
                                                else
                                                {
                                                    Debug.LogWarning("GotFar b: " + GotFar.GotFar);
                                                    tGotFar.Remove(GotFar);
                                                    tGotFar.Add(new Helper.TamingGotFar(
                                                        creaturezdoid: CreatureZDOID,
                                                        gotfar: false));
                                                    Debug.LogWarning("GotFar a: " + GotFar.GotFar);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            __instance.m_tamingTime = (tameTimeMath * 2);

                                            if (GotFar.GotFar == false)
                                            {
                                                float grow = __instance.m_tamingTime * ((__instance.m_nview.GetZDO().GetFloat("TameTimeLeft") * 100) / (__instance.m_tamingTime / 2) / 100);
                                                __instance.m_nview.GetZDO().Set("TameTimeLeft", grow);
                                            }
                                            tGotFar.Remove(GotFar);
                                            tGotFar.Add(new Helper.TamingGotFar(
                                                creaturezdoid: CreatureZDOID,
                                                gotfar: true));
                                        }
                                    }
                                    else
                                    {
                                        //Debug.LogWarning("You Dont know how to tame this");
                                        float tameTimeMath = oldTime * (Unlock - (level * 100));

                                        if (Distance < 75f)
                                        {
                                            __instance.m_tamingTime = tameTimeMath;

                                            while (Fixed.Fixed == false)
                                            {
                                                if (__instance.GetRemainingTime() != __instance.m_tamingTime)
                                                {
                                                    __instance.m_nview.GetZDO().Set("TameTimeLeft", __instance.m_tamingTime);
                                                }
                                                //Debug.LogWarning("Fixed b: " + Fixed.Fixed);
                                                tFixed.Remove(Fixed);
                                                tFixed.Add(new Helper.TamingFix(
                                                    creaturezdoid: CreatureZDOID,
                                                    tfixed: true));
                                                //Debug.LogWarning("Fixed a: " + Fixed.Fixed);
                                            }

                                            if (GotFar.GotFar == true)
                                            {
                                                if (__instance.GetRemainingTime() > __instance.m_tamingTime)
                                                {
                                                    float reset = __instance.m_tamingTime * ((__instance.m_nview.GetZDO().GetFloat("TameTimeLeft") * 100f) / (__instance.m_tamingTime * 2) / 100);
                                                    __instance.m_nview.GetZDO().Set("TameTimeLeft", reset);
                                                }
                                                else
                                                {
                                                    //Debug.LogWarning("GotFar b: " + GotFar.GotFar);
                                                    tGotFar.Remove(GotFar);
                                                    tGotFar.Add(new Helper.TamingGotFar(
                                                        creaturezdoid: CreatureZDOID,
                                                        gotfar: false));
                                                    //Debug.LogWarning("GotFar a: " + GotFar.GotFar);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            __instance.m_tamingTime = (tameTimeMath * 2);

                                            if (GotFar.GotFar == false)
                                            {
                                                float grow = __instance.m_tamingTime * ((__instance.m_nview.GetZDO().GetFloat("TameTimeLeft") * 100) / (__instance.m_tamingTime / 2) / 100);
                                                __instance.m_nview.GetZDO().Set("TameTimeLeft", grow);
                                            }
                                            tGotFar.Remove(GotFar);
                                            tGotFar.Add(new Helper.TamingGotFar(
                                                creaturezdoid: CreatureZDOID,
                                                gotfar: true));
                                        }
                                    }
                                }
                                if (MoreSkills_TamingConfig.EnableTamingEatMod.Value)
                                {
                                    if (level >= (Master / 100))
                                    {
                                        float tameEatMath = oldEat * 2;
                                        __instance.m_fedDuration = tameEatMath;
                                    }
                                    else if (level >= (Tamer / 100))
                                    {
                                        float tameEatMath = oldEat + (oldEat * ((level - (Tamer / 100)) * (1 / ((Master - Tamer) / 100))));
                                        __instance.m_fedDuration = tameEatMath;
                                    }
                                    else if (level >= (Unlock / 100))
                                    {
                                        float tameEatMath = (oldEat / 2) + ((oldEat / 2) * ((level - (Unlock / 100)) * (1 / ((Tamer - Unlock) / 100))));
                                        __instance.m_fedDuration = tameEatMath;
                                    }
                                    else
                                    {
                                        float tameEatMath = (oldEat / 2) / (Unlock - (level * 100));
                                        __instance.m_fedDuration = tameEatMath;
                                    }
                                }
                            }
                            else
                            {

                                if (MoreSkills_TamingConfig.EnableTamingTimeMod.Value)
                                {
                                    float tameTimeMath = (oldTime + 120f) - (oldTime * level);

                                    if (Distance < 75f)
                                    {
                                        __instance.m_tamingTime = tameTimeMath;

                                        while (Fixed.Fixed == false)
                                        {
                                            if (__instance.GetRemainingTime() != __instance.m_tamingTime)
                                            {
                                                __instance.m_nview.GetZDO().Set("TameTimeLeft", __instance.m_tamingTime);
                                            }
                                            Debug.LogWarning("Fixed b: " + Fixed.Fixed);
                                            tFixed.Remove(Fixed);
                                            tFixed.Add(new Helper.TamingFix(
                                                creaturezdoid: CreatureZDOID,
                                                tfixed: true));
                                            Debug.LogWarning("Fixed a: " + Fixed.Fixed);
                                        }

                                        if (GotFar.GotFar == true)
                                        {
                                            if (__instance.GetRemainingTime() != __instance.m_tamingTime)
                                            {
                                                float reset = __instance.m_tamingTime * ((__instance.m_nview.GetZDO().GetFloat("TameTimeLeft") * 100f) / (__instance.m_tamingTime * 2) / 100);
                                                __instance.m_nview.GetZDO().Set("TameTimeLeft", reset);
                                            }
                                            else
                                            {
                                                Debug.LogWarning("GotFar b: " + GotFar.GotFar);
                                                tGotFar.Remove(GotFar);
                                                tGotFar.Add(new Helper.TamingGotFar(
                                                    creaturezdoid: CreatureZDOID,
                                                    gotfar: false));
                                                Debug.LogWarning("GotFar a: " + GotFar.GotFar);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        __instance.m_tamingTime = (tameTimeMath * 2);

                                        if (GotFar.GotFar == false)
                                        {
                                            float grow = __instance.m_tamingTime * ((__instance.m_nview.GetZDO().GetFloat("TameTimeLeft") * 100) / (__instance.m_tamingTime / 2) / 100);
                                            __instance.m_nview.GetZDO().Set("TameTimeLeft", grow);
                                        }
                                        tGotFar.Remove(GotFar);
                                        tGotFar.Add(new Helper.TamingGotFar(
                                            creaturezdoid: CreatureZDOID,
                                            gotfar: true));
                                    }

                                }
                                if (MoreSkills_TamingConfig.EnableTamingEatMod.Value)
                                {
                                    float tameEatMath = (oldEat / 5) + (oldEat * level);
                                    __instance.m_fedDuration = tameEatMath;

                                }
                            }

                            //Debug.LogWarning("TameTime: " + __instance.m_nview.GetZDO().GetFloat("TameTimeLeft"));
                        }
                        else if (__instance.m_character.GetHealth() <= 0)
                        {
                            var tsave = tSaves.Find(x => x.CreatureZDOID == CreatureZDOID);
                            tSaves.Remove(tsave);
                            var tfix = tFixed.Find(x => x.CreatureZDOID == CreatureZDOID);
                            tFixed.Remove(tfix);
                            var tgotfar = tGotFar.Find(x => x.CreatureZDOID == CreatureZDOID);
                            tGotFar.Remove(tgotfar);
                            var tdoublecheck = tDoubleCheck.Find(x => x.CreatureZDOID == CreatureZDOID);
                            tDoubleCheck.Remove(tdoublecheck);
                        }
                        else if (__instance.m_character.IsTamed())
                        {
                            TamingSkillIncrease += ((__instance.m_tamingTime / 200) * __instance.m_character.GetLevel()) * MoreSkills_TamingConfig.TamingSkillIncreaseMultiplier.Value;
                            Debug.Log("[MoreSkills]: Gained " + TamingSkillIncrease + " EXP at Taming");
                            var tsave = tSaves.Find(x => x.CreatureZDOID == CreatureZDOID);
                            tSaves.Remove(tsave);
                            var tfix = tFixed.Find(x => x.CreatureZDOID == CreatureZDOID);
                            tFixed.Remove(tfix);
                            var tgotfar = tGotFar.Find(x => x.CreatureZDOID == CreatureZDOID);
                            tGotFar.Remove(tgotfar);
                            var tdoublecheck = tDoubleCheck.Find(x => x.CreatureZDOID == CreatureZDOID);
                            tDoubleCheck.Remove(tdoublecheck);
                        }
                    }

                    if (tDoubleCheck.Find(tdoublecheck => tdoublecheck.CreatureZDOID == CreatureZDOID).DoubleCheck < 5 && CreatureZDOID == tSaves.Find(tsave => tsave.CreatureZDOID == CreatureZDOID).CreatureZDOID)
                    {
                        int doublecheck = tDoubleCheck.Find(x => x.CreatureZDOID == CreatureZDOID).DoubleCheck + 1;
                        var tdoublecheck = tDoubleCheck.Find(x => x.CreatureZDOID == CreatureZDOID);
                        tDoubleCheck.Remove(tdoublecheck);
                        tDoubleCheck.Add(new Helper.TamingDoubleCheck(
                            creaturezdoid: CreatureZDOID,
                            doublecheck: doublecheck));
                        var tfix = tFixed.Find(x => x.CreatureZDOID == CreatureZDOID);
                        tFixed.Remove(tfix);
                        tFixed.Add(new Helper.TamingFix(
                            creaturezdoid: CreatureZDOID,
                            tfixed: false));
                    }

                    if (TamingSkillIncrease > 0.5f)
                    {
                        MoreSkills_Instances._player.RaiseSkill((Skills.SkillType)MoreSkills_TamingConfig.TamingSkill_Type, TamingSkillIncrease);
                        TamingSkillIncrease = 0f;
                    }

                    /*if (__instance.GetTameness() < 100
                        && __instance.m_character.GetZDOID() == Creature1
                        || __instance.m_character.GetZDOID() == Creature2
                        || __instance.m_character.GetZDOID() == Creature3
                        || __instance.m_character.GetZDOID() == Creature4
                        || __instance.m_character.GetZDOID() == Creature5)
                    {
                        Debug.LogWarning("TiempoZDO: " + __instance.m_nview.GetZDO().GetFloat("TameTimeLeft"));
                        Debug.LogWarning("ID: " + __instance.m_character.GetZDOID());


                        Debug.LogWarning("Animal: " + __instance.m_character.m_name);
                        Debug.LogWarning("TA: " + __instance.m_tamingTime);
                        Debug.LogWarning("Test2: " + __instance.m_fedDuration);

                        Debug.LogWarning("Tameness: " + __instance.GetTameness());
                        Debug.LogWarning("Distance from Creature: " + Distance);
                        Debug.LogWarning("Tiempo Funciton: " + __instance.GetRemainingTime());
                    }*/
                }

            }
        }

        [HarmonyPatch(typeof(Tameable), "GetHoverText")]
        public static class ShowTamingHoverText
        {
            public static void Postfix(ref string __result, ref Tameable __instance)
            {
                if (MoreSkills_Instances._player != null)
                {
                    if (MoreSkills_TamingConfig.EnableTamingUnlocks.Value)
                    {
                        string sCreature = __instance.name.Replace("(Clone)", "");
                        float Master = tLevels.Find(tlevel => tlevel.Creature == sCreature).Master;
                        float Tamer = tLevels.Find(tlevel => tlevel.Creature == sCreature).Tamer;
                        float Unlock = tLevels.Find(tlevel => tlevel.Creature == sCreature).Unlock;
                        float level = MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_TamingConfig.TamingSkill_Type);
                        float Dif = Unlock - (level * 100);

                        if (__instance.GetTameness() <= 0 && !__instance.m_character.IsTamed() && !__instance.m_character.IsPlayer())
                        {
                            if (level < (Unlock / 100))
                            {
                                __result += Localization.instance.Localize(string.Concat(new string[]
                                    {
                                "\n(<color=red><b>Requires ",
                                Dif.ToString("F0"),
                                " </b> more Levels to be tamed efficiently</color>"
                                    }));

                            }
                            else if (level < (Tamer / 100))
                            {
                                __result += Localization.instance.Localize("\n(<color=orange>You're <b>Starting</b> to tame efficiently</b></color>)");
                            }
                            else if (level < (Master / 100))
                            {
                                __result += Localization.instance.Localize("\n(<color=yellow>You're <b>Good</b> at Taming efficiently</color>)");
                            }
                            else
                            {
                                __result += Localization.instance.Localize("\n(<color=green>You're an efficient <b>Master Tamer</b></color>)");
                            }
                        }
                    }
                }
            }
        }

        public static float Masterlvl1;
        public static float Tamerlvl1;
        public static float Unlocklvl1;

        public static float TamingSkillIncrease;

        public static List<Helper.TamingSaves> tSaves = new List<Helper.TamingSaves>();
        public static List<Helper.TamingLevels> tLevels = new List<Helper.TamingLevels>();
        public static List<Helper.TamingFix> tFixed = new List<Helper.TamingFix>();
        public static List<Helper.TamingGotFar> tGotFar = new List<Helper.TamingGotFar>();
        public static List<Helper.TamingDoubleCheck> tDoubleCheck = new List<Helper.TamingDoubleCheck>();
    }
}
