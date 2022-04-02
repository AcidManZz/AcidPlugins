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
using GetPlayer = AcidLib.Unturned.Player.Get;

namespace AcidPlugin
{
    class GetIp : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "GetIp";

        public string Help => "/GetIp";

        public string Syntax => " id пользователя ";

        public List<string> Aliases => new List<string> { "apgip", "APGIP", "AP.GI" };

        public List<string> Permissions => new List<string> { "AP.GIP", "admin", "AP.FA" };
        public UnturnedPlayer player;
        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer target = GetPlayer.FromString(command[0]);
            string PIP;
            string mess;
            player = (UnturnedPlayer)caller;
            PIP = target.IP;
            mess = player.CharacterName + " , айпи игрока [ "+ target.CharacterName + " ] = [ " + PIP + " ] !";
            AcidLib.Unturned.Chat.Say(player.CSteamID, mess);
            AcidLib.Console.Warn(mess);
            AcidLib.Unturned.ChatEvent.ComUsedWParam(player, command, "AP.GIP");
        }
    }
}