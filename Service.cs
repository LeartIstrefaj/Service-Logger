using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf.Builders;

namespace Service_Logging
{
    public class Service
    {
        private readonly ILogger<Service> _logger;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

      
        public Service(IServiceProvider serviceProvider)
        {
            _logger = serviceProvider.GetRequiredService<ILogger<Service>>();
            _configuration = serviceProvider.GetRequiredService<IConfiguration>();
            _serviceProvider = serviceProvider;
            
        }

        public async Task Fillo()
        {
            _logger.LogInformation("The Service started");
            await Scheduler();
            
        }

        public async Task Ndalo()
        {
            _logger.LogInformation("The Service ended");
        }

        public async Task Scheduler()
        {
            if(!int.TryParse(_configuration["FrekuencaVezhguese"],out var frekuenca))
            {
                frekuenca = 2; // default value if failed conection from appsettings.json
            }

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(); 
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            SupervisorJobFactory supervisorJobFactory = new SupervisorJobFactory(_serviceProvider);
            scheduler.JobFactory = (Quartz.Spi.IJobFactory)supervisorJobFactory;

            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<Supervisor>()
                .WithIdentity("Vezhguesi fajllave")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("frekuenca e Vezhguesit te fjallave")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(frekuenca).RepeatForever())
                .Build();
            await scheduler.ScheduleJob(job,trigger);
        }
    }
}
