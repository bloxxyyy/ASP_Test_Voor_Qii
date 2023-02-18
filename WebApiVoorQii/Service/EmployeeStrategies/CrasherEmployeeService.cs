using WebApiVoorQii.Exceptions;

namespace WebApiVoorQii.Service.Employee;

public class CrasherEmployeeService : IEmployeeService
{
    private readonly ILogger<CrasherEmployeeService> _logger;
    public CrasherEmployeeService(ILogger<CrasherEmployeeService> logger) => _logger = logger;

    public string GetNewBusinessKey()
    {
        throw ToManyTriesException.Create(message: "Failed getting new business key.", _logger);
    }
}
