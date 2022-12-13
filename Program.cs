using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace LetsKube
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var machineName = Environment.MachineName;
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}