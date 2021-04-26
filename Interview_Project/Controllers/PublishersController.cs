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
    [Route("/api/publishers")]
    public class PublishersController : ControllerBase
    {
        private readonly IPublishersRepository _publishersRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PublishersController(IPublishersRepository publishersRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _publishersRepository = publishersRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

        [HttpPost]
        public async Task<IActionResult> AddPublisher(SavePublisherResource saveResource)
        {
            if (await _publishersRepository.GetPublisher(saveResource.PubId, false) != null)
                return BadRequest("The duplicated pubId");

            if (string.IsNullOrWhiteSpace(saveResource.Country))
                saveResource.Country = PublisherConstraints.DefaultCountryName;

            var publisher = _mapper.Map<SavePublisherResource, Publisher>(saveResource);
            var result = await _publishersRepository.AddAsync(publisher);
            await _unitOfWork.CompleteAsync();

            return Ok(_mapper.Map<Publisher, PublisherResource>(result));
        }
    }
}