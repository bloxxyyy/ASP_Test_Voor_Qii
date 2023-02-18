using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;
using WebApiVoorQii.Exceptions;
using WebApiVoorQii.Service;

namespace WebApiVoorQii.Controllers;
[ApiController]
[Route("[controller]")]
public class BusinessKeyController : ControllerBase {

    private readonly IEmployeeService _EmployeeService;
    public BusinessKeyController(EmployeeService employeeService) => _EmployeeService = employeeService;

    [HttpGet(Name = "GetNewBusinessKey")]
    [ProducesResponseType(typeof(string), 200)]
    [ProducesResponseType(typeof(void), 404)]
    public IActionResult Get() {
        try {
            return Ok(_EmployeeService.GetNewBusinessKey());
        } catch (ToManyTriesException) {
            return new StatusCodeResult(400);
        }
    }
}
