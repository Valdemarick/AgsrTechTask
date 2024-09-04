using AgsrTechTask.Api.Dto.Requests;
using FastEndpoints;

namespace AgsrTechTask.Api.Endpoints.Patients.Get.GetList;

internal sealed class GetPatientListEndpointSummary : Summary<GetPatientListEndpoint>
{
    public GetPatientListEndpointSummary()
    {
        Summary = "Gets a patient list";
        Description = "Gets a patient list";
        ExampleRequest = new GetPatientListRequest
        {
            DateFilter = "filter",
        };
        Responses[StatusCodes.Status200OK] = "Success";
        Responses[StatusCodes.Status400BadRequest] = "Validation errors occured";
        Responses[StatusCodes.Status500InternalServerError] = "Internal server error";
    }
}