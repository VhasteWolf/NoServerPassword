using HarmonyLib;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace NoServerPassword
{
    /// <summary>
    /// Set max player limit and disable server password 
    /// </summary>
    [HarmonyPatch(typeof(FejdStartup), "Awake")]
    public static class HookServerStart
    {
        private static void Postfix(ref FejdStartup __instance)
        {

            __instance.m_minimumPasswordLength = 0;

        }
    }

    /// <summary>
    /// Alters public password requirements
    /// </summary>
    [HarmonyPatch(typeof(FejdStartup), "IsPublicPasswordValid")]
    public static class ChangeServerPasswordBehavior
    {
        private static bool Prefix(ref bool __result)
        {

            // return always true
            __result = true;
            return false;

        }
    }

    /// <summary>
    /// Override password error
    /// </summary>
    [HarmonyPatch(typeof(FejdStartup), "GetPublicPasswordError")]
    public static class RemovePublicPasswordError
    {
        private static bool Prefix(ref string __result)
        {
            __result = "";
            return false;

        }
    }
}