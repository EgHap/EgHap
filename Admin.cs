using InfinityScript;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgHap
{
    internal class Admin
    {
        private static Dictionary<string, string> LoadAdmin = new Dictionary<string, string>();
        private static Dictionary<string, string> isAdmin = new Dictionary<string, string>();

        private static Dictionary<RankList, string> Ranks = new Dictionary<RankList, string>();

        public static string AdminsFileLoc = @"scripts\EgHap\Admins.txt";
        public static string Admins_PlayerFileLoc = @"scripts\EgHap\Admins_Player.txt";
        //private static string Rank = "User";

        public Admin()
        {
            if (!File.Exists(AdminsFileLoc))
            {
                string[] Contents =
                {
                    "User:^7::afk,rules,pm,help,admins",
                    "Moderator:^0[^2Mod^0] ^7:supermod:afk,rules,pm,help,admins,tempban,ban,warn,unwarn",
                    "Owner:^0[^5Owner^0] ^7:superowner:*all*",
                };
                File.WriteAllLines(AdminsFileLoc, Contents);
            }
            if (!File.Exists(Admins_PlayerFileLoc))
                File.Create(Admins_PlayerFileLoc);

            Utils.ReadFiles(AdminsFileLoc, LoadAdmin);

            //Utils.ReadFiles(AdminsFileLoc, LoadAdmin);
        }
        public void PlayerConnected(Entity obj)
        {
            GetRank(obj);

            Utils.ReadFiles(Admins_PlayerFileLoc, isAdmin);

            //if(LoadAdmin.ContainsKey(obj.HWID))
        }

        private void GetRank(Entity obj)
        {
            
        }
    }

    internal class RankList
    {
        public string Name = "User";
        public string Prefix = "^7";
        public string Password = "";
        public string Commands = "afk,rules,pm,help,admins";

        public RankList(string name, string prefix, string password, string commands)
        {
            Name = name;
            Prefix = prefix;
            Password = password;
            Commands = commands;
        }
    }
}
