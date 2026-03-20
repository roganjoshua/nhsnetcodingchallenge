using PatientSummaryApi.Infrastructure.Data;

public interface IPatientSummaryRepository
{
    Task<PatientSummaryDto?> GetPatientSummaryById(int id);

    IAsyncEnumerable<PatientSummaryDto> GetPatientSummaries();

    void AddPatientSummary(PatientSummaryDto patientSummary);

}