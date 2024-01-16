using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Logging
{
    public class TestLogim
    {
        private readonly ILogger<TestLogim> _logger;
        private readonly IConfiguration _configuration;
        public TestLogim(ILogger<TestLogim> logger, IConfiguration configuration) 
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void Shenim()
        {
            var test = _configuration["Folderi"];
            _logger.LogInformation($"writing in log-file:  {test}");

        }
    }
}
