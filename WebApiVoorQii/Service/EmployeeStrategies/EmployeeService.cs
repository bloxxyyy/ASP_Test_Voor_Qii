using WebApiVoorQii.Dao;
using WebApiVoorQii.Exceptions;

namespace WebApiVoorQii.Service.Employee;

public class EmployeeService : IEmployeeService
{

    private readonly ILogger<EmployeeService> _logger;
    private readonly EmployeeDao _employeeDao;

    public EmployeeService(EmployeeDao employeeDao, ILogger<EmployeeService> logger)
    {
        _employeeDao = employeeDao;
        _logger = logger;
    }

    public string GetNewBusinessKey()
    {
        var existingKeys = new HashSet<string>(_employeeDao.GetBusinessKeys());
        var maxTries = 50;

        for (int tries = 0; tries < maxTries; tries++)
        {
            var generatedKey = Guid.NewGuid().ToString();
            if (!existingKeys.Contains(generatedKey))
            {
                return generatedKey;
            }
        }

        throw ToManyTriesException.Create(message: "Failed getting new business key.", _logger);
    }

}
