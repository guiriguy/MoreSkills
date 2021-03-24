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
    [BepInPlugin("com.GuiriGuy.MoreSkills", "MoreSkills", "0.1.1")]
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
            MoreSkills_Config.StrengthSkillIncreaseMultiplier = base.Config.Bind<float>("MoreSkills: Strength", "Strength Skill Increase Multiplier", 1.0f, "Change the skill increase Multiplier, based on the Weight you are carrying 1/400000 when Encumbred, 1/800000 when HalfWeight and Running and 1/1200000 when Halfweight and Moving.");

            //Vitality.Health
            MoreSkills_Config.EnableHealthMod = base.Config.Bind<bool>("MoreSkills: Vitality", "Enable Vitality Mod", true, "Enables or disables the Vitality Modification.");
            MoreSkills_Config.BaseHealth = base.Config.Bind<float>("MoreSkills: Vitality", "Base Health", 25f, "Change the base Health. (Valheim Default is 25)");
            MoreSkills_Config.BaseMaxHealth = base.Config.Bind<float>("MoreSkills: Vitality", "Base Max Health", 100f, "Change the toal Health when Vitality is at level 100. (Valheim Default is 25)");

            //Vitality.Increase
            MoreSkills_Config.VitalitySkillIncreaseMultiplier = base.Config.Bind<float>("MoreSkills: Vitality", "Multiply the Vitality Skill Increase per Damage", 1.0f, "The Skill Increase is based in the Damaged recieved 1/100, so if you recieve 100 damage you increase the skill by 1. This allows you to multiply this number.");

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
            MoreSkills_Config.BaseDSideways = base.Config.Bind<float>("MoreSkills: Sailing", "Base Damping Sideways", 0.3f, "Changes the Base Damping Sideways, at higher values te boat moves sideways more. Making it dangerous when Sailing at low levels in a storm.");
            MoreSkills_Config.BaseMaxDSideways = base.Config.Bind<float>("MoreSkills: Sailing", "Max Damping Sideways", 0.075f, "Changes the Max Damping Sideways when Sailing is at Level 100.");

            //Sailing.Increase
            MoreSkills_Config.SailingSkillIncreaseMultiplier = base.Config.Bind<float>("MoreSkills: Sailing", "Multiply the Sailing Skill Increase", 1.0f, "The Skill Increase is bases in the Speed of the Ship 1/2000. CrewMates sitiing in the ship 1/4000 and Crewmates standing 1/8000");

            //Crafting.ResourceChanges
            MoreSkills_Config.EnableCraftingSkill = base.Config.Bind<bool>("MoreSkills: Crafting", "Enable Crafting Mod", true, "Enables or disables the Crafting Resources Modification");
            MoreSkills_Config.EnableHigherDifficultyCrafting = base.Config.Bind<bool>("MoreSkills: Crafting", "Enable Higher Difficulty in Crafting Mod", false, "Enables or disables the higher difficulty in the Crafting Resources Modification. Making it more expensive to craft at the begging so there is a better increase of the skill");
            MoreSkills_Config.CraftingHigherLevelMultiplier = base.Config.Bind<float>("MoreSkills: Crafting", "Change the Difficulty in the High Levels Crafting Mod", 5f, "This is for the Higher levels Crafting Mod, so higher the number the higher is the difficulty at the begging and easier at the end. DON'T GO HIGHER THAN 10 or you might just brake it haha");
            MoreSkills_Config.CraftingNormalLevel25 = base.Config.Bind<int>("MoreSkills: Crafting", "Number to at level 25 of Crafting Skill", 2, "The number into you divide the amount of resources needed at Crafting Skill Level 25");
            MoreSkills_Config.CraftingNormalLevel50 = base.Config.Bind<int>("MoreSkills: Crafting", "Number to at level 50 of Crafting Skill", 3, "The number into you divide the amount of resources needed at Crafting Skill Level 50"); ;
            MoreSkills_Config.CraftingNormalLevel75 = base.Config.Bind<int>("MoreSkills: Crafting", "Number to divide at level 75 of Crafting Skill", 4, "The number into you divide the amount of resources needed at Crafting Skill Level 75"); ;
            MoreSkills_Config.CraftingNormalLevel100 = base.Config.Bind<int>("MoreSkills: Crafting", "Number to divide at level 100 of Crafting Skill", 5, "The number into you divide the amount of resources needed at Crafting Skill Level 100"); ;

            //Crafting.SkillIncrease
            MoreSkills_Config.CraftingSkillIncreaseMultiplier = base.Config.Bind<float>("MoreSkills: Crafting", "Multiply the Crafting Skill Increase", 5, "Multiplies the Crafting Skill Increase that takes into count all the amount of resources used to craft the object");

            //Sneak.CrouchSpeed Changable to Hunting
            MoreSkills_Config.EnableCrouchMod = base.Config.Bind<bool>("MoreSkills: Sneak", "Enable Crouch Speed Mod", true, "Enables or disables the Crouch Speed Modification");
            MoreSkills_Config.BaseCrouchSpeed = base.Config.Bind<float>("MoreSkills: Sneak", "Base Crouch Speed", 2f, "Change the base Crouch Speed. (Valheim Default is 2)");
            MoreSkills_Config.BaseMaxCrouchSpeed = base.Config.Bind<float>("MoreSkills: Sneak", "Base Max Crouch Speed", 6f, "Change the base Max Crouch Speed at level 100. (Valheim Default is 2)");

            //Swim.SwimSpeed
            MoreSkills_Config.EnableSwimMod = base.Config.Bind<bool>("MoreSkills: Swim", "Enable Swim Speed Mod", true, "Enables or disables the Swim Speed Modification");
            MoreSkills_Config.BaseSwimSpeed = base.Config.Bind<float>("MoreSkills: Swim", "Base Swim Speed", 2f, "Change the base Swim Speed (Valheim Defailt is 2)");
            MoreSkills_Config.BaseMaxSwimSpeed = base.Config.Bind<float>("MoreSkills: Swim", "Base Max Swim Speed", 4f, "Change the base Max Swim Speed at level 100. (Valheim Default is 2)");

            //Pickaxe.Mod
            MoreSkills_Config.EnablePickaxeDropMod = base.Config.Bind<bool>("MoreSkills: Pickaxe", "Enable Pickaxe Drop Mod", true, "Enables or disables the Pickaxe Drops Modification");
            MoreSkills_Config.EnablePickaxeChanceMod = base.Config.Bind<bool>("MoreSkills: Pickaxe", "Enable Pickaxe MudPile Chance Mod", true, "DROP MOD NEEDS TO BE TRUE. Enables or disables the Pickaxe Chances Modification");
            MoreSkills_Config.PickaxeMultiplier = base.Config.Bind<int>("MoreSkills: Pickaxe", "Multiplier based on level Pickaxe", 1, "The based on level multipliers is on the max level. At level 100 you got x10 times the amount of min and max than vanilla. This multiplier changes that number.");

            //Inject.Strength
            SkillInjector.RegisterNewSkill(700, "Strength", "Able to carry more and with higher numbers", 1f, SkillIcons.Load_StrengthIcon(), Skills.SkillType.Unarmed);
            SkillInjector.RegisterNewSkill(701, "Vitality", "Endure and gain resistance as you recieve damage", 1f, SkillIcons.Load_VitalityIcon(), Skills.SkillType.Unarmed);
            SkillInjector.RegisterNewSkill(702, "Sailing", "You become a true viking with a great control of the boat in your adventures through seas", 1f, SkillIcons.Load_SailingIcon(), Skills.SkillType.Unarmed);
            SkillInjector.RegisterNewSkill(703, "Crafting", "You get better at this thing of crafting. You can probably even become more efficient...", 1f, SkillIcons.Load_CraftingIcon(), Skills.SkillType.Unarmed);

            //AllRocks.PickaxeMod
                //Rock
                MoreSkills_Config.BaseMinRock = base.Config.Bind<int>("MoreSkills: zRocks", "Min Drop of Rocks", 3);
                MoreSkills_Config.BaseMaxRock = base.Config.Bind<int>("MoreSkills: zRocks", "Max Drop of Rocks", 6);
                //Big Rock
                MoreSkills_Config.BaseMinBigRock = base.Config.Bind<int>("MoreSkills: zBigRocks", "Min Drop of Big Rocks", 4);
                MoreSkills_Config.BaseMaxBigRock = base.Config.Bind<int>("MoreSkills: zBigRocks", "Max Drop of Big Rocks", 8);
            //Copper Vein
                MoreSkills_Config.BaseMinCopperVein = base.Config.Bind<int>("MoreSkills: zCopperVein", "Min Drop of Copper Veins", 2);
                MoreSkills_Config.BaseMaxCopperVein = base.Config.Bind<int>("MoreSkills: zCopperVein", "Max Drop of Copper Veins", 4);
            //Mudpile (Iron)
                MoreSkills_Config.BaseMinMudPile = base.Config.Bind<int>("MoreSkills: zMudPile", "Min Drop of Mud Piles (Iron)", 1);
                MoreSkills_Config.BaseMaxMudPile = base.Config.Bind<int>("MoreSkills: zMudPile", "Max Drop of Mud Piles (Iron)", 1);
                MoreSkills_Config.BaseChanceMudPile = base.Config.Bind<float>("Moreskills: zMudPile", "Chance of Mud Piles (Iron)", 0.3f);
            //Silver Vein
                MoreSkills_Config.BaseMinSilverVein = base.Config.Bind<int>("MoreSkills: zSilverVein", "Min Drop of Silver Vein", 2);
                MoreSkills_Config.BaseMaxSilverVein = base.Config.Bind<int>("MoreSkills: zSilverVein", "Max Drop of Silver Vein", 3);

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
            {
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
            if (!MoreSkills_Config.EnableCraftingSkill.Value)
                Debug.LogWarning("[MoreSkills]: Crafting Mod Disabled");
            else
            {
                Debug.LogWarning("[MoreSkills]: Crafting Mod Enabled");
                if (!MoreSkills_Config.EnableHigherDifficultyCrafting.Value)
                    Debug.LogWarning("[MoreSkills]: Higher Difficulty Crafting Mod Disabled");
                else
                    Debug.LogWarning("[MoreSkills]: Higher Difficulty Crafting Mod Enabled");
            }
            if (!MoreSkills_Config.EnablePickaxeDropMod.Value)
                Debug.LogWarning("[MoreSkills]: Pickaxe Drop Mod Disabled");
            else
                Debug.LogWarning("[MoreSkills]: Pickaxe Drop Mod Enabled");
            if (!MoreSkills_Config.EnablePickaxeChanceMod.Value)
                Debug.LogWarning("[MoreSkills]: Pickaxe MudPile Chance Mod Disabled");
            else
                Debug.LogWarning("[MoreSkills]: Pickaxe MudPile Chance Mod Enabled");
        }
            
        // Stats Bases

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

        public static ConfigEntry<float> BaseDSideways;

        public static ConfigEntry<float> BaseMaxDSideways;

        //Multipliers

        public static ConfigEntry<int> PickaxeMultiplier;

        public static ConfigEntry<float> CraftingHigherLevelMultiplier;

        public static ConfigEntry<int> CraftingNormalLevel25;

        public static ConfigEntry<int> CraftingNormalLevel50;

        public static ConfigEntry<int> CraftingNormalLevel75;

        public static ConfigEntry<int> CraftingNormalLevel100;

        //Skill Increases Multpliers

        public static ConfigEntry<float> StrengthSkillIncreaseMultiplier;

        public static ConfigEntry<float> VitalitySkillIncreaseMultiplier;

        public static ConfigEntry<float> SailingSkillIncreaseMultiplier;

        public static ConfigEntry<float> CraftingSkillIncreaseMultiplier;

        //Enables

        public static ConfigEntry<bool> EnableWeightMod;

        public static ConfigEntry<bool> EnableHealthMod;

        public static ConfigEntry<bool> EnableCrouchMod;

        public static ConfigEntry<bool> EnableSwimMod;

        public static ConfigEntry<bool> EnableSailingMod;

        public static ConfigEntry<bool> EnableShipAcceleration;

        public static ConfigEntry<bool> EnableShipCrew;

        public static ConfigEntry<bool> EnableCraftingSkill;

        public static ConfigEntry<bool> EnableHigherDifficultyCrafting;

        public static ConfigEntry<bool> EnablePickaxeDropMod;

        public static ConfigEntry<bool> EnablePickaxeChanceMod;

        //Test

        public static Dictionary<string, Texture2D> cachedTextures = new Dictionary<string, Texture2D>();

        //Skills Types

        public const int StrengthSkill_Type = 700;

        public const int VitalitySkill_Type = 701;

        public const int SailingSkill_Type = 702;

        public const int CraftingSkill_Type = 703;

        //Rocks Bases

        public static ConfigEntry<int> BaseMinRock;

        public static ConfigEntry<int> BaseMaxRock;

        public static ConfigEntry<int> BaseMinBigRock;

        public static ConfigEntry<int> BaseMaxBigRock;

        public static ConfigEntry<int> BaseMinCopperVein;

        public static ConfigEntry<int> BaseMaxCopperVein;

        public static ConfigEntry<int> BaseMinMudPile;

        public static ConfigEntry<int> BaseMaxMudPile;

        public static ConfigEntry<int> BaseMinSilverVein;

        public static ConfigEntry<int> BaseMaxSilverVein;

        //Rocks Chances

        public static ConfigEntry<float> BaseChanceMudPile;
    }
}
