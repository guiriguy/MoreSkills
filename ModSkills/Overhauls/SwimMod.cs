using System;
using HarmonyLib;
using MoreSkills.Config;
using MoreSkills.Utility;

namespace MoreSkills.ModSkills
{
    class MoreSkills_SwimMod
    {
        [HarmonyPatch(typeof(Player), "UpdateStats")]
        public static class Swim_SwimSpeedMod
        {
            public static void Postfix()
            {
                if (MoreSkills_Config.EnableSwimMod.Value)
                    if (MoreSkills_Instances._player != null)
                    {
                        float swim_skill = (float)Math.Floor((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType.Swim)) * 100f) + 0.000001f);
                        float swim_skillinc = ((MoreSkills_Config.BaseMaxCrouchSpeed.Value - MoreSkills_Config.BaseSwimSpeed.Value) / 100) * swim_skill;
                        MoreSkills_Instances._player.m_swimSpeed = MoreSkills_Config.BaseSwimSpeed.Value + swim_skillinc;
                    }
            }
        }
    }
}
