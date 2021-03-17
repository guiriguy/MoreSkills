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
            public static void Postfix(ref Player __instance)
            {
                if (MoreSkills.EnableWeightMod.Value)
                {
                    if (__instance != null)
                    {
                        float weight_skill = (float)Math.Floor((__instance.GetSkillFactor((Skills.SkillType)StrengthSkill_Type) * 100f) + 0.000001f);
                        float weight_skillinc = ((MoreSkills.BaseMaxWeight.Value - MoreSkills.BaseWeight.Value) / 100f) * weight_skill;
                       __instance.m_maxCarryWeight = (MoreSkills.BaseWeight.Value + weight_skillinc);

                    }
                }
            }
        }

        [HarmonyPatch(typeof(Player), "GetMaxCarryWeight")]
        public static class RaiseSkill_Strength
        {
            public static void Postfix(ref Player __instance, ref float __result)
            {
                if(MoreSkills.EnableWeightMod.Value)
                {
                    if (__instance != null)
                    {
                        bool halfweight = __instance.GetInventory().GetTotalWeight() > (__result / 2);
                        Vector3 vel = __instance.m_currentVel;
                        bool moving = Math.Floor(vel.y + vel.x + vel.z) < -1 || Math.Floor(vel.y + vel.x + vel.z) > 1;
                        if (halfweight && moving) countsrs++;
                        if (countsrs >= 1000)
                        {
                            if (moving)
                            {
                                if (__instance.IsEncumbered)
                                {
                                    __instance.RaiseSkill((Skills.SkillType)StrengthSkill_Type, MoreSkills.StrengthSkillIncreaseWhenEncumbred.Value);
                                    countsrs = 0;
                                }
                                else if (halfweight)
                                {
                                    if (__instance.IsRunning())
                                        __instance.RaiseSkill((Skills.SkillType)StrengthSkill_Type, MoreSkills.StrengthSkillIncreaseWhenHalfnRunning.Value);
                                    else 
                                        __instance.RaiseSkill((Skills.SkillType)StrengthSkill_Type, MoreSkills.StrengthSkillIncreaseWhenHalfnMoving.Value);                                    
                                    countsrs = 0;
                                }                                
                            }
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

                            float health_skill = (float)Math.Floor((Player.m_localPlayer.GetSkillFactor((Skills.SkillType)VitalitySkill_Type) * 100f) + 0.00000001f);

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

                        Player.m_localPlayer.RaiseSkill((Skills.SkillType)VitalitySkill_Type, (hit.GetTotalDamage() / 100));

                    }

                }

            }

        }

    }

}
