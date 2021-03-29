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
    [BepInPlugin("com.GuiriGuy.MoreSkills", "MoreSkills", "0.1.6")]
    [BepInDependency("com.pipakin.SkillInjectorMod")]
    public class MoreSkills_Config : BaseUnityPlugin
    {
        public void Awake()
        {
            //1. Enablers
                //Strength
                MoreSkills_Config.EnableStrengthMod = base.Config.Bind<bool>("1. Enablers: Strength", "Enable Strength Mod", true, "Enables or disables the Strength Modification.");
                    //Weight
                    MoreSkills_Config.EnableWeightMod = base.Config.Bind<bool>("1. Enablers: Strength", "Enable Weight Mod", true, "Enables or disables the Weight Modification.");                    
                    //Stamina
                    MoreSkills_Config.EnableStrengthStaminaMod = base.Config.Bind<bool>("1. Enablers: Strength", "Enable Weight Mod", true, "Enables or disables the Weight Modification.");
            //Vitality.Health
            MoreSkills_Config.EnableHealthMod = base.Config.Bind<bool>("1. Enablers: Vitality", "Enable Vitality Mod", true, "Enables or disables the Vitality Modification.");
                //Sailing
                MoreSkills_Config.EnableSailingMod = base.Config.Bind<bool>("1. Enablers: Sailing", "Enable Sailing Mod", true, "Enables or disables the Sailing Modification");
                    //Sailing.ShipAcceleration
                    MoreSkills_Config.EnableShipAcceleration = base.Config.Bind<bool>("1. Enablers: Sailing", "Enable Acceleration Mod", true, "Enables or disables Acceleration to the Ship");
                    //Sailing.CrewMod
                    MoreSkills_Config.EnableShipCrew = base.Config.Bind<bool>("1. Enablers: Sailing", "Enable Ship Crew Mod", true, "Enables or disable the speed affect per player in the Ship");
                //Crafting
                MoreSkills_Config.EnableCraftingSkill = base.Config.Bind<bool>("1. Enablers: Crafting", "Enable Crafting Mod", true, "Enables or disables the Crafting Resources Modification");
                //Sneak.CrouchSpeed
                MoreSkills_Config.EnableCrouchMod = base.Config.Bind<bool>("1. Enablers: Sneak", "Enable Crouch Speed Mod", true, "Enables or disables the Crouch Speed Modification");
                //Swim.Mod
                MoreSkills_Config.EnableSwimMod = base.Config.Bind<bool>("1. Enablers: Swim", "Enable Swim Mod", true, "Enables or disables the Complete Swim Modification");
                    //Swim.Speed
                    MoreSkills_Config.EnableSwimSpeedMod = base.Config.Bind<bool>("1. Enablers: Swim", "Enable Swim Speed Mod", true, "Enables or disables the Swim Speed Modification");
                    //Swim.Stamina
                    MoreSkills_Config.EnableSwimStaminaMod = base.Config.Bind<bool>("1. Enablers: Swim", "Enable Swim Stamina Mod", true, "Enables or disables the Swim Stamina Modification");
                //Pickaxe.Mod
                MoreSkills_Config.EnablePickaxeDropMod = base.Config.Bind<bool>("1. Enablers: Pickaxe", "Enable Pickaxe Drop Mod", true, "Enables or disables the Pickaxe Drops Modification");
                //Hunting
                MoreSkills_Config.EnableHuntingSkill = base.Config.Bind<bool>("1. Enablers: Hunting", "Enable Hunting Skill", true, "Enables or disables the Hunting Skill Modification");
                    //Normal Mobs
                    MoreSkills_Config.EnableHuntingNormalMobsMod = base.Config.Bind<bool>("1. Enablers: Hunting", "Enable Hunting Normal Mobs Mod", true, "Enables or disables the Hunting Skill Modification to Normal Mobs");
                    //Bosses
                    MoreSkills_Config.EnableHuntingBossMod = base.Config.Bind<bool>("1. Enablers: Hunting", "Enable Hunting Bosses Mod", false, "Enables or disables the Hunting Skill Modification affect to Bosses. RECOMMENDED FOR EPIC LOOTS");
                    //MinMax Mods
                    MoreSkills_Config.EnableHuntingMinMaxMod = base.Config.Bind<bool>("1. Enablers: Hunting", "Enable Hunting Min and Max Drop Mod", true, "Enables or disables the Hunting Skill Modification to all Enabled Mobs Min and Max Item Drops");
                    //Chance Mod
                    MoreSkills_Config.EnableHuntingChanceMod = base.Config.Bind<bool>("1. Enablers: Hunting", "Enable Hunting Chance Mod", true, "Enables or disables the Hunting Skill Modification to the Chances of Droping an Item");
                    //Trophy Mods
                    MoreSkills_Config.EnableHuntingTrophyMod = base.Config.Bind<bool>("1. Enablers: Hunting", "Enable Hunting Trophy Mod", false, "Enables or disables the Hunting Skill Modification to affect Trophies. RECOMMENDED FOR EPIC LOOTS");
                    //Blob Affect
                    MoreSkills_Config.EnableHuntingBlobSpawn = base.Config.Bind<bool>("1. Enablers: Hunting", "Enable Hunting Blob Spawn Mod", false, "Enables or disables the Hunting Skill Modification to affect Blobs to count as ItemDrops from the Blob Elite");
                //WoodCutting.Mod
                MoreSkills_Config.EnableWoodCuttingDropMod = base.Config.Bind<bool>("1. Enablers: WoodCutting", "Enable WoodCutting Drop Mod", true, "Enables or disables the WoodCutting Drops Modification");

            //2. Multipliers
            //Strength
            //Skill
            MoreSkills_Config.StrengthSkillIncreaseMultiplier = base.Config.Bind<float>("2. Multipliers: Strength", "Strength Skill Increase Multiplier", 1.0f, "Change the skill increase Multiplier, based on the Weight you are carrying 1/400000 when Encumbred, 1/800000 when HalfWeight and Running and 1/1200000 when Halfweight and Moving.");
                    //Stamina 
                    MoreSkills_Config.StrengthStaminaMultiplier = base.Config.Bind<float>("2. Multipliers: Strength", "Strength Stamina Multiplier", 1.0f, "Change the stamina increase Multiplier, that you recieve when not moving Encumbred"); 
                //Vitality
                MoreSkills_Config.VitalitySkillIncreaseMultiplier = base.Config.Bind<float>("2. Multipliers: Vitality", "Multiply the Vitality Skill Increase per Damage", 5.0f, "The Skill Increase is based in the Damaged recieved 1/10, so if you recieve 100 damage you increase the skill by 1. This allows you to multiply this number.");
                //Sailing
                MoreSkills_Config.SailingSkillIncreaseMultiplier = base.Config.Bind<float>("2. Multipliers: Sailing", "Multiply the Sailing Skill Increase", 1.0f, "The Skill Increase is bases in the Speed of the Ship 1/2000. CrewMates sitiing in the ship 1/4000 and Crewmates standing 1/8000");
                //Swim
                    //Stamina
                    MoreSkills_Config.SwimStaminaMultiplier = base.Config.Bind<float>("2. Multipliers: Swim", "Multiply the Swim Stamina Increase", 1.0f, "Multiply the amount of stamina you gain staying still in the water.");
                //Crafting
                    //Skill
                    MoreSkills_Config.CraftingSkillIncreaseMultiplier = base.Config.Bind<float>("2. Multipliers: Crafting", "Multiply the Crafting Skill Increase", 1.0f, "Multiplies the Crafting Skill Increase that takes into count all the amount of resources used to craft the object");
                    //ResourceChanges
                    MoreSkills_Config.CraftingLevelMultiplier = base.Config.Bind<float>("2. Multipliers: Crafting", "Change the Starting Multiplier in Crafting Mod", 2f, "(If Middle Level is 0, this number will not be counted). This is the Level 0 Multiplier at which objects cost will be multiplied at the begging of the game until reached the level you marked at config to go back to vanilla.");
                    MoreSkills_Config.CraftingMiddleLevel = base.Config.Bind<int>("2. Multipliers: Crafting", "Set the Middle Level of the High Levels Crafting Mod", 50, "This is the level where it will stop Multipling and will start Dividing the cost of objects. Can be set to 100 and never have a divider. Or 0 if you dont want any Multipliers at the start of a game.");
                    MoreSkills_Config.CraftingLevelDivider = base.Config.Bind<float>("2. Multipliers: Crafting", "Change the Ending Multiplier in the Crafting Mod", 2f, "(If Middle Level is 100, this number will not be counted). This is the Level 100 Divider at which objects cost will be divided at the end of the game once you reached the level you marked at config.");
                //Pickaxe
                MoreSkills_Config.PickaxeMultiplier = base.Config.Bind<float>("2. Multipliers: Pickaxe", "Multiplier based on level Pickaxe", 3.0f, "The based on level multipliers, so at level 100 you reach such number. At level 100 you got default x3 times the amount of drops than vanilla. This multiplier changes that number.");
                //Hunting
                    //Skill
                    MoreSkills_Config.HuntingSkillMultiplier = base.Config.Bind<float>("2. Multipliers: Hunting", "Multiplies the Hunting Skill Increase", 1.0f, "The Skill Increase is based on the max Health of the Mob 1/10, so if the mob is killed and had a max health of 500 you get 50 (If you level up, it will only level you up and loose the rest of exp, to yet be fixed). This allows you to multiply this number.");
                    //Drops
                    MoreSkills_Config.HuntingDropMultiplier = base.Config.Bind<float>("2. Multipliers: Hunting", "Multiplies the Hunting Drops", 3.0f, "The based on level multipliers, so at level 100 you reach such number. At level 100 you recieve x3 at default to the amount of Drops from a Mob/Boss. This multiplier changes that number");
                //WoodCutting
                    //Drops
                    MoreSkills_Config.WoodCuttingMultiplier = base.Config.Bind<float>("2. Multipliers: WoodCutting", "Multiplier based on level Woodcutting", 3.0f, "The based on level multipliers, so at level 100 you reach such number. At level 100 you got default x3 times the amount of drops than vanilla. This multiplier changes that number.");

            //3. Base Configs
            //Strength
            MoreSkills_Config.BaseWeight = base.Config.Bind<float>("3. BaseConfigs: Strength", "Base Weight", 300f, "Change the base Weight. (Valheim Default is 300)");
                MoreSkills_Config.BaseMaxWeight = base.Config.Bind<float>("3. BaseConfigs: Strength", "Base Max Weight", 600f, "Change the total Weight when Strength is at level 100. (Valheim Default is 300)");
                //Vitality
                MoreSkills_Config.BaseHealth = base.Config.Bind<float>("3. BaseConfigs: Vitality", "Base Health", 25f, "Change the base Health. (Valheim Default is 25)");
                MoreSkills_Config.BaseMaxHealth = base.Config.Bind<float>("3. BaseConfigs: Vitality", "Base Max Health", 100f, "Change the toal Health when Vitality is at level 100. (Valheim Default is 25)");
                //Sailing
                MoreSkills_Config.BaseBForce = base.Config.Bind<float>("3. BaseConfigs: Sailing", "Base BackwardForce", 0.1f, "Changes the force when using the rudder, the higher the faster is the rudder");
                MoreSkills_Config.BaseMaxBForce = base.Config.Bind<float>("3. BaseConfigs: Sailing", "Base Max BackwardForce", 0.5f, "Changes the Max force when Sailing is at level 100");
                MoreSkills_Config.CrewMembersBForceAdd = base.Config.Bind<float>("3. BaseConfigs: Sailing", "Ammount of Add Up Per Crewmate", 1f, "Uses the Sailing Skill Level to calculate how does each player affect the BackForce when they are on-board of the ship. So if you are at level 100 and you have one more crewmate instead of having Default 0.5 Force you would have 0.6 Force");
                MoreSkills_Config.BaseRSpeed = base.Config.Bind<float>("3. BaseConfigs: Sailing", "Base Rudder Speed", 0.5f, "Changes the Speed of the Rudder to reach the max turning");
                MoreSkills_Config.BaseMaxRSpeed = base.Config.Bind<float>("3. BaseConfigs: Sailing", "Max Rudder Speed", 1.5f, "Changes the Max Speed of the Rudder to reach the max turning when Sailing is at Level 100.");
                MoreSkills_Config.BaseSForce = base.Config.Bind<float>("3. BaseConfigs: Sailing", "Base Sail Force", 0.025f, "Changes the Base Sail Force, incresing it increases the speed with the Sail Down");
                MoreSkills_Config.BaseMaxSForce = base.Config.Bind<float>("3. BaseConfigs: Sailing", "Max Sail Force", 0.5f, "Changes the Max Sail Force when Sailing is at Level 100.");
                MoreSkills_Config.BaseDSideways = base.Config.Bind<float>("3. BaseConfigs: Sailing", "Base Damping Sideways", 0.3f, "Changes the Base Damping Sideways, at higher values te boat moves sideways more. Making it dangerous when Sailing at low levels in a storm.");
                MoreSkills_Config.BaseMaxDSideways = base.Config.Bind<float>("3. BaseConfigs: Sailing", "Max Damping Sideways", 0.075f, "Changes the Max Damping Sideways when Sailing is at Level 100.");
                //Sneak
                MoreSkills_Config.BaseCrouchSpeed = base.Config.Bind<float>("3. BaseConfigs: Sneak", "Base Crouch Speed", 2f, "Change the base Crouch Speed. (Valheim Default is 2)");
                MoreSkills_Config.BaseMaxCrouchSpeed = base.Config.Bind<float>("3. BaseConfigs: Sneak", "Base Max Crouch Speed", 4f, "Change the base Max Crouch Speed at level 100. (Valheim Default is 2)");
                //Swim
                    //Speed
                    MoreSkills_Config.BaseSwimSpeed = base.Config.Bind<float>("3. BaseConfigs: Swim", "Base Swim Speed", 2f, "Change the base Swim Speed (Valheim Defailt is 2)");
                    MoreSkills_Config.BaseMaxSwimSpeed = base.Config.Bind<float>("3. BaseConfigs: Swim", "Base Max Swim Speed", 4f, "Change the base Max Swim Speed at level 100. (Valheim Default is 2)");

            //4. All Drops Configs
            //Minerals
            //Stone
            MoreSkills_Config.BaseStoneChance = base.Config.Bind<float>("4. BaseConfigs: Minerals", "Stone Base Chance", 1f);
            //CopperOre
            MoreSkills_Config.BaseCopperOreChance = base.Config.Bind<float>("4. BaseConfigs: Minerals", "Copper Ore Base Chance", 1f);
            //IronScrapOre
            MoreSkills_Config.BaseIronScrapChance = base.Config.Bind<float>("4. BaseConfigs: Minerals", "Iron Scrap Base Chance", 0.2f);
            //TinOre
            MoreSkills_Config.BaseTinOreChance = base.Config.Bind<float>("4. BaseConfigs: Minerals", "Tin Ore Base Chance", 1f);
            //SilverOre
            MoreSkills_Config.BaseSilverOreChance = base.Config.Bind<float>("4. BaseConfigs: Minerals", "Silver Ore Base Chance", 1f);
            //Obsidian
            MoreSkills_Config.BaseObsidianChance = base.Config.Bind<float>("4. BaseConfigs: Minerals", "Obsidian Base Chance", 1f);
            //Chitin
            MoreSkills_Config.BaseChitinChance = base.Config.Bind<float>("4. BaseConfigs: Minerals", "Chitin Base Chance", 1f);
            //Woods
            //Wood
            MoreSkills_Config.BaseWoodChance = base.Config.Bind<float>("4. BaseConfigs: Woods", "Wood Base Chance", 1f);
            //FineWood
            MoreSkills_Config.BaseFineWoodChance = base.Config.Bind<float>("4. BaseConfigs: Woods", "Fine Wood Base Chance", 1f);
            //RoundLog
            MoreSkills_Config.BaseRoundLogChance = base.Config.Bind<float>("4. BaseConfigs: Woods", "Round Log Base Chance", 1f);
            //BeechSeeds
            MoreSkills_Config.BaseBeechSeedChance = base.Config.Bind<float>("4. BaseConfigs: Woods", "Beech Seed Base Chance", 0.5f);
            //FirCone
            MoreSkills_Config.BaseFirConeChance = base.Config.Bind<float>("4. BaseConfigs: Woods", "Fir Cone Base Chance", 0.5f);
            //PineCone
            MoreSkills_Config.BasePineConeChance = base.Config.Bind<float>("4. BaseConfigs: Woods", "Pine Cone Base Chance", 0.5f);
            //ElderBark
            MoreSkills_Config.BaseElderBarkChance = base.Config.Bind<float>("4. BaseConfigs: Woods", "Elder Bark Base Chance", 1f);
            //Resin
            MoreSkills_Config.BaseResinChance = base.Config.Bind<float>("4. BaseConfigs: Woods", "Resin Base Chance", 0.5f);
            //Others
            //Feathers
            MoreSkills_Config.BaseFeathersChance = base.Config.Bind<float>("4. BaseConfigs: Others", "Feathers Base Chance", 1f);
            //Guck
            MoreSkills_Config.BaseGuckChance = base.Config.Bind<float>("4. BaseConfigs: Others", "Guck Base Chance", 1f);
            //LeatherScraps
            MoreSkills_Config.BaseLeatherScrapsChance = base.Config.Bind<float>("4. BaseConfigs: Others", "Leather Scraps Base Chance", 0.2f);
            //WitheredBone
            MoreSkills_Config.BaseWitheredBoneChance = base.Config.Bind<float>("4. BaseConfigs: Others", "Withered Bone Base Chance", 0.2f);


            /*//Rock             OLD
            MoreSkills_Config.BaseMinRock = base.Config.Bind<int>("4. AllRocksConfig: zRocks", "Min Drop of Rocks", 3);
            MoreSkills_Config.BaseMaxRock = base.Config.Bind<int>("4. AllRocksConfig: zRocks", "Max Drop of Rocks", 6);
            //Big Rock
            MoreSkills_Config.BaseMinBigRock = base.Config.Bind<int>("4. AllRocksConfig: zBigRocks", "Min Drop of Big Rocks", 4);
            MoreSkills_Config.BaseMaxBigRock = base.Config.Bind<int>("4. AllRocksConfig: zBigRocks", "Max Drop of Big Rocks", 8);
            //Copper Vein
            MoreSkills_Config.BaseMinCopperVein = base.Config.Bind<int>("4. AllRocksConfig: zCopperVein", "Min Drop of Copper Veins", 2);
            MoreSkills_Config.BaseMaxCopperVein = base.Config.Bind<int>("4. AllRocksConfig: zCopperVein", "Max Drop of Copper Veins", 4);
            //Mudpile (Iron)
            MoreSkills_Config.BaseMinMudPile = base.Config.Bind<int>("4. AllRocksConfig: zMudPile", "Min Drop of Mud Piles (Iron)", 1);
            MoreSkills_Config.BaseMaxMudPile = base.Config.Bind<int>("4. AllRocksConfig: zMudPile", "Max Drop of Mud Piles (Iron)", 1);
            MoreSkills_Config.BaseChanceMudPile = base.Config.Bind<float>("4. AllRocksConfig: zMudPile", "Chance of Mud Piles (Iron)", 0.3f);
            //Silver Vein
            MoreSkills_Config.BaseMinSilverVein = base.Config.Bind<int>("4. AllRocksConfig: zSilverVein", "Min Drop of Silver Vein", 2);
            MoreSkills_Config.BaseMaxSilverVein = base.Config.Bind<int>("4. AllRocksConfig: zSilverVein", "Max Drop of Silver Vein", 3);*/



            //5. All Mobs Configs
            //Hunting Skill
            //Blob
            //Ooze
            MoreSkills_Config.BaseMinBlobOoze = base.Config.Bind<int>("5. AllMobConfig: Blob", "Min Drop of Ooze", 1);
            MoreSkills_Config.BaseMaxBlobOoze = base.Config.Bind<int>("5. AllMobConfig: Blob", "Max Drop of Ooze", 2);
            MoreSkills_Config.BaseChanceBlobOoze = base.Config.Bind<float>("5. AllMobConfig: Blob", "Chance Drop of Ooze", 1f);
            MoreSkills_Config.BaseLevelMultiplierBlobOoze = base.Config.Bind<bool>("5. AllMobConfig: Blob", "Drop Multiplier per Level of Ooze", true);
            //Trophy
            MoreSkills_Config.BaseMinBlobTrophy = base.Config.Bind<int>("5. AllMobConfig: Blob", "Min Drop of BlobTrophy", 1);
            MoreSkills_Config.BaseMaxBlobTrophy = base.Config.Bind<int>("5. AllMobConfig: Blob", "Max Drop of BlobTrophy", 1);
            MoreSkills_Config.BaseChanceBlobTrophy = base.Config.Bind<float>("5. AllMobConfig: Blob", "Chance Drop of BlobTrophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierBlobTrophy = base.Config.Bind<bool>("5. AllMobConfig: Blob", "Drop Multiplier per Level of BlobTrophy", false);
            //BlobElite
            //Ooze
            MoreSkills_Config.BaseMinBlobEliteOoze = base.Config.Bind<int>("5. AllMobConfig: Blob Elite", "Min Drop of Ooze", 2);
            MoreSkills_Config.BaseMaxBlobEliteOoze = base.Config.Bind<int>("5. AllMobConfig: Blob Elite", "Max Drop of Ooze", 3);
            MoreSkills_Config.BaseChanceBlobEliteOoze = base.Config.Bind<float>("5. AllMobConfig: Blob Elite", "Chance Drop of Ooze", 1f);
            MoreSkills_Config.BaseLevelMultiplierBlobEliteOoze = base.Config.Bind<bool>("5. AllMobConfig: Blob Elite", "Drop Multiplier per Level of Ooze", true);
            //IronScrap
            MoreSkills_Config.BaseMinBlobEliteIronScrap = base.Config.Bind<int>("5. AllMobConfig: Blob Elite", "Min Drop of Iron Scrap", 1);
            MoreSkills_Config.BaseMaxBlobEliteIronScrap = base.Config.Bind<int>("5. AllMobConfig: Blob Elite", "Max Drop of Iron Scrap", 1);
            MoreSkills_Config.BaseChanceBlobEliteIronScrap = base.Config.Bind<float>("5. AllMobConfig: Blob Elite", "Chance Drop of Iron Scrap", 0.33f);
            MoreSkills_Config.BaseLevelMultiplierBlobEliteIronScrap = base.Config.Bind<bool>("5. AllMobConfig: Blob Elite", "Drop Multiplier per Level of Iron Scrap", true);
            //Trophy same as Blob
            //Blob
            MoreSkills_Config.BaseMinBlobEliteBlob = base.Config.Bind<int>("5. AllMobConfig: Blob Elite", "Min Drop of Blobs (Mob)", 2);
            MoreSkills_Config.BaseMaxBlobEliteBlob = base.Config.Bind<int>("5. AllMobConfig: Blob Elite", "Max Drop of Blobs (Mob)", 2);
            MoreSkills_Config.BaseChanceBlobEliteBlob = base.Config.Bind<float>("5. AllMobConfig: Blob Elite", "Chance Drop of Blobs (Mob)", 1f);
            MoreSkills_Config.BaseLevelMultiplierBlobEliteBlob = base.Config.Bind<bool>("5. AllMobConfig: Blob Elite", "Drop Multiplier per Level of Blobs (Mob)", true);
            //Boar
            //RawMeat
            MoreSkills_Config.BaseMinBoarRawMeat = base.Config.Bind<int>("5. AllMobConfig: Boar", "Min Drop of RawMeat", 1);
            MoreSkills_Config.BaseMaxBoarRawMeat = base.Config.Bind<int>("5. AllMobConfig: Boar", "Max Drop of RawMeat", 1);
            MoreSkills_Config.BaseChanceBoarRawMeat = base.Config.Bind<float>("5. AllMobConfig: Boar", "Chance Drop of RawMeat", 0.5f);
            MoreSkills_Config.BaseLevelMultiplierBoarRawMeat = base.Config.Bind<bool>("5. AllMobConfig: Boar", "Drop Multiplier per Level of RawMeat", true);
            //Leather Scraps
            MoreSkills_Config.BaseMinBoarLeatherScraps = base.Config.Bind<int>("5. AllMobConfig: Boar", "Min Drop of Leather Scraps", 1);
            MoreSkills_Config.BaseMaxBoarLeatherScraps = base.Config.Bind<int>("5. AllMobConfig: Boar", "Max Drop of Leather Scraps", 1);
            MoreSkills_Config.BaseChanceBoarLeatherScraps = base.Config.Bind<float>("5. AllMobConfig: Boar", "Chance Drop of Leather Scraps", 1f);
            MoreSkills_Config.BaseLevelMultiplierBoarLeatherScraps = base.Config.Bind<bool>("5. AllMobConfig: Boar", "Drop Multiplier per Level of Leather Scraps", true);
            //Trophy
            MoreSkills_Config.BaseMinBoarTrophy = base.Config.Bind<int>("5. AllMobConfig: Boar", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxBoarTrophy = base.Config.Bind<int>("5. AllMobConfig: Boar", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceBoarTrophy = base.Config.Bind<float>("5. AllMobConfig: Boar", "Chance Drop of Trophy", 0.15f);
            MoreSkills_Config.BaseLevelMultiplierBoarTrophy = base.Config.Bind<bool>("5. AllMobConfig: Boar", "Drop Multiplier per Level of Trophy", false);
            //Deathsquito
            //Needle
            MoreSkills_Config.BaseMinDeathsquitoNeedle = base.Config.Bind<int>("5. AllMobConfig: Deathsquito", "Min Drop of Needle", 1);
            MoreSkills_Config.BaseMaxDeathsquitoNeedle = base.Config.Bind<int>("5. AllMobConfig: Deathsquito", "Max Drop of Needle", 1);
            MoreSkills_Config.BaseChanceDeathsquitoNeedle = base.Config.Bind<float>("5. AllMobConfig: Deathsquito", "Chance Drop of Needle", 1f);
            MoreSkills_Config.BaseLevelMultiplierDeathsquitoNeedle = base.Config.Bind<bool>("5. AllMobConfig: Deathsquito", "Drop Multiplier per Level of Needle", false);
            //Trophy
            MoreSkills_Config.BaseMinDeathsquitoTrophy = base.Config.Bind<int>("5. AllMobConfig: Deathsquito", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxDeathsquitoTrophy = base.Config.Bind<int>("5. AllMobConfig: Deathsquito", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceDeathsquitoTrophy = base.Config.Bind<float>("5. AllMobConfig: Deathsquito", "Chance Drop of Trophy", 0.05f);
            MoreSkills_Config.BaseLevelMultiplierDeathsquitoTrophy = base.Config.Bind<bool>("5. AllMobConfig: Deathsquito", "Drop Multiplier per Level of Trophy", false);
            //Deer
            //Raw Meat
            MoreSkills_Config.BaseMinDeerRawMeat = base.Config.Bind<int>("5. AllMobConfig: Deer", "Min Drop of Raw Meat", 2);
            MoreSkills_Config.BaseMaxDeerRawMeat = base.Config.Bind<int>("5. AllMobConfig: Deer", "Max Drop of Raw Meat", 2);
            MoreSkills_Config.BaseChanceDeerRawMeat = base.Config.Bind<float>("5. AllMobConfig: Deer", "Chance Drop of Raw Meat", 1f);
            MoreSkills_Config.BaseLevelMultiplierDeerRawMeat = base.Config.Bind<bool>("5. AllMobConfig: Deer", "Drop Multiplier per Level of Raw Meat", true);
            //Deer Hide
            MoreSkills_Config.BaseMinDeerHide = base.Config.Bind<int>("5. AllMobConfig: Deer", "Min Drop of Deer Hide", 1);
            MoreSkills_Config.BaseMaxDeerHide = base.Config.Bind<int>("5. AllMobConfig: Deer", "Max Drop of Deer Hide", 3);
            MoreSkills_Config.BaseChanceDeerHide = base.Config.Bind<float>("5. AllMobConfig: Deer", "Chance Drop of Deer Hide", 1f);
            MoreSkills_Config.BaseLevelMultiplierDeerHide = base.Config.Bind<bool>("5. AllMobConfig: Deer", "Drop Multiplier per Level of Deer Hide", true);
            //Trophy
            MoreSkills_Config.BaseMinDeerTrophy = base.Config.Bind<int>("5. AllMobConfig: Deer", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxDeerTrophy = base.Config.Bind<int>("5. AllMobConfig: Deer", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceDeerTrophy = base.Config.Bind<float>("5. AllMobConfig: Deer", "Chance Drop of Trophy", 0.5f);
            MoreSkills_Config.BaseLevelMultiplierDeerTrophy = base.Config.Bind<bool>("5. AllMobConfig: Deer", "Drop Multiplier per Level of Trophy", false);
            //Drake
            //Freeze Gland
            MoreSkills_Config.BaseMinDrakeFreezeGland = base.Config.Bind<int>("5. AllMobConfig: Drake", "Min Drop of Freeze Gland", 1);
            MoreSkills_Config.BaseMaxDrakeFreezeGland = base.Config.Bind<int>("5. AllMobConfig: Drake", "Max Drop of Freeze Gland", 2);
            MoreSkills_Config.BaseChanceDrakeFreezeGland = base.Config.Bind<float>("5. AllMobConfig: Drake", "Chance Drop of Freeze Gland", 1f);
            MoreSkills_Config.BaseLevelMultiplierDrakeFreezeGland = base.Config.Bind<bool>("5. AllMobConfig: Drake", "Drop Multiplier per Level of Freeze Gland", true);
            //Trophy
            MoreSkills_Config.BaseMinDrakeTrophy = base.Config.Bind<int>("5. AllMobConfig: Drake", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxDrakeTrophy = base.Config.Bind<int>("5. AllMobConfig: Drake", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceDrakeTrophy = base.Config.Bind<float>("5. AllMobConfig: Drake", "Chance Drop of Trophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierDrakeTrophy = base.Config.Bind<bool>("5. AllMobConfig: Drake", "Drop Multiplier per Level of Trophy", false);
            //Draugr
            //Entrails
            MoreSkills_Config.BaseMinDraugrEntrails = base.Config.Bind<int>("5. AllMobConfig: Draugr", "Min Drop of Entrails", 1);
            MoreSkills_Config.BaseMaxDraugrEntrails = base.Config.Bind<int>("5. AllMobConfig: Draugr", "Max Drop of Entrails", 1);
            MoreSkills_Config.BaseChanceDraugrEntrails = base.Config.Bind<float>("5. AllMobConfig: Draugr", "Chance Drop of Entrails", 1f);
            MoreSkills_Config.BaseLevelMultiplierDraugrEntrails = base.Config.Bind<bool>("5. AllMobConfig: Draugr", "Drop Multiplier per Level of Entrails", true);
            //Trophy
            MoreSkills_Config.BaseMinDraugrTrophy = base.Config.Bind<int>("5. AllMobConfig: Draugr", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxDraugrTrophy = base.Config.Bind<int>("5. AllMobConfig: Draugr", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceDraugrTrophy = base.Config.Bind<float>("5. AllMobConfig: Draugr", "Chance Drop of Trophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierDraugrTrophy = base.Config.Bind<bool>("5. AllMobConfig: Draugr", "Drop Multiplier per Level of Trophy", false);
            //Draugr Elite
            //Entrails
            MoreSkills_Config.BaseMinDraugrEliteEntrails = base.Config.Bind<int>("5. AllMobConfig: Draugr Elite", "Min Drop of Entrails", 2);
            MoreSkills_Config.BaseMaxDraugrEliteEntrails = base.Config.Bind<int>("5. AllMobConfig: Draugr Elite", "Max Drop of Entrails", 3);
            MoreSkills_Config.BaseChanceDraugrEliteEntrails = base.Config.Bind<float>("5. AllMobConfig: Draugr Elite", "Chance Drop of Entrails", 1f);
            MoreSkills_Config.BaseLevelMultiplierDraugrEliteEntrails = base.Config.Bind<bool>("5. AllMobConfig: Draugr Elite", "Drop Multiplier per Level of Entrails", true);
            //Trophy
            MoreSkills_Config.BaseMinDraugrEliteTrophy = base.Config.Bind<int>("5. AllMobConfig: Draugr Elite", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxDraugrEliteTrophy = base.Config.Bind<int>("5. AllMobConfig: Draugr Elite", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceDraugrEliteTrophy = base.Config.Bind<float>("5. AllMobConfig: Draugr Elite", "Chance Drop of Trophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierDraugrEliteTrophy = base.Config.Bind<bool>("5. AllMobConfig: Draugr Elite", "Drop Multiplier per Level of Trophy", false);
            //Fenring
            //WolfFang
            MoreSkills_Config.BaseMinFenringWolfFang = base.Config.Bind<int>("5. AllMobConfig: Fenring", "Min Drop of WolfFang", 1);
            MoreSkills_Config.BaseMaxFenringWolfFang = base.Config.Bind<int>("5. AllMobConfig: Fenring", "Max Drop of WolfFang", 2);
            MoreSkills_Config.BaseChanceFenringWolfFang = base.Config.Bind<float>("5. AllMobConfig: Fenring", "Chance Drop of WolfFang", 1f);
            MoreSkills_Config.BaseLevelMultiplierFenringWolfFang = base.Config.Bind<bool>("5. AllMobConfig: Fenring", "Drop Multiplier per Level of WolfFang", true);
            //Trophy
            MoreSkills_Config.BaseMinFenringEliteTrophy = base.Config.Bind<int>("5. AllMobConfig: Fenring", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxFenringEliteTrophy = base.Config.Bind<int>("5. AllMobConfig: Fenring", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceFenringEliteTrophy = base.Config.Bind<float>("5. AllMobConfig: Fenring", "Chance Drop of Trophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierFenringEliteTrophy = base.Config.Bind<bool>("5. AllMobConfig: Fenring", "Drop Multiplier per Level of Trophy", false);
            //Goblin
            //Coins
            MoreSkills_Config.BaseMinGoblinCoins = base.Config.Bind<int>("5. AllMobConfig: Goblin", "Min Drop of Coins", 5);
            MoreSkills_Config.BaseMaxGoblinCoins = base.Config.Bind<int>("5. AllMobConfig: Goblin", "Max Drop of Coins", 10);
            MoreSkills_Config.BaseChanceGoblinCoins = base.Config.Bind<float>("5. AllMobConfig: Goblin", "Chance Drop of Coins", 0.25f);
            MoreSkills_Config.BaseLevelMultiplierGoblinCoins = base.Config.Bind<bool>("5. AllMobConfig: Goblin", "Drop Multiplier per Level of Coins", true);
            //Black Metal Scrap
            MoreSkills_Config.BaseMinGoblinBMS = base.Config.Bind<int>("5. AllMobConfig: Goblin", "Min Drop of Black Metal Scrap", 1);
            MoreSkills_Config.BaseMaxGoblinBMS = base.Config.Bind<int>("5. AllMobConfig: Goblin", "Max Drop of Black Metal Scrap", 2);
            MoreSkills_Config.BaseChanceGoblinBMS = base.Config.Bind<float>("5. AllMobConfig: Goblin", "Chance Drop of Black Metal Scrap", 1f);
            MoreSkills_Config.BaseLevelMultiplierGoblinBMS = base.Config.Bind<bool>("5. AllMobConfig: Goblin", "Drop Multiplier per Level of Black Metal Scrap", true);
            //Trophy
            MoreSkills_Config.BaseMinGoblinTrophy = base.Config.Bind<int>("5. AllMobConfig: Goblin", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxGoblinTrophy = base.Config.Bind<int>("5. AllMobConfig: Goblin", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceGoblinTrophy = base.Config.Bind<float>("5. AllMobConfig: Goblin", "Chance Drop of Trophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierGoblinTrophy = base.Config.Bind<bool>("5. AllMobConfig: Goblin", "Drop Multiplier per Level of Trophy", false);
            //Goblin Brute
            //Coins
            MoreSkills_Config.BaseMinGoblinBruteCoins = base.Config.Bind<int>("5. AllMobConfig: Goblin Brute", "Min Drop of Coins", 5);
            MoreSkills_Config.BaseMaxGoblinBruteCoins = base.Config.Bind<int>("5. AllMobConfig: Goblin Brute", "Max Drop of Coins", 20);
            MoreSkills_Config.BaseChanceGoblinBruteCoins = base.Config.Bind<float>("5. AllMobConfig: Goblin Brute", "Chance Drop of Coins", 1f);
            MoreSkills_Config.BaseLevelMultiplierGoblinBruteCoins = base.Config.Bind<bool>("5. AllMobConfig: Goblin Brute", "Drop Multiplier per Level of Coins", true);
            //Black Metal Scrap
            MoreSkills_Config.BaseMinGoblinBruteBMS = base.Config.Bind<int>("5. AllMobConfig: Goblin Brute", "Min Drop of Black Metal Scrap", 3);
            MoreSkills_Config.BaseMaxGoblinBruteBMS = base.Config.Bind<int>("5. AllMobConfig: Goblin Brute", "Max Drop of Black Metal Scrap", 5);
            MoreSkills_Config.BaseChanceGoblinBruteBMS = base.Config.Bind<float>("5. AllMobConfig: Goblin Brute", "Chance Drop of Black Metal Scrap", 1f);
            MoreSkills_Config.BaseLevelMultiplierGoblinBruteBMS = base.Config.Bind<bool>("5. AllMobConfig: Goblin Brute", "Drop Multiplier per Level of Black Metal Scrap", true);
            //Goblin Totem
            MoreSkills_Config.BaseMinGoblinBruteTotem = base.Config.Bind<int>("5. AllMobConfig: Goblin Brute", "Min Drop of Goblin Totem", 1);
            MoreSkills_Config.BaseMaxGoblinBruteTotem = base.Config.Bind<int>("5. AllMobConfig: Goblin Brute", "Max Drop of Goblin Totem", 1);
            MoreSkills_Config.BaseChanceGoblinBruteTotem = base.Config.Bind<float>("5. AllMobConfig: Goblin Brute", "Chance Drop of Goblin Totem", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierGoblinBruteTotem = base.Config.Bind<bool>("5. AllMobConfig: Goblin Brute", "Drop Multiplier per Level of Goblin Totem", false);
            //Trophy
            MoreSkills_Config.BaseMinGoblinBruteTrophy = base.Config.Bind<int>("5. AllMobConfig: Goblin Brute", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxGoblinBruteTrophy = base.Config.Bind<int>("5. AllMobConfig: Goblin Brute", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceGoblinBruteTrophy = base.Config.Bind<float>("5. AllMobConfig: Goblin Brute", "Chance Drop of Trophy", 0.05f);
            MoreSkills_Config.BaseLevelMultiplierGoblinBruteTrophy = base.Config.Bind<bool>("5. AllMobConfig: Goblin Brute", "Drop Multiplier per Level of Trophy", false);
            //Goblin Shaman
            //Coins
            MoreSkills_Config.BaseMinGoblinShamanCoins = base.Config.Bind<int>("5. AllMobConfig: Goblin Shaman", "Min Drop of Coins", 20);
            MoreSkills_Config.BaseMaxGoblinShamanCoins = base.Config.Bind<int>("5. AllMobConfig: Goblin Shaman", "Max Drop of Coins", 40);
            MoreSkills_Config.BaseChanceGoblinShamanCoins = base.Config.Bind<float>("5. AllMobConfig: Goblin Shaman", "Chance Drop of Coins", 0.25f);
            MoreSkills_Config.BaseLevelMultiplierGoblinShamanCoins = base.Config.Bind<bool>("5. AllMobConfig: Goblin Shaman", "Drop Multiplier per Level of Coins", true);
            //Black Metal Scrap
            MoreSkills_Config.BaseMinGoblinShamanBMS = base.Config.Bind<int>("5. AllMobConfig: Goblin Shaman", "Min Drop of Black Metal Scrap", 1);
            MoreSkills_Config.BaseMaxGoblinShamanBMS = base.Config.Bind<int>("5. AllMobConfig: Goblin Shaman", "Max Drop of Black Metal Scrap", 2);
            MoreSkills_Config.BaseChanceGoblinShamanBMS = base.Config.Bind<float>("5. AllMobConfig: Goblin Shaman", "Chance Drop of Black Metal Scrap", 1f);
            MoreSkills_Config.BaseLevelMultiplierGoblinShamanBMS = base.Config.Bind<bool>("5. AllMobConfig: Goblin Shaman", "Drop Multiplier per Level of Black Metal Scrap", true);
            //Trophy
            MoreSkills_Config.BaseMinGoblinShamanTrophy = base.Config.Bind<int>("5. AllMobConfig: Goblin Shaman", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxGoblinShamanTrophy = base.Config.Bind<int>("5. AllMobConfig: Goblin Shaman", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceGoblinShamanTrophy = base.Config.Bind<float>("5. AllMobConfig: Goblin Shaman", "Chance Drop of Trophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierGoblinShamanTrophy = base.Config.Bind<bool>("5. AllMobConfig: Goblin Shaman", "Drop Multiplier per Level of Trophy", false);
            //Greydwarf
            //Eyes
            MoreSkills_Config.BaseMinGreydwarfEyes = base.Config.Bind<int>("5. AllMobConfig: Greydwarf", "Min Drop of Eyes", 1);
            MoreSkills_Config.BaseMaxGreydwarfEyes = base.Config.Bind<int>("5. AllMobConfig: Greydwarf", "Max Drop of Eyes", 1);
            MoreSkills_Config.BaseChanceGreydwarfEyes = base.Config.Bind<float>("5. AllMobConfig: Greydwarf", "Chance Drop of Eyes", 0.5f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfEyes = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf", "Drop Multiplier per Level of Eyes", true);
            //Resin
            MoreSkills_Config.BaseMinGreydwarfResin = base.Config.Bind<int>("5. AllMobConfig: Greydwarf", "Min Drop of Resin", 1);
            MoreSkills_Config.BaseMaxGreydwarfResin = base.Config.Bind<int>("5. AllMobConfig: Greydwarf", "Max Drop of Resin", 1);
            MoreSkills_Config.BaseChanceGreydwarfResin = base.Config.Bind<float>("5. AllMobConfig: Greydwarf", "Chance Drop of Resin", 1f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfResin = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf", "Drop Multiplier per Level of Resin", true);
            //Stone
            MoreSkills_Config.BaseMinGreydwarfStone = base.Config.Bind<int>("5. AllMobConfig: Greydwarf", "Min Drop of Stone", 1);
            MoreSkills_Config.BaseMaxGreydwarfStone = base.Config.Bind<int>("5. AllMobConfig: Greydwarf", "Max Drop of Stone", 1);
            MoreSkills_Config.BaseChanceGreydwarfStone = base.Config.Bind<float>("5. AllMobConfig: Greydwarf", "Chance Drop of Stone", 1f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfStone = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf", "Drop Multiplier per Level of Stone", true);
            //Wood
            MoreSkills_Config.BaseMinGreydwarfWood = base.Config.Bind<int>("5. AllMobConfig: Greydwarf", "Min Drop of Wood", 1);
            MoreSkills_Config.BaseMaxGreydwarfWood = base.Config.Bind<int>("5. AllMobConfig: Greydwarf", "Max Drop of Wood", 1);
            MoreSkills_Config.BaseChanceGreydwarfWood = base.Config.Bind<float>("5. AllMobConfig: Greydwarf", "Chance Drop of Wood", 1);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfWood = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf", "Drop Multiplier per Level of Wood", true);
            //Trophy
            MoreSkills_Config.BaseMinGreydwarfTrophy = base.Config.Bind<int>("5. AllMobConfig: Greydwarf", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxGreydwarfTrophy = base.Config.Bind<int>("5. AllMobConfig: Greydwarf", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceGreydwarfTrophy = base.Config.Bind<float>("5. AllMobConfig: Greydwarf", "Chance Drop of Trophy", 0.05f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfTrophy = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf", "Drop Multiplier per Level of Trophy", false);
            //Greydwarf Shaman
            //Eyes
            MoreSkills_Config.BaseMinGreydwarfShamanEyes = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Shaman", "Min Drop of Eyes", 2);
            MoreSkills_Config.BaseMaxGreydwarfShamanEyes = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Shaman", "Max Drop of Eyes", 2);
            MoreSkills_Config.BaseChanceGreydwarfShamanEyes = base.Config.Bind<float>("5. AllMobConfig: Greydwarf Shaman", "Chance Drop of Eyes", 1f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfShamanEyes = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf Shaman", "Drop Multiplier per Level of Eyes", true);
            //Wood
            MoreSkills_Config.BaseMinGreydwarfShamanWood = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Shaman", "Min Drop of Wood", 2);
            MoreSkills_Config.BaseMaxGreydwarfShamanWood = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Shaman", "Max Drop of Wood", 2);
            MoreSkills_Config.BaseChanceGreydwarfShamanWood = base.Config.Bind<float>("5. AllMobConfig: Greydwarf Shaman", "Chance Drop of Wood", 1f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfShamanWood = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf Shaman", "Drop Multiplier per Level of Wood", true);
            //Resin
            MoreSkills_Config.BaseMinGreydwarfShamanResin = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Shaman", "Min Drop of Wood", 1);
            MoreSkills_Config.BaseMaxGreydwarfShamanResin = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Shaman", "Max Drop of Wood", 2);
            MoreSkills_Config.BaseChanceGreydwarfShamanResin = base.Config.Bind<float>("5. AllMobConfig: Greydwarf Shaman", "Chance Drop of Wood", 1f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfShamanResin = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf Shaman", "Drop Multiplier per Level of Wood", true);
            //Trophy
            MoreSkills_Config.BaseMinGreydwarfShamanTrophy = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Shaman", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxGreydwarfShamanTrophy = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Shaman", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceGreydwarfShamanTrophy = base.Config.Bind<float>("5. AllMobConfig: Greydwarf Shaman", "Chance Drop of Trophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfShamanTrophy = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf Shaman", "Drop Multiplier per Level of Trophy", false);
            //Greydwarf Brute
            //Eyes
            MoreSkills_Config.BaseMinGreydwarfBruteEyes = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Brute", "Min Drop of Eyes", 2);
            MoreSkills_Config.BaseMaxGreydwarfBruteEyes = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Brute", "Max Drop of Eyes", 2);
            MoreSkills_Config.BaseChanceGreydwarfBruteEyes = base.Config.Bind<float>("5. AllMobConfig: Greydwarf Brute", "Chance Drop of Eyes", 1f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfBruteEyes = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf Brute", "Drop Multiplier per Level of Eyes", true);
            //Stone
            MoreSkills_Config.BaseMinGreydwarfBruteStone = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Brute", "Min Drop of Stone", 2);
            MoreSkills_Config.BaseMaxGreydwarfBruteStone = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Brute", "Max Drop of Stone", 2);
            MoreSkills_Config.BaseChanceGreydwarfBruteStone = base.Config.Bind<float>("5. AllMobConfig: Greydwarf Brute", "Chance Drop of Stone", 1f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfBruteStone = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf Brute", "Drop Multiplier per Level of Stone", true);
            //Wood
            MoreSkills_Config.BaseMinGreydwarfBruteWood = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Brute", "Min Drop of Wood", 3);
            MoreSkills_Config.BaseMaxGreydwarfBruteWood = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Brute", "Max Drop of Wood", 5);
            MoreSkills_Config.BaseChanceGreydwarfBruteWood = base.Config.Bind<float>("5. AllMobConfig: Greydwarf Brute", "Chance Drop of Wood", 1f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfBruteWood = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf Brute", "Drop Multiplier per Level of Wood", true);
            //Dandelion
            MoreSkills_Config.BaseMinGreydwarfBruteDandelion = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Brute", "Min Drop of Dandelion", 1);
            MoreSkills_Config.BaseMaxGreydwarfBruteDandelion = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Brute", "Max Drop of Dandelion", 1);
            MoreSkills_Config.BaseChanceGreydwarfBruteDandelion = base.Config.Bind<float>("5. AllMobConfig: Greydwarf Brute", "Chance Drop of Dandelion", 1f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfBruteDandelion = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf Brute", "Drop Multiplier per Level of Dandelion", true);
            //Ancient Seed
            MoreSkills_Config.BaseMinGreydwarfBruteAncientSeed = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Brute", "Min Drop of Ancient Seed", 1);
            MoreSkills_Config.BaseMaxGreydwarfBruteAncientSeed = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Brute", "Max Drop of Ancient Seed", 1);
            MoreSkills_Config.BaseChanceGreydwarfBruteAncientSeed = base.Config.Bind<float>("5. AllMobConfig: Greydwarf Brute", "Chance Drop of Ancient Seed", 0.33f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfBruteAncientSeed = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf Brute", "Drop Multiplier per Level of Ancient Seed", true);
            //Trophy
            MoreSkills_Config.BaseMinGreydwarfBruteTrophy = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Brute", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxGreydwarfBruteTrophy = base.Config.Bind<int>("5. AllMobConfig: Greydwarf Brute", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceGreydwarfBruteTrophy = base.Config.Bind<float>("5. AllMobConfig: Greydwarf Brute", "Chance Drop of Trophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierGreydwarfBruteTrophy = base.Config.Bind<bool>("5. AllMobConfig: Greydwarf Brute", "Drop Multiplier per Level of Trophy", false);
            //Greyling
            //Resin
            MoreSkills_Config.BaseMinGreylingResin = base.Config.Bind<int>("5. AllMobConfig: Greyling", "Min Drop of Resin", 1);
            MoreSkills_Config.BaseMaxGreylingResin = base.Config.Bind<int>("5. AllMobConfig: Greyling", "Max Drop of Resin", 1);
            MoreSkills_Config.BaseChanceGreylingResin = base.Config.Bind<float>("5. AllMobConfig: Greyling", "Chance Drop of Resin", 1f);
            MoreSkills_Config.BaseLevelMultiplierGreylingResin = base.Config.Bind<bool>("5. AllMobConfig: Greyling", "Drop Multiplier per Level of Resin", true);
            //Leech
            //BloodBag
            MoreSkills_Config.BaseMinLeechBloodBag = base.Config.Bind<int>("5. AllMobConfig: Leech", "Min Drop of BloodBag", 1);
            MoreSkills_Config.BaseMaxLeechBloodBag = base.Config.Bind<int>("5. AllMobConfig: Leech", "Max Drop of BloodBag", 1);
            MoreSkills_Config.BaseChanceLeechBloodBag = base.Config.Bind<float>("5. AllMobConfig: Leech", "Chance Drop of BloodBag", 1f);
            MoreSkills_Config.BaseLevelMultiplierLeechBloodBag = base.Config.Bind<bool>("5. AllMobConfig: Leech", "Drop Multiplier per Level of BloodBag", true);
            //Trophy
            MoreSkills_Config.BaseMinLeechTrophy = base.Config.Bind<int>("5. AllMobConfig: Leech", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxLeechTrophy = base.Config.Bind<int>("5. AllMobConfig: Leech", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceLeechTrophy = base.Config.Bind<float>("5. AllMobConfig: Leech", "Chance Drop of Trophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierLeechTrophy = base.Config.Bind<bool>("5. AllMobConfig: Leech", "Drop Multiplier per Level of Trophy", false);
            //Lox
            //Lox Meat
            MoreSkills_Config.BaseMinLoxMeat = base.Config.Bind<int>("5. AllMobConfig: Lox", "Min Drop of Lox Meat", 4);
            MoreSkills_Config.BaseMaxLoxMeat = base.Config.Bind<int>("5. AllMobConfig: Lox", "Max Drop of Lox Meat", 6);
            MoreSkills_Config.BaseChanceLoxMeat = base.Config.Bind<float>("5. AllMobConfig: Lox", "Chance Drop of Lox Meat", 1f);
            MoreSkills_Config.BaseLevelMultiplierLoxMeat = base.Config.Bind<bool>("5. AllMobConfig: Lox", "Drop Multiplier per Level of Lox Meat", true);
            //Lox Pelt
            MoreSkills_Config.BaseMinLoxPelt = base.Config.Bind<int>("5. AllMobConfig: Lox", "Min Drop of Lox Pelt", 2);
            MoreSkills_Config.BaseMaxLoxPelt = base.Config.Bind<int>("5. AllMobConfig: Lox", "Max Drop of Lox Pelt", 3);
            MoreSkills_Config.BaseChanceLoxPelt = base.Config.Bind<float>("5. AllMobConfig: Lox", "Chance Drop of Lox Pelt", 1f);
            MoreSkills_Config.BaseLevelMultiplierLoxPelt = base.Config.Bind<bool>("5. AllMobConfig: Lox", "Drop Multiplier per Level of Lox Pelt", true);
            //Trophy
            MoreSkills_Config.BaseMinLoxTrophy = base.Config.Bind<int>("5. AllMobConfig: Lox", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxLoxTrophy = base.Config.Bind<int>("5. AllMobConfig: Lox", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceLoxTrophy = base.Config.Bind<float>("5. AllMobConfig: Lox", "Chance Drop of Trophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierLoxTrophy = base.Config.Bind<bool>("5. AllMobConfig: Lox", "Drop Multiplier per Level of Trophy", false);
            //Neck
            //Tail
            MoreSkills_Config.BaseMinNeckTail = base.Config.Bind<int>("5. AllMobConfig: Neck", "Min Drop of Tail", 1);
            MoreSkills_Config.BaseMaxNeckTail = base.Config.Bind<int>("5. AllMobConfig: Neck", "Max Drop of Tail", 1);
            MoreSkills_Config.BaseChanceNeckTail = base.Config.Bind<float>("5. AllMobConfig: Neck", "Chance Drop of Tail", 0.7f);
            MoreSkills_Config.BaseLevelMultiplierNeckTail = base.Config.Bind<bool>("5. AllMobConfig: Neck", "Drop Multiplier per Level of Tail", true);
            //Trophy
            MoreSkills_Config.BaseMinNeckTrophy = base.Config.Bind<int>("5. AllMobConfig: Neck", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxNeckTrophy = base.Config.Bind<int>("5. AllMobConfig: Neck", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceNeckTrophy = base.Config.Bind<float>("5. AllMobConfig: Neck", "Chance Drop of Trophy", 0.05f);
            MoreSkills_Config.BaseLevelMultiplierNeckTrophy = base.Config.Bind<bool>("5. AllMobConfig: Neck", "Drop Multiplier per Level of Trophy", false);
            //Serpent
            //Serpent Meat
            MoreSkills_Config.BaseMinSerpentMeat = base.Config.Bind<int>("5. AllMobConfig: Serpent", "Min Drop of Serpent Meat", 6);
            MoreSkills_Config.BaseMaxSerpentMeat = base.Config.Bind<int>("5. AllMobConfig: Serpent", "Max Drop of Serpent Meat", 8);
            MoreSkills_Config.BaseChanceSerpentMeat = base.Config.Bind<float>("5. AllMobConfig: Serpent", "Chance Drop of Serpent Meat", 1f);
            MoreSkills_Config.BaseLevelMultiplierSerpentMeat = base.Config.Bind<bool>("5. AllMobConfig: Serpent", "Drop Multiplier per Level of Serpent Meat", true);
            //Serpent Scale
            MoreSkills_Config.BaseMinSerpentScale = base.Config.Bind<int>("5. AllMobConfig: Serpent", "Min Drop of Serpent Scale", 8);
            MoreSkills_Config.BaseMaxSerpentScale = base.Config.Bind<int>("5. AllMobConfig: Serpent", "Max Drop of Serpent Scale", 10);
            MoreSkills_Config.BaseChanceSerpentScale = base.Config.Bind<float>("5. AllMobConfig: Serpent", "Chance Drop of Serpent Scale", 1f);
            MoreSkills_Config.BaseLevelMultiplierSerpentScale = base.Config.Bind<bool>("5. AllMobConfig: Serpent", "Drop Multiplier per Level of Serpent Scale", true);
            //Trophy
            MoreSkills_Config.BaseMinSerpentTrophy = base.Config.Bind<int>("5. AllMobConfig: Serpent", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxSerpentTrophy = base.Config.Bind<int>("5. AllMobConfig: Serpent", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceSerpentTrophy = base.Config.Bind<float>("5. AllMobConfig: Serpent", "Chance Drop of Trophy", 0.33f);
            MoreSkills_Config.BaseLevelMultiplierSerpentTrophy = base.Config.Bind<bool>("5. AllMobConfig: Serpent", "Drop Multiplier per Level of Trophy", false);
            //Skeleton
            //Bone Fragments
            MoreSkills_Config.BaseMinSkeletonBones = base.Config.Bind<int>("5. AllMobConfig: Skeleton", "Min Drop of Bone Fragments", 1);
            MoreSkills_Config.BaseMaxSkeletonBones = base.Config.Bind<int>("5. AllMobConfig: Skeleton", "Max Drop of Bone Fragments", 1);
            MoreSkills_Config.BaseChanceSkeletonBones = base.Config.Bind<float>("5. AllMobConfig: Skeleton", "Chance Drop of Bone Fragments", 1f);
            MoreSkills_Config.BaseLevelMultiplierSkeletonBones = base.Config.Bind<bool>("5. AllMobConfig: Skeleton", "Drop Multiplier per Level of Bone Fragments", true);
            //Trophy
            MoreSkills_Config.BaseMinSkeletonTrophy = base.Config.Bind<int>("5. AllMobConfig: Skeleton", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxSkeletonTrophy = base.Config.Bind<int>("5. AllMobConfig: Skeleton", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceSkeletonTrophy = base.Config.Bind<float>("5. AllMobConfig: Skeleton", "Chance Drop of Trophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierSkeletonTrophy = base.Config.Bind<bool>("5. AllMobConfig: Skeleton", "Drop Multiplier per Level of Trophy", false);
            //Skeketon Poison
            //Bone Fragments
            MoreSkills_Config.BaseMinSkeletonPoisonBones = base.Config.Bind<int>("5. AllMobConfig: Skeketon Poison", "Min Drop of Bone Fragments", 1);
            MoreSkills_Config.BaseMaxSkeletonPoisonBones = base.Config.Bind<int>("5. AllMobConfig: Skeketon Poison", "Max Drop of Bone Fragments", 1);
            MoreSkills_Config.BaseChanceSkeletonPoisonBones = base.Config.Bind<float>("5. AllMobConfig: Skeketon Poison", "Chance Drop of Bone Fragments", 1f);
            MoreSkills_Config.BaseLevelMultiplierSkeletonPoisonBones = base.Config.Bind<bool>("5. AllMobConfig: Skeketon Poison", "Drop Multiplier per Level of Bone Fragments", true);
            //Trophy
            MoreSkills_Config.BaseMinSkeletonPoisonTrophy = base.Config.Bind<int>("5. AllMobConfig: Skeketon Poison", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxSkeletonPoisonTrophy = base.Config.Bind<int>("5. AllMobConfig: Skeketon Poison", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceSkeletonPoisonTrophy = base.Config.Bind<float>("5. AllMobConfig: Skeketon Poison", "Chance Drop of Trophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierSkeletonPoisonTrophy = base.Config.Bind<bool>("5. AllMobConfig: Skeketon Poison", "Drop Multiplier per Level of Trophy", false);
            //Stone Golem
            //Stone
            MoreSkills_Config.BaseMinStoneGolemStone = base.Config.Bind<int>("5. AllMobConfig: Stone Golem", "Min Drop of Stone", 5);
            MoreSkills_Config.BaseMaxStoneGolemStone = base.Config.Bind<int>("5. AllMobConfig: Stone Golem", "Max Drop of Stone", 10);
            MoreSkills_Config.BaseChanceStoneGolemStone = base.Config.Bind<float>("5. AllMobConfig: Stone Golem", "Chance Drop of Stone", 1f);
            MoreSkills_Config.BaseLevelMultiplierStoneGolemStone = base.Config.Bind<bool>("5. AllMobConfig: Stone Golem", "Drop Multiplier per Level of Stone", true);
            //Crystal
            MoreSkills_Config.BaseMinStoneGolemCrystal = base.Config.Bind<int>("5. AllMobConfig: Stone Golem", "Min Drop of Crystal", 3);
            MoreSkills_Config.BaseMaxStoneGolemCrystal = base.Config.Bind<int>("5. AllMobConfig: Stone Golem", "Max Drop of Crystal", 6);
            MoreSkills_Config.BaseChanceStoneGolemCrystal = base.Config.Bind<float>("5. AllMobConfig: Stone Golem", "Chance Drop of Crystal", 1f);
            MoreSkills_Config.BaseLevelMultiplierStoneGolemCrystal = base.Config.Bind<bool>("5. AllMobConfig: Stone Golem", "Drop Multiplier per Level of Crystal", true);
            //Trophy
            MoreSkills_Config.BaseMinStoneGolemTrophy = base.Config.Bind<int>("5. AllMobConfig: Stone Golem", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxStoneGolemTrophy = base.Config.Bind<int>("5. AllMobConfig: Stone Golem", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceStoneGolemTrophy = base.Config.Bind<float>("5. AllMobConfig: Stone Golem", "Chance Drop of Trophy", 0.05f);
            MoreSkills_Config.BaseLevelMultiplierStoneGolemTrophy = base.Config.Bind<bool>("5. AllMobConfig: Stone Golem", "Drop Multiplier per Level of Trophy", false);
            //Surtling
            //Coal
            MoreSkills_Config.BaseMinSurtlingCoal = base.Config.Bind<int>("5. AllMobConfig: Surtling", "Min Drop of Coal", 4);
            MoreSkills_Config.BaseMaxSurtlingCoal = base.Config.Bind<int>("5. AllMobConfig: Surtling", "Max Drop of Coal", 5);
            MoreSkills_Config.BaseChanceSurtlingCoal = base.Config.Bind<float>("5. AllMobConfig: Surtling", "Chance Drop of Coal", 1);
            MoreSkills_Config.BaseLevelMultiplierSurtlingCoal = base.Config.Bind<bool>("5. AllMobConfig: Surtling", "Drop Multiplier per Level of Coal", true);
            //Surtling Core
            MoreSkills_Config.BaseMinSurtlingCore = base.Config.Bind<int>("5. AllMobConfig: Surtling", "Min Drop of Surtling Core", 1);
            MoreSkills_Config.BaseMaxSurtlingCore = base.Config.Bind<int>("5. AllMobConfig: Surtling", "Max Drop of Surtling Core", 1);
            MoreSkills_Config.BaseChanceSurtlingCore = base.Config.Bind<float>("5. AllMobConfig: Surtling", "Chance Drop of Surtling Core", 0.5f);
            MoreSkills_Config.BaseLevelMultiplierSurtlingCore = base.Config.Bind<bool>("5. AllMobConfig: Surtling", "Drop Multiplier per Level of Surtling Core", true);
            //Trophy
            MoreSkills_Config.BaseMinSurtlingTrophy = base.Config.Bind<int>("5. AllMobConfig: Surtling", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxSurtlingTrophy = base.Config.Bind<int>("5. AllMobConfig: Surtling", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceSurtlingTrophy = base.Config.Bind<float>("5. AllMobConfig: Surtling", "Chance Drop of Trophy", 0.05f);
            MoreSkills_Config.BaseLevelMultiplierSurtlingTrophy = base.Config.Bind<bool>("5. AllMobConfig: Surtling", "Drop Multiplier per Level of Trophy", false);
            //Troll
            //Coins
            MoreSkills_Config.BaseMinTrollCoins = base.Config.Bind<int>("5. AllMobConfig: Troll", "Min Drop of Coins", 20);
            MoreSkills_Config.BaseMaxTrollCoins = base.Config.Bind<int>("5. AllMobConfig: Troll", "Max Drop of Coins", 30);
            MoreSkills_Config.BaseChanceTrollCoins = base.Config.Bind<float>("5. AllMobConfig: Troll", "Chance Drop of Coins", 1f);
            MoreSkills_Config.BaseLevelMultiplierTrollCoins = base.Config.Bind<bool>("5. AllMobConfig: Troll", "Drop Multiplier per Level of Coins", true);
            //Troll Hide
            MoreSkills_Config.BaseMinTrollHide = base.Config.Bind<int>("5. AllMobConfig: Troll", "Min Drop of Troll Hide", 5);
            MoreSkills_Config.BaseMaxTrollHide = base.Config.Bind<int>("5. AllMobConfig: Troll", "Max Drop of Troll Hide", 5);
            MoreSkills_Config.BaseChanceTrollHide = base.Config.Bind<float>("5. AllMobConfig: Troll", "Chance Drop of Troll Hide", 1f);
            MoreSkills_Config.BaseLevelMultiplierTrollHide = base.Config.Bind<bool>("5. AllMobConfig: Troll", "Drop Multiplier per Level of Troll Hide", true);
            //Trophy
            MoreSkills_Config.BaseMinTrollTrophy = base.Config.Bind<int>("5. AllMobConfig: Troll", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxTrollTrophy = base.Config.Bind<int>("5. AllMobConfig: Troll", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceTrollTrophy = base.Config.Bind<float>("5. AllMobConfig: Troll", "Chance Drop of Trophy", 0.5f);
            MoreSkills_Config.BaseLevelMultiplierTrollTrophy = base.Config.Bind<bool>("5. AllMobConfig: Troll", "Drop Multiplier per Level of Trophy", false);
            //Wolf
            //Raw Meat
            MoreSkills_Config.BaseMinWolfRawMeat = base.Config.Bind<int>("5. AllMobConfig: Wolf", "Min Drop of Raw Meat", 1);
            MoreSkills_Config.BaseMaxWolfRawMeat = base.Config.Bind<int>("5. AllMobConfig: Wolf", "Max Drop of Raw Meat", 1);
            MoreSkills_Config.BaseChanceWolfRawMeat = base.Config.Bind<float>("5. AllMobConfig: Wolf", "Chance Drop of Raw Meat", 0.4f);
            MoreSkills_Config.BaseLevelMultiplierWolfRawMeat = base.Config.Bind<bool>("5. AllMobConfig: Wolf", "Drop Multiplier per Level of Raw Meat", true);
            //Wolf Pelt
            MoreSkills_Config.BaseMinWolfPelt = base.Config.Bind<int>("5. AllMobConfig: Wolf", "Min Drop of Wolf Pelt", 1);
            MoreSkills_Config.BaseMaxWolfPelt = base.Config.Bind<int>("5. AllMobConfig: Wolf", "Max Drop of Wolf Pelt", 2);
            MoreSkills_Config.BaseChanceWolfPelt = base.Config.Bind<float>("5. AllMobConfig: Wolf", "Chance Drop of Wolf Pelt", 1f);
            MoreSkills_Config.BaseLevelMultiplierWolfPelt = base.Config.Bind<bool>("5. AllMobConfig: Wolf", "Drop Multiplier per Level of Wolf Pelt", true);
            //Wolf Fang
            MoreSkills_Config.BaseMinWolfFang = base.Config.Bind<int>("5. AllMobConfig: Wolf", "Min Drop of Wolf Fang", 1);
            MoreSkills_Config.BaseMaxWolfFang = base.Config.Bind<int>("5. AllMobConfig: Wolf", "Max Drop of Wolf Fang", 1);
            MoreSkills_Config.BaseChanceWolfFang = base.Config.Bind<float>("5. AllMobConfig: Wolf", "Chance Drop of Wolf Fang", 0.4f);
            MoreSkills_Config.BaseLevelMultiplierWolfFang = base.Config.Bind<bool>("5. AllMobConfig: Wolf", "Drop Multiplier per Level of Wolf Fang", true);
            //Trophy
            MoreSkills_Config.BaseMinWolfTrophy = base.Config.Bind<int>("5. AllMobConfig: Wolf", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxWolfTrophy = base.Config.Bind<int>("5. AllMobConfig: Wolf", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceWolfTrophy = base.Config.Bind<float>("5. AllMobConfig: Wolf", "Chance Drop of Trophy", 0.1f);
            MoreSkills_Config.BaseLevelMultiplierWolfTrophy = base.Config.Bind<bool>("5. AllMobConfig: Wolf", "Drop Multiplier per Level of Trophy", false);
            //Wraith
            //Chain
            MoreSkills_Config.BaseMinWraithChain = base.Config.Bind<int>("5. AllMobConfig: Wraith", "Min Drop of Chain", 1);
            MoreSkills_Config.BaseMaxWraithChain = base.Config.Bind<int>("5. AllMobConfig: Wraith", "Max Drop of Chain", 1);
            MoreSkills_Config.BaseChanceWraithChain = base.Config.Bind<float>("5. AllMobConfig: Wraith", "Chance Drop of Chain", 1f);
            MoreSkills_Config.BaseLevelMultiplierWraithChain = base.Config.Bind<bool>("5. AllMobConfig: Wraith", "Drop Multiplier per Level of Chain", true);
            //Trophy
            MoreSkills_Config.BaseMinWraithTrophy = base.Config.Bind<int>("5. AllMobConfig: Wraith", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxWraithTrophy = base.Config.Bind<int>("5. AllMobConfig: Wraith", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceWraithTrophy = base.Config.Bind<float>("5. AllMobConfig: Wraith", "Chance Drop of Trophy", 0.05f);
            MoreSkills_Config.BaseLevelMultiplierWraithTrophy = base.Config.Bind<bool>("5. AllMobConfig: Wraith", "Drop Multiplier per Level of Trophy", false);
            //Eikthyr
            //Hard Antler
            MoreSkills_Config.BaseMinEikthyrHardAntler = base.Config.Bind<int>("6. AllBossConfig: Eikthyr", "Min Drop of Hard Antler", 3);
            MoreSkills_Config.BaseMaxEikthyrHardAntler = base.Config.Bind<int>("6. AllBossConfig: Eikthyr", "Max Drop of Hard Antler", 3);
            MoreSkills_Config.BaseChanceEikthyrHardAntler = base.Config.Bind<float>("6. AllBossConfig: Eikthyr", "Chance Drop of Hard Antler", 1f);
            MoreSkills_Config.BaseLevelMultiplierEikthyrHardAntler = base.Config.Bind<bool>("6. AllBossConfig: Eikthyr", "Drop Multiplier per Level of Hard Antler", false);
            //Trophy
            MoreSkills_Config.BaseMinEikthyrTrophy = base.Config.Bind<int>("6. AllBossConfig: Eikthyr", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxEikthyrTrophy = base.Config.Bind<int>("6. AllBossConfig: Eikthyr", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceEikthyrTrophy = base.Config.Bind<float>("6. AllBossConfig: Eikthyr", "Chance Drop of Trophy", 1f);
            MoreSkills_Config.BaseLevelMultiplierEikthyrTrophy = base.Config.Bind<bool>("6. AllBossConfig: Eikthyr", "Drop Multiplier per Level of Trophy", false);
            //The Elder
            //Crypt Key
            MoreSkills_Config.BaseMingdkingCryptKey = base.Config.Bind<int>("6. AllBossConfig: The Elder", "Min Drop of Crypt Key", 1);
            MoreSkills_Config.BaseMaxgdkingCryptKey = base.Config.Bind<int>("6. AllBossConfig: The Elder", "Max Drop of Crypt Key", 1);
            MoreSkills_Config.BaseChancegdkingCryptKey = base.Config.Bind<float>("6. AllBossConfig: The Elder", "Chance Drop of Crypt Key", 1f);
            MoreSkills_Config.BaseLevelMultipliergdkingCryptKey = base.Config.Bind<bool>("6. AllBossConfig: The Elder", "Drop Multiplier per Level of Crypt Key", false);
            //Trophy
            MoreSkills_Config.BaseMingdkingTrophy = base.Config.Bind<int>("6. AllBossConfig: The Elder", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxgdkingTrophy = base.Config.Bind<int>("6. AllBossConfig: The Elder", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChancegdkingTrophy = base.Config.Bind<float>("6. AllBossConfig: The Elder", "Chance Drop of Trophy", 1f);
            MoreSkills_Config.BaseLevelMultipliergdkingTrophy = base.Config.Bind<bool>("6. AllBossConfig: The Elder", "Drop Multiplier per Level of Trophy", false);
            //Bonemass
            //WishBone
            MoreSkills_Config.BaseMinBonemassWishbone = base.Config.Bind<int>("6. AllBossConfig: Bonemass", "Min Drop of WishBone", 1);
            MoreSkills_Config.BaseMaxBonemassWishbone = base.Config.Bind<int>("6. AllBossConfig: Bonemass", "Max Drop of WishBone", 1);
            MoreSkills_Config.BaseChanceBonemassWishbone = base.Config.Bind<float>("6. AllBossConfig: Bonemass", "Chance Drop of WishBone", 1f);
            MoreSkills_Config.BaseLevelMultiplierBonemassWishbone = base.Config.Bind<bool>("6. AllBossConfig: Bonemass", "Drop Multiplier per Level of WishBone", false);
            //Trophy
            MoreSkills_Config.BaseMinBonemassTrophy = base.Config.Bind<int>("6. AllBossConfig: Bonemass", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxBonemassTrophy = base.Config.Bind<int>("6. AllBossConfig: Bonemass", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceBonemassTrophy = base.Config.Bind<float>("6. AllBossConfig: Bonemass", "Chance Drop of Trophy", 1f);
            MoreSkills_Config.BaseLevelMultiplierBonemassTrophy = base.Config.Bind<bool>("6. AllBossConfig: Bonemass", "Drop Multiplier per Level of Trophy", false);
            //Dragon
            //Dragon Tear
            MoreSkills_Config.BaseMinDragonTear = base.Config.Bind<int>("6. AllBossConfig: Dragon", "Min Drop of Dragon Tear", 10);
            MoreSkills_Config.BaseMaxDragonTear = base.Config.Bind<int>("6. AllBossConfig: Dragon", "Max Drop of Dragon Tear", 10);
            MoreSkills_Config.BaseChanceDragonTear = base.Config.Bind<float>("6. AllBossConfig: Dragon", "Chance Drop of Dragon Tear", 1f);
            MoreSkills_Config.BaseLevelMultiplierDragonTear = base.Config.Bind<bool>("6. AllBossConfig: Dragon", "Drop Multiplier per Level of Dragon Tear", false);
            //Trophy
            MoreSkills_Config.BaseMinDragonQueenTrophy = base.Config.Bind<int>("6. AllBossConfig: Dragon", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxDragonQueenTrophy = base.Config.Bind<int>("6. AllBossConfig: Dragon", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceDragonQueenTrophy = base.Config.Bind<float>("6. AllBossConfig: Dragon", "Chance Drop of Trophy", 1f);
            MoreSkills_Config.BaseLevelMultiplierDragonQueenTrophy = base.Config.Bind<bool>("6. AllBossConfig: Dragon", "Drop Multiplier per Level of Trophy", false);
            //Goblin King
            //Yagluth
            MoreSkills_Config.BaseMinGoblinKingYagluthDrop = base.Config.Bind<int>("6. AllBossConfig: GoblinKing", "Min Drop of Yagluth", 1);
            MoreSkills_Config.BaseMaxGoblinKingYagluthDrop = base.Config.Bind<int>("6. AllBossConfig: GoblinKing", "Max Drop of Yagluth", 1);
            MoreSkills_Config.BaseChanceGoblinKingYagluthDrop = base.Config.Bind<float>("6. AllBossConfig: GoblinKing", "Chance Drop of Yagluth", 1f);
            MoreSkills_Config.BaseLevelMultiplierGoblinKingYagluthDrop = base.Config.Bind<bool>("6. AllBossConfig: GoblinKing", "Drop Multiplier per Level of Yagluth", false);
            //Trophy
            MoreSkills_Config.BaseMinGoblinKingTrophy = base.Config.Bind<int>("6. AllBossConfig: GoblinKing", "Min Drop of Trophy", 1);
            MoreSkills_Config.BaseMaxGoblinKingTrophy = base.Config.Bind<int>("6. AllBossConfig: GoblinKing", "Max Drop of Trophy", 1);
            MoreSkills_Config.BaseChanceGoblinKingTrophy = base.Config.Bind<float>("6. AllBossConfig: GoblinKing", "Chance Drop of Trophy", 1f);
            MoreSkills_Config.BaseLevelMultiplierGoblinKingTrophy = base.Config.Bind<bool>("6. AllBossConfig: GoblinKing", "Drop Multiplier per Level of Trophy", false);
            
            //Inject.Strength
            if (EnableStrengthMod.Value)
                SkillInjector.RegisterNewSkill(700, "Strength", "Able to carry more and with higher numbers", 1f, SkillIcons.Load_StrengthIcon(), Skills.SkillType.Unarmed);
            if (EnableHealthMod.Value)
                SkillInjector.RegisterNewSkill(701, "Vitality", "Endure and gain resistance as you recieve damage", 1f, SkillIcons.Load_VitalityIcon(), Skills.SkillType.Unarmed);
            if (EnableSailingMod.Value)
                SkillInjector.RegisterNewSkill(702, "Sailing", "You become a true viking with a great control of the boat in your adventures through seas", 1f, SkillIcons.Load_SailingIcon(), Skills.SkillType.Unarmed);
            if (EnableCraftingSkill.Value)
                SkillInjector.RegisterNewSkill(703, "Crafting", "You get better at this thing of crafting. You can probably even become more efficient...", 1f, SkillIcons.Load_CraftingIcon(), Skills.SkillType.Unarmed);
            if (EnableHuntingSkill.Value)
                SkillInjector.RegisterNewSkill(704, "Hunting", "You're gonna get better at gaining more resources when you kill something.", 1f, SkillIcons.Load_HuntingIcon(), Skills.SkillType.Unarmed);

            //--
            new Harmony("com.guiriguy.moreskills").PatchAll();

            //Logs
            if (!MoreSkills_Config.EnableStrengthMod.Value)
                Debug.LogWarning("[MoreSkills]: Strength Mod Disabled");
            else
            {
                if (!MoreSkills_Config.EnableWeightMod.Value)
                    Debug.LogWarning("[MoreSkills]: Strength/Weight Mod Disabled");
                else
                    Debug.LogWarning("[MoreSkills]: Strength/Weight Mod Enabled");
                if (!MoreSkills_Config.EnableStrengthStaminaMod.Value)
                    Debug.LogWarning("[MoreSkills]: Strength/Stamina Mod Disabled");
                else
                    Debug.LogWarning("[MoreSkills]: Strength/Stamina Mod Enabled");
            }
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
            {
                Debug.LogWarning("[MoreSkills]: Swim Mod Enabled");
                if (!MoreSkills_Config.EnableSwimSpeedMod.Value)
                    Debug.LogWarning("[MoreSkills]: Swim/Speed Mod Disabled");
                else
                    Debug.LogWarning("[MoreSkills]: Swim/Speed Mod Enabled");
                if (!MoreSkills_Config.EnableSwimStaminaMod.Value)
                    Debug.LogWarning("[MoreSkills]: Swim/Stamina Mod Disabled");
                else
                    Debug.LogWarning("[MoreSkills]: Swim/Stamina Mod Enabled");
            }
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
                Debug.LogWarning("[MoreSkills]: Crafting Mod Enabled");            
            if (!MoreSkills_Config.EnablePickaxeDropMod.Value)
                Debug.LogWarning("[MoreSkills]: Pickaxe Drop Mod Disabled");
            else
                Debug.LogWarning("[MoreSkills]: Pickaxe Drop Mod Enabled");
            if (!MoreSkills_Config.EnableHuntingSkill.Value)
                Debug.LogWarning("[MoreSkills]: Hunting Skill Mod Disabled");
            else
            {
                Debug.LogWarning("[MoreSkills]: Hunting Skill Mod Enabled");
                if (!MoreSkills_Config.EnableHuntingNormalMobsMod.Value)
                    Debug.LogWarning("[MoreSkills]: Hunting/Normal Mobs Mod Disabled");
                else
                    Debug.LogWarning("[MoreSkills]: Hunting/Normal Mobs Mod Enabled");
                if (!MoreSkills_Config.EnableHuntingBossMod.Value)
                    Debug.LogWarning("[MoreSkills]: Hunting/Boss Mobs Mod Disabled");
                else
                    Debug.LogWarning("[MoreSkills]: Hunting/Boss Mobs Mod Enabled");
                if (!MoreSkills_Config.EnableHuntingTrophyMod.Value)
                    Debug.LogWarning("[MoreSkills]: Hunting/Trophy Mod Disabled");
                else
                    Debug.LogWarning("[MoreSkills]: Hunting/Trophy Mod Enabled");
                if (!MoreSkills_Config.EnableHuntingMinMaxMod.Value)
                    Debug.LogWarning("[MoreSkills]: Hunting/MinMax Mod Disabled");
                else
                    Debug.LogWarning("[MoreSkills]: Hunting/MinMax Mobs Mod Enabled");
                if (!MoreSkills_Config.EnableHuntingChanceMod.Value)
                    Debug.LogWarning("[MoreSkills]: Hunting/Chance Mod Disabled");
                else
                    Debug.LogWarning("[MoreSkills]: Hunting/Chance Mod Enabled");
                if (!MoreSkills_Config.EnableHuntingBlobSpawn.Value)
                    Debug.LogWarning("[MoreSkills]: Hunting/Blob Spawn Mod Disabled");
                else
                    Debug.LogWarning("[MoreSkills]: Hunting/Blob Spawn Mod Enabled");
            }
            if (!MoreSkills_Config.EnableWoodCuttingDropMod.Value)
                Debug.LogWarning("[MoreSkills]: WoodCutting Drop Mod Disabled");
            else
                Debug.LogWarning("[MoreSkills]: WoodCutting Drop Mod Enabled");
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

        public static ConfigEntry<float> PickaxeMultiplier;

        public static ConfigEntry<float> CraftingLevelMultiplier;

        public static ConfigEntry<int> CraftingMiddleLevel;

        public static ConfigEntry<float> CraftingLevelDivider;

        public static ConfigEntry<float> SwimStaminaMultiplier;

        public static ConfigEntry<float> StrengthStaminaMultiplier;

        public static ConfigEntry<float> HuntingDropMultiplier;

        public static ConfigEntry<float> WoodCuttingMultiplier;

        //Skill Increases Multpliers

        public static ConfigEntry<float> StrengthSkillIncreaseMultiplier;

        public static ConfigEntry<float> VitalitySkillIncreaseMultiplier;

        public static ConfigEntry<float> SailingSkillIncreaseMultiplier;

        public static ConfigEntry<float> CraftingSkillIncreaseMultiplier;

        public static ConfigEntry<float> HuntingSkillMultiplier;

        //Enables

        public static ConfigEntry<bool> EnableWeightMod;

        public static ConfigEntry<bool> EnableHealthMod;

        public static ConfigEntry<bool> EnableCrouchMod;

        public static ConfigEntry<bool> EnableSwimMod;

        public static ConfigEntry<bool> EnableSailingMod;

        public static ConfigEntry<bool> EnableShipAcceleration;

        public static ConfigEntry<bool> EnableShipCrew;

        public static ConfigEntry<bool> EnableCraftingSkill;

        public static ConfigEntry<bool> EnablePickaxeDropMod;

        public static ConfigEntry<bool> EnablePickaxeChanceMod;

        public static ConfigEntry<bool> EnableSwimSpeedMod;

        public static ConfigEntry<bool> EnableSwimStaminaMod;

        public static ConfigEntry<bool> EnableStrengthMod;

        public static ConfigEntry<bool> EnableStrengthStaminaMod;

        public static ConfigEntry<bool> EnableHuntingSkill;

        public static ConfigEntry<bool> EnableHuntingMinMaxMod;

        public static ConfigEntry<bool> EnableHuntingChanceMod;

        public static ConfigEntry<bool> EnableHuntingBossMod;

        public static ConfigEntry<bool> EnableHuntingNormalMobsMod;

        public static ConfigEntry<bool> EnableHuntingTrophyMod;

        public static ConfigEntry<bool> EnableHuntingBlobSpawn;

        public static ConfigEntry<bool> EnableWoodCuttingDropMod;

        //Test

        public static Dictionary<string, Texture2D> cachedTextures = new Dictionary<string, Texture2D>();

        //Skills Types

        public const int StrengthSkill_Type = 700;

        public const int VitalitySkill_Type = 701;

        public const int SailingSkill_Type = 702;

        public const int CraftingSkill_Type = 703;

        public const int HuntingSkill_Type = 704;

        //Drops Bases
            //Pickaxe Mod

            public static ConfigEntry<float> BaseStoneChance;

            public static ConfigEntry<float> BaseCopperOreChance;

            public static ConfigEntry<float> BaseTinOreChance;

            public static ConfigEntry<float> BaseIronScrapChance;

            public static ConfigEntry<float> BaseWitheredBoneChance;

            public static ConfigEntry<float> BaseSilverOreChance;

            public static ConfigEntry<float> BaseObsidianChance;

            public static ConfigEntry<float> BaseChitinChance;

            //Hunting Skill

            public static ConfigEntry<float> BaseLeatherScrapsChance;

            public static ConfigEntry<float> BaseFeathersChance;

            public static ConfigEntry<float> BaseGuckChance;

            //WoodCutting Mod

            public static ConfigEntry<float> BaseWoodChance;

            public static ConfigEntry<float> BaseFineWoodChance;

            public static ConfigEntry<float> BaseRoundLogChance;

            public static ConfigEntry<float> BaseResinChance;

            public static ConfigEntry<float> BaseBeechSeedChance;

            public static ConfigEntry<float> BasePineConeChance;

            public static ConfigEntry<float> BaseFirConeChance;

            public static ConfigEntry<float> BaseElderBarkChance;

        /*//Rocks Bases          OLD

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

        public static ConfigEntry<float> BaseChanceMudPile;*/

        //Mobs Data Bases
        //Blob
        //Ooze
        public static ConfigEntry<int> BaseMinBlobOoze;
                public static ConfigEntry<int> BaseMaxBlobOoze;
                public static ConfigEntry<float> BaseChanceBlobOoze;
                public static ConfigEntry<bool> BaseLevelMultiplierBlobOoze;
                //TrophyBlob
                public static ConfigEntry<int> BaseMinBlobTrophy;
                public static ConfigEntry<int> BaseMaxBlobTrophy;
                public static ConfigEntry<float> BaseChanceBlobTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierBlobTrophy;
            //Blob Elite
                //Ooze
                public static ConfigEntry<int> BaseMinBlobEliteOoze;
                public static ConfigEntry<int> BaseMaxBlobEliteOoze;
                public static ConfigEntry<float> BaseChanceBlobEliteOoze;
                public static ConfigEntry<bool> BaseLevelMultiplierBlobEliteOoze;
                //Iron Scrap
                public static ConfigEntry<int> BaseMinBlobEliteIronScrap;
                public static ConfigEntry<int> BaseMaxBlobEliteIronScrap;
                public static ConfigEntry<float> BaseChanceBlobEliteIronScrap;
                public static ConfigEntry<bool> BaseLevelMultiplierBlobEliteIronScrap;
                //Blob
                public static ConfigEntry<int> BaseMinBlobEliteBlob;
                public static ConfigEntry<int> BaseMaxBlobEliteBlob;
                public static ConfigEntry<float> BaseChanceBlobEliteBlob;
                public static ConfigEntry<bool> BaseLevelMultiplierBlobEliteBlob;
                //Trophy same as blob
            //Boar
                //RawMeat
                public static ConfigEntry<int> BaseMinBoarRawMeat;
                public static ConfigEntry<int> BaseMaxBoarRawMeat;
                public static ConfigEntry<float> BaseChanceBoarRawMeat;
                public static ConfigEntry<bool> BaseLevelMultiplierBoarRawMeat;
                //LeatherScraps
                public static ConfigEntry<int> BaseMinBoarLeatherScraps;
                public static ConfigEntry<int> BaseMaxBoarLeatherScraps;
                public static ConfigEntry<float> BaseChanceBoarLeatherScraps;
                public static ConfigEntry<bool> BaseLevelMultiplierBoarLeatherScraps;
                //Trophy
                public static ConfigEntry<int> BaseMinBoarTrophy;
                public static ConfigEntry<int> BaseMaxBoarTrophy;
                public static ConfigEntry<float> BaseChanceBoarTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierBoarTrophy;
            //Deathsquito
                //Needle
                public static ConfigEntry<int> BaseMinDeathsquitoNeedle;
                public static ConfigEntry<int> BaseMaxDeathsquitoNeedle;
                public static ConfigEntry<float> BaseChanceDeathsquitoNeedle;
                public static ConfigEntry<bool> BaseLevelMultiplierDeathsquitoNeedle;
                //Trophy
                public static ConfigEntry<int> BaseMinDeathsquitoTrophy;
                public static ConfigEntry<int> BaseMaxDeathsquitoTrophy;
                public static ConfigEntry<float> BaseChanceDeathsquitoTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierDeathsquitoTrophy;
            //Deer
                //RawMeat
                public static ConfigEntry<int> BaseMinDeerRawMeat;
                public static ConfigEntry<int> BaseMaxDeerRawMeat;
                public static ConfigEntry<float> BaseChanceDeerRawMeat;
                public static ConfigEntry<bool> BaseLevelMultiplierDeerRawMeat;
                //DeerHide
                public static ConfigEntry<int> BaseMinDeerHide;
                public static ConfigEntry<int> BaseMaxDeerHide;
                public static ConfigEntry<float> BaseChanceDeerHide;
                public static ConfigEntry<bool> BaseLevelMultiplierDeerHide;
                //Trophy
                public static ConfigEntry<int> BaseMinDeerTrophy;
                public static ConfigEntry<int> BaseMaxDeerTrophy;
                public static ConfigEntry<float> BaseChanceDeerTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierDeerTrophy;
            //Drake
                //FreezeGland
                public static ConfigEntry<int> BaseMinDrakeFreezeGland;
                public static ConfigEntry<int> BaseMaxDrakeFreezeGland;
                public static ConfigEntry<float> BaseChanceDrakeFreezeGland;
                public static ConfigEntry<bool> BaseLevelMultiplierDrakeFreezeGland;
                //TrophyHatchling
                public static ConfigEntry<int> BaseMinDrakeTrophy;
                public static ConfigEntry<int> BaseMaxDrakeTrophy;
                public static ConfigEntry<float> BaseChanceDrakeTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierDrakeTrophy;
            //Draugr
                //Entrails
                public static ConfigEntry<int> BaseMinDraugrEntrails;
                public static ConfigEntry<int> BaseMaxDraugrEntrails;
                public static ConfigEntry<float> BaseChanceDraugrEntrails;
                public static ConfigEntry<bool> BaseLevelMultiplierDraugrEntrails;
                //Trophy
                public static ConfigEntry<int> BaseMinDraugrTrophy;
                public static ConfigEntry<int> BaseMaxDraugrTrophy;
                public static ConfigEntry<float> BaseChanceDraugrTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierDraugrTrophy;
            //Draugr Elite
                //Entrails
                public static ConfigEntry<int> BaseMinDraugrEliteEntrails;
                public static ConfigEntry<int> BaseMaxDraugrEliteEntrails;
                public static ConfigEntry<float> BaseChanceDraugrEliteEntrails;
                public static ConfigEntry<bool> BaseLevelMultiplierDraugrEliteEntrails;
                //Trophy
                public static ConfigEntry<int> BaseMinDraugrEliteTrophy;
                public static ConfigEntry<int> BaseMaxDraugrEliteTrophy;
                public static ConfigEntry<float> BaseChanceDraugrEliteTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierDraugrEliteTrophy;
            //Fenring
                //WolfFang
                public static ConfigEntry<int> BaseMinFenringWolfFang;
                public static ConfigEntry<int> BaseMaxFenringWolfFang;
                public static ConfigEntry<float> BaseChanceFenringWolfFang;
                public static ConfigEntry<bool> BaseLevelMultiplierFenringWolfFang;
                //Trophy
                public static ConfigEntry<int> BaseMinFenringEliteTrophy;
                public static ConfigEntry<int> BaseMaxFenringEliteTrophy;
                public static ConfigEntry<float> BaseChanceFenringEliteTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierFenringEliteTrophy;
            //Goblin
                //Coins
                public static ConfigEntry<int> BaseMinGoblinCoins;
                public static ConfigEntry<int> BaseMaxGoblinCoins;
                public static ConfigEntry<float> BaseChanceGoblinCoins;
                public static ConfigEntry<bool> BaseLevelMultiplierGoblinCoins;
                //Black Metal Scrap
                public static ConfigEntry<int> BaseMinGoblinBMS;
                public static ConfigEntry<int> BaseMaxGoblinBMS;
                public static ConfigEntry<float> BaseChanceGoblinBMS;
                public static ConfigEntry<bool> BaseLevelMultiplierGoblinBMS;
                //Trophy
                public static ConfigEntry<int> BaseMinGoblinTrophy;
                public static ConfigEntry<int> BaseMaxGoblinTrophy;
                public static ConfigEntry<float> BaseChanceGoblinTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierGoblinTrophy;
            //GoblinBrute
                //Coins
                public static ConfigEntry<int> BaseMinGoblinBruteCoins;
                public static ConfigEntry<int> BaseMaxGoblinBruteCoins;
                public static ConfigEntry<float> BaseChanceGoblinBruteCoins;
                public static ConfigEntry<bool> BaseLevelMultiplierGoblinBruteCoins;
                //Black Metal Scrap
                public static ConfigEntry<int> BaseMinGoblinBruteBMS;
                public static ConfigEntry<int> BaseMaxGoblinBruteBMS;
                public static ConfigEntry<float> BaseChanceGoblinBruteBMS;
                public static ConfigEntry<bool> BaseLevelMultiplierGoblinBruteBMS;
                //Goblin Totem
                public static ConfigEntry<int> BaseMinGoblinBruteTotem;
                public static ConfigEntry<int> BaseMaxGoblinBruteTotem;
                public static ConfigEntry<float> BaseChanceGoblinBruteTotem;
                public static ConfigEntry<bool> BaseLevelMultiplierGoblinBruteTotem;
                //Trophy
                public static ConfigEntry<int> BaseMinGoblinBruteTrophy;
                public static ConfigEntry<int> BaseMaxGoblinBruteTrophy;
                public static ConfigEntry<float> BaseChanceGoblinBruteTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierGoblinBruteTrophy;
            //GoblinShaman
                //Coins
                public static ConfigEntry<int> BaseMinGoblinShamanCoins;
                public static ConfigEntry<int> BaseMaxGoblinShamanCoins;
                public static ConfigEntry<float> BaseChanceGoblinShamanCoins;
                public static ConfigEntry<bool> BaseLevelMultiplierGoblinShamanCoins;
                //Black Metal Scrap
                public static ConfigEntry<int> BaseMinGoblinShamanBMS;
                public static ConfigEntry<int> BaseMaxGoblinShamanBMS;
                public static ConfigEntry<float> BaseChanceGoblinShamanBMS;
                public static ConfigEntry<bool> BaseLevelMultiplierGoblinShamanBMS;
                //Trophy
                public static ConfigEntry<int> BaseMinGoblinShamanTrophy;
                public static ConfigEntry<int> BaseMaxGoblinShamanTrophy;
                public static ConfigEntry<float> BaseChanceGoblinShamanTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierGoblinShamanTrophy;
            //Greydwarf
                //GreydwarfEyes
                public static ConfigEntry<int> BaseMinGreydwarfEyes;
                public static ConfigEntry<int> BaseMaxGreydwarfEyes;
                public static ConfigEntry<float> BaseChanceGreydwarfEyes;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfEyes;
                //Resin
                public static ConfigEntry<int> BaseMinGreydwarfResin;
                public static ConfigEntry<int> BaseMaxGreydwarfResin;
                public static ConfigEntry<float> BaseChanceGreydwarfResin;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfResin;
                //Stone
                public static ConfigEntry<int> BaseMinGreydwarfStone;
                public static ConfigEntry<int> BaseMaxGreydwarfStone;
                public static ConfigEntry<float> BaseChanceGreydwarfStone;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfStone;
                //Wood
                public static ConfigEntry<int> BaseMinGreydwarfWood;
                public static ConfigEntry<int> BaseMaxGreydwarfWood;
                public static ConfigEntry<float> BaseChanceGreydwarfWood;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfWood;
                //Trophy
                public static ConfigEntry<int> BaseMinGreydwarfTrophy;
                public static ConfigEntry<int> BaseMaxGreydwarfTrophy;
                public static ConfigEntry<float> BaseChanceGreydwarfTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfTrophy;
            //GreydwarfBrute
                //GreydwarfEyes
                public static ConfigEntry<int> BaseMinGreydwarfBruteEyes;
                public static ConfigEntry<int> BaseMaxGreydwarfBruteEyes;
                public static ConfigEntry<float> BaseChanceGreydwarfBruteEyes;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfBruteEyes;
                //Dandelion
                public static ConfigEntry<int> BaseMinGreydwarfBruteDandelion;
                public static ConfigEntry<int> BaseMaxGreydwarfBruteDandelion;
                public static ConfigEntry<float> BaseChanceGreydwarfBruteDandelion;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfBruteDandelion;
                //Stone
                public static ConfigEntry<int> BaseMinGreydwarfBruteStone;
                public static ConfigEntry<int> BaseMaxGreydwarfBruteStone;
                public static ConfigEntry<float> BaseChanceGreydwarfBruteStone;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfBruteStone;
                //Wood
                public static ConfigEntry<int> BaseMinGreydwarfBruteWood;
                public static ConfigEntry<int> BaseMaxGreydwarfBruteWood;
                public static ConfigEntry<float> BaseChanceGreydwarfBruteWood;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfBruteWood;
                //AncientSeed
                public static ConfigEntry<int> BaseMinGreydwarfBruteAncientSeed;
                public static ConfigEntry<int> BaseMaxGreydwarfBruteAncientSeed;
                public static ConfigEntry<float> BaseChanceGreydwarfBruteAncientSeed;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfBruteAncientSeed;
                //Trophy
                public static ConfigEntry<int> BaseMinGreydwarfBruteTrophy;
                public static ConfigEntry<int> BaseMaxGreydwarfBruteTrophy;
                public static ConfigEntry<float> BaseChanceGreydwarfBruteTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfBruteTrophy;
            //GreydwarfShaman
                //GreydwarfEyes
                public static ConfigEntry<int> BaseMinGreydwarfShamanEyes;
                public static ConfigEntry<int> BaseMaxGreydwarfShamanEyes;
                public static ConfigEntry<float> BaseChanceGreydwarfShamanEyes;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfShamanEyes;
                //Resin
                public static ConfigEntry<int> BaseMinGreydwarfShamanResin;
                public static ConfigEntry<int> BaseMaxGreydwarfShamanResin;
                public static ConfigEntry<float> BaseChanceGreydwarfShamanResin;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfShamanResin;
                //Wood
                public static ConfigEntry<int> BaseMinGreydwarfShamanWood;
                public static ConfigEntry<int> BaseMaxGreydwarfShamanWood;
                public static ConfigEntry<float> BaseChanceGreydwarfShamanWood;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfShamanWood;
                //Trophy
                public static ConfigEntry<int> BaseMinGreydwarfShamanTrophy;
                public static ConfigEntry<int> BaseMaxGreydwarfShamanTrophy;
                public static ConfigEntry<float> BaseChanceGreydwarfShamanTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierGreydwarfShamanTrophy;
            //Greyling
                //Resin
                public static ConfigEntry<int> BaseMinGreylingResin;
                public static ConfigEntry<int> BaseMaxGreylingResin;
                public static ConfigEntry<float> BaseChanceGreylingResin;
                public static ConfigEntry<bool> BaseLevelMultiplierGreylingResin;
                //Leech
                //Bloodbag
                public static ConfigEntry<int> BaseMinLeechBloodBag;
                public static ConfigEntry<int> BaseMaxLeechBloodBag;
                public static ConfigEntry<float> BaseChanceLeechBloodBag;
                public static ConfigEntry<bool> BaseLevelMultiplierLeechBloodBag;
                //Trophy
                public static ConfigEntry<int> BaseMinLeechTrophy;
                public static ConfigEntry<int> BaseMaxLeechTrophy;
                public static ConfigEntry<float> BaseChanceLeechTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierLeechTrophy;
            //Lox
                //Meat
                public static ConfigEntry<int> BaseMinLoxMeat;
                public static ConfigEntry<int> BaseMaxLoxMeat;
                public static ConfigEntry<float> BaseChanceLoxMeat;
                public static ConfigEntry<bool> BaseLevelMultiplierLoxMeat;
                //Pelt
                public static ConfigEntry<int> BaseMinLoxPelt;
                public static ConfigEntry<int> BaseMaxLoxPelt;
                public static ConfigEntry<float> BaseChanceLoxPelt;
                public static ConfigEntry<bool> BaseLevelMultiplierLoxPelt;
                //Trophy
                public static ConfigEntry<int> BaseMinLoxTrophy;
                public static ConfigEntry<int> BaseMaxLoxTrophy;
                public static ConfigEntry<float> BaseChanceLoxTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierLoxTrophy;
            //Neck
                //Tail
                public static ConfigEntry<int> BaseMinNeckTail;
                public static ConfigEntry<int> BaseMaxNeckTail;
                public static ConfigEntry<float> BaseChanceNeckTail;
                public static ConfigEntry<bool> BaseLevelMultiplierNeckTail;
                //Trophy
                public static ConfigEntry<int> BaseMinNeckTrophy;
                public static ConfigEntry<int> BaseMaxNeckTrophy;
                public static ConfigEntry<float> BaseChanceNeckTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierNeckTrophy;
            //Serpent
                //Meat
                public static ConfigEntry<int> BaseMinSerpentMeat;
                public static ConfigEntry<int> BaseMaxSerpentMeat;
                public static ConfigEntry<float> BaseChanceSerpentMeat;
                public static ConfigEntry<bool> BaseLevelMultiplierSerpentMeat;
                //Scale
                public static ConfigEntry<int> BaseMinSerpentScale;
                public static ConfigEntry<int> BaseMaxSerpentScale;
                public static ConfigEntry<float> BaseChanceSerpentScale;
                public static ConfigEntry<bool> BaseLevelMultiplierSerpentScale;
                //Trophy
                public static ConfigEntry<int> BaseMinSerpentTrophy;
                public static ConfigEntry<int> BaseMaxSerpentTrophy;
                public static ConfigEntry<float> BaseChanceSerpentTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierSerpentTrophy;
            //Skeleton
                //BoneFragments
                public static ConfigEntry<int> BaseMinSkeletonBones;
                public static ConfigEntry<int> BaseMaxSkeletonBones;
                public static ConfigEntry<float> BaseChanceSkeletonBones;
                public static ConfigEntry<bool> BaseLevelMultiplierSkeletonBones;
                //Trophy
                public static ConfigEntry<int> BaseMinSkeletonTrophy;
                public static ConfigEntry<int> BaseMaxSkeletonTrophy;
                public static ConfigEntry<float> BaseChanceSkeletonTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierSkeletonTrophy;
            //SkeletonPoison
                //BoneFragments
                public static ConfigEntry<int> BaseMinSkeletonPoisonBones;
                public static ConfigEntry<int> BaseMaxSkeletonPoisonBones;
                public static ConfigEntry<float> BaseChanceSkeletonPoisonBones;
                public static ConfigEntry<bool> BaseLevelMultiplierSkeletonPoisonBones;
                //Trophy
                public static ConfigEntry<int> BaseMinSkeletonPoisonTrophy;
                public static ConfigEntry<int> BaseMaxSkeletonPoisonTrophy;
                public static ConfigEntry<float> BaseChanceSkeletonPoisonTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierSkeletonPoisonTrophy;
            //StoneGolem
                //Stone
                public static ConfigEntry<int> BaseMinStoneGolemStone;
                public static ConfigEntry<int> BaseMaxStoneGolemStone;
                public static ConfigEntry<float> BaseChanceStoneGolemStone;
                public static ConfigEntry<bool> BaseLevelMultiplierStoneGolemStone;
                //Crystal
                public static ConfigEntry<int> BaseMinStoneGolemCrystal;
                public static ConfigEntry<int> BaseMaxStoneGolemCrystal;
                public static ConfigEntry<float> BaseChanceStoneGolemCrystal;
                public static ConfigEntry<bool> BaseLevelMultiplierStoneGolemCrystal;
                //Trophy
                public static ConfigEntry<int> BaseMinStoneGolemTrophy;
                public static ConfigEntry<int> BaseMaxStoneGolemTrophy;
                public static ConfigEntry<float> BaseChanceStoneGolemTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierStoneGolemTrophy;
            //Surtling
                //Coal
                public static ConfigEntry<int> BaseMinSurtlingCoal;
                public static ConfigEntry<int> BaseMaxSurtlingCoal;
                public static ConfigEntry<float> BaseChanceSurtlingCoal;
                public static ConfigEntry<bool> BaseLevelMultiplierSurtlingCoal;
                //SurtlingCore
                public static ConfigEntry<int> BaseMinSurtlingCore;
                public static ConfigEntry<int> BaseMaxSurtlingCore;
                public static ConfigEntry<float> BaseChanceSurtlingCore;
                public static ConfigEntry<bool> BaseLevelMultiplierSurtlingCore;
                //Trophy
                public static ConfigEntry<int> BaseMinSurtlingTrophy;
                public static ConfigEntry<int> BaseMaxSurtlingTrophy;
                public static ConfigEntry<float> BaseChanceSurtlingTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierSurtlingTrophy;
            //Troll
                //Coins
                public static ConfigEntry<int> BaseMinTrollCoins;
                public static ConfigEntry<int> BaseMaxTrollCoins;
                public static ConfigEntry<float> BaseChanceTrollCoins;
                public static ConfigEntry<bool> BaseLevelMultiplierTrollCoins;
                //TrollHide
                public static ConfigEntry<int> BaseMinTrollHide;
                public static ConfigEntry<int> BaseMaxTrollHide;
                public static ConfigEntry<float> BaseChanceTrollHide;
                public static ConfigEntry<bool> BaseLevelMultiplierTrollHide;
                //Trophy
                public static ConfigEntry<int> BaseMinTrollTrophy;
                public static ConfigEntry<int> BaseMaxTrollTrophy;
                public static ConfigEntry<float> BaseChanceTrollTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierTrollTrophy;
            //Wolf
                //RawMeat
                public static ConfigEntry<int> BaseMinWolfRawMeat;
                public static ConfigEntry<int> BaseMaxWolfRawMeat;
                public static ConfigEntry<float> BaseChanceWolfRawMeat;
                public static ConfigEntry<bool> BaseLevelMultiplierWolfRawMeat;
                //WolfPelt
                public static ConfigEntry<int> BaseMinWolfPelt;
                public static ConfigEntry<int> BaseMaxWolfPelt;
                public static ConfigEntry<float> BaseChanceWolfPelt;
                public static ConfigEntry<bool> BaseLevelMultiplierWolfPelt;
                //WolfFang
                public static ConfigEntry<int> BaseMinWolfFang;
                public static ConfigEntry<int> BaseMaxWolfFang;
                public static ConfigEntry<float> BaseChanceWolfFang;
                public static ConfigEntry<bool> BaseLevelMultiplierWolfFang;
                //Trophy
                public static ConfigEntry<int> BaseMinWolfTrophy;
                public static ConfigEntry<int> BaseMaxWolfTrophy;
                public static ConfigEntry<float> BaseChanceWolfTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierWolfTrophy;
            //Wraith
                //RawMeat
                public static ConfigEntry<int> BaseMinWraithChain;
                public static ConfigEntry<int> BaseMaxWraithChain;
                public static ConfigEntry<float> BaseChanceWraithChain;
                public static ConfigEntry<bool> BaseLevelMultiplierWraithChain;
                //Trophy
                public static ConfigEntry<int> BaseMinWraithTrophy;
                public static ConfigEntry<int> BaseMaxWraithTrophy;
                public static ConfigEntry<float> BaseChanceWraithTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierWraithTrophy;
            //Eikthyr
                //HardAntler
                public static ConfigEntry<int> BaseMinEikthyrHardAntler;
                public static ConfigEntry<int> BaseMaxEikthyrHardAntler;
                public static ConfigEntry<float> BaseChanceEikthyrHardAntler;
                public static ConfigEntry<bool> BaseLevelMultiplierEikthyrHardAntler;
                //Trophy
                public static ConfigEntry<int> BaseMinEikthyrTrophy;
                public static ConfigEntry<int> BaseMaxEikthyrTrophy;
                public static ConfigEntry<float> BaseChanceEikthyrTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierEikthyrTrophy;
            //TheElder (gdking)
                //CryptKey
                public static ConfigEntry<int> BaseMingdkingCryptKey;
                public static ConfigEntry<int> BaseMaxgdkingCryptKey;
                public static ConfigEntry<float> BaseChancegdkingCryptKey;
                public static ConfigEntry<bool> BaseLevelMultipliergdkingCryptKey;
                //Trophy
                public static ConfigEntry<int> BaseMingdkingTrophy;
                public static ConfigEntry<int> BaseMaxgdkingTrophy;
                public static ConfigEntry<float> BaseChancegdkingTrophy;
                public static ConfigEntry<bool> BaseLevelMultipliergdkingTrophy;
            //Bonemass
                //Wishbone
                public static ConfigEntry<int> BaseMinBonemassWishbone;
                public static ConfigEntry<int> BaseMaxBonemassWishbone;
                public static ConfigEntry<float> BaseChanceBonemassWishbone;
                public static ConfigEntry<bool> BaseLevelMultiplierBonemassWishbone;
                //Trophy
                public static ConfigEntry<int> BaseMinBonemassTrophy;
                public static ConfigEntry<int> BaseMaxBonemassTrophy;
                public static ConfigEntry<float> BaseChanceBonemassTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierBonemassTrophy;
            //Dragon
                //DragonTear
                public static ConfigEntry<int> BaseMinDragonTear;
                public static ConfigEntry<int> BaseMaxDragonTear;
                public static ConfigEntry<float> BaseChanceDragonTear;
                public static ConfigEntry<bool> BaseLevelMultiplierDragonTear;
                //Trophy
                public static ConfigEntry<int> BaseMinDragonQueenTrophy;
                public static ConfigEntry<int> BaseMaxDragonQueenTrophy;
                public static ConfigEntry<float> BaseChanceDragonQueenTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierDragonQueenTrophy;
            //GoblinKing
                //YagluthDrop
                public static ConfigEntry<int> BaseMinGoblinKingYagluthDrop;
                public static ConfigEntry<int> BaseMaxGoblinKingYagluthDrop;
                public static ConfigEntry<float> BaseChanceGoblinKingYagluthDrop;
                public static ConfigEntry<bool> BaseLevelMultiplierGoblinKingYagluthDrop;
                //Trophy
                public static ConfigEntry<int> BaseMinGoblinKingTrophy;
                public static ConfigEntry<int> BaseMaxGoblinKingTrophy;
                public static ConfigEntry<float> BaseChanceGoblinKingTrophy;
                public static ConfigEntry<bool> BaseLevelMultiplierGoblinKingTrophy;        
    }
}
