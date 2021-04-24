using System.Collections.Generic;
using System.Threading.Tasks;
using Interview_Project.Core.Domain;
using Interview_Project.Core.Repositories;
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

        // Use includeEmployee flag to determine whether to join employee table because sometimes we only need to return
        // job object like Inserting, Update operations.
        public async Task<IEnumerable<Job>> GetJobs(bool includeEmployee = true)
        {
            if (!includeEmployee)
                return await _context.Jobs.ToListAsync();

            return await _context.Jobs.Include(j => j.Employees).ToListAsync();
        }

        // Use includeEmployee flag to determine whether to join employee table because sometimes we only need to return
        // job object like Inserting, Update operations.
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