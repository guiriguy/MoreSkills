using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace MoreSkills.Config
{
    [BepInPlugin("MoreSkills.OverhaulsConfig", "MoreSkills: Overhauls", "0.0.4")]
    [BepInDependency("com.pipakin.SkillInjectorMod")]
    public class MoreSkills_OverhaulsConfig : BaseUnityPlugin
    {
        public void Awake()
        {
            Debug.Log("Loading All Overhauls...");
            //Enablers
            //Sneak.CrouchSpeed
            EnableCrouchMod = base.Config.Bind<bool>("1. Enablers: Sneak", "Enable Crouch Speed Mod", true, "Enables or disables the Crouch Speed Modification");
            //Swim.Mod
            EnableSwimMod = base.Config.Bind<bool>("1. Enablers: Swim", "Enable Swim Mods", true, "Enables or disables the Complete Swim Modification");
            //Swim.Speed
            EnableSwimSpeedMod = base.Config.Bind<bool>("1. Enablers: Swim", "Enable Swim Speed Mod", true, "Enables or disables the Swim Speed Modification");
            //Swim.Stamina
            EnableSwimStaminaMod = base.Config.Bind<bool>("1. Enablers: Swim", "Enable Swim Stamina Mod", true, "Enables or disables the Swim Stamina Modification");
            //Pickaxe.Mod
            EnablePickaxeDropMod = base.Config.Bind<bool>("1. Enablers: Pickaxe", "Enable Pickaxe Drop Mod", true, "Enables or disables the Pickaxe Drops Modification");
            //WoodCutting.Mod
            EnableWoodCuttingDropMod = base.Config.Bind<bool>("1. Enablers: WoodCutting", "Enable WoodCutting Drop Mod", true, "Enables or disables the WoodCutting Drops Modification");
            //Jumping
            EnableJumpMod = base.Config.Bind<bool>("1. Enablers: Jump", "Enable Jump Mods", true, "Enables or disables the Jumping Modifications");
            //FallDamage
            EnableDecreaseFallDamageMod = base.Config.Bind<bool>("1. Enablers: Jump", "Enable Fall Damage Mods", true, "Enables or disables the Jumping Fall Damage Modifications");
            //RollonFall
            EnableRollOnFall = base.Config.Bind<bool>("1. Enablers: Jump", "Enable Roll on Fall Mod", true, "Enables or disables the Roll on Fall Modification");
            //HigherJump
            EnableHigherJump = base.Config.Bind<bool>("1. Enablers: Jump", "Enable Higher Jump Mod", true, "Enables or disables the Higher Jump Modification");
            //HaveToShift
            EnableHaveToShiftToHigherJump = base.Config.Bind<bool>("1. Enablers: Jump", "Enable Need to Shift for Higher Jump Mod", true, "Enables or disables Need to Shift (or custom key) to make a Higher Jump Modification");
            //Multipliers
            //Swim
            //Stamina
            SwimStaminaMultiplier = base.Config.Bind<float>("2. Multipliers: Swim", "Multiply the Swim Stamina Increase", 1.0f, "Multiply the amount of stamina you gain staying still in the water.");
            //Pickaxe
            PickaxeMultiplier = base.Config.Bind<float>("2. Multipliers: Pickaxe", "Multiplier based on Pickaxe Skill", 1.5f, "The based on level multipliers, so at level 100 you reach such number. At level 100 you got default x1.5 times the amount of drops than vanilla. This multiplier changes that number.");
            //WoodCutting
            //Drops
            WoodCuttingMultiplier = base.Config.Bind<float>("2. Multipliers: WoodCutting", "Multiplier based on WoodCutting Skill", 1.5f, "The based on level multipliers, so at level 100 you reach such number. At level 100 you got default x1.5 times the amount of drops than vanilla. This multiplier changes that number.");
            //Jumping
            FallDamageDecrease = base.Config.Bind<float>("2. Multipliers: Jump", "Deacrease Multiplier based on Jumping Skill", 2.0f, "Decreases the Damage Recieved by Falling from a High Altitude (4 meters)");
            //Base Configs
            //Sneak
            BaseCrouchSpeed = base.Config.Bind<float>("3. BaseConfigs: Sneak", "Base Crouch Speed", 2f, "Change the base Crouch Speed. (Valheim Default is 2)");
            BaseMaxCrouchSpeed = base.Config.Bind<float>("3. BaseConfigs: Sneak", "Base Max Crouch Speed", 4f, "Change the base Max Crouch Speed at level 100. (Valheim Default is 2)");
            //Swim
            //Speed
            BaseSwimSpeed = base.Config.Bind<float>("3. BaseConfigs: Swim", "Base Swim Speed", 2f, "Change the base Swim Speed (Valheim Defailt is 2)");
            BaseMaxSwimSpeed = base.Config.Bind<float>("3. BaseConfigs: Swim", "Base Max Swim Speed", 4f, "Change the base Max Swim Speed at level 100. (Valheim Default is 2)");
            //Jump
            //Heights and Key
            BaseJumpForce = base.Config.Bind<float>("3. BaseConfigs: Jump", "Base Jump Force", 8f, "Change the base Jump Force (Valheim Defailt is 8)");
            BaseMaxJumpForce = base.Config.Bind<float>("3. BaseConfigs: Jump", "Base Max Jump Force", 12f, "Change the base Max Jump Force at level 100. (Valheim Default is 8)");
            HigherJumpKey = base.Config.Bind<KeyCode>("3. BaseConfigs: Jump", "Base Higher Jump Key Force", KeyCode.LeftShift, "Change the button to hold when wanted a Higher Jump. Keys: https://docs.unity3d.com/Manual/class-InputManager.html");

            //--
            new Harmony("MoreSkills.OverhaulsConfig.GuiriGuyMods");

            //Logs
            if (!EnableCrouchMod.Value)
                Debug.LogWarning("[MoreSkills]: Crouch Mod Disabled");
            else
                Debug.Log("[MoreSkills]: Crouch Mod Enabled");
            if (!EnableSwimMod.Value)
                Debug.LogWarning("[MoreSkills]: Swim Mod Disabled");
            else
            {
                Debug.Log("[MoreSkills]: Swim Mod Enabled");
                if (!EnableSwimSpeedMod.Value)
                    Debug.LogWarning("[MoreSkills]: Swim/Speed Mod Disabled");
                else
                    Debug.Log("[MoreSkills]: Swim/Speed Mod Enabled");
                if (!EnableSwimStaminaMod.Value)
                    Debug.LogWarning("[MoreSkills]: Swim/Stamina Mod Disabled");
                else
                    Debug.Log("[MoreSkills]: Swim/Stamina Mod Enabled");
            }
            if (!EnablePickaxeDropMod.Value)
                Debug.LogWarning("[MoreSkills]: Pickaxe Drop Mod Disabled");
            else
                Debug.Log("[MoreSkills]: Pickaxe Drop Mod Enabled");

            if (!EnableWoodCuttingDropMod.Value)
                Debug.LogWarning("[MoreSkills]: WoodCutting Drop Mod Disabled");
            else
                Debug.Log("[MoreSkills]: WoodCutting Drop Mod Enabled");

            if (!EnableJumpMod.Value)
                Debug.LogWarning("[MoreSkills]: Jump Mod Disabled");
            else
            {
                Debug.Log("[MoreSkills]: Jump Mod Enabled");
                if (!EnableHigherJump.Value)
                    Debug.LogWarning("[MoreSkills]: Jump/Higher Mod Disabled");
                else
                    Debug.Log("[MoreSkills]: Jump/Higher Mod Enabled");
                if (!EnableDecreaseFallDamageMod.Value)
                    Debug.LogWarning("[MoreSkills]: Jump/Decreased Fall Damage Mod Disabled");
                else
                    Debug.Log("[MoreSkills]: Jump/Decreased Fall Damage Mod Enabled");
                if (!EnableHaveToShiftToHigherJump.Value)
                    Debug.LogWarning("[MoreSkills]: Jump/Need to Shift for Higher Jump Mod Disabled");
                else
                    Debug.Log("[MoreSkills]: Jump/Need to Shift for Higher Jump Mod Enabled");
                if (!EnableRollOnFall.Value)
                    Debug.LogWarning("[MoreSkills]: Jump/Roll On Fall Mod Disabled");
                else
                    Debug.Log("[MoreSkills]: Jump/Roll On Fall Mod Enabled");

            }

            Debug.Log("All Overhauls Loaded!");
        }

        // Stats Bases

        public static ConfigEntry<float> BaseCrouchSpeed;

        public static ConfigEntry<float> BaseMaxCrouchSpeed;

        public static ConfigEntry<float> BaseSwimSpeed;

        public static ConfigEntry<float> BaseMaxSwimSpeed;

        public static ConfigEntry<float> BaseJumpForce;

        public static ConfigEntry<float> BaseMaxJumpForce;

        //Multipliers

        public static ConfigEntry<float> PickaxeMultiplier;

        public static ConfigEntry<float> SwimStaminaMultiplier;

        public static ConfigEntry<float> WoodCuttingMultiplier;

        public static ConfigEntry<float> FallDamageDecrease;

        //Enables

        public static ConfigEntry<bool> EnableCrouchMod;

        public static ConfigEntry<bool> EnableSwimMod;

        public static ConfigEntry<bool> EnablePickaxeDropMod;

        public static ConfigEntry<bool> EnablePickaxeChanceMod;

        public static ConfigEntry<bool> EnableSwimSpeedMod;

        public static ConfigEntry<bool> EnableSwimStaminaMod;

        public static ConfigEntry<bool> EnableWoodCuttingDropMod;

        public static ConfigEntry<bool> EnableJumpMod;

        public static ConfigEntry<bool> EnableDecreaseFallDamageMod;

        public static ConfigEntry<bool> EnableHigherJump;

        public static ConfigEntry<bool> EnableRollOnFall;

        public static ConfigEntry<bool> EnableHaveToShiftToHigherJump;

        public static ConfigEntry<KeyCode> HigherJumpKey;

    }
}