using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Interview_Project.Controllers.Resources;
using Interview_Project.Core;
using Interview_Project.Core.Domain;
using Interview_Project.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Interview_Project.Controllers
{
    [ApiController]
    [Route("/api/jobs")]
    public class JobsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public JobsController(IMapper mapper, IJobsRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _repository.GetJobs();

            return Ok(_mapper.Map<IEnumerable<Job>, IEnumerable<JobResource>>(jobs));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(short id)
        {
            var job = await _repository.GetJob(id);

            if (job == null)
                return NotFound();

            return Ok(_mapper.Map<Job, JobResource>(job));
        }

        [HttpPost]
        public async Task<IActionResult> AddJob([FromBody] SaveJobResource jobResource)
        {
            var job = _mapper.Map<SaveJobResource, Job>(jobResource);
            await _repository.AddAsync(job);
            await _unitOfWork.CompleteAsync();

            var addedJob = await _repository.GetJob(job.JobId, false);
            var result = _mapper.Map<Job, JobResource>(addedJob);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(short id)
        {
            var deletedJob = await _repository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();

            return Ok(_mapper.Map<Job, JobResource>(deletedJob));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(short id, [FromBody] SaveJobResource jobResource)
        {
            var job = await _repository.GetJob(id, false);
            _mapper.Map(jobResource, job);
            await _unitOfWork.CompleteAsync();

            job = await _repository.GetJob(id, false);
            var result = _mapper.Map<Job, JobResource>(job);

            return Ok(result);
        }
    }
}