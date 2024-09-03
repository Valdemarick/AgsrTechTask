using AgsrTechTask.Api.Dto.Requests;
using AgsrTechTask.Api.Features.Patients.Commands.Update;
using MediatR;

namespace AgsrTechTask.Api.Endpoints.Patients.Put;

internal sealed class UpdatePatientEndpoint : BaseEndpoint<UpdatePatientRequest>
{
    public UpdatePatientEndpoint(ISender sender) : base(sender)
    {
    }

    public override void Configure()
    {
        Put("/");
        Group<PatientEndpointsGroup>();
    }

    public override async Task HandleAsync(UpdatePatientRequest req, CancellationToken ct)
    {
        var command = new UpdatePatientCommand();
        await Sender.Send(command, ct);

        await SendNoContentAsync(ct);
    }
}