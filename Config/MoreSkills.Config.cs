using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Pipakin.SkillInjectorMod;
using MoreSkills.Utility;
using MoreSkills.UI;
using UnityEngine;

namespace MoreSkills.Config
{
    [BepInPlugin("com.GuiriGuy.MoreSkills", "MoreSkills", "0.1.0")]
    [BepInDependency("com.pipakin.SkillInjectorMod")]
    public class MoreSkills_Config : BaseUnityPlugin
    {
        public void Awake()
        {
            //Strength.Weight
            MoreSkills_Config.EnableWeightMod = base.Config.Bind<bool>("MoreSkills: Strength", "Enable Weight Mod", true, "Enables or disables the Weight Modification.");
            MoreSkills_Config.BaseWeight = base.Config.Bind<float>("MoreSkills: Strength", "Base Weight", 300f, "Change the base Weight. (Valheim Default is 300)");
            MoreSkills_Config.BaseMaxWeight = base.Config.Bind<float>("MoreSkills: Strength", "Base Max Weight", 600f, "Change the total Weight when Strength is at level 100. (Valheim Default is 300)");

            //Strength.Increases
            MoreSkills_Config.StrengthSkillIncreaseWhenEncumbred = base.Config.Bind<float>("MoreSkills: Strength", "Strength Skill Increase When Encumbred", 0.2f, "Change the skill increase when Encumbred.");
            MoreSkills_Config.StrengthSkillIncreaseWhenHalfnRunning = base.Config.Bind<float>("MoreSkills: Strength", "Strength Skill Increase When Halfweight and Running", 0.1f, "Change the skill increase when Carrying Half of your Max Weight and running.");
            MoreSkills_Config.StrengthSkillIncreaseWhenHalfnMoving = base.Config.Bind<float>("MoreSkills: Strength", "Strength Skill Increase When Halfweight and Moving", 0.05f, "Change the skill increase when Carrying Half of your Max Weight and moving.");

            //Vitality.Health
            MoreSkills_Config.EnableHealthMod = base.Config.Bind<bool>("MoreSkills: Vitality", "Enable Vitality Mod", true, "Enables or disables the Vitality Modification.");
            MoreSkills_Config.BaseHealth = base.Config.Bind<float>("MoreSkills: Vitality", "Base Health", 25f, "Change the base Health. (Valheim Default is 25)");
            MoreSkills_Config.BaseMaxHealth = base.Config.Bind<float>("MoreSkills: Vitality", "Base Max Health", 100f, "Change the toal Health when Vitality is at level 100. (Valheim Default is 25)");

            //Sneak.CrouchSpeed Changable to Hunting
            MoreSkills_Config.EnableCrouchMod = base.Config.Bind<bool>("MoreSkills: Sneak", "Enable Crouch Speed Mod", true, "Enables or disables the Crouch Speed Modification");
            MoreSkills_Config.BaseCrouchSpeed = base.Config.Bind<float>("MoreSkills: Sneak", "Base Crouch Speed", 2f, "Change the base Crouch Speed. (Valheim Default is 2)");
            MoreSkills_Config.BaseMaxCrouchSpeed = base.Config.Bind<float>("MoreSkills: Sneak", "Base Max Crouch Speed", 6f, "Change the base Max Crouch Speed at level 100. (Valheim Default is 2)");

            //Inject.Strength
            SkillInjector.RegisterNewSkill(700, "Strength", "Able to carry more and with higher numbers", 1f, SkillIcons.Load_StrengthIcon(), Skills.SkillType.Unarmed);
            SkillInjector.RegisterNewSkill(701, "Vitality", "Endure and gain resistance as you recieve damage", 1f, SkillIcons.Load_VitalityIcon(), Skills.SkillType.Unarmed);

            //--
            new Harmony("com.guiriguy.moreskills").PatchAll();

            //Logs
            if (!MoreSkills_Config.EnableWeightMod.Value)
            {
                Debug.LogWarning("[MoreSkills]: Weight Mod Disabled");
            }
            else
            {
                Debug.LogWarning("[MoreSkills]: Weight Mod Enabled");
            }

            if (!MoreSkills_Config.EnableHealthMod.Value)
            {
                Debug.LogWarning("[MoreSkills]: Health Mod Disabled");
            }
            else
            {
                Debug.LogWarning("[MoreSkills]: Health Mod Enabled");
            }
            if (!MoreSkills_Config.EnableCrouchMod.Value)
            {
                Debug.LogWarning("[MoreSkills]: Crouch Mod Disabled");
            }
            else
            {
                Debug.LogWarning("[MoreSkills]: Crouch Mod Enabled");
            }
        }

        public static ConfigEntry<float> BaseWeight;

        public static ConfigEntry<float> BaseMaxWeight;

        public static ConfigEntry<float> BaseHealth;

        public static ConfigEntry<float> BaseMaxHealth;

        public static ConfigEntry<float> BaseCrouchSpeed;

        public static ConfigEntry<float> BaseMaxCrouchSpeed;

        public static ConfigEntry<float> StrengthSkillIncreaseWhenEncumbred;

        public static ConfigEntry<float> StrengthSkillIncreaseWhenHalfnMoving;

        public static ConfigEntry<float> StrengthSkillIncreaseWhenHalfnRunning;

        public static ConfigEntry<bool> EnableWeightMod;

        public static ConfigEntry<bool> EnableHealthMod;

        public static ConfigEntry<bool> EnableCrouchMod;

        public static Dictionary<string, Texture2D> cachedTextures = new Dictionary<string, Texture2D>();

        public const int StrengthSkill_Type = 700;

        public const int VitalitySkill_Type = 701;
    }
}
