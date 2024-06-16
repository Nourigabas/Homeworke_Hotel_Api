using AutoMapper;
using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.Models.ModelsWithOut;
using Homeworke_Hotel_Api.Services;
using Homeworke_Hotel_Api.Services.Guests;
using Homeworke_Hotel_Api.ViewModels.Employee;
using Homeworke_Hotel_Api.ViewModels.Guest;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Homeworke_Hotel_Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[Controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository Employee;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRepository Employee, IMapper mapper)
        {
            this.Employee = Employee;
            this.mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Employee>> GetEmployees([FromHeader] bool WithOut = true)
        {
            var respone = Employee.GetEmployees();
            if (respone == null)
                return NotFound();
            return WithOut ? Ok(mapper.Map<List<EmployeeWithOutBooking>>(respone)) : Ok(respone);
        }

        [AllowAnonymous]
        [HttpGet("{EmployeeId}",Name = "GetEmployee")]
        public ActionResult<Employee> GetEmployee([FromRoute]int EmployeeId, [FromHeader]bool WithOut = true)
        {
            var respone =  Employee.GetEmployee(EmployeeId);
            if (respone == null)
                return NotFound();
            return WithOut ? Ok(mapper.Map<EmployeeWithOutBooking>(respone)) : Ok(respone);
        }


        [HttpDelete("{EmployeeId}")]
        public ActionResult DeletEmployee([FromRoute]int EmployeeId)
        {
            var Check = Employee.GetEmployee(EmployeeId);
            if (Check == null)
                return NotFound();
            Employee.DeletEmployee(EmployeeId);
            return Ok();
        }


        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody]EmployeeForCreate employee)
        {
            var EmployeeForCreate = mapper.Map<Employee>(employee);
            Employee.CreateEmployye(EmployeeForCreate);
            var EmployeeForCreateWithOut = mapper.Map<EmployeeWithOutBooking>(EmployeeForCreate);
            return CreatedAtRoute("GetEmployee",new { EmployeeId= EmployeeForCreate.Id}, EmployeeForCreateWithOut);
        }
        [HttpPatch]
        public ActionResult<Employee> UpdateEmployee([FromHeader] int EmployeeId, [FromBody] JsonPatchDocument<EmployeeForUpdate> PatchDocument)
        {
            var Check = Employee.GetEmployee(EmployeeId);
            if (Check == null)
                return NotFound();
            Employee.UpdateEmployee(EmployeeId, PatchDocument);
            return NoContent();
        }
    }
}
