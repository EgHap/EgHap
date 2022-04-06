using InfinityScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgHap
{
    internal class Utils
    {
        private static string sv_hostname = GSCFunctions.GetDvar("sv_hostname");
        private static string sv_currentdsr = GSCFunctions.GetDvar("sv_currentdsr");

        internal static void PrintInfo(string message) => Utilities.PrintToConsole($"[EgHap::Info]: {message}");
        internal static void PrintError(string message) => Utilities.PrintToConsole($"[EgHap::Error]: {message}");
        internal static void RawSayAll(string message) => Utilities.RawSayAll(Config.ReadConfig["Admin_Prefix"] + message);
        internal static void RawSayTo(Entity player, string message) => Utilities.RawSayTo(player.EntRef, Config.ReadConfig["Private_Prefix"] + message);
        internal static void ReadFiles(string file, Dictionary<string, string> dic)
        {
            var lines = System.IO.File.ReadAllLines(file);
            lines.Select(line => line.Split('='))
                 .Where(line => line.Length == 2)
                 .ToList()
                 .ForEach(line => dic.Add(line[0], line[1]));
        }

        private static Dictionary<string, string> Colors = new Dictionary<string, string>
        {
            {"black","^0"},
            {"red","^1"},
            {"green","^2"},
            {"yellow","^3"},
            {"blue","^4"},
            {"cyan","^5"},
            {"pink","^6"},
            {"white","^7"},
            {"default","^8"},
            {"grey","^9"},
            {"yale blue","^;"},
            {"light yellow","^:"}
        };

        private static Dictionary<string, string> Maps = new Dictionary<string, string>
        {
            {"dome","mp_dome"},
            {"seatown","mp_seatown"}
        };
    }
}
