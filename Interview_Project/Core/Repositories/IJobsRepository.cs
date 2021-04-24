using System.Collections.Generic;
using System.Threading.Tasks;
using Interview_Project.Core.Domain;

namespace Interview_Project.Core.Repositories
{
    public interface IJobsRepository : IRepository<Job>
    {
        Task<IEnumerable<Job>> GetJobs(bool includeEmployee = true);

        Task<Job> GetJob(short id, bool includeEmployee = true);
    }
}