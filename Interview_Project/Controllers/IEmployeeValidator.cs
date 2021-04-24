using System.Threading.Tasks;

namespace Interview_Project.Controllers
{
    public interface IEmployeeValidator
    {
        bool ValidateEmpId(string empId);
        Task<bool> ValidateJobId(short jobId);
        bool ValidateJobLvl(byte jobLvl);
    }
}