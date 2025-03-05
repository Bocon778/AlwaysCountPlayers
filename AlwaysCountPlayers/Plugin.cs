using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using AlwaysCountPlayers.Patches;

namespace AlwaysCountPlayers
{
    [BepInPlugin(modGUID, modeName, modVersion)]
    public class AlwaysCountPlayers : BaseUnityPlugin
    {
        private const string modGUID = "Bocon.AlwaysCountPlayers";
        private const string modeName = "God Mode";
        private const string modVersion = "1.3.0";

        private const string ASCII_LOGO = @"
            _                                _____                      _     _____   _                                
     /\    | |                              / ____|                    | |   |  __ \ | |                               
    /  \   | |__      __ __ _  _   _  ___  | |      ___   _   _  _ __  | |_  | |__) || |  __ _  _   _   ___  _ __  ___ 
   / /\ \  | |\ \ /\ / // _` || | | |/ __| | |     / _ \ | | | || '_ \ | __| |  ___/ | | / _` || | | | / _ \| '__|/ __|
  / ____ \ | | \ V  V /| (_| || |_| |\__ \ | |____| (_) || |_| || | | || |_  | |     | || (_| || |_| ||  __/| |   \__ \
 /_/    \_\|_|  \_/\_/  \__,_| \__, ||___/  \_____|\___/  \__,_||_| |_| \__| |_|     |_| \__,_| \__, | \___||_|   |___/
                                __/ |                                                            __/ |                 
                               |___/                                                            |___/                  ";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static AlwaysCountPlayers Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo(ASCII_LOGO);

            harmony.PatchAll();
        }
    }
}