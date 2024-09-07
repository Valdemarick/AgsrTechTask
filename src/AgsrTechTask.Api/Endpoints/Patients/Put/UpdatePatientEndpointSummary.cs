using AgsrTechTask.Api.Dto.Requests;
using FastEndpoints;

namespace AgsrTechTask.Api.Endpoints.Patients.Put;

internal sealed class UpdatePatientEndpointSummary : Summary<UpdatePatientEndpoint>
{
    public UpdatePatientEndpointSummary()
    {
        Summary = "Updates an existing patient";
        Description = "Updates a patient if he exists, otherwise 404 will be occured";
        ExampleRequest = new UpdatePatientRequest
        {
            // Name = "John Wick 2",
        };
        Responses[StatusCodes.Status200OK] = "The patient has been updated";
        Responses[StatusCodes.Status400BadRequest] = "Validation errors have been occured";
        Responses[StatusCodes.Status404NotFound] = "The patient hasn't been found";
        Responses[StatusCodes.Status500InternalServerError] = "Internal server error";
    }
}