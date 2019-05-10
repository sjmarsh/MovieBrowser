using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using static System.Runtime.InteropServices.RuntimeInformation;
using static System.Runtime.InteropServices.OSPlatform;

namespace MovieBrowser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string url = "http://localhost:5001/";

            using (var server = CreateServer(args, url))
            {

#if RELEASE
                // if running in release mode - start the browser with the url
                StartBrowserWhenServerStarts(server, url);
#endif
                server.Run(); //blocks
            }
        }

        /// <summary>
        /// Create the kestrel server, but don't start it
        /// </summary>
        private static IWebHost CreateServer(string[] args, string url) => WebHost
            .CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureKestrel((context, options) => { options.AllowSynchronousIO = true; })  // work-around for core 3.3 https://stackoverflow.com/questions/55052319/net-core-3-preview-synchronous-operations-are-disallowed
            .UseUrls(url)
            .Build();

        /// <summary>
        /// Register a browser to launch when the server is listening
        /// </summary>
        private static void StartBrowserWhenServerStarts(IWebHost server, string url)
        {
            var serverLifetime = server.Services.GetService(typeof(IHostApplicationLifetime)) as IHostApplicationLifetime;
            serverLifetime.ApplicationStarted.Register(() =>
            {
                var browser =
                    IsOSPlatform(Windows) ? new ProcessStartInfo("cmd", $"/c start {url}") :
                    IsOSPlatform(OSX) ? new ProcessStartInfo("open", url) :
                    new ProcessStartInfo("xdg-open", url); //linux, unix-like

                Process.Start(browser);
            });
        }
    }
}