﻿using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using HarmonyLib;
using Rocket.API.Collections;

namespace ExtraConcentratedJuice.AntiLock
{
    public class AntiLock : RocketPlugin<AntiLockConfiguration>
    {
        public static AntiLock instance;

        protected override void Load()
        {
            instance = this;

            var harmony = new Harmony("pw.cirno.extraconcentratedjuice");

            harmony.PatchAll();

            Logger.Log("Loaded AntiLock! Default locks allocated: " + Configuration.Instance.defaultLocks);
            Logger.Log("Groups:");
            foreach (LockGroup l in Configuration.Instance.lockGroups)
                Logger.Log("  " + l.Permission + " | " + l.MaxLocks + " locks");
        }

        public override TranslationList DefaultTranslations =>
            new TranslationList
            {
                { "clear_success_other", "You've unlocked all of {0}'s vehicles. ({1} in total.)" },
                { "clear_success", "You've unlocked all of your vehicles. ({0} in total.)" },
                { "player_not_found", "The specified player was not found." },
                { "max_locked_notice", "You have reached your allocated number of vehicle locks. ({0})" },
                { "locked_notice", "You have locked a vehicle. ({0}/{1} locks remaining.)" }
            };
    }
}
