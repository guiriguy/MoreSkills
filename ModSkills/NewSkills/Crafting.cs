using System.Collections.Generic;
using HarmonyLib;
using MoreSkills.Config;
using MoreSkills.Utility;
using UnityEngine;

namespace MoreSkills.ModSkills
{
    class MoreSkills_Crafting
    {
        [HarmonyPatch(typeof(InventoryGui), "Show")]
        public static class CraftingSkill_InventoryShow
        {
            public static void Postfix()
            {
                if (MoreSkills_Instances._player != null)
                {
                    if (MoreSkills_CraftingConfig.EnableCraftingSkill.Value)
                    {
                        IGUI = true;

                        if (!Saved)
                        {
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                foreach (Piece.Requirement req in recipe.m_resources)
                                {
                                    if (recipe == null || recipe.m_item == null)
                                        continue;

                                    string objnumitem = string.Concat(recipe.m_item.name + ":" + recipe.m_amount + ":" + req.m_resItem.name);
                                    float objnum = recipe.m_amount;
                                    float itemcnum = req.m_amount;
                                    float itemunum = req.m_amountPerLevel;
                                    var getcSaves = cSaves.Find(csaves => csaves.ObjNumItem == objnumitem);

                                    if (getcSaves.ObjNumItem != objnumitem)
                                    {
                                        cSaves.Add(new Helper.CraftingSaves(
                                            objnumitem: objnumitem,
                                            objnum: objnum,
                                            itemcnum: itemcnum,
                                            itemunum: itemunum));

                                        //Debug.LogWarning("Added to Temp Database: " + objnumitem);
                                    }


                                    //Debug.LogWarning("Objeto: " + recipe.m_item.name + " Cantidad: " + recipe.m_amount + " Recurso: " + req.m_resItem.name + " Cantidad Crafteo: " + req.m_amount + " Cantidad Upgradeo: " + req.m_amountPerLevel + " Que es?: " + req.m_recover);
                                }
                            }
                            Saved = true;
                            Debug.Log("Saved All Objects in DataBase");
                        }


                        foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                        {
                            foreach (Piece.Requirement req in recipe.m_resources)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                string objnumitem = string.Concat(recipe.m_item.name + ":" + recipe.m_amount + ":" + req.m_resItem.name);
                                float level = MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_CraftingConfig.CraftingSkill_Type);
                                float multiplier = MoreSkills_CraftingConfig.CraftingLevelMultiplier.Value;
                                float middle = MoreSkills_CraftingConfig.CraftingMiddleLevel.Value;
                                float divider = MoreSkills_CraftingConfig.CraftingLevelDivider.Value;
                                var getcSaves = cSaves.Find(csaves => csaves.ObjNumItem == objnumitem);

                                //Debug.LogWarning("ONI: " + objnumitem);



                                if (getcSaves.ObjNumItem == objnumitem)
                                {
                                    if (level < (middle / 100))
                                    {
                                        if (middle == 0f)
                                        {
                                            MathsOpen = 1f;
                                        }
                                        else
                                        {
                                            MathsOpen = multiplier - ((level * (1 / (middle / 100))) * (multiplier - 1));
                                        }

                                        if (req.m_amount >= 1)
                                        {
                                            if ((getcSaves.ItemCNum * MathsOpen) < 1)
                                                req.m_amount = 1;
                                            else
                                                req.m_amount = Mathf.RoundToInt(getcSaves.ItemCNum * MathsOpen);
                                        }
                                        if (req.m_amountPerLevel >= 1)
                                        {
                                            if ((getcSaves.ItemUNum * MathsOpen) < 1)
                                                req.m_amountPerLevel = 1;
                                            else
                                                req.m_amountPerLevel = Mathf.RoundToInt(getcSaves.ItemUNum * MathsOpen);
                                        }
                                    }
                                    else if (level > (middle / 100))
                                    {
                                        if (middle == 100f)
                                        {
                                            MathsOpen = 1f;
                                        }
                                        else
                                        {
                                            MathsOpen = 1 + ((level - (middle / 100)) * (1 / (1 - (middle / 100))) * (divider - 1));
                                        }

                                        if (req.m_amount >= 1)
                                        {
                                            if ((getcSaves.ItemCNum / MathsOpen) < 1)
                                                req.m_amount = 1;
                                            else
                                                req.m_amount = Mathf.RoundToInt(getcSaves.ItemCNum / MathsOpen);
                                        }
                                        if (req.m_amountPerLevel >= 1)
                                        {
                                            if ((getcSaves.ItemUNum / MathsOpen) < 1)
                                                req.m_amountPerLevel = 1;
                                            else
                                                req.m_amountPerLevel = Mathf.RoundToInt(getcSaves.ItemUNum / MathsOpen);
                                        }
                                    }
                                    else
                                    {
                                        if (req.m_amount >= 1)
                                        {
                                            req.m_amount = (int)(getcSaves.ItemCNum);
                                        }
                                        if (req.m_amountPerLevel >= 1)
                                        {
                                            req.m_amountPerLevel = (int)(getcSaves.ItemUNum);
                                        }
                                    }
                                    //Debug.LogWarning("Found in Database");
                                }
                            }
                        }

                    }
                }
            }
        }
                        

        [HarmonyPatch(typeof(InventoryGui), "DoCrafting")]
        public static class CraftingSkillMod_SkillIncrease
        {
            public static void Postfix()
            {
                if (MoreSkills_Instances._player != null)
                {
                    if (MoreSkills_CraftingConfig.EnableCraftingSkill.Value)
                    {
                        foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                        {
                            foreach (Piece.Requirement req in recipe.m_resources)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                string objnumitem = string.Concat(recipe.m_item.name + ":" + recipe.m_amount + ":" + req.m_resItem.name);
                                float level = MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_CraftingConfig.CraftingSkill_Type);
                                float multiplier = MoreSkills_CraftingConfig.CraftingLevelMultiplier.Value;
                                float middle = MoreSkills_CraftingConfig.CraftingMiddleLevel.Value;
                                float divider = MoreSkills_CraftingConfig.CraftingLevelDivider.Value;
                                var getcSaves = cSaves.Find(csaves => csaves.ObjNumItem == objnumitem);

                                //Debug.LogWarning("ONI: " + objnumitem);



                                if (getcSaves.ObjNumItem == objnumitem)
                                {
                                    if (level < (middle / 100))
                                    {
                                        if (middle == 0f)
                                        {
                                            MathsOpen = 1f;
                                        }
                                        else
                                        {
                                            MathsOpen = multiplier - ((level * (1 / (middle / 100))) * (multiplier - 1));
                                        }

                                        if (req.m_amount >= 1)
                                        {
                                            if ((getcSaves.ItemCNum * MathsOpen) < 1)
                                                req.m_amount = 1;
                                            else
                                                req.m_amount = Mathf.RoundToInt(getcSaves.ItemCNum * MathsOpen);
                                        }
                                        if (req.m_amountPerLevel >= 1)
                                        {
                                            if ((getcSaves.ItemUNum * MathsOpen) < 1)
                                                req.m_amountPerLevel = 1;
                                            else
                                                req.m_amountPerLevel = Mathf.RoundToInt(getcSaves.ItemUNum * MathsOpen);
                                        }
                                    }
                                    else if (level > (middle / 100))
                                    {
                                        if (middle == 100f)
                                        {
                                            MathsOpen = 1f;
                                        }
                                        else
                                        {
                                            MathsOpen = 1 + ((level - (middle / 100)) * (1 / (1 -(middle / 100))) * (divider - 1));
                                        }

                                        if (req.m_amount >= 1)
                                        {
                                            if ((getcSaves.ItemCNum / MathsOpen) < 1)
                                                req.m_amount = 1;
                                            else
                                                req.m_amount = Mathf.RoundToInt(getcSaves.ItemCNum / MathsOpen);
                                        }
                                        if (req.m_amountPerLevel >= 1)
                                        {
                                            if ((getcSaves.ItemUNum / MathsOpen) < 1)
                                                req.m_amountPerLevel = 1;
                                            else
                                                req.m_amountPerLevel = Mathf.RoundToInt(getcSaves.ItemUNum / MathsOpen);
                                        }
                                    }
                                    else
                                    {
                                        if (req.m_amount >= 1)
                                        {
                                            req.m_amount = (int)(getcSaves.ItemCNum);
                                        }
                                        if (req.m_amountPerLevel >= 1)
                                        {
                                            req.m_amountPerLevel = (int)(getcSaves.ItemUNum);
                                        }
                                    }
                                    //Debug.LogWarning("Found in Database");
                                }
                            }
                        }

                        foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                        {
                            if (recipe == null || recipe.m_item == null)
                                continue;

                            if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                            {

                                foreach (Piece.Requirement req in recipe.m_resources)
                                {
                                    if (req == null || req.m_resItem == null)
                                        continue;

                                    CraftSkillInc += req.m_amount;
                                    CraftSkillInc += req.m_amountPerLevel;
                                }
                            }
                        }

                        MoreSkills_Instances._player.RaiseSkill((Skills.SkillType)MoreSkills_CraftingConfig.CraftingSkill_Type, ((CraftSkillInc * MoreSkills_CraftingConfig.CraftingSkillIncreaseMultiplier.Value)) / 10);
                        Debug.Log("Granted Crafting EXP: " + (CraftSkillInc * MoreSkills_CraftingConfig.CraftingSkillIncreaseMultiplier.Value));
                        CraftSkillInc = 0;
                    }
                }
            }
        }

        public static bool IGUI;

        public static float CraftSkillInc;

        public static bool Saved;

        public static float MathsOpen;

        public static List<Helper.CraftingSaves> cSaves = new List<Helper.CraftingSaves>();
    }

}
