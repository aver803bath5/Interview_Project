using System.Collections.Generic;
using System.Threading.Tasks;
using Interview_Project.Controllers.Resources;
using Interview_Project.Core.Domain;
using Interview_Project.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Interview_Project.Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee, PubsContext>, IEmployeeRepository
    {
        private readonly PubsContext _context;

        public EmployeeRepository(PubsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees(bool includeRelated = true)
        {
            if (!includeRelated)
                return await _context.Employees.ToListAsync();

            return await _context.Employees
                .Include(e => e.Job)
                .Include(e => e.Pub)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployee(string id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await _context.Employees.FindAsync(id);

            return await  _context.Employees
                .Include(e => e.Job)
                .Include(e => e.Pub)
                .SingleOrDefaultAsync(e => e.EmpId == id);
        }
    }
}