﻿
using CommandLine;
using log4net.Config;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace SlidingApps.TaskRunner.CommandLine
{
    class Program
    {
        private const ConsoleColor FOREGROUNDCOLOR = ConsoleColor.Yellow;

        private static readonly string[] HEADER = new[]
        {
            @"  _____         _    ____                              ",
            @" |_   _|_ _ ___| | _|  _ \ _   _ _ __  _ __   ___ _ __ ",
            @"   | |/ _` / __| |/ / |_) | | | | '_ \| '_ \ / _ \ '__|",
            @"   | | (_| \__ \   <|  _ <| |_| | | | | | | |  __/ |   ",
            @"   |_|\__,_|___/_|\_\_|_\_\\__,_|_| |_|_| |_|\___|_|   ",
            @"                   / ___| |   |_ _|                    ",
            @"                  | |   | |    | |                     ",
            @"                  | |___| |___ | |                     ",
            @"                   \____|_____|___|                    ",
            @"                                                       "
        };

        internal static string SESSION_ID = Path.GetRandomFileName().Replace(".", string.Empty);

		internal static log4net.ILog LOGGER = null;

        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------------------------------");

            Console.ForegroundColor = Program.FOREGROUNDCOLOR;
            Program.HEADER.ToList().ForEach(Console.WriteLine);
            Console.ResetColor();

            Console.WriteLine("-----------------------------------------------------------------");

            Program.WriteFormat("session id {0}", Program.SESSION_ID);

            Arguments arguments = new Arguments();
            Parser.Default.ParseArguments(args, arguments);

            XmlConfigurator.Configure();
            Program.LOGGER = log4net.LogManager.GetLogger(typeof(Program));
            LogLevel.SetLevel(arguments.LogLevel);

            try
            {
                if (args.Count() == 0) throw new ArgumentException("No arguments provided.");

                var instance = PluginManager.GetPlugin(args[0], args);
				Console.WriteLine("-----------------------------------------------------------------");
                instance.Start(Program.SESSION_ID, args);
            }
            catch(Exception ex)
            {
                Program.LOGGER.Error(ex.Message);
            }
            finally
            {
				Console.WriteLine("-----------------------------------------------------------------");
				Program.Write("closing CLI");

#if DEBUG
                Console.ReadKey();
#endif
            }
        }

        internal static void Write(string message)
        {
            Program.WriteFormat("{0}", message);
        }

        internal static void WriteFormat(string format, params object[] args)
        {
            if (Console.CursorLeft > 0) Console.Write("\r\n");

            Console.ForegroundColor = Program.FOREGROUNDCOLOR;
            Console.WriteLine("{0} - {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff"), string.Format(format, args));
            Console.ResetColor();
        }
    }
}
