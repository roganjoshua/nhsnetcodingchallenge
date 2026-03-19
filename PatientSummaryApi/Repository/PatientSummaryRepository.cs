using Microsoft.EntityFrameworkCore;
using PatientSummaryApi.Models;
using PatientSummaryApi.Persistence;

namespace PatientSummaryApi.Repository;

public class PatientSummaryRepository : IPatientSummaryRepository
{
    private readonly PatientContext _context;

    public PatientSummaryRepository(PatientContext context)
        => _context = context;

    public async Task<PatientSummary?> GetPatientSummaryById(int id)
        => await _context.PatientSummaries.FirstOrDefaultAsync(b => b.Id == id);

    public IAsyncEnumerable<PatientSummary> GetPatientSummaries()
        => _context.PatientSummaries.AsAsyncEnumerable();

    public void AddPatientSummary(PatientSummary patientSummary)
    {
        _context.PatientSummaries.Add(patientSummary);
        _context.SaveChanges();
    }
}