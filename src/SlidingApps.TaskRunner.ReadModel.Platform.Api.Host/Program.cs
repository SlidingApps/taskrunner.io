
using SlidingApps.TaskRunner.Foundation.Configuration;
using SlidingApps.TaskRunner.Foundation.Infrastructure;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Extension;
using SlidingApps.TaskRunner.Foundation.Infrastructure.Logging;
using log4net.Config;
using Microsoft.Owin.Hosting;
using System;
using System.Linq;
using System.Threading;

namespace SlidingApps.TaskRunner.ReadModel.Platform.Api.Host
{
    internal class Program
	{
        private const ConsoleColor APP_FOREGROUNDCOLOR = ConsoleColor.Green;
        private const ConsoleColor LOG_FOREGROUNDCOLOR = ConsoleColor.Yellow;

		private static void Main(string[] args)
		{
			Console.Clear();

            Console.ForegroundColor = Program.APP_FOREGROUNDCOLOR;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine(string.Format("{0} ({1})", typeof(Program).Assembly.GetName().Name, typeof(Program).Assembly.GetName().Version));
            Console.WriteLine("Press q to quit ...");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.ResetColor();

            XmlConfigurator.Configure();

			try
			{
                var hostUri = WebApiConfiguration.HostUri;
                Program.WriteMessage(string.Format("Network binding: {0}", hostUri));

                var server = WebApp.Start(hostUri, app =>
                {
                    app.Properties.Add("Development", true);
                    var startup = new Startup();
                    startup.Configuration(app);
                });

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
                        server.Dispose();
                        break;
                    }
                }
            }
			catch (Exception ex)
			{
				Logger.Log.Error(ex.ToJson());
			    Logger.Log.Error(ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                Console.ReadKey();
			}

		}

        internal static void WriteMessage(string message)
        {
            if (Console.CursorLeft > 0) Console.Write("\r\n");

            Console.ForegroundColor = Program.LOG_FOREGROUNDCOLOR;
            Console.WriteLine("[{0}] {1}", DateTime.Now.ToString("HH:mm:ss.fff"), message);
            Console.ResetColor();
        }
	}
}
