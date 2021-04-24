using Interview_Project.Core.Repositories;
using Interview_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Interview_Project.Persistence.Repositories
{
    public class JobRepository : Repository<Job, PubsContext>, IJobsRepository
    {
        public JobRepository(PubsContext context) : base(context)
        {
        }
    }
}