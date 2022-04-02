using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Steamworks;
using SDG.Unturned;
using SDG.SteamworksProvider;
using Rocket.Unturned.Player;
using Rocket.Core.Plugins;
using AcidLib;
using System.IO;
using Rocket.Unturned.Events;
using Console = AcidLib.Console;
using ALFunctions = AcidLib.Functions;
using APFunctions = AcidPlugin.Data.Functins;
using U = Rocket.Unturned.U;
using Rocket.Unturned.Permissions;
using Rocket.Unturned.Extensions;

namespace AcidPlugin
{
    class TestCom : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "TestCommand";

        public string Help => "testc";

        public string Syntax => "tes tex";

        public List<string> Aliases => new List<string> { "tco", "tc" };

        public List<string> Permissions => new List<string> { "AP.TC" };
        public UnturnedPlayer player;
        public void Execute(IRocketPlayer caller, string[] command)
        {
            player = (UnturnedPlayer)caller;
            EffectManager.sendUIEffect(32002, 1, player.CSteamID, true);
            player.Player.setPluginWidgetFlag(EPluginWidgetFlags.Modal, true);
        }
    }
}
