using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

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
                .AddScoped<TestLogim>();
                
                ;


            using (var serviceProvider = services.BuildServiceProvider())
            {
                var obj = serviceProvider.GetRequiredService<TestLogim>();
                obj.Shenim();
            }
            


            
        }
    }
}