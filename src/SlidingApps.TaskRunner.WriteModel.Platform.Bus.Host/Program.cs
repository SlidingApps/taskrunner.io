﻿
using Autofac;
using SlidingApps.TaskRunner.Foundation.Infrastructure;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Logging;
using log4net.Config;
using MassTransit;
using System;
using System.Linq;
using System.Threading;

namespace SlidingApps.TaskRunner.WriteModel.Platform.Bus.Host
{
    internal class Program
    {
        private const ConsoleColor FOREGROUNDCOLOR = ConsoleColor.Yellow;

        private static readonly string[] HEADER = new[]
        {
            @"      ____      _   _               ____                _           ",
            @"     / ___|___ | |_| |_ ___  _ __  / ___|__ _ _ __   __| |_   _     ",
            @"    | |   / _ \| __| __/ _ \| '_ \| |   / _` | '_ \ / _` | | | |    ",
            @"    | |__| (_) | |_| || (_) | | | | |__| (_| | | | | (_| | |_| |    ",
            @"   __\____\___/ \__|\__\___/|_| |_|\____\__,_|_| |_|\__,_|\__, |    ",
            @"  / ___|___  _ __ ___  _ __ ___   __ _ _ __   __| | __ ) _|___/___  ",
            @" | |   / _ \| '_ ` _ \| '_ ` _ \ / _` | '_ \ / _` |  _ \| | | / __| ",
            @" | |__| (_) | | | | | | | | | | | (_| | | | | (_| | |_) | |_| \__ \ ",
            @"  \____\___/|_| |_| |_|_| |_| |_|\__,_|_| |_|\__,_|____/ \__,_|___/ ",
            @"                                                                    "
        };

        private static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");

            Console.ForegroundColor = Program.FOREGROUNDCOLOR;
            HEADER.ToList().ForEach(Console.WriteLine);
            Console.ResetColor();

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine(string.Format("{0} ({1})", typeof(Program).Assembly.GetName().Name, typeof(Program).Assembly.GetName().Version));
            Console.WriteLine("Press q to quit ...");
            Console.WriteLine("-----------------------------------------------------------------");

            XmlConfigurator.Configure();

            IBusControl bus = null;
            ConnectHandle handle = null;
            try
            {
                IContainer container = Program.ConfigureAutofac();
                bus = Program.ConfigureMassTransit(container);
                handle = Program.ConfigureConsumers(bus);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToJson());
                Logger.Log.Error(ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                Console.ReadKey();
            }
            finally
            {
                Console.WriteLine("-----------------------------------------------------------------");
            }

            Program.WriteMessage("Listening ...");
            while (true)
            {
                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(250);
                }

                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    Program.WriteMessage("Received 'q' to quit");
                    break;
                }
            }

            handle.Disconnect();
            bus.Stop();

        }

        internal static void WriteMessage(string message)
        {
            if (Console.CursorLeft > 0) Console.Write("\r\n");

            Console.ForegroundColor = Program.FOREGROUNDCOLOR;
            Console.WriteLine("{0} - {1}", DateTime.Now.ToString("HH:mm:ss.fff"), message);
            Console.ResetColor();
        }

        private static IContainer ConfigureAutofac()
		{
			IContainer container = AutofacConfig.BuildContainer();
            Program.WriteMessage("Autofac configuration DONE");

			return container;
		}

		private static IBusControl ConfigureMassTransit(IContainer container)
		{
			IBusControl bus = MassTransitConfig.Configure(container);
			bus.Start();
            Program.WriteMessage("MassTransit configuration DONE");

			return bus;
		}

		private static ConnectHandle ConfigureConsumers(IBusControl bus )
		{
			ConnectHandle handle = bus.ConnectConsumer<PlatformConsumer>();
            Program.WriteMessage("Consumer configuration DONE");

			return handle;
		}
    }
}
