namespace PatientSummaryApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Models;

public class PatientContext(DbContextOptions<PatientContext> options) : DbContext(options)
{
    public DbSet<PatientSummary> PatientSummaries { get; set; }
}