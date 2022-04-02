using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcidLib;
using Rocket.Core.Plugins;
using System.IO;
using Rocket.Unturned.Events;
using SDG.Unturned;
using SDG.SteamworksProvider;
using Rocket.Unturned.Player;
using Console = AcidLib.Console;
using ALFunctions = AcidLib.Functions;
using APFunctions = AcidPlugin.Data.Functins;
using U = Rocket.Unturned.U;
using Rocket.Unturned.Permissions;
using Steamworks;
using Rocket.Unturned.Extensions;
using GetPlayer = AcidLib.Unturned.Player.Get;
using uChat = AcidLib.Unturned.Chat;

namespace AcidPlugin.Comands
{
    internal class Console : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Console;

        public string Name => "Console";

        public string Help => "not supports help";

        public string Syntax => "not supports syntax";

        public List<string> Aliases => new List<string> { "AP.C", "Con" };

        public List<string> Permissions => new List<string> { "administrator", "admin" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command[0] == "color")
            {
                if (command[1] == "black")
                {
                    AcidLib.Console.Color(System.ConsoleColor.Black);
                } else if (command[1] == "white")
                {
                    AcidLib.Console.Color(System.ConsoleColor.White);
                } else if (command[1] == "yellow")
                {
                    AcidLib.Console.Color(System.ConsoleColor.Yellow);
                } else if (command[1] == "blue")
                {
                    AcidLib.Console.Color(System.ConsoleColor.Blue);
                }
            } else if (command[1] == "ChatSay")
            {
                if (command[2] == "All")
                {
                    Rocket.Unturned.Chat.UnturnedChat.Say(command[3]);
                } else if (command[2] == "To")
                {
                    UnturnedPlayer player = GetPlayer.FromString(command[4]);
                    uChat.Say(player, command[5]);
                }
            } else if (command[1] == "Clear")
            {
                AcidLib.Console.Clear();
            }
        }
    }
}
