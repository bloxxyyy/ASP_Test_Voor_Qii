using WebApiVoorQii.Fake_Database;

namespace WebApiVoorQii.Dao;

public class EmployeeDao {
    private readonly FakeDatabaseData _fakeDatabaseData;
    public EmployeeDao(FakeDatabaseData fakeDatabaseData) => _fakeDatabaseData = fakeDatabaseData;
    public List<string> GetBusinessKeys() => _fakeDatabaseData.BusinessKeys;
}
