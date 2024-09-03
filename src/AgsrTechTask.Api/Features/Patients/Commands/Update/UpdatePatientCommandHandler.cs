using AgsrTechTask.Api.Abstractions.Messaging;

namespace AgsrTechTask.Api.Features.Patients.Commands.Update;

internal sealed class UpdatePatientCommandHandler : ICommandHandler<UpdatePatientCommand>
{
    public Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}