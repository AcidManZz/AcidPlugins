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

namespace AcidPlugin
{
    class leave : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "leave";

        public string Help => "выйти с сервера";

        public string Syntax => "/leave {разделение параметров с помощью знака \". пример: [ /leave \"я вышел\" ] }";

        public List<string> Aliases => new List<string> { "apl", "APL", "Leave" };

        public List<string> Permissions => new List<string> { "admin", "AP.FA", "AP.L" };
        public UnturnedPlayer player;
        public void Execute(IRocketPlayer caller, string[] command)
        {
            string message = command[0];
            player = (UnturnedPlayer)caller;
            string mess = "игрок с ником [ " + player.SteamName + " ] и ID [ " + player.CSteamID + " ] использовал команду { leave } с сообщением [ " + message + " ]";
            AcidLib.Unturned.Player.Kick(player, message, mess);
        }
    }
}
