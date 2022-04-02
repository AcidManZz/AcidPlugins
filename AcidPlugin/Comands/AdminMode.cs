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
    class AdminMode : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "AdminMode";

        public string Help => "/AdminMode (on/off)";

        public string Syntax => "on - включить, off - выключить";

        public List<string> Aliases => new List<string> { "AM", "am", "AP.AM", "AP.AdminMode" };

        public List<string> Permissions => new List<string> { "AP.FA", "admin", "AP.AM" };
        public UnturnedPlayer player;
        public void Execute(IRocketPlayer caller, string[] command)
        {
            player = (UnturnedPlayer)caller;

            AcidLib.Unturned.ChatEvent.ComUsedWParam(player, command, "AP.AM");

            CSteamID pi = player.CSteamID;
            AcidLib.Console.Alert("com0 = " + command[0]);
            if (command.Length == 0) { string mess = player.CharacterName + ", вы ввели неправильное значение!"; AcidLib.Unturned.Chat.Say(pi, mess); }
            if ( command[0] == "on" )
            {
                string mess = player.CharacterName + ", вы в режиме администратора!";
                player.GodMode = true;
                player.VanishMode = true;
                AcidLib.Unturned.Chat.Say(pi, mess);
            } else if ( command[0] == "off" )
            {
                string mess = player.CharacterName + ", вы больше не в режиме администратора!";
                player.GodMode = false;
                player.VanishMode = false;
                AcidLib.Unturned.Chat.Say(pi, mess);
            } else
            {
                string mess = player.CharacterName + ", вы ввели неправильное значение!";
                AcidLib.Unturned.Chat.Say(pi, mess);
            }
        }
    }
}
