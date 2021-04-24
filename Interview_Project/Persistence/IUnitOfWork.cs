using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Interview_Project.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}