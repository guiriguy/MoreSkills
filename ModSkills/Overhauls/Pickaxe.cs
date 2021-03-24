using System;
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
                if (MoreSkills_Config.EnablePickaxeDropMod.Value && ((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 100f) + 0.0001f) >= 10)
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

                        if (__instance.m_name == "Rock")
                        {
                            if (((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 100f) + 0.0001f) < 50)
                            {
                                int skill = (int)((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 10) * MoreSkills_Config.PickaxeMultiplier.Value) * 2;
                                int skill_inc = MoreSkills_Config.BaseMaxRock.Value * skill;
                                __instance.m_dropItems.m_dropMax = MoreSkills_Config.BaseMaxRock.Value + skill_inc;
                            }
                            else
                            {
                                int maxskill = 10 * MoreSkills_Config.PickaxeMultiplier.Value;
                                int maxskill_inc = MoreSkills_Config.BaseMaxRock.Value * maxskill;
                                __instance.m_dropItems.m_dropMax = MoreSkills_Config.BaseMaxRock.Value + maxskill_inc;
                                int skill = (int)((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 10) * MoreSkills_Config.PickaxeMultiplier.Value);
                                int skill_inc = MoreSkills_Config.BaseMinRock.Value * skill;
                                __instance.m_dropItems.m_dropMin = MoreSkills_Config.BaseMinRock.Value + skill_inc;
                            }
                        }

                        if (__instance.m_name == "$piece_deposit_copper")
                        {
                            if (((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 100f) + 0.0001f) < 50)
                            {
                                int skill = (int)((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 10) * MoreSkills_Config.PickaxeMultiplier.Value) * 2;
                                int skill_inc = MoreSkills_Config.BaseMaxCopperVein.Value * skill;
                                __instance.m_dropItems.m_dropMax = MoreSkills_Config.BaseMaxCopperVein.Value + skill_inc;
                            }
                            else
                            {
                                int maxskill = 10 * MoreSkills_Config.PickaxeMultiplier.Value;
                                int maxskill_inc = MoreSkills_Config.BaseMaxCopperVein.Value * maxskill;
                                __instance.m_dropItems.m_dropMax = MoreSkills_Config.BaseMaxCopperVein.Value + maxskill_inc;
                                int skill = (int)((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 10) * MoreSkills_Config.PickaxeMultiplier.Value);
                                int skill_inc = MoreSkills_Config.BaseMinCopperVein.Value * skill;
                                __instance.m_dropItems.m_dropMin = MoreSkills_Config.BaseMinCopperVein.Value + skill_inc;
                            }
                        }

                        if (__instance.m_name == "$piece_mudpile")
                        {
                            if (MoreSkills_Config.EnablePickaxeChanceMod.Value)
                            {
                                __instance.m_dropItems.m_dropChance = MoreSkills_Config.BaseChanceMudPile.Value + (MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes));
                            }

                            if (((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 100f) + 0.0001f) < 50)
                            {
                                int skill = (int)((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 10) * MoreSkills_Config.PickaxeMultiplier.Value) * 2;
                                int skill_inc = MoreSkills_Config.BaseMaxMudPile.Value * skill;
                                __instance.m_dropItems.m_dropMax = MoreSkills_Config.BaseMaxMudPile.Value + skill_inc;
                            }
                            else
                            {
                                int maxskill = 10 * MoreSkills_Config.PickaxeMultiplier.Value;
                                int maxskill_inc = MoreSkills_Config.BaseMaxMudPile.Value * maxskill;
                                __instance.m_dropItems.m_dropMax = MoreSkills_Config.BaseMaxMudPile.Value + maxskill_inc;
                                int skill = (int)((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 10) * MoreSkills_Config.PickaxeMultiplier.Value);
                                int skill_inc = MoreSkills_Config.BaseMinMudPile.Value * skill;
                                __instance.m_dropItems.m_dropMin = MoreSkills_Config.BaseMinMudPile.Value + skill_inc;
                            }
                        }

                        if (__instance.m_name == "Silver vein")
                        {
                            if (((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 100f) + 0.0001f) < 50)
                            {
                                int skill = (int)((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 10) * MoreSkills_Config.PickaxeMultiplier.Value) * 2;
                                int skill_inc = MoreSkills_Config.BaseMaxSilverVein.Value * skill;
                                __instance.m_dropItems.m_dropMax = MoreSkills_Config.BaseMaxSilverVein.Value + skill_inc;
                            }
                            else
                            {
                                int maxskill = 10 * MoreSkills_Config.PickaxeMultiplier.Value;
                                int maxskill_inc = MoreSkills_Config.BaseMaxSilverVein.Value * maxskill;
                                __instance.m_dropItems.m_dropMax = MoreSkills_Config.BaseMaxSilverVein.Value + maxskill_inc;
                                int skill = (int)((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 10) * MoreSkills_Config.PickaxeMultiplier.Value);
                                int skill_inc = MoreSkills_Config.BaseMinSilverVein.Value * skill;
                                __instance.m_dropItems.m_dropMin = MoreSkills_Config.BaseMinSilverVein.Value + skill_inc;
                            }
                        }

                        if (__instance.m_name == null && __instance.m_hitAreas.Count > 10)
                        {
                            if (((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 100f) + 0.0001f) < 50)
                            {
                                int skill = (int)((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 10) * MoreSkills_Config.PickaxeMultiplier.Value) * 2;
                                int skill_inc = MoreSkills_Config.BaseMaxBigRock.Value * skill;
                                __instance.m_dropItems.m_dropMax = MoreSkills_Config.BaseMaxBigRock.Value + skill_inc;
                            }
                            else
                            {
                                int maxskill = 10 * MoreSkills_Config.PickaxeMultiplier.Value;
                                int maxskill_inc = MoreSkills_Config.BaseMaxBigRock.Value * maxskill;
                                __instance.m_dropItems.m_dropMax = MoreSkills_Config.BaseMaxBigRock.Value + maxskill_inc;
                                int skill = (int)((MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Pickaxes) * 10) * MoreSkills_Config.PickaxeMultiplier.Value);
                                int skill_inc = MoreSkills_Config.BaseMinBigRock.Value * skill;
                                __instance.m_dropItems.m_dropMin = MoreSkills_Config.BaseMinBigRock.Value + skill_inc;
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
