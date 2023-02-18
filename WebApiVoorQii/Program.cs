using WebApiVoorQii.Dao;
using WebApiVoorQii.Fake_Database;
using WebApiVoorQii.Service.Employee;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register the fakeDB as a singleton
builder.Services.AddSingleton<FakeDatabaseData>();

// Register the EmployeeDao as a singleton
builder.Services.AddSingleton<EmployeeDao>();

// Register the Crasher as a singleton and inject the ILogger<EmployeeService>
builder.Services.AddSingleton<CrasherEmployeeService>(sp => new CrasherEmployeeService(
    sp.GetService<ILogger<CrasherEmployeeService>>()
));

// Register the EmployeeService as a singleton and inject the ILogger<EmployeeService>
builder.Services.AddSingleton<EmployeeService>(sp => new EmployeeService(
    sp.GetService<EmployeeDao>(),
    sp.GetService<ILogger<EmployeeService>>()
));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
