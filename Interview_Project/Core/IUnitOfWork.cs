using System.Threading.Tasks;

namespace Interview_Project.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}