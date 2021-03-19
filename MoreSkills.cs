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
                        if (countsrs >= 100)
                            if (moving)
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
                        float health_skill = (float)Math.Floor((__instance.GetSkillFactor((Skills.SkillType)MoreSkills_Config.VitalitySkill_Type) * 100f) + 0.000001f);
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
                        __instance.RaiseSkill((Skills.SkillType)MoreSkills_Config.VitalitySkill_Type, ((hit.GetTotalDamage() / 100) * MoreSkills_Config.VitalitySkillIncreaseMultiplier.Value));
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
                        if (__instance.IsCrouching())
                        {
                            float sneak_skill = (float)Math.Floor((__instance.GetSkillFactor((Skills.SkillType.Sneak)) * 100f) + 0.000001f);
                            float sneak_skillinc = ((MoreSkills_Config.BaseMaxCrouchSpeed.Value - MoreSkills_Config.BaseCrouchSpeed.Value) / 100) * sneak_skill;
                            __instance.m_crouchSpeed = MoreSkills_Config.BaseCrouchSpeed.Value + sneak_skillinc;
                        }
                        else
                            __instance.m_crouchSpeed = 2f;
                    }
            }
        }

        [HarmonyPatch(typeof(Player), "UpdateStats")]
        public static class Swim_SwimSpeedMod
        {
            public static void Postfix(ref Player __instance)
            {
                if(MoreSkills_Config.EnableSwimMod.Value)
                    if(__instance != null)
                    {
                        float swim_skill = (float)Math.Floor((__instance.GetSkillFactor((Skills.SkillType.Swim)) * 100f) + 0.000001f);
                        float swim_skillinc = ((MoreSkills_Config.BaseMaxCrouchSpeed.Value - MoreSkills_Config.BaseSwimSpeed.Value) / 100) * swim_skill;
                        __instance.m_swimSpeed = MoreSkills_Config.BaseSwimSpeed.Value + swim_skillinc;
                    }
            }
        }

        [HarmonyPatch(typeof(Player), "UpdateShipControl")]
        public static class Sailing_Skill
        {
            public static void Postfix(ref Player __instance)
            {
                if (__instance != null)
                {
                    if (MoreSkills_Config.EnableSailingMod.Value)
                    {
                        if (__instance.GetControlledShip() != null)
                        {
                            float sailing_skill = (float)Math.Floor((__instance.GetSkillFactor((Skills.SkillType)MoreSkills_Config.SailingSkill_Type) * 100f) + 0.000001f);
                            float bforce_skillinc = ((MoreSkills_Config.BaseMaxBForce.Value - MoreSkills_Config.BaseBForce.Value) / 100) * sailing_skill;
                            float rspeed_skillinc = ((MoreSkills_Config.BaseMaxRSpeed.Value - MoreSkills_Config.BaseRSpeed.Value) / 100) * sailing_skill;
                            float sforce_skillinc = ((MoreSkills_Config.BaseMaxSForce.Value - MoreSkills_Config.BaseSForce.Value) / 100) * sailing_skill;
                            float angdamping_skillinc = ((MoreSkills_Config.BaseMaxAngDamping.Value - MoreSkills_Config.BaseAngDamping.Value) / 100) * sailing_skill;
                            float dsideways_skillinc = ((MoreSkills_Config.BaseMaxDSideways.Value - MoreSkills_Config.BaseDSideways.Value) / 100) * sailing_skill;
                            float mbforce = __instance.GetControlledShip().m_backwardForce;
                            float msforce = __instance.GetControlledShip().m_sailForceFactor;
                            float CrewMult = ((MoreSkills_Config.BaseBForce.Value + bforce_skillinc) + (((MoreSkills_Config.CrewMembersBForceAdd.Value * bforce_skillinc) / 5) * __instance.GetControlledShip().m_players.Count));

                            if (__instance.GetVelocity().x < -1)
                                svelx = __instance.GetVelocity().x * -1;
                            else if (__instance.GetVelocity().x > 1)
                                svelx = __instance.GetVelocity().x;
                            if (__instance.GetVelocity().z < -1)
                                svelz = __instance.GetVelocity().z * -1;
                            else if (__instance.GetVelocity().z > 1)
                                svelz = __instance.GetVelocity().z;                            

                            if (!MoreSkills_Config.EnableShipAcceleration.Value)
                            {
                                if (!MoreSkills_Config.EnableShipCrew.Value)                                
                                    __instance.GetControlledShip().m_backwardForce = MoreSkills_Config.BaseBForce.Value + bforce_skillinc;                                
                                else                                
                                    __instance.GetControlledShip().m_backwardForce = (MoreSkills_Config.BaseBForce.Value + bforce_skillinc) + (((MoreSkills_Config.CrewMembersBForceAdd.Value * bforce_skillinc) / 5) * __instance.GetControlledShip().m_players.Count);
                                __instance.GetControlledShip().m_sailForceFactor = MoreSkills_Config.BaseSForce.Value + sforce_skillinc;
                            }
                            else
                            {
                                if (__instance.GetControlledShip().GetSpeedSetting().ToString() == "Stop")
                                {
                                    __instance.GetControlledShip().m_sailForceFactor = 0.01f;
                                    __instance.GetControlledShip().m_backwardForce = 0.01f;
                                }
                                else if (msforce < (MoreSkills_Config.BaseSForce.Value + sforce_skillinc) && (__instance.GetControlledShip().GetSpeedSetting().ToString() == "Half" || __instance.GetControlledShip().GetSpeedSetting().ToString() == "Full"))
                                    __instance.GetControlledShip().m_sailForceFactor += 0.0001f;
                                else if (mbforce < (MoreSkills_Config.BaseBForce.Value + bforce_skillinc) && !MoreSkills_Config.EnableShipCrew.Value && (__instance.GetControlledShip().GetSpeedSetting().ToString() == "Slow" || __instance.GetControlledShip().GetSpeedSetting().ToString() == "Back"))
                                    __instance.GetControlledShip().m_backwardForce += 0.001f;
                                else if (mbforce < CrewMult && MoreSkills_Config.EnableShipCrew.Value && (__instance.GetControlledShip().GetSpeedSetting().ToString() == "Slow" || __instance.GetControlledShip().GetSpeedSetting().ToString() == "Back"))
                                    __instance.GetControlledShip().m_backwardForce += 0.001f;
                            }

                            __instance.GetControlledShip().m_rudderSpeed = MoreSkills_Config.BaseRSpeed.Value + rspeed_skillinc;
                            __instance.GetControlledShip().m_angularDamping = MoreSkills_Config.BaseAngDamping.Value + angdamping_skillinc;
                            __instance.GetControlledShip().m_dampingSideway = MoreSkills_Config.BaseDSideways.Value + dsideways_skillinc;

                            if (((svelx + svelz) / 1000) >= 0.0001)
                                __instance.RaiseSkill((Skills.SkillType)MoreSkills_Config.SailingSkill_Type, ((svelx + svelz) / (2000 * MoreSkills_Config.SailingSkillIncreaseMultiplier.Value)));
                        }
                        else if (__instance.GetStandingOnShip() != null || SittingInBoat)
                        {

                            if (__instance.GetVelocity().x < -1)
                                svelx = __instance.GetVelocity().x * -1;
                            else if (__instance.GetVelocity().x > 1)
                                svelx = __instance.GetVelocity().x;
                            if (__instance.GetVelocity().z < -1)
                                svelz = __instance.GetVelocity().z * -1;
                            else if (__instance.GetVelocity().z > 1)
                                svelz = __instance.GetVelocity().z;

                            if (__instance.IsAttached())
                            {
                                SittingInBoat = true;
                                if (((svelx + svelz) / 2500) >= 0.0001)
                                    __instance.RaiseSkill((Skills.SkillType)MoreSkills_Config.SailingSkill_Type, ((svelx + svelz) / (4000 * MoreSkills_Config.SailingSkillIncreaseMultiplier.Value)));
                            }
                            else
                            {
                                SittingInBoat = false;
                                if (((svelx + svelz) / 5000) >= 0.0001)
                                    __instance.RaiseSkill((Skills.SkillType)MoreSkills_Config.SailingSkill_Type, ((svelx + svelz) / (8000 * MoreSkills_Config.SailingSkillIncreaseMultiplier.Value)));
                            }
                        }
                    }
                }
            }

            public static bool InBoat;
            public static bool SittingInBoat;
            public static float svelx;
            public static float svelz;
        }
    }
}

