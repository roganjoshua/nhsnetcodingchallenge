using PatientSummaryApi.Api;
using PatientSummaryApi.Domain.PatientSummary;
using PatientSummaryApi.Infrastructure.Data;

namespace PatientSummaryApi;

public static class Mappings
{
    public static PatientSummaryResponse ToResponse(this PatientSummary patientSummary)
    {
        if  (patientSummary == null) return null;
        return new PatientSummaryResponse()
        {
            Id = patientSummary.Id,
            Name = patientSummary.Name,
            DateOfBirth = patientSummary.DateOfBirth,
            NhsNumber = patientSummary.NhsNumber,
            GpPractice = patientSummary.GpPractice,
        };
    }
    public static PatientSummary ToModel(this PatientSummaryDto patientSummary)
    {
        if  (patientSummary == null) return null;
        return new PatientSummary()
        {
            Id = patientSummary.Id,
            Name = patientSummary.Name,
            DateOfBirth = patientSummary.DateOfBirth,
            NhsNumber = patientSummary.NhsNumber,
            GpPractice = patientSummary.GpPractice,
        };
    }
}