namespace WebApiVoorQii.Fake_Database;

public class FakeDatabaseData {

    public List<string> BusinessKeys { get; set; } = new();

    public FakeDatabaseData() {
        for (int i = 0; i < 10000; i++) {
            BusinessKeys.Add(Guid.NewGuid().ToString());
        }
    }
}
