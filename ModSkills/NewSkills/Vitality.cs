using System;
using UnityEngine;
using HarmonyLib;
using MoreSkills.Config;
using MoreSkills.Utility;

namespace MoreSkills.ModSkills
{
    class MoreSkills_Vitality
    {
        [HarmonyPatch(typeof(Player), "SetMaxHealth")]
        public static class Vitality_ApplyBaseHealthMod
        {
            public static void Prefix(ref float health)
            {
                if (MoreSkills_Config.EnableHealthMod.Value)
                {
                    if (MoreSkills_Instances._player != null)
                    {
                        float health_skill = (float)Math.Floor((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.VitalitySkill_Type) * 100f) + 0.000001f);
                        float health_skillinc = ((MoreSkills_Config.BaseMaxHealth.Value - MoreSkills_Config.BaseHealth.Value) / 100) * health_skill;
                        health += (MoreSkills_Config.BaseHealth.Value + health_skillinc) - 25f;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(Player), "OnDamaged")]
        public static class Vitality_RaiseSkill
        {
            public static void Postfix(ref HitData hit)
            {
                if (MoreSkills_Config.EnableHealthMod.Value)
                {
                    if (MoreSkills_Instances._player != null)
                    {
                        if (IncVitality >= 0.10f)
                        {
                            MoreSkills_Instances._player.RaiseSkill((Skills.SkillType)MoreSkills_Config.VitalitySkill_Type, IncVitality);
                            IncVitality = 0f;
                        }
                        else
                        {
                            IncVitality += ((hit.GetTotalDamage() / 10) * MoreSkills_Config.VitalitySkillIncreaseMultiplier.Value);
                        }
                    }
                }
            }
            public static float IncVitality;
        }
    }
}
