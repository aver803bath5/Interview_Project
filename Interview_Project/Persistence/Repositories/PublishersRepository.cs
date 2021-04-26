using System.Collections.Generic;
using System.Threading.Tasks;
using Interview_Project.Core.Domain;
using Interview_Project.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Interview_Project.Persistence.Repositories
{
    public class PublishersRepository : Repository<Publisher, PubsContext>, IPublishersRepository
    {
        private readonly PubsContext _context;

        public PublishersRepository(PubsContext context) : base(context)
        {
            _context = context;
        }

        public async  Task<IEnumerable<Publisher>> GetPublishers(bool includeRelated = true)
        {
            if (!includeRelated)
                return await _context.Publishers.ToListAsync();
            
            return await _context.Publishers
                .Include(p => p.Employees)
                .Include(p => p.Titles)
                .Include(p => p.PubInfo)
                .ToListAsync();
        }

        public async Task<Publisher> GetPublisher(string pubId, bool includedRelated = true)
        {
            if (!includedRelated)
                return await _context.Publishers.FindAsync(pubId);

            return await _context.Publishers
                .Include(p => p.Employees)
                .Include(p => p.Titles)
                .Include(p => p.PubInfo)
                .SingleOrDefaultAsync(p => p.PubId == pubId);
        }
    }
}