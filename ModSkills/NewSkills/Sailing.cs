using System;
using UnityEngine;
using HarmonyLib;
using MoreSkills.Config;
using MoreSkills.Utility;

namespace MoreSkills.ModSkills
{
    class MoreSkills_Sailing
    {
        [HarmonyPatch(typeof(Player), "UpdateShipControl")]
        public static class Sailing_Skill
        {
            public static void Postfix()
            {
                if (MoreSkills_Instances._player != null)
                {
                    if (MoreSkills_Config.EnableSailingMod.Value)
                    {
                        if (MoreSkills_Instances._player.GetControlledShip() != null)
                        {
                            float sailing_skill = (float)Math.Floor((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.SailingSkill_Type) * 100f) + 0.000001f);
                            float bforce_skillinc = ((MoreSkills_Config.BaseMaxBForce.Value - MoreSkills_Config.BaseBForce.Value) / 100) * sailing_skill;
                            float rspeed_skillinc = ((MoreSkills_Config.BaseMaxRSpeed.Value - MoreSkills_Config.BaseRSpeed.Value) / 100) * sailing_skill;
                            float sforce_skillinc = ((MoreSkills_Config.BaseMaxSForce.Value - MoreSkills_Config.BaseSForce.Value) / 100) * sailing_skill;
                            float dsideways_skillinc = ((MoreSkills_Config.BaseMaxDSideways.Value - MoreSkills_Config.BaseDSideways.Value) / 100) * sailing_skill;
                            float mbforce = MoreSkills_Instances._player.GetControlledShip().m_backwardForce;
                            float msforce = MoreSkills_Instances._player.GetControlledShip().m_sailForceFactor;
                            float CrewMult = ((MoreSkills_Config.BaseBForce.Value + bforce_skillinc) + (((MoreSkills_Config.CrewMembersBForceAdd.Value * bforce_skillinc) / 5) * MoreSkills_Instances._player.GetControlledShip().m_players.Count));

                            if (MoreSkills_Instances._player.GetVelocity().x < -1)
                                svelx = MoreSkills_Instances._player.GetVelocity().x * -1;
                            else if (MoreSkills_Instances._player.GetVelocity().x > 1)
                                svelx = MoreSkills_Instances._player.GetVelocity().x;
                            else
                                svelx = 0f;
                            if (MoreSkills_Instances._player.GetVelocity().z < -1)
                                svelz = MoreSkills_Instances._player.GetVelocity().z * -1;
                            else if (MoreSkills_Instances._player.GetVelocity().z > 1)
                                svelz = MoreSkills_Instances._player.GetVelocity().z;
                            else
                                svelz = 0f;

                            if (!MoreSkills_Config.EnableShipAcceleration.Value)
                            {
                                if (!MoreSkills_Config.EnableShipCrew.Value)
                                    MoreSkills_Instances._player.GetControlledShip().m_backwardForce = MoreSkills_Config.BaseBForce.Value + bforce_skillinc;
                                else
                                    MoreSkills_Instances._player.GetControlledShip().m_backwardForce = (MoreSkills_Config.BaseBForce.Value + bforce_skillinc) + (((MoreSkills_Config.CrewMembersBForceAdd.Value * bforce_skillinc) / 5) * MoreSkills_Instances._player.GetControlledShip().m_players.Count);
                                MoreSkills_Instances._player.GetControlledShip().m_sailForceFactor = MoreSkills_Config.BaseSForce.Value + sforce_skillinc;
                            }
                            else
                            {
                                if (MoreSkills_Instances._player.GetControlledShip().GetSpeedSetting().ToString() == "Stop")
                                {
                                    MoreSkills_Instances._player.GetControlledShip().m_sailForceFactor = 0.01f;
                                    MoreSkills_Instances._player.GetControlledShip().m_backwardForce = 0.01f;
                                }
                                else if (msforce < (MoreSkills_Config.BaseSForce.Value + sforce_skillinc) && (MoreSkills_Instances._player.GetControlledShip().GetSpeedSetting().ToString() == "Half" || MoreSkills_Instances._player.GetControlledShip().GetSpeedSetting().ToString() == "Full"))
                                    MoreSkills_Instances._player.GetControlledShip().m_sailForceFactor += 0.0001f;
                                else if (mbforce < (MoreSkills_Config.BaseBForce.Value + bforce_skillinc) && !MoreSkills_Config.EnableShipCrew.Value && (MoreSkills_Instances._player.GetControlledShip().GetSpeedSetting().ToString() == "Slow" || MoreSkills_Instances._player.GetControlledShip().GetSpeedSetting().ToString() == "Back"))
                                    MoreSkills_Instances._player.GetControlledShip().m_backwardForce += 0.001f;
                                else if (mbforce < CrewMult && MoreSkills_Config.EnableShipCrew.Value && (MoreSkills_Instances._player.GetControlledShip().GetSpeedSetting().ToString() == "Slow" || MoreSkills_Instances._player.GetControlledShip().GetSpeedSetting().ToString() == "Back"))
                                    MoreSkills_Instances._player.GetControlledShip().m_backwardForce += 0.001f;
                            }

                            MoreSkills_Instances._player.GetControlledShip().m_rudderSpeed = MoreSkills_Config.BaseRSpeed.Value + rspeed_skillinc;
                            MoreSkills_Instances._player.GetControlledShip().m_dampingSideway = MoreSkills_Config.BaseDSideways.Value + dsideways_skillinc;

                            if (((svelx + svelz) / 1000) >= 0.0001)
                                if (Captain >= 0.10f)
                                {
                                    MoreSkills_Instances._player.RaiseSkill((Skills.SkillType)MoreSkills_Config.SailingSkill_Type, Captain);
                                    Captain = 0f;
                                }
                                else
                                {
                                    Captain += ((svelx + svelz) / (4000 * MoreSkills_Config.SailingSkillIncreaseMultiplier.Value));
                                }

                                
                        }
                        else if (MoreSkills_Instances._player.GetStandingOnShip() != null || SittingInBoat)
                        {

                            if (MoreSkills_Instances._player.GetVelocity().x < -1)
                                svelx = MoreSkills_Instances._player.GetVelocity().x * -1;
                            else if (MoreSkills_Instances._player.GetVelocity().x > 1)
                                svelx = MoreSkills_Instances._player.GetVelocity().x;
                            if (MoreSkills_Instances._player.GetVelocity().z < -1)
                                svelz = MoreSkills_Instances._player.GetVelocity().z * -1;
                            else if (MoreSkills_Instances._player.GetVelocity().z > 1)
                                svelz = MoreSkills_Instances._player.GetVelocity().z;

                            if (MoreSkills_Instances._player.IsAttached())
                            {
                                SittingInBoat = true;
                                if (((svelx + svelz) / 2500) >= 0.0001)
                                    if (SittingCrew >= 0.10f)
                                    {
                                        MoreSkills_Instances._player.RaiseSkill((Skills.SkillType)MoreSkills_Config.SailingSkill_Type, SittingCrew);
                                        SittingCrew = 0f;
                                    }
                                    else
                                    {
                                        SittingCrew += ((svelx + svelz) / (8000 * MoreSkills_Config.SailingSkillIncreaseMultiplier.Value));
                                    }
                                    
                            }
                            else
                            {
                                SittingInBoat = false;
                                if (((svelx + svelz) / 5000) >= 0.0001)
                                    if (StandingCrew >= 0.10f)
                                    {
                                        MoreSkills_Instances._player.RaiseSkill((Skills.SkillType)MoreSkills_Config.SailingSkill_Type, StandingCrew);
                                        StandingCrew = 0f;
                                    }
                                    else
                                    {
                                        StandingCrew += ((svelx + svelz) / (16000 * MoreSkills_Config.SailingSkillIncreaseMultiplier.Value));
                                    }                                    
                            }
                        }
                    }
                }
            }

            public static bool SittingInBoat;
            public static float svelx;
            public static float svelz;
            public static float Captain;
            public static float SittingCrew;
            public static float StandingCrew;
        }
    }
}
