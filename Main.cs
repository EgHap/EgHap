using InfinityScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgHap
{
    public class Main : BaseScript
    {
        public static string version = "0.0.3";
        public string[] credits =
        {
            "This scripts has been made by EgHap",
            "NoKnife was C&P from SAT",
        };

        Utils Utils;
        Config Config;
        Clients Clients;
        Admin Admin;
        Commands Commands;
        public Main()
        {
            Utils = new Utils();
            Config = new Config();
            Clients = new Clients();
            Admin = new Admin();
            Commands = new Commands();

            PlayerConnecting += Main_PlayerConnecting;
            PlayerConnected += Main_PlayerConnected;
            PlayerDisconnected += Main_PlayerDisconnected;

            #region credits

            HudElem VHud = HudElem.CreateServerFontString(HudElem.Fonts.HudSmall, 0.5f);
            VHud.SetText("^1EgHap Script v" + version);
            VHud.SetPoint("bottomright", "bottomright");

            Utils.PrintInfo("EgHap Script v" + version);
            Utils.PrintInfo(credits[0]);
            Utils.PrintInfo(credits[1]);
            #endregion
        }

        private void Main_PlayerDisconnected(Entity obj)
        {
            Clients.PlayerDisconnected(obj);
        }

        private void Main_PlayerConnecting(Entity obj)
        {
            Clients.PlayerConnecting(obj);
        }

        private void Main_PlayerConnected(Entity obj)
        {
            Clients.PlayerConnected(obj);
            Admin.PlayerConnected(obj);
        }

        public override EventEat OnSay3(Entity player, ChatType type, string name, ref string message)
        {
            if (message.StartsWith("!"))
            {
                Command.LoadCommmands(player, message);
                return EventEat.EatGame;
            }
            return EventEat.EatNone;
        }
    }
}
