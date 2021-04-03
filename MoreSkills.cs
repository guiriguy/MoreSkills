using System;
using HarmonyLib;
using MoreSkills.Config;
using MoreSkills.Utility;
using UnityEngine;

namespace MoreSkills_Skills
{
    class MoreSkills
    {
        

        /*[HarmonyPatch(typeof(TreeBase), "Damage")]
        public static class TreeBaseTest
        {
            public static void Postfix(ref TreeBase __instance, HitData hit)
            {
                Debug.LogWarning("Nombre: " + __instance.name);
                Debug.LogWarning("Chance: " + __instance.m_dropWhenDestroyed.m_dropChance);
                Debug.LogWarning("Min: " + __instance.m_dropWhenDestroyed.m_dropMin);
                Debug.LogWarning("Max: " + __instance.m_dropWhenDestroyed.m_dropMax);

                try
                {
                    List<GameObject> dropList = __instance.m_dropWhenDestroyed.GetDropList();
                    for (int i = 0; i < (dropList.Count * 200); i++)
                    {
                        Vector2 vector = UnityEngine.Random.insideUnitCircle * 0.5f;
                        Vector3 position = __instance.transform.position + Vector3.up * __instance.m_spawnYOffset + new Vector3(vector.x, __instance.m_spawnYStep * (float)i, vector.y);
                        Quaternion rotation = Quaternion.Euler(0f, (float)UnityEngine.Random.Range(0, 360), 0f);
                        UnityEngine.Object.Instantiate<GameObject>(dropList[i], position, rotation);
                        Debug.LogWarning("Drop: " + dropList[i] + " " + i);
                        Debug.LogWarning("mates health: " + (__instance.m_health - hit.GetTotalDamage()));
                    }
                    
                }
                catch (Exception)
                {

                }
            }
        }

        [HarmonyPatch(typeof(TreeLog), "Damage")]
        public static class TreeLogTest
        {
            public static void Postfix(ref TreeLog __instance)
            {
                Debug.LogWarning("Nombre: " + __instance.name);
                Debug.LogWarning("Chance: " + __instance.m_dropWhenDestroyed.m_dropChance);
                Debug.LogWarning("Min: " + __instance.m_dropWhenDestroyed.m_dropMin);
                Debug.LogWarning("Max: " + __instance.m_dropWhenDestroyed.m_dropMax);
                try
                {
                    List<GameObject> dropList = __instance.m_dropWhenDestroyed.GetDropList();
                    for (int i = 0; i < (dropList.Count * 200); i++)
                    {
                        Vector2 vector = UnityEngine.Random.insideUnitCircle * 0.5f;
                        Vector3 position = __instance.transform.position + __instance.transform.up * UnityEngine.Random.Range(-__instance.m_spawnDistance, __instance.m_spawnDistance) + Vector3.up * 0.3f * (float)i;
                        Quaternion rotation = Quaternion.Euler(0f, (float)UnityEngine.Random.Range(0, 360), 0f);
                        UnityEngine.Object.Instantiate<GameObject>(dropList[i], position, rotation);
                        Debug.LogWarning("Drop: " + dropList[i] + " " + i);
                    }
                    
                }
                catch (Exception)
                {

                }
            }
        }*/

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

