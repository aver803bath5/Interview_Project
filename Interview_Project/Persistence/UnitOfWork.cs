using System.Threading.Tasks;
using Interview_Project.Core;

namespace Interview_Project.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PubsContext _context;

        public UnitOfWork(PubsContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}