using UnityEngine;
using HarmonyLib;
using MoreSkills.Utility;
using MoreSkills.Config;

namespace MoreSkills.ModSkills.NewSkills
{
    class MoreSkills_Hunting
    {
        [HarmonyPatch(typeof(CharacterDrop), "Start")]
        public static class Hunting_UpdateDrops
        {
            public static void Postfix(ref CharacterDrop __instance)
            {
                if (MoreSkills_Instances._player != null)
                    if (MoreSkills_Config.EnableHuntingSkill.Value)
                    {
                        bool MinMax = MoreSkills_Config.EnableHuntingMinMaxMod.Value;
                        bool Chance = MoreSkills_Config.EnableHuntingChanceMod.Value;
                        bool Trophy = MoreSkills_Config.EnableHuntingTrophyMod.Value;
                        float level = MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.HuntingSkill_Type);

                        foreach (CharacterDrop.Drop drop in __instance.m_drops)
                        {

                            if (MoreSkills_Config.EnableHuntingNormalMobsMod.Value)
                            {
                                if (__instance.m_character.m_name == "$enemy_blob")
                                {
                                    name = "Blob";
                                    if (drop.m_prefab.name == "Ooze")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBlobOoze.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBlobOoze.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinBlobOoze.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinBlobOoze.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBlobOoze.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBlobOoze.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceBlobOoze.Value + ((1 - MoreSkills_Config.BaseChanceBlobOoze.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyBlob")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBlobTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBlobTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinBlobTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinBlobTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBlobTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBlobTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceBlobTrophy.Value + ((1 - MoreSkills_Config.BaseChanceBlobTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_blobelite")
                                {
                                    name = "Blob Elite";
                                    if (drop.m_prefab.name == "Ooze")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreylingResin.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBlobEliteOoze.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.BaseMaxBlobEliteOoze.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinBlobEliteOoze.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinBlobEliteOoze.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBlobEliteOoze.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBlobEliteOoze.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceBlobEliteOoze.Value + ((1 - MoreSkills_Config.BaseChanceBlobEliteOoze.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "IronScrap")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBlobEliteIronScrap.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBlobEliteIronScrap.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinBlobEliteIronScrap.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinBlobEliteIronScrap.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBlobEliteIronScrap.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBlobEliteIronScrap.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceBlobEliteIronScrap.Value + ((1 - MoreSkills_Config.BaseChanceBlobEliteIronScrap.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "Blob")
                                    {
                                        if (MoreSkills_Config.EnableHuntingBlobSpawn.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBlobEliteBlob.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBlobEliteBlob.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinBlobEliteBlob.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinBlobEliteBlob.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBlobEliteBlob.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBlobEliteBlob.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceBlobEliteBlob.Value + ((1 - MoreSkills_Config.BaseChanceBlobEliteBlob.Value) * level);
                                        }
                                    }
                                    else if (drop.m_prefab.name == "TrophyBlob")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBlobTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBlobTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinBlobTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinBlobTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBlobTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBlobTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseMaxBlobTrophy.Value + ((1 - MoreSkills_Config.BaseMaxBlobTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_boar")
                                {
                                    name = "Boar";
                                    if (drop.m_prefab.name == "RawMeat")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBoarRawMeat.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBoarRawMeat.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinBoarRawMeat.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinBoarRawMeat.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBoarRawMeat.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBoarRawMeat.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceBoarRawMeat.Value + ((1 - MoreSkills_Config.BaseChanceBoarRawMeat.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "LeatherScraps")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBoarLeatherScraps.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBoarLeatherScraps.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinBoarLeatherScraps.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinBoarLeatherScraps.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBoarLeatherScraps.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBoarLeatherScraps.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceBoarLeatherScraps.Value + ((1 - MoreSkills_Config.BaseChanceBoarLeatherScraps.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyBoar")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBoarTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBoarTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinBoarTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinBoarTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBoarTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBoarTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceBoarTrophy.Value + ((1 - MoreSkills_Config.BaseChanceBoarTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_deathsquito")
                                {
                                    name = "Deathsquito";
                                    if (drop.m_prefab.name == "Needle")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDeathsquitoNeedle.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDeathsquitoNeedle.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinDeathsquitoNeedle.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinDeathsquitoNeedle.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDeathsquitoNeedle.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDeathsquitoNeedle.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceDeathsquitoNeedle.Value + ((1 - MoreSkills_Config.BaseChanceDeathsquitoNeedle.Value) * level);
                                    }

                                    if (drop.m_prefab.name == "TrophyDeathsquito")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDeathsquitoTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDeathsquitoTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinDeathsquitoTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinDeathsquitoTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDeathsquitoTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDeathsquitoTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceDeathsquitoTrophy.Value + ((1 - MoreSkills_Config.BaseChanceDeathsquitoTrophy.Value) * level);
                                        }
                                    }

                                }
                                else if (__instance.m_character.m_name == "$enemy_deer")
                                {
                                    name = "Deer";
                                    if (drop.m_prefab.name == "RawMeat")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDeerRawMeat.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDeerRawMeat.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinDeerRawMeat.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinDeerRawMeat.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDeerRawMeat.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDeerRawMeat.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceDeerRawMeat.Value + ((1 - MoreSkills_Config.BaseChanceDeerRawMeat.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "DeerHide")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDeerHide.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDeerHide.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinDeerHide.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinDeerHide.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDeerHide.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDeerHide.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceDeerHide.Value + ((1 - MoreSkills_Config.BaseChanceDeerHide.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyDeer")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDeerTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDeerTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinDeerTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinDeerTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDeerTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDeerTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceDeerTrophy.Value + ((1 - MoreSkills_Config.BaseChanceDeerTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_drake")
                                {
                                    name = "Drake";
                                    if (drop.m_prefab.name == "FreezeGland")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDrakeFreezeGland.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDrakeFreezeGland.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinDrakeFreezeGland.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinDrakeFreezeGland.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDrakeFreezeGland.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDrakeFreezeGland.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceDrakeFreezeGland.Value + ((1 - MoreSkills_Config.BaseChanceDrakeFreezeGland.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyDrake")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDrakeTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDrakeTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinDrakeTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinDrakeTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDrakeTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDrakeTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceDrakeTrophy.Value + ((1 - MoreSkills_Config.BaseChanceDrakeTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_draugr")
                                {
                                    name = "Draugr";
                                    if (drop.m_prefab.name == "Entrails")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDraugrEntrails.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDraugrEntrails.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinDraugrEntrails.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinDraugrEntrails.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDraugrEntrails.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDraugrEntrails.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceDraugrEntrails.Value + ((1 - MoreSkills_Config.BaseChanceDraugrEntrails.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyDraugr")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDraugrTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDraugrTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinDraugrTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinDraugrTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDraugrTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDraugrTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceDraugrTrophy.Value + ((1 - MoreSkills_Config.BaseChanceDraugrTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_draugrelite")
                                {
                                    name = "Draugr Elite";
                                    if (drop.m_prefab.name == "Entrails")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDraugrEliteEntrails.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDraugrEliteEntrails.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinDraugrEliteEntrails.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinDraugrEliteEntrails.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDraugrEliteEntrails.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDraugrEliteEntrails.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceDraugrEliteEntrails.Value + ((1 - MoreSkills_Config.BaseChanceDraugrEliteEntrails.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyDraugrElite")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDraugrEliteTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDraugrEliteTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinDraugrEliteTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinDraugrEliteTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDraugrEliteTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDraugrEliteTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceDraugrEliteTrophy.Value + ((1 - MoreSkills_Config.BaseChanceDraugrEliteTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_fenring")
                                {
                                    name = "Fenring";
                                    if (drop.m_prefab.name == "WolfFang")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxFenringWolfFang.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxFenringWolfFang.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinFenringWolfFang.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinFenringWolfFang.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxFenringWolfFang.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxFenringWolfFang.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceFenringWolfFang.Value + ((1 - MoreSkills_Config.BaseChanceFenringWolfFang.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyFenring")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxFenringEliteTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxFenringEliteTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinFenringEliteTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinFenringEliteTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxFenringEliteTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxFenringEliteTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceFenringEliteTrophy.Value + ((1 - MoreSkills_Config.BaseChanceFenringEliteTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_goblin")
                                {
                                    name = "Goblin";
                                    if (drop.m_prefab.name == "Coins")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinCoins.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinCoins.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGoblinCoins.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGoblinCoins.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinCoins.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinCoins.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGoblinCoins.Value + ((1 - MoreSkills_Config.BaseChanceGoblinCoins.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "BlackMetalScrap")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinBMS.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinBMS.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGoblinBMS.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGoblinBMS.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinBMS.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinBMS.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGoblinBMS.Value + ((1 - MoreSkills_Config.BaseChanceGoblinBMS.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyGoblin")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGoblinTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGoblinTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceGoblinTrophy.Value + ((1 - MoreSkills_Config.BaseChanceGoblinTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_goblinbrute")
                                {
                                    name = "Goblin Brute";
                                    if (drop.m_prefab.name == "Coins")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinBruteCoins.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinBruteCoins.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGoblinBruteCoins.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGoblinBruteCoins.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinBruteCoins.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinBruteCoins.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGoblinBruteCoins.Value + ((1 - MoreSkills_Config.BaseChanceGoblinBruteCoins.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "BlackMetalScrap")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinBruteBMS.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinBruteBMS.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGoblinBruteBMS.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGoblinBruteBMS.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinBruteBMS.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinBruteBMS.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGoblinBruteBMS.Value + ((1 - MoreSkills_Config.BaseChanceGoblinBruteBMS.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "GoblinTotem")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinBruteTotem.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinBruteTotem.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGoblinBruteTotem.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGoblinBruteTotem.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinBruteTotem.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinBruteTotem.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceGoblinBruteTotem.Value + ((1 - MoreSkills_Config.BaseChanceGoblinBruteTotem.Value) * level);
                                        }
                                    }
                                    else if (drop.m_prefab.name == "TrophyGoblinBrute")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinBruteTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinBruteTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGoblinBruteTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGoblinBruteTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinBruteTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinBruteTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceGoblinBruteTrophy.Value + ((1 - MoreSkills_Config.BaseChanceGoblinBruteTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_goblinshaman")
                                {
                                    name = "Goblin Shaman";
                                    if (drop.m_prefab.name == "Coins")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinShamanCoins.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinShamanCoins.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGoblinShamanCoins.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGoblinShamanCoins.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinShamanCoins.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinShamanCoins.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGoblinShamanCoins.Value + ((1 - MoreSkills_Config.BaseChanceGoblinShamanCoins.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "BlackMetalScrap")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinShamanBMS.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinShamanBMS.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGoblinShamanBMS.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGoblinShamanBMS.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinShamanBMS.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinShamanBMS.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGoblinShamanBMS.Value + ((1 - MoreSkills_Config.BaseChanceGoblinShamanBMS.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyGoblinShaman")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinShamanTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinShamanTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGoblinShamanTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGoblinShamanTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinShamanTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinShamanTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceGoblinShamanTrophy.Value + ((1 - MoreSkills_Config.BaseChanceGoblinShamanTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_greydwarf")
                                {
                                    name = "Greydwarf";
                                    if (drop.m_prefab.name == "GreydwarfEye")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfEyes.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfEyes.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfEyes.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfEyes.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfEyes.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfEyes.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfEyes.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfEyes.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "Resin")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfResin.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfResin.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfResin.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfResin.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfResin.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfResin.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfResin.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfResin.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "Stone")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfStone.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfStone.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfStone.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfStone.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfStone.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfStone.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseMinGreydwarfStone.Value + ((1 - MoreSkills_Config.BaseMinGreydwarfStone.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "Wood")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfWood.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfWood.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfWood.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfWood.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfWood.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfWood.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfWood.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfWood.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyGreydwarf")
                                    {

                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfTrophy.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_greydwarfbrute")
                                {
                                    name = "Greydwarf Brute";
                                    if (drop.m_prefab.name == "GreydwarfEye")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfBruteEyes.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfBruteEyes.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfBruteEyes.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfBruteEyes.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfBruteEyes.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfBruteEyes.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfBruteEyes.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfBruteEyes.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "Dandelion")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfBruteDandelion.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfBruteDandelion.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfBruteDandelion.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfBruteDandelion.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfBruteDandelion.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfBruteDandelion.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfBruteDandelion.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfBruteDandelion.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "Stone")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfBruteStone.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfBruteStone.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfBruteStone.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfBruteStone.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfBruteStone.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfBruteStone.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfBruteStone.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfBruteStone.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "Wood")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfBruteWood.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfBruteWood.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfBruteWood.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfBruteWood.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfBruteWood.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfBruteWood.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfBruteWood.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfBruteWood.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "AncientSeed")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfBruteAncientSeed.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfBruteAncientSeed.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfBruteAncientSeed.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfBruteAncientSeed.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfBruteAncientSeed.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfBruteAncientSeed.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfBruteAncientSeed.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfBruteAncientSeed.Value) * level);
                                        }
                                    }
                                    else if (drop.m_prefab.name == "TrophyGreydwarfBrute")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfBruteTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfBruteTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfBruteTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfBruteTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfBruteTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfBruteTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfBruteTrophy.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfBruteTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_greydwarfshaman")
                                {
                                    name = "Greydwarf Shaman";
                                    if (drop.m_prefab.name == "GreydwarfEye")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfShamanEyes.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfShamanEyes.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfShamanEyes.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfShamanEyes.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfShamanEyes.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfShamanEyes.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfShamanEyes.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfShamanEyes.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "Resin")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfShamanResin.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfShamanResin.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfShamanResin.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfShamanResin.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfShamanResin.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfShamanResin.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfShamanResin.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfShamanResin.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "Wood")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfShamanWood.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfShamanWood.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfShamanWood.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfShamanWood.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfShamanWood.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfShamanWood.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfShamanWood.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfShamanWood.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyGreydwarfShaman")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfShamanTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfShamanTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreydwarfShamanTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreydwarfShamanTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreydwarfShamanTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreydwarfShamanTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceGreydwarfShamanTrophy.Value + ((1 - MoreSkills_Config.BaseChanceGreydwarfShamanTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_greyling")
                                {
                                    name = "Greyling";
                                    if (drop.m_prefab.name == "Resin")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreylingResin.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreylingResin.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGreylingResin.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGreylingResin.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGreylingResin.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGreylingResin.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGreylingResin.Value + ((1 - MoreSkills_Config.BaseChanceGreylingResin.Value) * level);
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);
                                }
                                else if (__instance.m_character.m_name == "$enemy_leech")
                                {
                                    name = "Leech";
                                    if (drop.m_prefab.name == "Bloodbag")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxLeechBloodBag.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxLeechBloodBag.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinLeechBloodBag.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinLeechBloodBag.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxLeechBloodBag.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxLeechBloodBag.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceLeechBloodBag.Value + ((1 - MoreSkills_Config.BaseChanceLeechBloodBag.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyLeech")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxLeechTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxLeechTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinLeechTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinLeechTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxLeechTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxLeechTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceLeechTrophy.Value + ((1 - MoreSkills_Config.BaseChanceLeechTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_lox")
                                {
                                    name = "Lox";
                                    if (drop.m_prefab.name == "LoxMeat")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxLoxMeat.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxLoxMeat.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinLoxMeat.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinLoxMeat.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxLoxMeat.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxLoxMeat.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceLoxMeat.Value + ((1 - MoreSkills_Config.BaseChanceLoxMeat.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "LoxPelt")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxLoxPelt.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxLoxPelt.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinLoxPelt.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinLoxPelt.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxLoxPelt.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxLoxPelt.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceLoxPelt.Value + ((1 - MoreSkills_Config.BaseChanceLoxPelt.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyLox")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxLoxTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxLoxTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinLoxTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinLoxTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxLoxTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxLoxTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceLoxTrophy.Value + ((1 - MoreSkills_Config.BaseChanceLoxTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_neck")
                                {
                                    name = "Neck";
                                    if (drop.m_prefab.name == "NeckTail")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxNeckTail.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxNeckTail.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinNeckTail.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinNeckTail.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxNeckTail.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxNeckTail.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceNeckTail.Value + ((1 - MoreSkills_Config.BaseChanceNeckTail.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyNeck")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxNeckTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxNeckTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinNeckTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinNeckTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxNeckTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxNeckTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceNeckTrophy.Value + ((1 - MoreSkills_Config.BaseChanceNeckTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_serpent")
                                {
                                    name = "Serpent";
                                    if (drop.m_prefab.name == "SerpentMeat")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSerpentMeat.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSerpentMeat.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinSerpentMeat.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinSerpentMeat.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSerpentMeat.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSerpentMeat.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceSerpentMeat.Value + ((1 - MoreSkills_Config.BaseChanceSerpentMeat.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "SerpentScale")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSerpentScale.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSerpentScale.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinSerpentScale.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinSerpentScale.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSerpentScale.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSerpentScale.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceSerpentScale.Value + ((1 - MoreSkills_Config.BaseChanceSerpentScale.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophySerpent")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSerpentTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSerpentTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinSerpentTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinSerpentTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSerpentTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSerpentTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceSerpentTrophy.Value + ((1 - MoreSkills_Config.BaseChanceSerpentTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_skeleton")
                                {
                                    name = "Skeleton";
                                    if (drop.m_prefab.name == "BoneFragments")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSkeletonBones.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSkeletonBones.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinSkeletonBones.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinSkeletonBones.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSkeletonBones.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSkeletonBones.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceSkeletonBones.Value + ((1 - MoreSkills_Config.BaseChanceSkeletonBones.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophySkeleton")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSkeletonTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSkeletonTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinSkeletonTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinSkeletonTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSkeletonTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSkeletonTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseMinSkeletonTrophy.Value + ((1 - MoreSkills_Config.BaseMinSkeletonTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_skeletonpoison")
                                {
                                    name = "SkeletonPoison";
                                    if (drop.m_prefab.name == "BoneFragments")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSkeletonPoisonBones.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSkeletonPoisonBones.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinSkeletonPoisonBones.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinSkeletonPoisonBones.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSkeletonPoisonBones.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSkeletonPoisonBones.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceSkeletonPoisonBones.Value + ((1 - MoreSkills_Config.BaseChanceSkeletonPoisonBones.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophySkeletonPoison")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSkeletonPoisonTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSkeletonPoisonTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinSkeletonPoisonTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinSkeletonPoisonTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSkeletonPoisonTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSkeletonPoisonTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceSkeletonPoisonTrophy.Value + ((1 - MoreSkills_Config.BaseChanceSkeletonPoisonTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_stonegolem")
                                {
                                    name = "StoneGolem";
                                    if (drop.m_prefab.name == "Stone")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxStoneGolemStone.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxStoneGolemStone.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinStoneGolemStone.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinStoneGolemStone.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxStoneGolemStone.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxStoneGolemStone.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceStoneGolemStone.Value + ((1 - MoreSkills_Config.BaseChanceStoneGolemStone.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "Crystal")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxStoneGolemCrystal.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxStoneGolemCrystal.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinStoneGolemCrystal.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinStoneGolemCrystal.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxStoneGolemCrystal.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxStoneGolemCrystal.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceStoneGolemCrystal.Value + ((1 - MoreSkills_Config.BaseChanceStoneGolemCrystal.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophySGolem")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxStoneGolemTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxStoneGolemTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinStoneGolemTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinStoneGolemTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxStoneGolemTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxStoneGolemTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceStoneGolemTrophy.Value + ((1 - MoreSkills_Config.BaseChanceStoneGolemTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_surtling")
                                {
                                    name = "Surtling";
                                    if (drop.m_prefab.name == "Coal")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSurtlingCoal.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSurtlingCoal.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinSurtlingCoal.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinSurtlingCoal.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSurtlingCoal.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSurtlingCoal.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceSurtlingCoal.Value + ((1 - MoreSkills_Config.BaseChanceSurtlingCoal.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "SurtlingCore")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSurtlingCore.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSurtlingCore.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinSurtlingCore.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinSurtlingCore.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSurtlingCore.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSurtlingCore.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceSurtlingCore.Value + ((1 - MoreSkills_Config.BaseChanceSurtlingCore.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophySurtling")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSurtlingTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSurtlingTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinSurtlingTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinSurtlingTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSurtlingTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxSurtlingTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceSurtlingTrophy.Value + ((1 - MoreSkills_Config.BaseChanceSurtlingTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_troll")
                                {
                                    name = "Troll";
                                    if (drop.m_prefab.name == "Coins")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxTrollCoins.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxTrollCoins.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinTrollCoins.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinTrollCoins.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxTrollCoins.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxTrollCoins.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceTrollCoins.Value + ((1 - MoreSkills_Config.BaseChanceTrollCoins.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrollHide")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxTrollHide.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxTrollHide.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinTrollHide.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinTrollHide.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxTrollHide.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxTrollHide.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceTrollHide.Value + ((1 - MoreSkills_Config.BaseChanceTrollHide.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyFrostTroll")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxTrollTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxTrollTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinTrollTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinTrollTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxTrollTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxTrollTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceTrollTrophy.Value + ((1 - MoreSkills_Config.BaseChanceTrollTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_wolf")
                                {
                                    name = "Wolf";
                                    if (drop.m_prefab.name == "RawMeat")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxWolfRawMeat.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxWolfRawMeat.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinWolfRawMeat.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinWolfRawMeat.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxWolfRawMeat.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxWolfRawMeat.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceWolfRawMeat.Value + ((1 - MoreSkills_Config.BaseChanceWolfRawMeat.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "WolfFang")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxWolfFang.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxWolfFang.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinWolfFang.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinWolfFang.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxWolfFang.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxWolfFang.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceWolfFang.Value + ((1 - MoreSkills_Config.BaseChanceWolfFang.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "WolfPelt")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxWolfPelt.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxWolfPelt.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinWolfPelt.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinWolfPelt.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxWolfPelt.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxWolfPelt.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceWolfPelt.Value + ((1 - MoreSkills_Config.BaseChanceWolfPelt.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyWolf")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxWolfTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxWolfTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinWolfTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinWolfTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxWolfTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxWolfTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceWolfTrophy.Value + ((1 - MoreSkills_Config.BaseChanceWolfTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_wraith")
                                {
                                    name = "Wraith";
                                    if (drop.m_prefab.name == "Chain")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxWraithChain.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxWraithChain.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinWraithChain.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinWraithChain.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxWraithChain.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxWraithChain.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceWraithChain.Value + ((1 - MoreSkills_Config.BaseChanceWraithChain.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyWraith")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxWraithTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxWraithTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinWraithTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinWraithTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxWraithTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxWraithTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceWraithTrophy.Value + ((1 - MoreSkills_Config.BaseChanceWraithTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }

                                if (!MoreSkills_Config.EnableHuntingBossMod.Value)
                                    Debug.Log("Updated mob: " + name + " Item: " + drop.m_prefab.name + " Min: " + drop.m_amountMin + " Max: " + drop.m_amountMax + " Chance: " + drop.m_chance);
                            }

                            if (MoreSkills_Config.EnableHuntingBossMod.Value)
                            {
                                if (__instance.m_character.m_name == "$enemy_eikthyr")
                                {
                                    name = "Eikthyr";
                                    if (drop.m_prefab.name == "HardAntler")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxEikthyrHardAntler.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxEikthyrHardAntler.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinEikthyrHardAntler.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinEikthyrHardAntler.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxEikthyrHardAntler.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxEikthyrHardAntler.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceEikthyrHardAntler.Value + ((1 - MoreSkills_Config.BaseChanceEikthyrHardAntler.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyEikthyr")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxEikthyrTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxEikthyrTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinEikthyrTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinEikthyrTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxEikthyrTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxEikthyrTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceEikthyrTrophy.Value + ((1 - MoreSkills_Config.BaseChanceEikthyrTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_gdking")
                                {
                                    name = "TheElder";
                                    if (drop.m_prefab.name == "CryptKey")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxgdkingCryptKey.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxgdkingCryptKey.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMingdkingCryptKey.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMingdkingCryptKey.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxgdkingCryptKey.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxgdkingCryptKey.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChancegdkingCryptKey.Value + ((1 - MoreSkills_Config.BaseChancegdkingCryptKey.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyTheElder")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxgdkingTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxgdkingTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMingdkingTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMingdkingTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxgdkingTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxgdkingTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChancegdkingTrophy.Value + ((1 - MoreSkills_Config.BaseChancegdkingTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_bonemass")
                                {
                                    name = "BoneMass";
                                    if (drop.m_prefab.name == "Wishbone")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBonemassWishbone.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBonemassWishbone.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinBonemassWishbone.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinBonemassWishbone.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBonemassWishbone.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBonemassWishbone.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceBonemassWishbone.Value + ((1 - MoreSkills_Config.BaseChanceBonemassWishbone.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyBonemass")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBonemassTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBonemassTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinBonemassTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinBonemassTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBonemassTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxBonemassTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceBonemassTrophy.Value + ((1 - MoreSkills_Config.BaseChanceBonemassTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_dragon")
                                {
                                    name = "Moder";
                                    if (drop.m_prefab.name == "DragonTear")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDragonTear.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDragonTear.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinDragonTear.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinDragonTear.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDragonTear.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDragonTear.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceDragonTear.Value + ((1 - MoreSkills_Config.BaseChanceDragonTear.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyDragonQueen")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDragonQueenTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDragonQueenTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinDragonQueenTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinDragonQueenTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxDragonQueenTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxDragonQueenTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceDragonQueenTrophy.Value + ((1 - MoreSkills_Config.BaseChanceDragonQueenTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }
                                else if (__instance.m_character.m_name == "$enemy_goblinking")
                                {
                                    name = "GoblinKing";
                                    if (drop.m_prefab.name == "YagluthDrop")
                                    {
                                        if (MinMax)
                                        {
                                            if ((level) > 0.5)
                                            {
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinKingYagluthDrop.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinKingYagluthDrop.Value + maxskill_inc);
                                                float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGoblinKingYagluthDrop.Value * skill);
                                                drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGoblinKingYagluthDrop.Value + skill_inc);
                                            }
                                            else
                                            {
                                                float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinKingYagluthDrop.Value * maxskill);
                                                drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinKingYagluthDrop.Value + maxskill_inc);
                                            }
                                        }
                                        if (Chance)
                                            drop.m_chance = MoreSkills_Config.BaseChanceGoblinKingYagluthDrop.Value + ((1 - MoreSkills_Config.BaseChanceGoblinKingYagluthDrop.Value) * level);
                                    }
                                    else if (drop.m_prefab.name == "TrophyGoblinKing")
                                    {
                                        if (MoreSkills_Config.EnableHuntingTrophyMod.Value)
                                        {
                                            if (MinMax)
                                            {
                                                if ((level) > 0.5)
                                                {
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinKingTrophy.Value * MoreSkills_Config.HuntingDropMultiplier.Value);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinKingTrophy.Value + maxskill_inc);
                                                    float skill = level * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinGoblinKingTrophy.Value * skill);
                                                    drop.m_amountMin = (int)(MoreSkills_Config.BaseMinGoblinKingTrophy.Value + skill_inc);
                                                }
                                                else
                                                {
                                                    float maxskill = (level * 2) * MoreSkills_Config.HuntingDropMultiplier.Value;
                                                    float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxGoblinKingTrophy.Value * maxskill);
                                                    drop.m_amountMax = (int)(MoreSkills_Config.BaseMaxGoblinKingTrophy.Value + maxskill_inc);
                                                }
                                            }
                                            if (Chance)
                                                drop.m_chance = MoreSkills_Config.BaseChanceGoblinKingTrophy.Value + ((1 - MoreSkills_Config.BaseChanceGoblinKingTrophy.Value) * level);
                                        }
                                    }
                                    else
                                        Debug.LogError("[MoreSkills]: Missing Object to add of fix: " + drop.m_prefab.name);

                                }

                                //Debug.Log("Updated mob: " + name + " Item: " + drop.m_prefab.name + " Min: " + drop.m_amountMin + " Max: " + drop.m_amountMax + " Chance: " + drop.m_chance);
                            }

                            /*Debug.Log("__________________________");
                            Debug.Log("Character: " + __instance.m_character.m_name);
                            Debug.Log("Item " + drop.m_prefab.name);
                            Debug.Log("Item Min: " + drop.m_amountMin);
                            Debug.Log("Item Max: " + drop.m_amountMax);
                            Debug.Log("Item Chance: " + drop.m_chance);
                            Debug.Log("Item LvlMult: " + drop.m_levelMultiplier);
                            Debug.Log("__________________________");*/

                        }

                        if (__instance.m_character.m_name == "$enemy_blob"
                            || __instance.m_character.m_name == "$enemy_blobelite"
                            || __instance.m_character.m_name == "$enemy_boar"
                            || __instance.m_character.m_name == "$enemy_deathsquito"
                            || __instance.m_character.m_name == "$enemy_deer"
                            || __instance.m_character.m_name == "$enemy_drake"
                            || __instance.m_character.m_name == "$enemy_draugr"
                            || __instance.m_character.m_name == "$enemy_draugrelite"
                            || __instance.m_character.m_name == "$enemy_fenring"
                            || __instance.m_character.m_name == "$enemy_goblin"
                            || __instance.m_character.m_name == "$enemy_goblinbrute"
                            || __instance.m_character.m_name == "$enemy_goblinshaman"
                            || __instance.m_character.m_name == "$enemy_greydwarf"
                            || __instance.m_character.m_name == "$enemy_greydwarfbrute"
                            || __instance.m_character.m_name == "$enemy_greydwarfshaman"
                            || __instance.m_character.m_name == "$enemy_greyling"
                            || __instance.m_character.m_name == "$enemy_leech"
                            || __instance.m_character.m_name == "$enemy_lox"
                            || __instance.m_character.m_name == "$enemy_neck"
                            || __instance.m_character.m_name == "$enemy_serpent"
                            || __instance.m_character.m_name == "$enemy_skeleton"
                            || __instance.m_character.m_name == "$enemy_skeletonpoison"
                            || __instance.m_character.m_name == "$enemy_stonegolem"
                            || __instance.m_character.m_name == "$enemy_surtling"
                            || __instance.m_character.m_name == "$enemy_troll"
                            || __instance.m_character.m_name == "$enemy_wolf"
                            || __instance.m_character.m_name == "$enemy_wraith"
                            || __instance.m_character.m_name == "$enemy_eikthyr"
                            || __instance.m_character.m_name == "$enemy_gdking"
                            || __instance.m_character.m_name == "$enemy_bonemass"
                            || __instance.m_character.m_name == "$enemy_dragon"
                            || __instance.m_character.m_name == "$enemy_goblinking")
                        {
                        }
                        else
                            Debug.LogError("[MoreSkills]: Character missing in DataBase. Please report this with this name: " + "..." + __instance.m_character.m_name + "...");

                    }
            }

            public static string name;
        }

        [HarmonyPatch(typeof(CharacterDrop), "OnDeath")]
        public static class Hunting_RaiseSkill
        {
            public static void Postfix(ref CharacterDrop __instance)
            {
                if (MoreSkills_Instances._player != null)
                {
                    if (MoreSkills_Config.EnableHuntingSkill.Value)
                    {
                        if (MoreSkills_Instances._CDAttacker == MoreSkills_Instances._player.GetZDOID())
                        {
                            HuntIncrease += ((__instance.m_character.GetMaxHealth()) / 100) * __instance.m_character.GetLevel();
                            //Debug.LogWarning("Vida máx: " + __instance.m_character.GetMaxHealth() + " Nivel: " + __instance.m_character.GetLevel());
                        }

                        if (HuntIncrease > 0.1f)
                        {
                            MoreSkills_Instances._player.RaiseSkill((Skills.SkillType)MoreSkills_Config.HuntingSkill_Type, HuntIncrease);
                            HuntIncrease = 0f;
                        }
                    }
                }
            }

            public static float HuntIncrease;
        }
    }
}
