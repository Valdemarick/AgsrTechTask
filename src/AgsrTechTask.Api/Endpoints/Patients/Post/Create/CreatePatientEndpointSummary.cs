using AgsrTechTask.Api.Dto.Requests;
using FastEndpoints;

namespace AgsrTechTask.Api.Endpoints.Patients.Post.Create;

internal sealed class CreatePatientEndpointSummary : Summary<CreatePatientEndpoint>
{
    public CreatePatientEndpointSummary()
    {
        Summary = "Creates a new patient";
        Description = "Creates a new patient";
        ExampleRequest = new CreatePatientRequest
        {
            Name = "John Wick",
        };
        Responses[StatusCodes.Status201Created] = "A new patient was created";
        Responses[StatusCodes.Status400BadRequest] = "Validation errors occured";
        Responses[StatusCodes.Status500InternalServerError] = "Internal server error";
    }
}