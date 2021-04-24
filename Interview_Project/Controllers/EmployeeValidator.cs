using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Interview_Project.Core.Repositories;

namespace Interview_Project.Controllers
{
    public class EmployeeValidator : IEmployeeValidator
    {
        private readonly IJobsRepository _jobsRepository;

        public EmployeeValidator(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }
        
        public bool ValidateEmpId(string empId)
        {
            var reg = new Regex(
                @"[A-Z][A-Z][A-Z][1-9][0-9][0-9][0-9][0-9][FM]|[A-Z]-[A-Z][1-9][0-9][0-9][0-9][0-9][FM]");
            var isFitConstraint = reg.IsMatch(empId);
            return isFitConstraint;
        }

        public async Task<bool> ValidateJobId(short jobId)
        {
            var job = await _jobsRepository.GetJob(jobId, false);
            return job != null;
        }

        public bool ValidateJobLvl(byte jobLvl)
        {
            return jobLvl > JobConstraints.MinJobLevel || jobLvl < JobConstraints.MaxJobLevel;
        }
    }
}