namespace PatientSummaryApi.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(PatientContext context)
    {
        // Look for any students.
        if (context.PatientSummaries.Any())
        {
            return; // DB has been seeded
        }

        var patientSummaries = new[]
        {
            new PatientSummaryDto
            {
                Name = "Martin Sarosi", 
                NhsNumber = "625 007 2349", 
                DateOfBirth = DateOnly.Parse("1967-11-14"),
                GpPractice = "Spring Terrace Health Centre"
            },
            new PatientSummaryDto
            {
                Name = "Jonathan Pickering", 
                NhsNumber = "123 456 7890", 
                DateOfBirth = DateOnly.Parse("1974-09-22"),
                GpPractice = "Acme Health Centre"
            },
            new PatientSummaryDto
            {
                Name = "Martin Fowler", 
                NhsNumber = "987 654 3210",
                DateOfBirth = DateOnly.Parse("1964-08-02"),
                GpPractice = "Another Health Centre"
            }
        };

        context.PatientSummaries.AddRange(patientSummaries);
        context.SaveChanges();
    }
}