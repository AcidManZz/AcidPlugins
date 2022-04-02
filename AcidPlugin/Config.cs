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

namespace AcidPlugin
{
    public class Config : IRocketPluginConfiguration
    {
        public void LoadDefaults()
        {
            Console.Alert("AcidPlugin загрузился!");
        }

        public List<string> PlayerInfo;

        public void SaveData(UnturnedPlayer player)
        {
            
        }

        public void SaveName(UnturnedPlayer player, string Name)
        {
            
        }

        public void SaveLastName(UnturnedPlayer player, string LastName)
        {

        }

        

        public class Data
        {
            public string Name;
            public string LastName;
            public string SteamId;
            public string SteamName;
            public string HaveReg;
        }
    }
}
