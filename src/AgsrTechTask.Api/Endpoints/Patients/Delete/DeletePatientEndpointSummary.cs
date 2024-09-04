using AgsrTechTask.Api.Dto.Requests;
using FastEndpoints;

namespace AgsrTechTask.Api.Endpoints.Patients.Delete;

internal sealed class DeletePatientEndpointSummary : Summary<DeletePatientEndpoint>
{
    public DeletePatientEndpointSummary()
    {
        Summary = "Deletes a patient by his identifier";
        Description =
            "Deletes a patient by his identifier. If the patient with such identifier exists, he will be removed, otherwise 404 will occur";
        ExampleRequest = new DeletePatientRequest
        {
            Id = Guid.NewGuid(),
        };
        Responses[StatusCodes.Status204NoContent] = "The patient was removed";
        Responses[StatusCodes.Status400BadRequest] = "Some validation errors occured";
        Responses[StatusCodes.Status404NotFound] = "The patient with such id does not exist";
        Responses[StatusCodes.Status500InternalServerError] = "Internal server error";
    }
}