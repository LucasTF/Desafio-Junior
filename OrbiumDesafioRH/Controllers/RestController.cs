using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrbiumDesafioRH.Extensions;
using OrbiumDesafioRH.Converters;
using OrbiumDesafioRH.Models;
using OrbiumDesafioRH.Resources;
using OrbiumDesafioRH.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace OrbiumDesafioRH.Controllers
{
    [Route("api")]
    [ApiController]
    public class RestController : ControllerBase
    {
        private readonly ILogger<RestController> _logger;
        private readonly IHumanResourcesService _service;
        private readonly EmployeeConverter _converter;

        public RestController(ILogger<RestController> logger, IHumanResourcesService service, EmployeeConverter converter)
        {
            _logger = logger;
            _service = service;
            _converter = converter;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> FindAllEmployees()
        {
            return await _service.FindAllEmployees();
        }

        // GET: api/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> FindEmployeeById(int id)
        {
            var result = await _service.FindEmployeeById(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Employee);
        }

        [HttpGet]
        [Route("email")]
        public async Task<IActionResult> FindEmployeeByEmail(string email)
        {
            var result = await _service.FindEmployeeByEmail(email);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeResource empResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var isEmailUsed = await _service.FindEmployeeByEmail(empResource.Email);
            if (isEmailUsed.Success)
            {
                return Conflict("Esse email já foi utilizado.");
            }
            var employee = _converter.ConvertToModel(empResource);
            var result = await _service.AddEmployee(employee);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Employee);
        }

        // PUT: api/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeResource empResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var isEmailUsed = await _service.FindEmployeeByEmail(empResource.Email);
            if (isEmailUsed.Success)
            {
                if(isEmailUsed.Employee.Id != id)
                {
                    return Conflict("Esse email já foi utilizado.");
                }
            }
            var employee = _converter.ConvertToModel(empResource);
            var result = await _service.UpdateEmployee(id, employee);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Employee);
        }

        // DELETE: api/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            var result = await _service.RemoveEmployee(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Employee);
        }
    }
}
