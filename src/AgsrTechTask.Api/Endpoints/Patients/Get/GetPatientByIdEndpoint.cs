using AgsrTechTask.Api.Dto.Requests;
using AgsrTechTask.Api.Dto.Responses;
using AgsrTechTask.Api.Features.Patients.Queries.GetById;
using MediatR;

namespace AgsrTechTask.Api.Endpoints.Patients.Get;

internal sealed class GetPatientByIdEndpoint : BaseEndpoint<GetPatientByIdRequest, PatientResponse>
{
    public GetPatientByIdEndpoint(ISender sender) : base(sender)
    {
    }

    public override void Configure()
    {
        Get($"/{{{nameof(GetPatientByIdRequest.Id)}}}");
        Group<PatientEndpointsGroup>();
    }

    public override async Task HandleAsync(GetPatientByIdRequest req, CancellationToken ct)
    {
        var query = new GetByIdQuery(req.Id);
        var response = await Sender.Send(query, ct);

        await SendOkAsync(response, ct);
    }
}