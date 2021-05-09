using System.Threading.Tasks;
using Interview_Project.Core.Repositories;

namespace Interview_Project.Controllers
{
    public class EmployeeValidator : IEmployeeValidator
    {
        private readonly IJobsRepository _jobsRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPublishersRepository _publishersRepository;

        public EmployeeValidator(IJobsRepository jobsRepository, IEmployeeRepository employeeRepository,
            IPublishersRepository publishersRepository)
        {
            _jobsRepository = jobsRepository;
            _employeeRepository = employeeRepository;
            _publishersRepository = publishersRepository;
        }

        public async Task<bool> ValidateIfEmpIdIsDuplicated(string empId)
        {
            return await _employeeRepository.GetEmployeeByEmpId(empId) != null;
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

        public async Task<bool> ValidateIfThePubExists(string pubId)
        {
            return await _publishersRepository.GetPublisher(pubId, false) != null;
        }
    }
}