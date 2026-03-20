using PatientSummaryApi.Domain.PatientSummary;
using PatientSummaryApi.Infrastructure.Repository;

namespace PatientSummaryApi.Domain.PatientSummary;


public class PatientSummaryService(IPatientSummaryRepository patientSummaryRepository) : IPatientSummaryService
{
    public async Task<PatientSummary> GetPatientSummaryById(int id)
    {
       var patientSummaryDto =  await patientSummaryRepository.GetPatientSummaryById(id);
       return patientSummaryDto.ToModel();

    }
}