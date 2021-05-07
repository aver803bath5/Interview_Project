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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmployeeValidator _validator;

        public EmployeesController(IEmployeeRepository employeeRepository,
            IUnitOfWork unitOfWork, IMapper mapper, IEmployeeValidator validator)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();

            return Ok(_mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employees));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(string id)
        {
            var employee = await _employeeRepository.GetEmployee(id.Trim());

            if (employee == null)
                return NotFound();

            return Ok(_mapper.Map<Employee, EmployeeResource>(employee));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] SaveEmployeeResource saveResource)
        {
            var employeeResourceEmpId = saveResource.EmpId;
            var employeeResourceJobLvl = saveResource.JobLvl;
            var employeeResourceJobId = saveResource.JobId;

            if (await _validator.ValidateIfEmployeeExisted(employeeResourceEmpId))
                return BadRequest("The EmpId existed.");
            if (!await _validator.ValidateIfTheJobExists(employeeResourceJobId))
                return BadRequest("The job doesn't exist.");
            if (!await _validator.ValidateJobLvlIsWithinTheRangeOfTheGivenJob(employeeResourceJobId,
                employeeResourceJobLvl))
                return BadRequest("The given job level is not in the range of the job levels of the given job.");
            if (!await _validator.ValidateIfThePubExists(saveResource.PubId))
                return BadRequest("The publisher does not exist.");

            var employee = _mapper.Map<SaveEmployeeResource, Employee>(saveResource);
            await _employeeRepository.AddAsync(employee);
            await _unitOfWork.CompleteAsync();

            var addedEmployee = await _employeeRepository.GetEmployee(employee.EmpId);
            var result = _mapper.Map<Employee, EmployeeResource>(addedEmployee);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var deletedEmployee = await _employeeRepository.DeleteAsync(id.Trim());
            if (deletedEmployee == null)
                return NotFound();

            await _unitOfWork.CompleteAsync();

            return Ok(deletedEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(string id, [FromBody] SaveEmployeeResource saveEmployeeResource)
        {
            var employee = await _employeeRepository.GetEmployee(id, false);
            if (employee == null)
                return NotFound();

            var employeeResourceJobLvl = saveEmployeeResource.JobLvl;
            var employeeResourceJobId = saveEmployeeResource.JobId;
            if (!await _validator.ValidateIfTheJobExists(employeeResourceJobId))
                return BadRequest("The job doesn't exist.");
            if (!await _validator.ValidateJobLvlIsWithinTheRangeOfTheGivenJob(employeeResourceJobId,
                employeeResourceJobLvl))
                return BadRequest("The given job level is not in the range of the job levels of the given job.");
            if (!await _validator.ValidateIfThePubExists(saveEmployeeResource.PubId))
                return BadRequest("The publisher does not exist.");

            _mapper.Map(saveEmployeeResource, employee);
            await _unitOfWork.CompleteAsync();

            employee = await _employeeRepository.GetEmployee(id, false);
            var result = _mapper.Map<Employee, EmployeeWithoutRelatedResource>(employee);

            return Ok(result);
        }
    }
}