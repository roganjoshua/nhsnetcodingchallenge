namespace PatientSummaryApi.Domain.PatientSummary;

public interface IPatientSummaryService
{
    Task<PatientSummary> GetPatientSummaryById(int id); 
}