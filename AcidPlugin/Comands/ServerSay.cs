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
using AcidLib;

namespace AcidPlugin.Comands
{
    class ServerSay : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "ServerSay";

        public string Help => "/ServerSay message";

        public string Syntax => "message - сообщение, разделять с помощью знака \"";

        public List<string> Aliases => new List<string> { "apss", "APSS", "AP.SS" };

        public List<string> Permissions => new List<string> { "default", "AP.SS", "AP.FA" };
        public UnturnedPlayer player;
        public void Execute(IRocketPlayer caller, string[] command)
        {
            player = (UnturnedPlayer)caller;
            string comUsed = "AP.SS";
            AcidLib.Unturned.ChatEvent.ComUsedWParam(player, command, comUsed);
            AcidLib.Unturned.Chat.Say(command[0]);
        }
    }
}
