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

            //Vitality.Increase
            MoreSkills_Config.VitalitySkillIncreaseMultiplier = base.Config.Bind<float>("MoreSkills: Vitality", "Multiply the Skill Increase per Damage", 1.0f, "The Skill Increase is based in the Damaged recieved 1/100, so if you recieve 100 damage you increase the skill by 1. This allows you to multiply this number.");

            //Sailing.SpeedsAndControls
            MoreSkills_Config.EnableSailingMod = base.Config.Bind<bool>("MoreSkills: Sailing", "Enable Sailing Mod", true, "Enables or disables the Sailing Modification");
            MoreSkills_Config.EnableShipAcceleration = base.Config.Bind<bool>("MoreSkills: Sailing", "Enable Acceleration Mod", true, "Enables or disables Acceleration to the Ship");
            MoreSkills_Config.EnableShipCrew = base.Config.Bind<bool>("MoreSkills: Sailing", "Enable Ship Crew Mod", true, "Enables or disable the speed affect per player in the Ship");
            MoreSkills_Config.BaseBForce = base.Config.Bind<float>("MoreSkills: Sailing", "Base BackwardForce", 0.1f, "Changes the force when using the rudder, the higher the faster is the rudder");
            MoreSkills_Config.BaseMaxBForce = base.Config.Bind<float>("MoreSkills: Sailing", "Base Max BackwardForce", 0.5f, "Changes the Max force when Sailing is at level 100");
            MoreSkills_Config.CrewMembersBForceAdd = base.Config.Bind<float>("MoreSkills: Sailing", "Ammount of Add Up Per Crewmate", 1f, "Uses the Sailing Skill Level to calculate how does each player affect the BackForce when they are on-board of the ship. So if you are at level 100 and you have one more crewmate instead of having Default 0.5 Force you would have 0.6 Force");
            MoreSkills_Config.BaseRSpeed = base.Config.Bind<float>("MoreSkills: Sailing", "Base Rudder Speed", 0.5f, "Changes the Speed of the Rudder to reach the max turning");
            MoreSkills_Config.BaseMaxRSpeed = base.Config.Bind<float>("MoreSkills: Sailing", "Max Rudder Speed", 1.5f, "Changes the Max Speed of the Rudder to reach the max turning when Sailing is at Level 100.");
            MoreSkills_Config.BaseSForce = base.Config.Bind<float>("MoreSkills: Sailing", "Base Sail Force", 0.025f, "Changes the Base Sail Force, incresing it increases the speed with the Sail Down");
            MoreSkills_Config.BaseMaxSForce = base.Config.Bind<float>("MoreSkills: Sailing", "Max Sail Force", 0.5f, "Changes the Max Sail Force when Sailing is at Level 100.");
            MoreSkills_Config.BaseAngDamping = base.Config.Bind<float>("MoreSkills: Sailing", "Base Angle Damping", 0.6f, "Changes the Base Angle Damping, I believe that it affects the control of the boat, making it more dificult at higher values to turn and control");
            MoreSkills_Config.BaseMaxAngDamping = base.Config.Bind<float>("MoreSkills: Sailing", "Max Angle Damping", 0.15f, "Changes the Max Angle Damping when Sailing is at Level 100.");
            MoreSkills_Config.BaseDSideways = base.Config.Bind<float>("MoreSkills: Sailing", "Base Damping Sideways", 0.3f, "Changes the Base Damping Sideways, at higher values te boat moves sideways more. Making it dangerous when Sailing at low levels in a storm.");
            MoreSkills_Config.BaseMaxDSideways = base.Config.Bind<float>("MoreSkills: Sailing", "Max Damping Sideways", 0.075f, "Changes the Max Damping Sideways when Sailing is at Level 100.");

            //Sailing.Increase
            MoreSkills_Config.SailingSkillIncreaseMultiplier = base.Config.Bind<float>("MoreSkills: Sailing", "Multiply the Skill Increase", 1.0f, "The Skill Increase is bases in the Speed of the Ship 1/2000. CrewMates sitiing in the ship 1/4000 and Crewmates standing 1/8000");

            //Sneak.CrouchSpeed Changable to Hunting
            MoreSkills_Config.EnableCrouchMod = base.Config.Bind<bool>("MoreSkills: Sneak", "Enable Crouch Speed Mod", true, "Enables or disables the Crouch Speed Modification");
            MoreSkills_Config.BaseCrouchSpeed = base.Config.Bind<float>("MoreSkills: Sneak", "Base Crouch Speed", 2f, "Change the base Crouch Speed. (Valheim Default is 2)");
            MoreSkills_Config.BaseMaxCrouchSpeed = base.Config.Bind<float>("MoreSkills: Sneak", "Base Max Crouch Speed", 6f, "Change the base Max Crouch Speed at level 100. (Valheim Default is 2)");

            //Swim.SwimSpeed
            MoreSkills_Config.EnableSwimMod = base.Config.Bind<bool>("MoreSkills: Swim", "Enable Swim Speed Mod", true, "Enables or disables the Swim Speed Modification");
            MoreSkills_Config.BaseSwimSpeed = base.Config.Bind<float>("MoreSkills: Swim", "Base Swim Speed", 2f, "Change the base Swim Speed (Valheim Defailt is 2)");
            MoreSkills_Config.BaseMaxSwimSpeed = base.Config.Bind<float>("MoreSkills: Swim", "Base Max Swim Speed", 4f, "Change the base Max Swim Speed at level 100. (Valheim Default is 2)");

            //Inject.Strength
            SkillInjector.RegisterNewSkill(700, "Strength", "Able to carry more and with higher numbers", 1f, SkillIcons.Load_StrengthIcon(), Skills.SkillType.Unarmed);
            SkillInjector.RegisterNewSkill(701, "Vitality", "Endure and gain resistance as you recieve damage", 1f, SkillIcons.Load_VitalityIcon(), Skills.SkillType.Unarmed);
            SkillInjector.RegisterNewSkill(702, "Sailing", "You become a true viking with a great control of the boat in your adventures through seas", 1f, SkillIcons.Load_SailingIcon(), Skills.SkillType.Unarmed);

            //--
            new Harmony("com.guiriguy.moreskills").PatchAll();

            //Logs
            if (!MoreSkills_Config.EnableWeightMod.Value)
                Debug.LogWarning("[MoreSkills]: Weight Mod Disabled");
            else
                Debug.LogWarning("[MoreSkills]: Weight Mod Enabled");
            if (!MoreSkills_Config.EnableHealthMod.Value)
                Debug.LogWarning("[MoreSkills]: Health Mod Disabled");
            else
                Debug.LogWarning("[MoreSkills]: Health Mod Enabled");
            if (!MoreSkills_Config.EnableCrouchMod.Value)
                Debug.LogWarning("[MoreSkills]: Crouch Mod Disabled");
            else
                Debug.LogWarning("[MoreSkills]: Crouch Mod Enabled");
            if (!MoreSkills_Config.EnableSwimMod.Value)
                Debug.LogWarning("[MoreSkills]: Swim Mod Disabled");
            else
                Debug.LogWarning("[MoreSkills]: Swim Mod Enabled");
            if (!MoreSkills_Config.EnableSailingMod.Value)
                Debug.LogWarning("[MoreSkills]: Sailing Mod Disabled");
            else
                Debug.LogWarning("[MoreSkills]: Sailing Mod Enabled");
            if (!MoreSkills_Config.EnableShipAcceleration.Value)
                Debug.LogWarning("[MoreSkills]: Sailing/Ship Acceleration Mod Disabled");
            else
                Debug.LogWarning("[MoreSkills]: Sailing/Ship Acceleration Mod Enabled");
            if (!MoreSkills_Config.EnableShipCrew.Value)
                Debug.LogWarning("[MoreSkills]: Sailing/CrewMates Mod Disabled");
            else
                Debug.LogWarning("[MoreSkills]: Sailing/CrewMates Mod Enabled");
        }

        public static ConfigEntry<float> BaseWeight;

        public static ConfigEntry<float> BaseMaxWeight;

        public static ConfigEntry<float> BaseHealth;

        public static ConfigEntry<float> BaseMaxHealth;

        public static ConfigEntry<float> BaseCrouchSpeed;

        public static ConfigEntry<float> BaseMaxCrouchSpeed;

        public static ConfigEntry<float> BaseSwimSpeed;

        public static ConfigEntry<float> BaseMaxSwimSpeed;

        public static ConfigEntry<float> BaseBForce;

        public static ConfigEntry<float> BaseMaxBForce;

        public static ConfigEntry<float> CrewMembersBForceAdd;

        public static ConfigEntry<float> BaseRSpeed;

        public static ConfigEntry<float> BaseMaxRSpeed;

        public static ConfigEntry<float> BaseSForce;

        public static ConfigEntry<float> BaseMaxSForce;

        public static ConfigEntry<float> BaseAngDamping;

        public static ConfigEntry<float> BaseMaxAngDamping;

        public static ConfigEntry<float> BaseDSideways;

        public static ConfigEntry<float> BaseMaxDSideways;

        public static ConfigEntry<float> StrengthSkillIncreaseWhenEncumbred;

        public static ConfigEntry<float> StrengthSkillIncreaseWhenHalfnMoving;

        public static ConfigEntry<float> StrengthSkillIncreaseWhenHalfnRunning;

        public static ConfigEntry<float> VitalitySkillIncreaseMultiplier;

        public static ConfigEntry<float> SailingSkillIncreaseMultiplier;

        public static ConfigEntry<bool> EnableWeightMod;

        public static ConfigEntry<bool> EnableHealthMod;

        public static ConfigEntry<bool> EnableCrouchMod;

        public static ConfigEntry<bool> EnableSwimMod;

        public static ConfigEntry<bool> EnableSailingMod;

        public static ConfigEntry<bool> EnableShipAcceleration;

        public static ConfigEntry<bool> EnableShipCrew;

        public static Dictionary<string, Texture2D> cachedTextures = new Dictionary<string, Texture2D>();

        public const int StrengthSkill_Type = 700;

        public const int VitalitySkill_Type = 701;

        public const int SailingSkill_Type = 702;
    }
}
