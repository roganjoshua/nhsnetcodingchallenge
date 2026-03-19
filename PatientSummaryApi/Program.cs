using Microsoft.EntityFrameworkCore;
using PatientSummaryApi.Persistence;
using PatientSummaryApi.Repository;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddDbContext<PatientContext>(options => options
        .UseInMemoryDatabase("PatientSummaryDatabase")
    );

builder.Services.AddScoped<IPatientSummaryRepository, PatientSummaryRepository>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PatientContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}


// app.MapGet("/patientsummary", (IPatientSummaryRepository patientSummaryRepository) => patientSummaryRepository.GetPatientSummaries());
app.MapGet("/patientsummary/{id:int}", async (int id, IPatientSummaryRepository repo) =>
{
    var patientSummary = await repo.GetPatientSummaryById(id);
    return patientSummary is not null ? Results.Ok(patientSummary) : Results.NotFound();
});

app.Run();
