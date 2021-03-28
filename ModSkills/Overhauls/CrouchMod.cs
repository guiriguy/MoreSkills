using System;
using HarmonyLib;
using MoreSkills.Config;
using MoreSkills.Utility;


namespace MoreSkills.ModSkills
{
    class MoreSkills_CrouchMod
    {
        [HarmonyPatch(typeof(Player), "UpdateStats")]
        public static class Sneak_CrouchSpeedMod
        {
            public static void Postfix()
            {
                if (MoreSkills_Config.EnableCrouchMod.Value)
                    if (MoreSkills_Instances._player != null)
                    {
                        if (MoreSkills_Instances._player.IsCrouching())
                        {
                            float sneak_skill = (float)Math.Floor((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType.Sneak)) * 100f) + 0.000001f);
                            float sneak_skillinc = ((MoreSkills_Config.BaseMaxCrouchSpeed.Value - MoreSkills_Config.BaseCrouchSpeed.Value) / 100) * sneak_skill;
                            MoreSkills_Instances._player.m_crouchSpeed = MoreSkills_Config.BaseCrouchSpeed.Value + sneak_skillinc;
                        }
                        else
                            MoreSkills_Instances._player.m_crouchSpeed = 2f;

                        if (MoreSkills_Instances._player.IsEncumbered())
                        {
                            MoreSkills_Instances._player.SetCrouch(false);
                        }
                    }
            }
        }
    }
}
