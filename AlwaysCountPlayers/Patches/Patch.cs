using HarmonyLib;
using UnityEngine;

namespace AlwaysCountPlayers.Patches
{
    class AlwaysCountPlayersPatch
    {
        private static bool hasAppliedUpgrade = false;

        [HarmonyPatch(typeof(GameDirector), "Start")]
        class GameDirectorPatch
        {
            static void Postfix()
            {
                GameObject.FindObjectOfType<MonoBehaviour>().StartCoroutine(WaitForLevel());
            }
        }

        private static System.Collections.IEnumerator WaitForLevel()
        {
            while (!SemiFunc.LevelGenDone())
            {
                yield return new WaitForSeconds(0.5f);
            }

            if (!hasAppliedUpgrade && SemiFunc.RunIsLevel())
            {
                foreach (PlayerAvatar player in SemiFunc.PlayerGetAll())
                {
                    PunManager.instance.UpgradeMapPlayerCount(SemiFunc.PlayerGetSteamID(player));
                }
                hasAppliedUpgrade = true;
            }
        }

        [HarmonyPatch(typeof(RunManager), "ResetProgress")]
        class RunManagerResetPatch
        {
            static void Postfix()
            {
                hasAppliedUpgrade = false;
            }
        }
    }
}
