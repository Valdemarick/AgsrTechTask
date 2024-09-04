using AgsrTechTask.Api.Dto.Requests;
using AgsrTechTask.Api.Dto.Responses;
using AgsrTechTask.Api.Features.Patients.Queries.GetList;
using MediatR;

namespace AgsrTechTask.Api.Endpoints.Patients.Get.GetList;

internal sealed class GetPatientListEndpoint : BaseEndpoint<GetPatientListRequest, PatientListResponse>
{
    public GetPatientListEndpoint(ISender sender) : base(sender)
    {
    }

    public override void Configure()
    {
        Get("/list");
        Group<PatientEndpointsGroup>();
        Summary(new GetPatientListEndpointSummary());
    }

    public override async Task HandleAsync(GetPatientListRequest req, CancellationToken ct)
    {
        var query = new GetListQuery(req);
        var response = await Sender.Send(query, ct);

        await SendOkAsync(response, ct);
    }
}