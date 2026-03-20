using Microsoft.EntityFrameworkCore;
using PatientSummaryApi.Infrastructure.Data;
namespace PatientSummaryApi.Infrastructure.Repository;

public class PatientSummaryRepository : IPatientSummaryRepository
{
    private readonly PatientContext _context;

    public PatientSummaryRepository(PatientContext context)
        => _context = context;

    public async Task<PatientSummaryDto?> GetPatientSummaryById(int id)
        => await _context.PatientSummaries.FirstOrDefaultAsync(b => b.Id == id);

    public IAsyncEnumerable<PatientSummaryDto> GetPatientSummaries()
        => _context.PatientSummaries.AsAsyncEnumerable();

    public void AddPatientSummary(PatientSummaryDto patientSummary)
    {
        _context.PatientSummaries.Add(patientSummary);
        _context.SaveChanges();
    }
}