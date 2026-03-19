using PatientSummaryApi.Models;

namespace PatientSummaryApi.Repository;
public interface IPatientSummaryRepository
{
    Task<PatientSummary?> GetPatientSummaryById(int id);

    IAsyncEnumerable<PatientSummary> GetPatientSummaries();

    void AddPatientSummary(PatientSummary patientSummary);

}