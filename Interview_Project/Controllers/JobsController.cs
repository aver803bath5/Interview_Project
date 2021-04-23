using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Interview_Project.Controllers.Resources;
using Interview_Project.Models;
using Interview_Project.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interview_Project.Controllers
{
    [ApiController]
    [Route("/api/jobs")]
    public class JobsController : ControllerBase
    {
        private readonly PubsContext _context;
        private readonly IMapper _mapper;

        public JobsController(PubsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _context.Jobs.Include(j => j.Employees).ToListAsync();

            return Ok(_mapper.Map<IList<Job>, IList<JobResource>>(jobs));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(short id)
        {
            var job = await _context.Jobs.Include(j => j.Employees).FirstOrDefaultAsync(j => j.JobId == id);

            if (job == null)
                return NotFound();

            return Ok(_mapper.Map<Job, JobResource>(job));
        }

        [HttpPost]
        public async Task<IActionResult> AddJob([FromBody] JobResource jobResource)
        {
            var job = _mapper.Map<JobResource, Job>(jobResource);
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();

            var addedJob = await _context.Jobs.Include(j => j.Employees).FirstAsync(j => j.JobId == job.JobId);
            var result = _mapper.Map<Job, JobResource>(addedJob);
            
            return Ok(result);
        }
        
        
    }
}