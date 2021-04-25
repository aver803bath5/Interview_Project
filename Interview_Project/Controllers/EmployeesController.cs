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
            var employee = await _employeeRepository.GetEmployee(id);

            if (employee == null)
                return NotFound();

            return Ok(_mapper.Map<Employee, EmployeeResource>(employee));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeResource employeeResource)
        {
            var employeeResourceEmpId = employeeResource.EmpId;
            var employeeResourceJobLvl = employeeResource.JobLvl;
            var employeeResourceJobId = employeeResource.JobId;

            if (await _validator.ValidateIfEmployeeExisted(employeeResourceEmpId))
                return BadRequest("The EmpId existed.");
            // Check if EmpId is match the constraint of emp_id column of employee table.
            if (!_validator.ValidateEmpId(employeeResourceEmpId))
                return BadRequest("EmpId is invalid");

            if (!await _validator.ValidateJobId(employeeResourceJobId))
                return BadRequest("The job does not exist");

            // If the input values of jobId or jobLvl is other than the default value. We must verify if the given
            // jobLvl is in the range of the max value and the min value of the job related with the given jobId.
            if (employeeResourceJobId != EmployeeConstraint.JobIdDefaultValue ||
                employeeResourceJobLvl != EmployeeConstraint.JobLvlDefaultValue)
            {
                if (!await _validator.ValidateJobLvlAndJobId(employeeResourceJobId,
                    employeeResourceJobLvl.GetValueOrDefault()))
                    return BadRequest("The job level is out of the range of the given job.");
            }

            // TODO: return BadRequest when the employeeResource.PubId doesn't belong to any publishers in the pubs table.

            var employee = _mapper.Map<EmployeeResource, Employee>(employeeResource);
            await _employeeRepository.AddAsync(employee);
            await _unitOfWork.CompleteAsync();

            var addedEmployee = await _employeeRepository.GetEmployee(employee.EmpId);
            var result = _mapper.Map<Employee, EmployeeResource>(addedEmployee);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var deletedEmployee = await _employeeRepository.DeleteAsync(id);
            if (deletedEmployee == null)
                return NotFound();

            await _unitOfWork.CompleteAsync();

            return Ok(deletedEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(string id, [FromBody] EmployeeResource employeeResource)
        {
            // TODO: Add validation code to validate given jobLvl, jobId, pubId, and hireDate values.
            var employee = await _employeeRepository.GetEmployee(id, false);
            if (employee == null)
                return NotFound();

            _mapper.Map(employeeResource, employee);
            await _unitOfWork.CompleteAsync();

            employee = await _employeeRepository.GetEmployee(id, false);
            var result = _mapper.Map<Employee, EmployeeWithoutRelatedResource>(employee);

            return Ok(result);
        }
    }
}