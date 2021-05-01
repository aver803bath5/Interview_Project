using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Interview_Project.Core.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Interview_Project.Controllers
{
    public class EmployeeValidator : IEmployeeValidator
    {
        private readonly IJobsRepository _jobsRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeValidator(IJobsRepository jobsRepository, IEmployeeRepository employeeRepository)
        {
            _jobsRepository = jobsRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> ValidateIfEmployeeExisted(string empId)
        {
            return await _employeeRepository.GetEmployee(empId) != null;
        }
        
        public async Task<bool> ValidateIfTheJobExists(short jobId)
        {
            var job = await _jobsRepository.GetJob(jobId, false);
            return job != null;
        }

        // Check if the given jobLvl value is within the max and the min value of the given job.
        public async Task<bool> ValidateJobLvlIsWithinTheRangeOfTheGivenJob(short jobId, byte jobLvl)
        {
            var job = await _jobsRepository.GetJob(jobId, false);
            var minLvl = job.MinLvl;
            var maxLvl = job.MaxLvl;

            return jobLvl >= minLvl && jobLvl <= maxLvl;
        }
    }
}