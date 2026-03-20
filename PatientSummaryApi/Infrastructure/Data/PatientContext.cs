namespace PatientSummaryApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class PatientContext(DbContextOptions<PatientContext> options) : DbContext(options)
{
    public DbSet<PatientSummaryDto> PatientSummaries { get; set; }
}