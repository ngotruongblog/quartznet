using DemoQuartzNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoQuartzNet.Services
{
    public class DemoService : IDemoService
    {
        private readonly SchoolContext _context;
        public DemoService(SchoolContext context)
        {
            _context = context;
        }

        public async Task WriteData(Student data)
        {
            _context.Students.Add(data);
            await _context.SaveChangesAsync();
        }

        public Task<List<Student>> GetData()
        {
            var lst = _context.Students.ToList();
            return Task.FromResult(lst);
        }
    }
}
