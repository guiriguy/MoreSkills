using System;
using UnityEngine;
using HarmonyLib;
using MoreSkills.Config;
using MoreSkills.Utility;

namespace MoreSkills.ModSkills
{
    class MoreSkills_Crafting
    {
        [HarmonyPatch(typeof(InventoryGui), "Show")]
        public static class CraftingSkill_InventoryShow
        {
            public static void Postfix()
            {
                if (MoreSkills_Instances._player != null && MoreSkills_Config.EnableCraftingSkill.Value)
                {
                    IGUI = true;
                    if (MoreSkills_Config.EnableHigherDifficultyCrafting.Value)
                    {
                        if ((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f >= 5)
                        {
                            float maths = (MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * MoreSkills_Config.CraftingHigherLevelMultiplier.Value);
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            float maths = (MoreSkills_Config.CraftingHigherLevelMultiplier.Value / 20);
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (!MoreSkills_Config.EnableHigherDifficultyCrafting.Value)
                    {
                        if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 99)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel100.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 74)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel75.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 49)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel50.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 24)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel25.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(InventoryGui), "Hide")]
        public static class CraftingSkill_InventoryHide
        {
            public static void Postfix()
            {
                if (MoreSkills_Instances._player != null && MoreSkills_Config.EnableCraftingSkill.Value && IGUI)
                {
                    foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                    {
                        if (recipe == null || recipe.m_item == null)
                            continue;

                        if (recipe.m_item == C0oI)
                        {
                            //Debug.LogError("Encontrado Objeto: " + C0oI);
                            foreach (Piece.Requirement req in recipe.m_resources)
                            {
                                if (req == null || req.m_resItem == null)
                                    continue;

                                if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                {
                                    break;
                                }

                                if (C0rI1 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI1);
                                    if (req.m_amount >= 1)
                                    {
                                       // Debug.LogWarning("Devolviendo valor a original: " + C0rA1);
                                        req.m_amount = C0rA1;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA1 = 0;
                                        C0m1 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA1 + " y " + C0m1);
                                        C0rI1 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI1);
                                    }
                                }
                                else if (C0rI2 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI2);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA2);
                                        req.m_amount = C0rA2;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA2 = 0;
                                        C0m2 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA2 + " y " + C0m2);
                                        C0rI2 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI2);
                                    }
                                }
                                else if (C0rI3 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI3);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA3);
                                        req.m_amount = C0rA3;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA3 = 0;
                                        C0m3 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA3 + " y " + C0m3);
                                        C0rI3 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI3);
                                    }
                                }
                                else if (C0rI4 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI4);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA4);
                                        req.m_amount = C0rA4;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA4 = 0;
                                        C0m4 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA4 + " y " + C0m4);
                                        C0rI4 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI4);
                                    }
                                }

                                if (C0rIPL1 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL1);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL1);
                                        req.m_amountPerLevel = C0rAPL1;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL1 = 0;
                                        C0mPL1 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL1 + " y " + C0mPL1);
                                        C0rIPL1 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL1);
                                    }
                                }
                                else if (C0rIPL2 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL2);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL2);
                                        req.m_amountPerLevel = C0rAPL2;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL2 = 0;
                                        C0mPL2 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL2 + " y " + C0mPL2);
                                        C0rIPL2 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL2);
                                    }
                                }
                                else if (C0rIPL3 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL3);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL3);
                                        req.m_amountPerLevel = C0rAPL3;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL3 = 0;
                                        C0mPL3 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL3 + " y " + C0mPL3);
                                        C0rIPL3 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL3);
                                    }
                                }
                                else if (C0rIPL4 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL4);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL4);
                                        req.m_amountPerLevel = C0rAPL4;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL4 = 0;
                                        C0mPL4 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL4 + " y " + C0mPL4);
                                        C0rIPL4 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL4);
                                    }
                                }
                            }
                            C0oI = null;
                        }
                    }
                    IGUI = false;
                }
            }
        }
        //No revisado
        [HarmonyPatch(typeof(InventoryGui), "OnSelectedRecipe")]
        public static class CraftingSkill_InventoryOnSelectedRecipe
        {
            public static void Postfix()
            {
                if (MoreSkills_Instances._player != null && MoreSkills_Config.EnableCraftingSkill.Value)
                {
                    foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                    {
                        if (recipe == null || recipe.m_item == null)
                            continue;

                        if (recipe.m_item == C0oI)
                        {
                            //Debug.LogError("Encontrado Objeto: " + C0oI);
                            foreach (Piece.Requirement req in recipe.m_resources)
                            {
                                if (req == null || req.m_resItem == null)
                                    continue;

                                if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                {
                                    break;
                                }

                                if (C0rI1 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI1);
                                    if (req.m_amount >= 1)
                                    {
                                        // Debug.LogWarning("Devolviendo valor a original: " + C0rA1);
                                        req.m_amount = C0rA1;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA1 = 0;
                                        C0m1 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA1 + " y " + C0m1);
                                        C0rI1 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI1);
                                    }
                                }
                                else if (C0rI2 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI2);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA2);
                                        req.m_amount = C0rA2;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA2 = 0;
                                        C0m2 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA2 + " y " + C0m2);
                                        C0rI2 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI2);
                                    }
                                }
                                else if (C0rI3 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI3);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA3);
                                        req.m_amount = C0rA3;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA3 = 0;
                                        C0m3 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA3 + " y " + C0m3);
                                        C0rI3 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI3);
                                    }
                                }
                                else if (C0rI4 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI4);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA4);
                                        req.m_amount = C0rA4;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA4 = 0;
                                        C0m4 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA4 + " y " + C0m4);
                                        C0rI4 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI4);
                                    }
                                }

                                if (C0rIPL1 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL1);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL1);
                                        req.m_amountPerLevel = C0rAPL1;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL1 = 0;
                                        C0mPL1 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL1 + " y " + C0mPL1);
                                        C0rIPL1 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL1);
                                    }
                                }
                                else if (C0rIPL2 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL2);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL2);
                                        req.m_amountPerLevel = C0rAPL2;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL2 = 0;
                                        C0mPL2 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL2 + " y " + C0mPL2);
                                        C0rIPL2 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL2);
                                    }
                                }
                                else if (C0rIPL3 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL3);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL3);
                                        req.m_amountPerLevel = C0rAPL3;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL3 = 0;
                                        C0mPL3 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL3 + " y " + C0mPL3);
                                        C0rIPL3 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL3);
                                    }
                                }
                                else if (C0rIPL4 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL4);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL4);
                                        req.m_amountPerLevel = C0rAPL4;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL4 = 0;
                                        C0mPL4 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL4 + " y " + C0mPL4);
                                        C0rIPL4 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL4);
                                    }
                                }
                            }
                            C0oI = null;
                        }
                    }

                    if (MoreSkills_Config.EnableHigherDifficultyCrafting.Value)
                    {
                        if ((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f >= 5)
                        {
                            float maths = (MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * MoreSkills_Config.CraftingHigherLevelMultiplier.Value);
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            float maths = (MoreSkills_Config.CraftingHigherLevelMultiplier.Value / 20);
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (!MoreSkills_Config.EnableHigherDifficultyCrafting.Value)
                    {
                        if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 99)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel100.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 74)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel75.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 49)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel50.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 24)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel25.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //Revisado: Medio
        [HarmonyPatch(typeof(InventoryGui), "OnTabCraftPressed")]
        public static class InventoryOnTabCraftPressed_CraftingSkillMod
        {
            public static void Postfix()
            {
                if (MoreSkills_Instances._player != null && MoreSkills_Config.EnableCraftingSkill.Value)
                {
                    foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                    {
                        if (recipe == null || recipe.m_item == null)
                            continue;

                        if (recipe.m_item == C0oI)
                        {
                            //Debug.LogError("Encontrado Objeto: " + C0oI);
                            foreach (Piece.Requirement req in recipe.m_resources)
                            {
                                if (req == null || req.m_resItem == null)
                                    continue;

                                if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                {
                                    break;
                                }

                                if (C0rI1 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI1);
                                    if (req.m_amount >= 1)
                                    {
                                        // Debug.LogWarning("Devolviendo valor a original: " + C0rA1);
                                        req.m_amount = C0rA1;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA1 = 0;
                                        C0m1 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA1 + " y " + C0m1);
                                        C0rI1 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI1);
                                    }
                                }
                                else if (C0rI2 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI2);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA2);
                                        req.m_amount = C0rA2;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA2 = 0;
                                        C0m2 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA2 + " y " + C0m2);
                                        C0rI2 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI2);
                                    }
                                }
                                else if (C0rI3 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI3);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA3);
                                        req.m_amount = C0rA3;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA3 = 0;
                                        C0m3 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA3 + " y " + C0m3);
                                        C0rI3 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI3);
                                    }
                                }
                                else if (C0rI4 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI4);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA4);
                                        req.m_amount = C0rA4;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA4 = 0;
                                        C0m4 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA4 + " y " + C0m4);
                                        C0rI4 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI4);
                                    }
                                }

                                if (C0rIPL1 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL1);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL1);
                                        req.m_amountPerLevel = C0rAPL1;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL1 = 0;
                                        C0mPL1 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL1 + " y " + C0mPL1);
                                        C0rIPL1 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL1);
                                    }
                                }
                                else if (C0rIPL2 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL2);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL2);
                                        req.m_amountPerLevel = C0rAPL2;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL2 = 0;
                                        C0mPL2 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL2 + " y " + C0mPL2);
                                        C0rIPL2 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL2);
                                    }
                                }
                                else if (C0rIPL3 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL3);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL3);
                                        req.m_amountPerLevel = C0rAPL3;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL3 = 0;
                                        C0mPL3 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL3 + " y " + C0mPL3);
                                        C0rIPL3 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL3);
                                    }
                                }
                                else if (C0rIPL4 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL4);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL4);
                                        req.m_amountPerLevel = C0rAPL4;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL4 = 0;
                                        C0mPL4 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL4 + " y " + C0mPL4);
                                        C0rIPL4 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL4);
                                    }
                                }
                            }
                            C0oI = null;
                        }
                    }

                    if (MoreSkills_Config.EnableHigherDifficultyCrafting.Value)
                    {
                        if ((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f >= 5)
                        {
                            float maths = (MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * MoreSkills_Config.CraftingHigherLevelMultiplier.Value);
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            float maths = (MoreSkills_Config.CraftingHigherLevelMultiplier.Value / 20);
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (!MoreSkills_Config.EnableHigherDifficultyCrafting.Value)
                    {
                        if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 99)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel100.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 74)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel75.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 49)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel50.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 24)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel25.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //Revisado: Medio
        [HarmonyPatch(typeof(InventoryGui), "OnTabUpgradePressed")]
        public static class InventoryOnTabUpgradePressed_CraftingSkillMod
        {
            public static void Postfix()
            {
                if (MoreSkills_Instances._player != null && MoreSkills_Config.EnableCraftingSkill.Value)
                {
                    foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                    {
                        if (recipe == null || recipe.m_item == null)
                            continue;

                        if (recipe.m_item == C0oI)
                        {
                            //Debug.LogError("Encontrado Objeto: " + C0oI);
                            foreach (Piece.Requirement req in recipe.m_resources)
                            {
                                if (req == null || req.m_resItem == null)
                                    continue;

                                if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                {
                                    break;
                                }

                                if (C0rI1 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI1);
                                    if (req.m_amount >= 1)
                                    {
                                        // Debug.LogWarning("Devolviendo valor a original: " + C0rA1);
                                        req.m_amount = C0rA1;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA1 = 0;
                                        C0m1 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA1 + " y " + C0m1);
                                        C0rI1 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI1);
                                    }
                                }
                                else if (C0rI2 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI2);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA2);
                                        req.m_amount = C0rA2;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA2 = 0;
                                        C0m2 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA2 + " y " + C0m2);
                                        C0rI2 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI2);
                                    }
                                }
                                else if (C0rI3 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI3);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA3);
                                        req.m_amount = C0rA3;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA3 = 0;
                                        C0m3 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA3 + " y " + C0m3);
                                        C0rI3 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI3);
                                    }
                                }
                                else if (C0rI4 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI4);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA4);
                                        req.m_amount = C0rA4;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA4 = 0;
                                        C0m4 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA4 + " y " + C0m4);
                                        C0rI4 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI4);
                                    }
                                }

                                if (C0rIPL1 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL1);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL1);
                                        req.m_amountPerLevel = C0rAPL1;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL1 = 0;
                                        C0mPL1 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL1 + " y " + C0mPL1);
                                        C0rIPL1 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL1);
                                    }
                                }
                                else if (C0rIPL2 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL2);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL2);
                                        req.m_amountPerLevel = C0rAPL2;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL2 = 0;
                                        C0mPL2 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL2 + " y " + C0mPL2);
                                        C0rIPL2 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL2);
                                    }
                                }
                                else if (C0rIPL3 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL3);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL3);
                                        req.m_amountPerLevel = C0rAPL3;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL3 = 0;
                                        C0mPL3 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL3 + " y " + C0mPL3);
                                        C0rIPL3 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL3);
                                    }
                                }
                                else if (C0rIPL4 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL4);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL4);
                                        req.m_amountPerLevel = C0rAPL4;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL4 = 0;
                                        C0mPL4 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL4 + " y " + C0mPL4);
                                        C0rIPL4 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL4);
                                    }
                                }
                            }
                            C0oI = null;
                        }
                    }

                    if (MoreSkills_Config.EnableHigherDifficultyCrafting.Value)
                    {
                        if ((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f >= 5)
                        {
                            float maths = (MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * MoreSkills_Config.CraftingHigherLevelMultiplier.Value);
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            float maths = (MoreSkills_Config.CraftingHigherLevelMultiplier.Value / 20);
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (!MoreSkills_Config.EnableHigherDifficultyCrafting.Value)
                    {
                        if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 99)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel100.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 74)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel75.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 49)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel50.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 24)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel25.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }
        //No revisado
        [HarmonyPatch(typeof(InventoryGui), "DoCrafting")]
        public static class CraftingSkillMod_SkillIncrease
        {
            public static void Postfix()
            {
                if (MoreSkills_Instances._player != null && MoreSkills_Config.EnableCraftingSkill.Value)
                {
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

                    foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                    {
                        if (recipe == null || recipe.m_item == null)
                            continue;

                        if (recipe.m_item == C0oI)
                        {
                            //Debug.LogError("Encontrado Objeto: " + C0oI);
                            foreach (Piece.Requirement req in recipe.m_resources)
                            {
                                if (req == null || req.m_resItem == null)
                                    continue;

                                if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                {
                                    break;
                                }

                                if (C0rI1 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI1);
                                    if (req.m_amount >= 1)
                                    {
                                        // Debug.LogWarning("Devolviendo valor a original: " + C0rA1);
                                        req.m_amount = C0rA1;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA1 = 0;
                                        C0m1 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA1 + " y " + C0m1);
                                        C0rI1 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI1);
                                    }
                                }
                                else if (C0rI2 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI2);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA2);
                                        req.m_amount = C0rA2;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA2 = 0;
                                        C0m2 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA2 + " y " + C0m2);
                                        C0rI2 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI2);
                                    }
                                }
                                else if (C0rI3 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI3);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA3);
                                        req.m_amount = C0rA3;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA3 = 0;
                                        C0m3 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA3 + " y " + C0m3);
                                        C0rI3 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI3);
                                    }
                                }
                                else if (C0rI4 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rI4);
                                    if (req.m_amount >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rA4);
                                        req.m_amount = C0rA4;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rA4 = 0;
                                        C0m4 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rA4 + " y " + C0m4);
                                        C0rI4 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rI4);
                                    }
                                }

                                if (C0rIPL1 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL1);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL1);
                                        req.m_amountPerLevel = C0rAPL1;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL1 = 0;
                                        C0mPL1 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL1 + " y " + C0mPL1);
                                        C0rIPL1 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL1);
                                    }
                                }
                                else if (C0rIPL2 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL2);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL2);
                                        req.m_amountPerLevel = C0rAPL2;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL2 = 0;
                                        C0mPL2 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL2 + " y " + C0mPL2);
                                        C0rIPL2 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL2);
                                    }
                                }
                                else if (C0rIPL3 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL3);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL3);
                                        req.m_amountPerLevel = C0rAPL3;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL3 = 0;
                                        C0mPL3 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL3 + " y " + C0mPL3);
                                        C0rIPL3 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL3);
                                    }
                                }
                                else if (C0rIPL4 == req.m_resItem)
                                {
                                    //Debug.LogWarning("Encontrado Recurso 1: " + C0rIPL4);
                                    if (req.m_amountPerLevel >= 1)
                                    {
                                        //Debug.LogWarning("Devolviendo valor a original: " + C0rAPL4);
                                        req.m_amountPerLevel = C0rAPL4;
                                        //Debug.LogWarning("Asignado valor a: " + req.m_amount);
                                        C0rAPL4 = 0;
                                        C0mPL4 = 0;
                                        //Debug.LogWarning("Resetados valores de guardado y mates a: " + C0rAPL4 + " y " + C0mPL4);
                                        C0rIPL4 = null;
                                        //Debug.LogWarning("Reseteado valor guardado item a:" + C0rIPL4);
                                    }
                                }
                            }
                            C0oI = null;
                        }
                    }

                    if (MoreSkills_Config.EnableHigherDifficultyCrafting.Value)
                    {
                        if ((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f >= 5)
                        {
                            float maths = (MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * MoreSkills_Config.CraftingHigherLevelMultiplier.Value);
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            float maths = (MoreSkills_Config.CraftingHigherLevelMultiplier.Value / 20);
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (!MoreSkills_Config.EnableHigherDifficultyCrafting.Value)
                    {
                        if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 99)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel100.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 74)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel75.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 49)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel50.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (((MoreSkills_Instances._player.GetSkillFactor((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type) * 100f) + 0.0001f) >= 24)
                        {
                            float maths = MoreSkills_Config.CraftingNormalLevel25.Value;
                            foreach (Recipe recipe in MoreSkills_Instances._objectDB.m_recipes)
                            {
                                if (recipe == null || recipe.m_item == null)
                                    continue;

                                if (recipe.m_item == MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item)
                                {

                                    //Debug.LogError("Receta " + counter);
                                    C0oI = MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item;
                                    //Debug.LogWarning("Objeto: " + C0oI);

                                    foreach (Piece.Requirement req in recipe.m_resources)
                                    {
                                        if (req == null)
                                            continue;

                                        if (MoreSkills_Instances._inventoryGui.m_selectedRecipe.Key.m_item.m_itemData.m_shared.m_name == "$item_bronze")
                                        {
                                            break;
                                        }

                                        if (C0rI1 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rI1);
                                                C0rA1 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 1: " + C0rA1);
                                                C0m1 = C0rA1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 1: " + C0m1);
                                                if (C0m1 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 1: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI2 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 2: " + C0rI2);
                                                C0rA2 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rA2);
                                                C0m2 = C0rA2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 2: " + C0m2);
                                                if (C0m2 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 2: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI3 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 3: " + C0rI3);
                                                C0rA3 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 3: " + C0rA3);
                                                C0m3 = C0rA3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 3: " + C0m3);
                                                if (C0m3 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 3: " + req.m_amount);
                                            }
                                        }
                                        else if (C0rI4 == null)
                                        {
                                            if (req.m_amount >= 1)
                                            {
                                                C0rI4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 4: " + C0rI4);
                                                C0rA4 = req.m_amount;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 4: " + C0rA4);
                                                C0m4 = C0rA4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0m4);
                                                if (C0m4 < 1)
                                                    req.m_amount = 1;
                                                else
                                                    req.m_amount = (int)C0m4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amount);
                                            }
                                        }

                                        if (C0rIPL1 == null)
                                        {
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL1 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL1);
                                                C0rAPL1 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL1);
                                                C0mPL1 = C0rAPL1 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL1);
                                                if (C0mPL1 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL1;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL2 == null)
                                        {

                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL2 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL2);
                                                C0rAPL2 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL2);
                                                C0mPL2 = C0rAPL2 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL2);
                                                if (C0mPL2 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL2;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL3 == null)
                                        {
                                            C0rIPL3 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL3 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL3);
                                                C0rAPL3 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL3);
                                                C0mPL3 = C0rAPL3 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL3);
                                                if (C0mPL3 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL3;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);
                                            }
                                        }
                                        else if (C0rIPL4 == null)
                                        {
                                            C0rIPL4 = req.m_resItem;
                                            if (req.m_amountPerLevel >= 1)
                                            {
                                                C0rIPL4 = req.m_resItem;
                                                //Debug.LogWarning("Guardado Recurso Crafteo 1: " + C0rIPL4);
                                                C0rAPL4 = req.m_amountPerLevel;
                                                //Debug.LogWarning("Guardado cantidad del Recurso Crafteo 2: " + C0rAPL4);
                                                C0mPL4 = C0rAPL4 / maths;
                                                //Debug.LogWarning("Calculos cantidad del Recurso Crafteo 4: " + C0mPL4);
                                                if (C0mPL4 < 1)
                                                    req.m_amountPerLevel = 1;
                                                else
                                                    req.m_amountPerLevel = (int)C0mPL4;
                                                //Debug.LogWarning("Asignado cantidad del Recurso Crafteo 4: " + req.m_amountPerLevel);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                MoreSkills_Instances._player.RaiseSkill((Skills.SkillType)MoreSkills_Config.CraftingSkill_Type, ((CraftSkillInc * MoreSkills_Config.CraftingSkillIncreaseMultiplier.Value)) / 100);
                //Debug.LogError("EXP: " + CraftSkillInc);
                CraftSkillInc = 0;
            }
        }

        public static ItemDrop C0oI;

        public static ItemDrop C0rI1;
        public static ItemDrop C0rI2;
        public static ItemDrop C0rI3;
        public static ItemDrop C0rI4;

        public static ItemDrop C0rIPL1;
        public static ItemDrop C0rIPL2;
        public static ItemDrop C0rIPL3;
        public static ItemDrop C0rIPL4;

        public static int C0rA1;
        public static int C0rA2;
        public static int C0rA3;
        public static int C0rA4;

        public static int C0rAPL1;
        public static int C0rAPL2;
        public static int C0rAPL3;
        public static int C0rAPL4;

        public static float C0m1;
        public static float C0m2;
        public static float C0m3;
        public static float C0m4;

        public static float C0mPL1;
        public static float C0mPL2;
        public static float C0mPL3;
        public static float C0mPL4;

        public static bool IGUI;

        public static float CraftSkillInc;
    }
    
}
