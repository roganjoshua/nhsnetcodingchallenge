namespace PatientSummaryApi.Api;

public class PatientSummaryResponse
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string NhsNumber { get; init; }
    public required string GpPractice { get; init; }
    public DateOnly DateOfBirth { get; init; }
}