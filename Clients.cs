using InfinityScript;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgHap
{
    internal class Clients
    {
        //private static Dictionary<string, string> NewPlayerData = new Dictionary<string, string>();
        private static List<PlayerData> IsBanned = new List<PlayerData>();

        private static string ClientsFileLoc = @"scripts\EgHap\Clients.txt";
        private static string BansFileLoc = @"scripts\EgHap\Banned.txt";

        List<Entity> Players;

        public Clients()
        {
            SetupFiles();

            Players = new List<Entity>();
        }

        private void SetupFiles()
        {
            if (!File.Exists(ClientsFileLoc))
                File.Create(ClientsFileLoc); 
            if (!File.Exists(BansFileLoc))
                File.Create(BansFileLoc);
        }

        internal void PlayerConnected(Entity obj)
        {
            Players.Add(obj);

            Utils.RawSayAll(Config.ReadConfig["Welcome_Message"].Replace("<player>", obj.Name));
        }
        internal void PlayerDisconnected(Entity obj)
        {
            Players.Remove(obj);
        }

        internal void PlayerConnecting(Entity obj)
        {
            //NewPlayerData.Add(obj.HWID, obj.GUID.ToString(), obj.GetXUID, obj.Name, obj.IP.Address.ToString())
            PlayerData data = new PlayerData(obj);
            if (IsBanned.Contains(data))
                return;
        }
    }

    internal class PlayerData
    {
        public string Name;
        public string HWID;
        public PlayerData(Entity player)
        {
            Name = player.Name;
            HWID = player.HWID;
        }
    }
}
