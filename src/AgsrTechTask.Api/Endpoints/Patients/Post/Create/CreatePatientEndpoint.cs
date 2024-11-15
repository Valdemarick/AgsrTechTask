using AgsrTechTask.Api.Dto.Requests;
using AgsrTechTask.Api.Dto.Responses;
using AgsrTechTask.Api.Features.Patients.Commands.Create;
using MediatR;

namespace AgsrTechTask.Api.Endpoints.Patients.Post.Create;

internal sealed class CreatePatientEndpoint : BaseEndpoint<CreatePatientRequest, PatientCreatedResponse>
{
    public CreatePatientEndpoint(ISender sender) : base(sender)
    {
    }

    public override void Configure()
    {
        Post("/");
        Group<PatientEndpointsGroup>();
        Summary(new CreatePatientEndpointSummary());
    }

    public override async Task HandleAsync(CreatePatientRequest req, CancellationToken ct)
    {
        var command = new CreatePatientCommand(req);
        var response = await Sender.Send(command, ct);

        await SendOkAsync(response, ct);
    }
}