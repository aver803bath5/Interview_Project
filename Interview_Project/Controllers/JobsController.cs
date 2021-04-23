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
    }
}