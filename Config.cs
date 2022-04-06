using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;
namespace EgHap
{
    internal class Config
    {
        #region Configs
        private static string WelcomeMessage = "<player> connected";

        private static string BanMessage = "<player> has been permanently banned by <sender> for <reason>";
        private static string BanMessageToPlayer = "You have been permanently banned for <reason> by <sender>";
        private static string IsBanned = "You are permanently banned from this server";

        private static string TempBanMessage = "<player> has been temporarily banned by <sender> for <reason>";
        private static string TempBanMessageToPlayer = "You have been temporarily banned for <reason> by <sender>";
        private static string IsTempBanned = "You are temporarily banned from this server time remaining <time>";

        private static string WarnMessage = "<player> has been warned for <reason> <warncount>/<maxwarn> by <sender>";


        private static string AdminPrefix = "^7[^2EgHap^7]: ";
        private static string PrivatePrefix = "^7[^1PM^7]: ";

        private static string AlliesPrefix = "Allies";
        private static string AxisPrefix = "Axis";

        private static string MaxWarns = "3";
        private static string TimeFormat = "dd/MM/yyyy";
        #endregion


        public static string NonColoredSvName => GSCFunctions.GetDvar("sv_hostname").ToString().Replace("^0", "").Replace("^1", "").Replace("^2", "").Replace("^3", "").Replace("^4", "").Replace("^5", "").Replace("^6", "").Replace("^7", "").Replace("^8", "").Replace("^9", "").Replace("^;", "").Replace("^:", "");
        
        private static string MainLoc = @"scripts\EgHap\";
        private static string ServerLoc = MainLoc + NonColoredSvName + @"\";
        private string MainConfigLoc = MainLoc + "Config.txt";
        private string ServerConfigLoc = ServerLoc + "Config.txt";

        private static Dictionary<string, string> WriteConfig = new Dictionary<string, string>
        {
            #region Simple Config
            {"Welcome_Message", WelcomeMessage},
            {"Admin_Prefix", AdminPrefix},
            {"Private_Prefix", PrivatePrefix},
            {"AlliesPrefix", AlliesPrefix},
            {"AxisPrefix", AxisPrefix},
            {"MaxWarns", MaxWarns},
            {"TimeFormat", TimeFormat},
            #endregion

            #region Message
            {"BanMessage", BanMessage},
            {"BanMessageToPlayer", BanMessageToPlayer},
            {"IsBanned", IsBanned},

            {"TempBanMessage", TempBanMessage},
            {"TempBanMessageToPlayer", TempBanMessageToPlayer},
            {"IsTempBanned", IsTempBanned},

            {"WarnMessage", WarnMessage},
            #endregion
        };

        public static Dictionary<string, string> ReadConfig = new Dictionary<string, string>();

        public Config()
        {
            CheckDirectorys();
            CheckFiles();

            Utils.ReadFiles(MainConfigLoc, ReadConfig);
        }

        private void CheckDirectorys()
        {
            Utils.PrintInfo("Checking Main Directory...");
            if (!Directory.Exists(MainLoc))
            {
                Utils.PrintInfo("Missing Main Directory, creating new one...");
                Directory.CreateDirectory(MainLoc);
            }

            Utils.PrintInfo("Checking Server Directory...");
            if (!Directory.Exists(ServerLoc))
            {
                Utils.PrintInfo("Missing Server Directory, creating new one...");
                Directory.CreateDirectory(ServerLoc);
            }

        }

        private void CheckFiles()
        {
            Utils.PrintInfo("Checking Files...");
            if (!File.Exists(MainConfigLoc))
            {
                Utils.PrintInfo($"Missing {MainConfigLoc}, creating new one...");
                File.WriteAllLines(MainConfigLoc, WriteConfig.Select(x => x.Key + "=" + x.Value ));
            }

            if (!File.Exists(ServerConfigLoc))
            {
                Utils.PrintInfo($"Missing {ServerConfigLoc}, creating new one...");
                File.Create(ServerConfigLoc);
            }
        }
    }
}