using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Interview_Project.Controllers.Resources;
using Interview_Project.Core.Domain;
using Interview_Project.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Interview_Project.Controllers
{
    [ApiController]
    [Route("/api/publishers")]
    public class PublishersController : ControllerBase
    {
        private readonly IPublishersRepository _publishersRepository;
        private readonly IMapper _mapper;

        public PublishersController(IPublishersRepository publishersRepository, IMapper mapper)
        {
            _publishersRepository = publishersRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPublishers()
        {
            // TODO: PubInfo is too fat, may use other URL to get the publisher's info.
            var publishers = await _publishersRepository.GetPublishers();
            
            return Ok(_mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherResource>>(publishers));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisher(string id)
        {
            var publisher = await _publishersRepository.GetPublisher(id);
            if (publisher == null)
                return NotFound();

            return Ok(_mapper.Map<Publisher, PublisherResource>(publisher));
        }
    }
}