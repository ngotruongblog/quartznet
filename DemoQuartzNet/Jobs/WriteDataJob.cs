using DemoQuartzNet.Models;
using DemoQuartzNet.Services;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Threading.Tasks;

namespace DemoQuartzNet.Jobs
{
    public class WriteDataJob: IJob
    {
        private readonly IDemoService _service;
        private readonly ILogger<WriteDataJob> _logger;
        public WriteDataJob(
            ILogger<WriteDataJob> logger, 
            IDemoService service)
        {
            this._logger = logger;
            _service = service;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var data = await _service.GetData();
            var std = new Student { Name = $"Name_{DateTime.Now.Ticks}" };
            await _service.WriteData(std);
            _logger.LogInformation($"WriteData Job: at {DateTime.Now} and Jobtype: {context.JobDetail.JobType}");
        }
    }
}
