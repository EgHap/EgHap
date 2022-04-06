using InfinityScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgHap
{
    internal class Commands
    {
        public static List<Command> cmd;

        public Commands()
        {
            cmd = new List<Command>();

            NewCommand("version", (sender, args) =>
            {
                Utils.RawSayTo(sender, "version " + Main.version);
            }, "version ",
            "version of EgHap Script"); 
            
            NewCommand("help", (sender, args) =>
            {
                Utils.RawSayTo(sender, "idiot");
            }, "help",
 "You can see what command you are able to use");

            /*NewCommand("usage", (sender, args) =>
            {
                if (args[1] == cmd[1].Name)
                    Utils.RawSayTo(sender, cmd[1].Description);
                else
                    Utils.RawSayTo(sender, "Command not found");
            },
            "usage <cmd>",
            "You can see what command you are able to use");*/
        }
        public void NewCommand(string Command_Name, Action<Entity, string[]> arguments, string Command_Usage, string Command_Description)
        {
            cmd.Add(new Command(Command_Name, arguments, Command_Usage, Command_Description));
        }
    }

    internal class Command
    {
        private static Action<Entity, string[]> Action;
        public string Name;
        public string Usage;
        public string Description;


        public Command(string command_name, Action<Entity, string[]> action, string command_usage, string command_description)
        {
            Name = command_name;
            Action = action;
            Usage = command_usage;
            Description = command_description;
        }

        internal static void LoadCommmands(Entity player, string message)
        {
            string command = message.Substring(1).Split(' ')[0].ToLowerInvariant();
            
            bool hasMatch = Commands.cmd.Any(x => x.Name == command);

            string[] args = null;

            if (hasMatch)
                Action(player, args);
            else
                Utils.RawSayTo(player, "This command does not exist");

        }
    }
}
