using System;
using System.Collections.Generic;
using UnityEngine;
using HarmonyLib;
using MoreSkills.Config;
using MoreSkills.Utility;

namespace MoreSkills_Skills
{
    class MoreSkills
    {
        /*[HarmonyPatch(typeof(InventoryGui), "Show")]
        public static class Test1
        {
            public static void Postfix(ref InventoryGui __instance)
            {
                foreach (Recipe recipe in ObjectDB.instance.m_recipes)
                {
                    if (recipe.m_item == null || recipe == null)
                        continue;

                    Debug.LogWarning("Nombre: " + recipe.m_item);
                    Debug.LogWarning("Cantidad: " + recipe.m_amount);
                    foreach (Piece.Requirement req in recipe.m_resources)
                    {
                        Debug.LogWarning("Recurso: " + req.m_resItem + " Cantidad Crafteo: " + req.m_amount + " Cantidad upgrade: " + req.m_amountPerLevel);
                    }
                }
            }
        }*/
    }
}

