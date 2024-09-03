using AgsrTechTask.Api.Abstractions.Messaging;

namespace AgsrTechTask.Api.Features.Patients.Commands.Delete;

internal sealed class DeletePatientCommandHandler : ICommandHandler<DeletePatientCommand>
{
    public Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
