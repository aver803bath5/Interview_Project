using System.Threading.Tasks;

namespace Interview_Project.Controllers
{
    public interface IEmployeeValidator
    {
        Task<bool> ValidateIfTheJobExists(short jobId);
        Task<bool> ValidateIfEmployeeExisted(string empId);
        Task<bool> ValidateJobLvlIsWithinTheRangeOfTheGivenJob(short jobId, byte jobLvl);
    }
}