using System.Collections.Generic;
using System.Threading.Tasks;
using Interview_Project.Core.Repositories;
using Interview_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Interview_Project.Persistence.Repositories
{
    public class JobRepository : Repository<Job, PubsContext>, IJobsRepository
    {
        private readonly PubsContext _context;

        public JobRepository(PubsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetJobs(bool includeEmployee = true)
        {
            if (!includeEmployee)
                return await _context.Jobs.ToListAsync();

            return await _context.Jobs.Include(j => j.Employees).ToListAsync();
        }

        public async Task<Job> GetJob(short id, bool includeEmployee = true)
        {
            if (!includeEmployee)
                return await _context.Jobs.FindAsync(id);

            return await _context.Jobs
                .Include(j => j.Employees)
                .SingleOrDefaultAsync(j => j.JobId == id);
        }
    }
}