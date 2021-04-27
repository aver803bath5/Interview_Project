using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Interview_Project.Core.Domain;

namespace Interview_Project.Core.Repositories
{
    public interface IPublishersRepository : IRepository<Publisher>
    {
        Task<IEnumerable<Publisher>> GetPublishers(bool includeRelated = true);
        Task<Publisher> GetPublisher(string pubId, bool includedRelated = true);
    }
}