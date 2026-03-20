using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using PatientSummaryApi.Api;
using Refit;

namespace PatientSummaryApi.Tests;

public interface IPatientSummaryApi
{
    [Get("/patientsummary/{id}")]
    Task<PatientSummaryResponse> GetPatientSummaryById(int id);
}

public class IntegrationTestPatientSummary : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly IPatientSummaryApi _api;

    public IntegrationTestPatientSummary(WebApplicationFactory<Program> factory)
    {
        var httpClient = factory.CreateClient();
        _api = RestService.For<IPatientSummaryApi>(httpClient);
    }

    [Fact]
    public async Task GetPatientSummaryById_ReturnsPatient_WhenIdExists()
    {
        var result = await _api.GetPatientSummaryById(1);

        result.Id.Should().Be(1);
        result.Name.Should().Be("Martin Sarosi");
        result.NhsNumber.Should().Be("625 007 2349");
    }

    [Fact]
    public async Task GetPatientSummaryById_ThrowsApiException_WhenIdDoesNotExist()
    {
        var act = () => _api.GetPatientSummaryById(999);

        await act.Should().ThrowAsync<ApiException>()
            .Where(e => e.StatusCode == HttpStatusCode.NotFound);
    }
}
