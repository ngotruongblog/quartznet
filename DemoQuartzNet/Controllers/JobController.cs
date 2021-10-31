using DemoQuartzNet.Jobs;
using Microsoft.AspNetCore.Mvc;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoQuartzNet.Controllers
{
    public class JobController : Controller
    {
        private readonly IScheduler _scheduler;
        public JobController(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }
        public void Start()
        {
            if (!_scheduler.IsStarted)
            {
                _scheduler.Start();
            }
        }
        public async Task AddJob()
        {
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("WriteDataJob")
                .WithCronSchedule("0 40 9 * * ?")
                .WithPriority(1)
                .Build();
            IJobDetail job = JobBuilder.Create<WriteDataJob>()
                        .WithIdentity("WriteDataJob")
                        .Build();
            if (await _scheduler.CheckExists(job.Key))
            {
                await _scheduler.AddJob(job, true, true);
                await _scheduler.ResumeJob(job.Key);
                await _scheduler.RescheduleJob(trigger.Key, trigger);
            }
            else
            {
                await _scheduler.ScheduleJob(job, trigger);
            }
            if (!_scheduler.IsStarted)
            {
                await _scheduler.Start();
            }
        }
    }
}
