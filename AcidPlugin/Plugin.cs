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
using Chat = AcidLib.Unturned.Chat;

namespace AcidPlugin
{
    class Plugin : RocketPlugin<Config>
    {
        public static Plugin Instance;

        protected override void Load()
        {
            
            base.Load();
            /*Functions.SendToSocket("93.159.233.235", 7564, "AcidPlugin загрузился");*/
            AcidLib.Console.Color(ConsoleColor.DarkBlue);
            AcidLib.Console.Say("Загрузка AcidPlugin!");
            Console.Say("вы можете прочитать документацию по использованию на нашем сайте: http://api.mlac.host/unturned/plugins/AcidPlugin/");

            Console.Say("Загружено: 9%");

            UnturnedPlayerEvents.OnPlayerUpdateGesture += UnturnedPlayerEvents_OnPlayerUpdateGesture;
            Console.Say("Событие обновления жестов создано");
            Console.Say("Загружено: 15%");

            U.Events.OnBeforePlayerConnected += Events_OnPlayerConnected;
            Console.Say("Загружено: 25%");
            EffectManager.onEffectButtonClicked += OnButtonClicked;
            Console.Say("Загружено: 50%");
            EffectManager.onEffectTextCommitted += OnTextCommited;
            Console.Say("Загружено: 75%");
            UnturnedPermissions.OnJoinRequested += OnJoinRequested;
            Console.Say("Загружено: 100%");
            Console.Color(ConsoleColor.Black);
            Console.Color(ConsoleColor.Black);
            Console.Color(ConsoleColor.Black);
        }

        private void OnJoinRequested(CSteamID player, ref ESteamRejection? rejectionReason)
        {
            var uplayer = UnturnedPlayer.FromCSteamID(player);
            EffectManager.sendUIEffect(32001, 1, player, true);
            //unturnedPlayer.Player.setPluginWidgetFlag(EPluginWidgetFlags.Modal, true);
            
        }

        private void OnButtonClicked(Player player, string buttonName)
        {
            if (buttonName == "exit_01")
            {
                UnturnedPlayer unturnedPlayer = AcidLib.Unturned.Player.Get.FromPlayer(player);
                unturnedPlayer.Player.setPluginWidgetFlag(EPluginWidgetFlags.Modal, false);
                EffectManager.askEffectClearByID(32001, unturnedPlayer.CSteamID);
            }
        }

        private void OnTextCommited(Player player, string buttonName, string text)
        {
            throw new NotImplementedException();
        }

        private void UnturnedPlayerEvents_OnPlayerUpdateGesture(UnturnedPlayer player, UnturnedPlayerEvents.PlayerGesture gesture)
        {
            
        }
        private void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            AcidLib.Unturned.Chat.Say(player, player.CharacterName + ", приветствуем на сервере " + AcidPlugin.Dat.Server.Name + "!");
            Chat.Say(player, "сайт: https://mlarp.mlac.host?from=game");
            Chat.Say(player, "дискорд: https://discord.gg/HRMe7FDqdC");
            Chat.Say(player, "Приятной игры!");
        }

        protected override void Unload()
        {
            base.Unload();
            UnturnedPlayerEvents.OnPlayerUpdateGesture -= UnturnedPlayerEvents_OnPlayerUpdateGesture;
        }
        public void FixedUpdate()
        {
            foreach(var steampl in Provider.clients)
            {

                UnturnedPlayer uplayer = steampl.ToUnturnedPlayer();

            }
        }
    }
}
