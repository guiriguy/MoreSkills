using System;
using UnityEngine;
using HarmonyLib;
using MoreSkills.Config;
using MoreSkills.Utility;

namespace MoreSkills.ModSkills
{
    class MoreSkills_PickaxeMod
    {
        [HarmonyPatch(typeof(MineRock5), "Damage")]
        public static class Pickaxe_DropMod
        {
            public static void Postfix(MineRock5 __instance, HitData hit)
            {
                if (MoreSkills_Config.EnablePickaxeDropMod.Value)
                {
                    if (MoreSkills_Instances._player != null && hit.m_attacker == MoreSkills_Instances._player.GetZDOID())
                    {
                        /*for (int i = 0; i < ((__instance.m_hitAreas.Count <= 128) ? __instance.m_hitAreas.Count : 128); i++)
                        {
                            int[] j = new int[i];

                            if (__instance.m_hitAreas[i].m_health > 0f)


                            __instance.m_nview.InvokeRPC("Damage", new object[]
                            {
                            hit,
                            i
                            });
                        }*/

                        float level = MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes);

                        if (__instance.m_name == "Rock")
                        {
                            if ((level * 100f) > 50)
                            {
                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxRock.Value * MoreSkills_Config.PickaxeMultiplier.Value);
                                __instance.m_dropItems.m_dropMax = (int)(MoreSkills_Config.BaseMaxRock.Value + maxskill_inc);
                                float skill = level * MoreSkills_Config.PickaxeMultiplier.Value;
                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinRock.Value * skill);
                                __instance.m_dropItems.m_dropMin = (int)(MoreSkills_Config.BaseMinRock.Value + skill_inc);
                            }
                            else
                            {
                                float maxskill = (level * 2) * MoreSkills_Config.PickaxeMultiplier.Value;
                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxRock.Value * maxskill);
                                __instance.m_dropItems.m_dropMax = (int)(MoreSkills_Config.BaseMaxRock.Value + maxskill_inc);
                            }
                        }

                        if (__instance.m_name == "$piece_deposit_copper")
                        {
                            if ((level * 100f) > 50)
                            {
                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxCopperVein.Value * MoreSkills_Config.PickaxeMultiplier.Value);
                                __instance.m_dropItems.m_dropMax = (int)(MoreSkills_Config.BaseMaxCopperVein.Value + maxskill_inc);
                                float skill = level * MoreSkills_Config.PickaxeMultiplier.Value;
                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinCopperVein.Value * skill);
                                __instance.m_dropItems.m_dropMin = (int)(MoreSkills_Config.BaseMinCopperVein.Value + skill_inc);
                            }
                            else
                            {
                                float maxskill = (level * 2) * MoreSkills_Config.PickaxeMultiplier.Value;
                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxCopperVein.Value * maxskill);
                                __instance.m_dropItems.m_dropMax = (int)(MoreSkills_Config.BaseMaxCopperVein.Value + maxskill_inc);
                            }
                        }

                        if (__instance.m_name == "$piece_mudpile")
                        {
                            if (MoreSkills_Config.EnablePickaxeChanceMod.Value)
                            {
                                __instance.m_dropItems.m_dropChance = MoreSkills_Config.BaseChanceMudPile.Value + (MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes));
                            }
                            if ((level * 100f) > 50)
                            {
                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxMudPile.Value * MoreSkills_Config.PickaxeMultiplier.Value);
                                __instance.m_dropItems.m_dropMax = (int)(MoreSkills_Config.BaseMaxMudPile.Value + maxskill_inc);
                                float skill = level * MoreSkills_Config.PickaxeMultiplier.Value;
                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinMudPile.Value * skill);
                                __instance.m_dropItems.m_dropMin = (int)(MoreSkills_Config.BaseMinMudPile.Value + skill_inc);
                            }
                            else
                            {
                                float maxskill = (level * 2) * MoreSkills_Config.PickaxeMultiplier.Value;
                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxMudPile.Value * maxskill);
                                __instance.m_dropItems.m_dropMax = (int)(MoreSkills_Config.BaseMaxMudPile.Value + maxskill_inc);
                            }
                        }

                        if (__instance.m_name == "Silver vein")
                        {
                            if ((level * 100f) > 50)
                            {
                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSilverVein.Value * MoreSkills_Config.PickaxeMultiplier.Value);
                                __instance.m_dropItems.m_dropMax = (int)(MoreSkills_Config.BaseMaxSilverVein.Value + maxskill_inc);
                                float skill = level * MoreSkills_Config.PickaxeMultiplier.Value;
                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinSilverVein.Value * skill);
                                __instance.m_dropItems.m_dropMin = (int)(MoreSkills_Config.BaseMinSilverVein.Value + skill_inc);
                            }
                            else
                            {
                                float maxskill = (level * 2) * MoreSkills_Config.PickaxeMultiplier.Value;
                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxSilverVein.Value * maxskill);
                                __instance.m_dropItems.m_dropMax = (int)(MoreSkills_Config.BaseMaxSilverVein.Value + maxskill_inc);
                            }
                        }

                        if (__instance.m_name == null && __instance.m_hitAreas.Count > 10)
                        {
                            if ((level * 100f) > 50)
                            {
                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBigRock.Value * MoreSkills_Config.PickaxeMultiplier.Value);
                                __instance.m_dropItems.m_dropMax = (int)(MoreSkills_Config.BaseMaxBigRock.Value + maxskill_inc);
                                float skill = level * MoreSkills_Config.PickaxeMultiplier.Value;
                                float skill_inc = Mathf.Round(MoreSkills_Config.BaseMinBigRock.Value * skill);
                                __instance.m_dropItems.m_dropMin = (int)(MoreSkills_Config.BaseMinBigRock.Value + skill_inc);
                            }
                            else
                            {
                                float maxskill = (level * 2) * MoreSkills_Config.PickaxeMultiplier.Value;
                                float maxskill_inc = Mathf.Round(MoreSkills_Config.BaseMaxBigRock.Value * maxskill);
                                __instance.m_dropItems.m_dropMax = (int)(MoreSkills_Config.BaseMaxBigRock.Value + maxskill_inc);
                            }
                        }

                        /*Debug.LogWarning("Nombre: " + __instance.m_name);
                        Debug.LogWarning("Cantidad de rocas: " + __instance.m_hitAreas.Count);
                        Debug.LogWarning("Chance: " + __instance.m_dropItems.m_dropChance);
                        Debug.LogWarning("Min: " + __instance.m_dropItems.m_dropMin);
                        Debug.LogWarning("Max: " + __instance.m_dropItems.m_dropMax);*/
                    }
                }



            }
        }
    }
}
