using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Logging   
{
    [DisallowConcurrentExecution]
    public class Supervisor : IJob
    {
        //private readonly IProgramManager _manageri;

        //public Supervisor(IProgramManager manageri)
        //{
        //    _manageri = manageri;
        //}

        public async Task Execute(IJobExecutionContext context)
        {
            //await._manageri.DoWork();
        }
    }
}
