using AgsrTechTask.Api.Abstractions.Messaging;
using AgsrTechTask.Api.Exceptions;
using AgsrTechTask.Api.Extensions.Patients;
using AgsrTechTask.Domain.Patients;
using MediatR;

namespace AgsrTechTask.Api.Features.Patients.Commands.Delete;

internal sealed class DeletePatientCommandHandler : ICommandHandler<DeletePatientCommand>
{
    private readonly IPatientRepository _patientRepository;

    public DeletePatientCommandHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdOrThrowAsync(request.Id);
        
        _patientRepository.Delete(patient!);
        await _patientRepository.SaveChangesAsync(cancellationToken);
    }
}
