using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Topshelf;

namespace Service_Logging
{
    public class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configFile = new ConfigurationBuilder().AddJsonFile("appsettings.json",false,true).Build();
            
            var services = new ServiceCollection();
            services.AddLogging(
                log => { log.ClearProviders(); log.AddNLog(); })

                .AddSingleton(configFile)
                
                ;


            using (var serviceProvider = services.BuildServiceProvider())
            {
                HostFactory.Run(ser =>
                {
                    ser.SetServiceName("Service-Logging");
                    ser.SetDisplayName("Service Logging");
                    ser.SetDescription("Service Logging Project using .NET");
                    ser.Service<Service>(s =>
                    {
                        s.ConstructUsing(_ => new Service(serviceProvider));
                        s.WhenStarted(async ss => await ss.Fillo());
                        s.WhenStopped(ss => ss.Ndalo());
                    });
                });
            }
            


            
        }
    }
}