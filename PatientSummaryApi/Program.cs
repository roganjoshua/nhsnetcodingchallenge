using Microsoft.EntityFrameworkCore;
using PatientSummaryApi;
using PatientSummaryApi.Domain.PatientSummary;
using PatientSummaryApi.Infrastructure.Data;
using PatientSummaryApi.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add the in-memory db for use by the repository
// This would normally come from configuration
// so we can swap db contexts for Mock for Testing, PostgreSQL or MS SQL Server, and include connection strings
builder
    .Services
    .AddDbContext<PatientContext>(options => options
        .UseInMemoryDatabase("PatientSummaryDatabase")
    );

builder.Services.AddScoped<IPatientSummaryRepository, PatientSummaryRepository>();
builder.Services.AddScoped<IPatientSummaryService, PatientSummaryService>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PatientContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}


// constrain id to an int
app.MapGet("/patientsummary/{id:int}", async (int id, IPatientSummaryService patientSummaryService) =>
{
    var patientSummary = await patientSummaryService.GetPatientSummaryById(id);
    if (patientSummary == null)
    {
       return Results.NotFound();
    }

    return Results.Ok(patientSummary.ToResponse());
});

app.Run();
