using System.Collections.Generic;
using System.Threading.Tasks;
using Interview_Project.Core.Domain;

namespace Interview_Project.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployees(bool includeRelated = true);
    }
}