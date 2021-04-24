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
    [Route("/api/employees")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _repository.GetEmployees();
            
            return Ok(_mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employees));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(string id)
        {
            var employee = await _repository.GetEmployee(id);

            if (employee == null)
                return NotFound();

            return Ok(_mapper.Map<Employee, EmployeeResource>(employee));
        }
    }
}