using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

        public Service(ILogger<Service> logger, IServiceProvider serviceProvider)
        {
            _logger = serviceProvider.GetRequiredService<ILogger<Service>>();
            _configuration = serviceProvider.GetRequiredService<IConfiguration>();
            _serviceProvider = serviceProvider;
            
        }

        public void Start()
        {
            _logger.LogInformation("The Service started");
            
        }

        public void Stop()
        {
            _logger.LogInformation("The Service ended");
        }
    }
}
