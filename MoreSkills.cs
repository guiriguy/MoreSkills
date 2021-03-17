using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Pipakin.SkillInjectorMod;
using UnityEngine;

namespace MoreSkills
{

    [BepInPlugin("com.GuiriGuy.MoreSkills","MoreSkills","0.0.2")]
    [BepInDependency("com.pipakin.SkillInjectorMod")]

    public class MoreSkills : BaseUnityPlugin
    {

        public void Awake()
        {
            //Strength.Weight

            MoreSkills.EnableWeightMod = base.Config.Bind<bool>("MoreSkills: Strength", "Enable Weight Mod", true, "Enables or disables the Weight Modification.");

            MoreSkills.BaseWeight = base.Config.Bind<float>("MoreSkills: Strength", "Base Weight", 300f, "Change the base Weight. (Valheim Default is 300)");

            MoreSkills.BaseMaxWeight = base.Config.Bind<float>("MoreSkills: Strength", "Base Max Weight", 600f, "Change the total Weight when Strength is at level 100. (Valheim Default is 300)");

            //Strength.Increases

            MoreSkills.StrengthSkillIncreaseWhenEncumbred = base.Config.Bind<float>("MoreSkills: Strength", "Strength Skill Increase When Encumbred", 0.2f, "Change the skill increase when Encumbred.");

            MoreSkills.StrengthSkillIncreaseWhenHalfnRunning = base.Config.Bind<float>("MoreSkills: Strength", "Strength Skill Increase When Halfweight and Running", 0.1f, "Change the skill increase when Carrying Half of your Max Weight and running.");

            MoreSkills.StrengthSkillIncreaseWhenHalfnMoving = base.Config.Bind<float>("MoreSkills: Strength", "Strength Skill Increase When Halfweight and Moving", 0.05f, "Change the skill increase when Carrying Half of your Max Weight and moving.");

            //Vitality.Health

            MoreSkills.EnableHealthMod = base.Config.Bind<bool>("MoreSkills: Vitality", "Enable Vitality Mod", true, "Enables or disables the Vitality Modification.");

            MoreSkills.BaseHealth = base.Config.Bind<float>("MoreSkills: Vitality", "Base Health", 25f, "Change the base Health. (Valheim Default is 25)");

            MoreSkills.BaseMaxHealth = base.Config.Bind<float>("MoreSkills: Vitality", "Base Max Health", 100f, "Change the toal Health when Vitality is at level 100. (Valheim Default is 25)");

            //Inject.Strength

            SkillInjector.RegisterNewSkill(700, "Strength", "Able to carry more and with higher numbers", 1f, MoreSkills.StrengthLoadCustomTexture(), Skills.SkillType.Unarmed);

            SkillInjector.RegisterNewSkill(701, "Vitality", "Endure and gain resistance as you recieve damage", 1f, MoreSkills.VitalityLoadCustomTexture(), Skills.SkillType.Unarmed);

            //--

            new Harmony("com.guiriguy.moreskills").PatchAll();

            //Logs

            bool Weightdisabled = !MoreSkills.EnableWeightMod.Value;
            bool Healthdisabled = !MoreSkills.EnableHealthMod.Value;

            if (Weightdisabled)
            {

                Debug.LogWarning("[MoreSkills]: Weight Mod Disabled");

            }
            else
            {

                Debug.LogWarning("[MoreSkills]: Weight Mod Enabled");

            }

            if (Healthdisabled)
            {

                Debug.LogWarning("[MoreSkills]: Health Mod Disabled");

            }
            else
            {

                Debug.LogWarning("[MoreSkills]: Health Mod Enabled");

            }

        }

        
        public static Sprite StrengthLoadCustomTexture()
        {

            string StrengthdirectoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string Strengthfilepath = Path.Combine(StrengthdirectoryName, "strengthicon.png");

            Texture2D Strengthtexture2D = MoreSkills.StrengthLoadTexture(Strengthfilepath);

            return Sprite.Create(Strengthtexture2D, new Rect(0f, 0f, 32f, 32f), Vector2.zero);

        }

        public static Sprite VitalityLoadCustomTexture()
        {

            string VitalitydirectoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string Vitalityfilepath = Path.Combine(VitalitydirectoryName, "vitalityicon.png"); //Icon made by https://www.flaticon.com/authors/dinosoftlabs DinosoftLabs

            Texture2D Vitalitytexture2D = MoreSkills.VitalityLoadTexture(Vitalityfilepath);

            return Sprite.Create(Vitalitytexture2D, new Rect(0f, 0f, 32f, 32f), Vector2.zero);

        }

        public static Texture2D StrengthLoadTexture(string Strengthfilepath)
        {

            bool flag = MoreSkills.cachedTextures.ContainsKey(Strengthfilepath);

            Texture2D result;

            if (flag)
            {

                result = MoreSkills.cachedTextures[Strengthfilepath];

            }
            else
            {

                Texture2D texture2D = new Texture2D(0, 0);
                ImageConversion.LoadImage(texture2D, File.ReadAllBytes(Strengthfilepath));
                result = texture2D;

            }

            return result;

        }

        public static Texture2D VitalityLoadTexture(string Vitalityfilepath)
        {

            bool flag = MoreSkills.cachedTextures.ContainsKey(Vitalityfilepath);

            Texture2D result;

            if (flag)
            {

                result = MoreSkills.cachedTextures[Vitalityfilepath];

            }
            else
            {

                Texture2D texture2D = new Texture2D(0, 0);

                ImageConversion.LoadImage(texture2D, File.ReadAllBytes(Vitalityfilepath));

                result = texture2D;

            }

            return result;

        }

        public static ConfigEntry<float> BaseWeight;

        public static ConfigEntry<float> BaseMaxWeight;

