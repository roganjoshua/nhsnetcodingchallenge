namespace PatientSummaryApi.Infrastructure.Data;

public class PatientSummaryDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string NhsNumber { get; init; }
    public required string GpPractice { get; init; }
    public DateOnly DateOfBirth { get; init; }
}