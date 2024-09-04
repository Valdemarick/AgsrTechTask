using AgsrTechTask.Api.Dto.Requests;
using AgsrTechTask.Api.Features.Patients.Commands.Delete;
using FastEndpoints;
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
        Summary(new DeletePatientEndpointSummary());
        Description(b => b.ClearDefaultProduces(StatusCodes.Status200OK));
        Description(b => b.Produces(StatusCodes.Status204NoContent));
        Description(b => b.Produces(StatusCodes.Status400BadRequest));
        Description(b => b.Produces(StatusCodes.Status404NotFound));
        Description(b => b.Produces(StatusCodes.Status500InternalServerError));
    }

    public override async Task HandleAsync(DeletePatientRequest req, CancellationToken ct)
    {
        var command = new DeletePatientCommand(req.Id);
        await Sender.Send(command, ct);

        await SendNoContentAsync(ct);
    }
}