using DemoQuartzNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoQuartzNet.Services
{
    public interface IDemoService
    {
        public Task<List<Student>> GetData();
        public Task WriteData(Student data);
    }
}
