using AgsrTechTask.Api.Dto.Requests;
using AgsrTechTask.Api.Features.Patients.Commands.Delete;
using MediatR;

namespace AgsrTechTask.Api.Endpoints.Patients.Delete;

internal sealed class DeletePatientEndpoint : BaseEndpoint<DeletePatientRequest>
{
    public DeletePatientEndpoint(ISender sender) : base(sender)
    {
    }

    public override void Configure()
    {
        Delete($"/{{{nameof(DeletePatientRequest.Id)}}}");
        Group<PatientEndpointsGroup>();
    }

    public override async Task HandleAsync(DeletePatientRequest req, CancellationToken ct)
    {
        var command = new DeletePatientCommand(req.Id);
        await Sender.Send(command, ct);

        await SendNoContentAsync(ct);
    }
}