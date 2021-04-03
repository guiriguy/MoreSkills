using HarmonyLib;
using MoreSkills.Config;
using MoreSkills.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MoreSkills.ModSkills.Overhauls
{
    class MoreSkills_JumpMod
    {
        [HarmonyPatch(typeof(Player), "UpdateStats")]
        public static class TestJump
        {
            public static void Postfix(ref Character __instance)
            {
                if (MoreSkills_Instances._player != null)
                {
                    if (MoreSkills_OverhaulsConfig.EnableJumpMod.Value)
                    {
                        if (MoreSkills_OverhaulsConfig.EnableHigherJump.Value)
                        {
                            if (MoreSkills_OverhaulsConfig.EnableHaveToShiftToHigherJump.Value)
                            {
                                if (Input.GetKey(MoreSkills_OverhaulsConfig.HigherJumpKey.Value))
                                    MoreSkills_Instances._player.m_jumpForce = MoreSkills_OverhaulsConfig.BaseJumpForce.Value + (MoreSkills_OverhaulsConfig.BaseMaxJumpForce.Value - MoreSkills_OverhaulsConfig.BaseJumpForce.Value) * MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Jump);
                                else
                                    MoreSkills_Instances._player.m_jumpForce = MoreSkills_OverhaulsConfig.BaseJumpForce.Value;
                            }
                            else if (!MoreSkills_OverhaulsConfig.EnableHaveToShiftToHigherJump.Value)
                            {
                                MoreSkills_Instances._player.m_jumpForce = MoreSkills_OverhaulsConfig.BaseJumpForce.Value + (MoreSkills_OverhaulsConfig.BaseMaxJumpForce.Value - MoreSkills_OverhaulsConfig.BaseJumpForce.Value) * MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Jump);
                            }
                        }

                        if (MoreSkills_OverhaulsConfig.EnableRollOnFall.Value)
                        {
                            float Altitude = Mathf.Max(0f, __instance.m_maxAirAltitude - MoreSkills_Instances._player.transform.position.y);
                            if (Altitude > 4f && Altitude < 8f)
                            {
                                inAir = true;
                                onGround = false;
                            }

                            if (inAir)
                            {
                                if (Altitude == 0f)
                                {
                                    onGround = true;
                                    if (onGround)
                                    {
                                        Vector3 rollDir = MoreSkills_Instances._player.m_moveDir;
                                        if (rollDir.magnitude < 0.1f)
                                        {
                                            rollDir = MoreSkills_Instances._player.m_lookDir;
                                            rollDir.y = 0f;
                                            rollDir.Normalize();
                                        }
                                        MoreSkills_Instances._player.Dodge(rollDir);
                                        inAir = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(Character), "Damage")]
        public static class TestDamage
        {
            public static void Prefix(ref Character __instance, ref HitData hit)
            {
                if (MoreSkills_Instances._player != null)
                {
                    if (MoreSkills_OverhaulsConfig.EnableJumpMod.Value && MoreSkills_OverhaulsConfig.EnableDecreaseFallDamageMod.Value)
                    {
                        float Altitude = Mathf.Max(0f, __instance.m_maxAirAltitude - MoreSkills_Instances._player.transform.position.y);

                        if (Altitude > 4f && Altitude < 8f)
                        {
                            if (hit.m_attacker.m_userID == 0)
                            {
                                hit.m_damage.m_damage /= MoreSkills_OverhaulsConfig.FallDamageDecrease.Value * MoreSkills_Instances._player.GetSkillFactor(Skills.SkillType.Jump);
                            }
                        }
                    }
                }
            }
        }
        public static bool inAir;
        public static bool onGround;
    }
}
