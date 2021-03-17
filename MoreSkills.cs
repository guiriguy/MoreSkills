using System;
using HarmonyLib;
using UnityEngine;
using MoreSkills.Config;

namespace MoreSkills_Skills
{
    public class MoreSkills
    { 
        [HarmonyPatch(typeof(Player), "GetMaxCarryWeight")]
        public static class Strength_ApplyWeightMod
        {
            public static void Postfix(ref Player __instance)
            {
                if (MoreSkills_Config.EnableWeightMod.Value)
                {
                    if (__instance != null)
                    {
                        float weight_skill = (float)Math.Floor((__instance.GetSkillFactor((Skills.SkillType)MoreSkills_Config.StrengthSkill_Type) * 100f) + 0.000001f);
                        float weight_skillinc = ((MoreSkills_Config.BaseMaxWeight.Value - MoreSkills_Config.BaseWeight.Value) / 100f) * weight_skill;
                        __instance.m_maxCarryWeight = (MoreSkills_Config.BaseWeight.Value + weight_skillinc);

                    }
                }
            }
        }

        [HarmonyPatch(typeof(Player), "UpdateStats")]
        public static class RaiseSkill_Strength
        {
            public static void Postfix(ref Player __instance)
            {
                if (MoreSkills_Config.EnableWeightMod.Value)
                {
                    if (__instance != null)
                    {
                        bool halfweight = __instance.GetInventory().GetTotalWeight() > (__instance.GetMaxCarryWeight() / 2);
                        Vector3 vel = __instance.m_currentVel;
                        bool moving = Math.Floor(vel.y + vel.x + vel.z) < -1 || Math.Floor(vel.y + vel.x + vel.z) > 1;
                        if (halfweight && moving) countsrs++;
                        if (countsrs >= 1000)
                        {
                            if (moving)
                            {
                                if (__instance.IsEncumbered())
                                {
                                    __instance.RaiseSkill((Skills.SkillType)MoreSkills_Config.StrengthSkill_Type, MoreSkills_Config.StrengthSkillIncreaseWhenEncumbred.Value);
                                    countsrs = 0;
                                }
                                else if (halfweight)
                                {
                                    if (__instance.IsRunning())
                                        __instance.RaiseSkill((Skills.SkillType)MoreSkills_Config.StrengthSkill_Type, MoreSkills_Config.StrengthSkillIncreaseWhenHalfnRunning.Value);
                                    else
                                        __instance.RaiseSkill((Skills.SkillType)MoreSkills_Config.StrengthSkill_Type, MoreSkills_Config.StrengthSkillIncreaseWhenHalfnMoving.Value);
                                    countsrs = 0;
                                }
                            }
                        }
                    }
                }
            }

            public static int countsrs;

        }

        [HarmonyPatch(typeof(Player), "SetMaxHealth")]
        public static class Vitality_ApplyBaseHealthMod
        {            
            public static void Prefix(ref float health, ref Player __instance)
            {
                if (MoreSkills_Config.EnableHealthMod.Value)
                {
                    if (__instance != null)
                    {
                        float health_skill = (float)Math.Floor((__instance.GetSkillFactor((Skills.SkillType)MoreSkills_Config.VitalitySkill_Type) * 100f) + 0.00000001f);
                        float health_skillinc = ((MoreSkills_Config.BaseMaxHealth.Value - MoreSkills_Config.BaseHealth.Value) / 100) * health_skill;
                        health += (MoreSkills_Config.BaseHealth.Value + health_skillinc) - 25f;
                    }
                }
            }
        }
            
        [HarmonyPatch(typeof(Player), "OnDamaged")]
        public static class Vitality_RaiseSkill
        {
            public static void Postfix(ref HitData hit, ref Player __instance)
            {
                if (MoreSkills_Config.EnableHealthMod.Value)
                {
                    if (__instance != null)
                    {
                        __instance.RaiseSkill((Skills.SkillType)701, (hit.GetTotalDamage() / 100));
                    }
                }
            }
        }

        [HarmonyPatch(typeof(Player), "UpdateStats")]

        public static class Sneak_CrouchSpeedMod
        {
            public static void Postfix(ref Player __instance)
            {
                if (MoreSkills_Config.EnableCrouchMod.Value)                
                    if (__instance != null)
                    {
                        float sneak_skill = (float)Math.Floor((__instance.GetSkillFactor((Skills.SkillType.Sneak)) * 100f) + 0.0000000000000000000001f);
                        float sneak_skillinc = ((MoreSkills_Config.BaseMaxCrouchSpeed.Value - MoreSkills_Config.BaseCrouchSpeed.Value) / 100) * sneak_skill;
                        __instance.m_crouchSpeed = MoreSkills_Config.BaseCrouchSpeed.Value + sneak_skillinc;
                    }
            }
        }
    }
}

