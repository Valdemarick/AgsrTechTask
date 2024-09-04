using AgsrTechTask.Api.Dto.Requests;
using FastEndpoints;

namespace AgsrTechTask.Api.Endpoints.Patients.Get.GetById;

internal sealed class GetPatientByIdEndpointSummary : Summary<GetPatientByIdEndpoint>
{
    public GetPatientByIdEndpointSummary()
    {
        Summary = "Gets a patient by his identifier";
        Description = "Gets a patient if he exists, otherwise 404 will be occured";
        ExampleRequest = new GetPatientByIdRequest
        {
            Id = Guid.NewGuid(),
        };
        Responses[StatusCodes.Status200OK] = "The patient found";
        Responses[StatusCodes.Status400BadRequest] = "Validation errors occured";
        Responses[StatusCodes.Status404NotFound] = "The patient with such id not found";
        Responses[StatusCodes.Status500InternalServerError] = "Internal server error";
    }
}