        public static ConfigEntry<float> BaseHealth;

        public static ConfigEntry<float> BaseMaxHealth;

        public static ConfigEntry<float> StrengthSkillIncreaseWhenEncumbred;

        public static ConfigEntry<float> StrengthSkillIncreaseWhenHalfnMoving;

        public static ConfigEntry<float> StrengthSkillIncreaseWhenHalfnRunning;

        public static ConfigEntry<bool> EnableWeightMod;

        public static ConfigEntry<bool> EnableHealthMod;

        public static Dictionary<string, Texture2D> cachedTextures = new Dictionary<string, Texture2D>();

        public const int StrengthSkill_Type = 700;

        public const int VitalitySkill_Type = 701;

        [HarmonyPatch(typeof(Player), "UpdateStats")]
        public static class Strength_ApplyWeightMod
        {

            [HarmonyPrefix]
            public static void Strength_WeightMod()
            {

                bool disabled = !MoreSkills.EnableWeightMod.Value;

                if (disabled)
                {


                }
                else
                {
                    try
                    {

                        bool player = Player.m_localPlayer == null;

                        if (!player)

                        {


                            float weight_skill = (float)Math.Floor((Player.m_localPlayer.GetSkillFactor((Skills.SkillType)700) * 100f) + 0.000001f);

                            float weight_skillinc = ((MoreSkills.BaseMaxWeight.Value - MoreSkills.BaseWeight.Value) / 100f) * weight_skill;

                            Player.m_localPlayer.m_maxCarryWeight = (MoreSkills.BaseWeight.Value + weight_skillinc);

                        }
                        else
                        {
                        }

                    }
                    catch (Exception ex)
                    {

                        Debug.LogError("Error al intentar poner peso base: " + ex);

                    }

                }

            }

        }

        [HarmonyPatch(typeof(Player), "GetMaxCarryWeight")]
        public static class RaiseSkill_Strength
        {

            [HarmonyPostfix]
            public static void RS_Strength(ref float __result)
            {

                bool player = Player.m_localPlayer == null;

                bool disabled = !MoreSkills.EnableWeightMod.Value;

                if (disabled)
                {

                }
                else
                {

                    if (!player)
                    {

                        bool halfweight = Player.m_localPlayer.GetInventory().GetTotalWeight() > (__result / 2);

                        bool encumbered = Player.m_localPlayer.GetInventory().GetTotalWeight() > __result;

                        Vector3 vel = Player.m_localPlayer.m_currentVel;

                        bool moving = Math.Floor(vel.y + vel.x + vel.z) < -1 || Math.Floor(vel.y + vel.x + vel.z) > 1;

                        bool running = Player.m_localPlayer.IsRunning();

                        if (halfweight && moving)
                        {

                            countsrs++;

                        }

                        if (encumbered && moving && countsrs >= 1000)
                        {

                            Player.m_localPlayer.RaiseSkill((Skills.SkillType)700, MoreSkills.StrengthSkillIncreaseWhenEncumbred.Value);

                            Debug.LogWarning("Incremented Strength skill in " + MoreSkills.StrengthSkillIncreaseWhenEncumbred.Value);

                            countsrs -= countsrs;

                        }
                        else if (halfweight && running && countsrs >= 1000)
                        {

                            Player.m_localPlayer.RaiseSkill((Skills.SkillType)700, MoreSkills.StrengthSkillIncreaseWhenHalfnRunning.Value);

                            Debug.LogWarning("Incremented Strength skill in " + MoreSkills.StrengthSkillIncreaseWhenHalfnRunning.Value);

                            countsrs -= countsrs;

                        }
                        else if (halfweight && moving && countsrs >= 1000)
                        {

                            Player.m_localPlayer.RaiseSkill((Skills.SkillType)700, MoreSkills.StrengthSkillIncreaseWhenHalfnMoving.Value);

                            Debug.LogWarning("Incremented Strength skill in " + MoreSkills.StrengthSkillIncreaseWhenHalfnMoving.Value);

                            countsrs -= countsrs;

                        }

                    }

                }

            }

            public static int countsrs;

        }

        [HarmonyPatch(typeof(Player), "SetMaxHealth")]
        public static class Vitality_ApplyBaseHealthMod
        {

            [HarmonyPrefix]
            public static void Vitality_HealthMod(ref float health)
            {

                bool disabled = !MoreSkills.EnableHealthMod.Value;

                if (disabled)
                {


                }
                else
                {

                    try
                    {

                        List<HitData.DamageModPair> list = new List<HitData.DamageModPair>();

                        bool player = Player.m_localPlayer == null;

                        if (!player)
                        {

                            float health_skill = (float)Math.Floor((Player.m_localPlayer.GetSkillFactor((Skills.SkillType)701) * 100f) + 0.00000001f);

                            float health_skillinc = ((MoreSkills.BaseMaxHealth.Value - MoreSkills.BaseHealth.Value) / 100) * health_skill;

                            health += (MoreSkills.BaseHealth.Value + health_skillinc) - 25f;

                        }

                    }
                    catch (Exception ex)
                    {

                        Debug.LogError("Error adjusting base health: " + ex.ToString());

                    }

                }

            }

        }
        
        [HarmonyPatch(typeof(Player), "OnDamaged")]
        public static class Vitality_RaiseSkill
        {

            [HarmonyPostfix]
            public static void RS_Vitality(ref HitData hit)
            {

                bool disabled = !MoreSkills.EnableHealthMod.Value;

                if (disabled)
                {

                }
                else
                {

                    bool player = Player.m_localPlayer == null;

                    if (!player)
                    {

                        Player.m_localPlayer.RaiseSkill((Skills.SkillType)701, (hit.GetTotalDamage() / 100));

                    }

                }

            }

        }

    }

}
