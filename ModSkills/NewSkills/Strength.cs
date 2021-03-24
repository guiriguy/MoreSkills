using System;
using UnityEngine;
using HarmonyLib;
using MoreSkills.Config;
using MoreSkills.Utility;

namespace MoreSkills.ModSkills
{
    class MoreSkills_Strength
    {
        [HarmonyPatch(typeof(Player), "GetMaxCarryWeight")]
        public static class Strength_ApplyWeightMod
        {
            public static void Postfix()
            {
                if (MoreSkills_Config.EnableWeightMod.Value)
                {
                    if (MoreSkills_Instances._player != null)
                    {
                        float weight_skill = (float)Math.Floor((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.StrengthSkill_Type) * 100f) + 0.000001f);
                        float weight_skillinc = ((MoreSkills_Config.BaseMaxWeight.Value - MoreSkills_Config.BaseWeight.Value) / 100f) * weight_skill;
                        MoreSkills_Instances._player.m_maxCarryWeight = (MoreSkills_Config.BaseWeight.Value + weight_skillinc);

                    }
                }
            }
        }

        [HarmonyPatch(typeof(Player), "UpdateStats")]
        public static class RaiseSkill_Strength
        {
            public static void Postfix()
            {
                if (MoreSkills_Config.EnableWeightMod.Value)
                {
                    if (MoreSkills_Instances._player != null)
                    {
                        bool halfweight = MoreSkills_Instances._player.GetInventory().GetTotalWeight() > (MoreSkills_Instances._player.GetMaxCarryWeight() / 2);
                        Vector3 vel = MoreSkills_Instances._player.m_currentVel;
                        bool moving = Math.Floor(vel.y + vel.x + vel.z) < -1 || Math.Floor(vel.y + vel.x + vel.z) > 1;
                        if (halfweight && moving)
                            if (MoreSkills_Instances._player.IsEncumbered())
                            {
                                if (IncEncumbred >= 0.10f)
                                {
                                    MoreSkills_Instances._player.RaiseSkill((Skills.SkillType)MoreSkills_Config.StrengthSkill_Type, IncEncumbred);
                                    IncEncumbred = 0f;
                                }
                                else
                                    IncEncumbred += ((MoreSkills_Instances._player.GetInventory().GetTotalWeight() / 40000) * MoreSkills_Config.StrengthSkillIncreaseMultiplier.Value);
                            }
                            else if (halfweight)
                            {
                                if (MoreSkills_Instances._player.IsRunning())
                                {
                                    if (IncHalfnRunning >= 0.10f)
                                    {
                                        MoreSkills_Instances._player.RaiseSkill((Skills.SkillType)MoreSkills_Config.StrengthSkill_Type, IncHalfnRunning);
                                        IncHalfnRunning = 0f;
                                    }
                                    else
                                        IncHalfnRunning += ((MoreSkills_Instances._player.GetInventory().GetTotalWeight() / 80000) * MoreSkills_Config.StrengthSkillIncreaseMultiplier.Value);
                                }
                                else
                                {
                                    if (IncHalfnMoving >= 0.10f)
                                    {
                                        MoreSkills_Instances._player.RaiseSkill((Skills.SkillType)MoreSkills_Config.StrengthSkill_Type, IncHalfnMoving);
                                        IncHalfnMoving = 0f;
                                    }
                                    else
                                        IncHalfnMoving += ((MoreSkills_Instances._player.GetInventory().GetTotalWeight() / 120000) * MoreSkills_Config.StrengthSkillIncreaseMultiplier.Value);
                                }



                            }
                    }
                }
            }

            public static float IncEncumbred;
            public static float IncHalfnRunning;
            public static float IncHalfnMoving;
        }
    }
}
