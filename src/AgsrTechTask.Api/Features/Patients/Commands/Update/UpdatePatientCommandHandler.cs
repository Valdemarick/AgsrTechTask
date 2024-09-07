using AgsrTechTask.Api.Abstractions.Messaging;
using AgsrTechTask.Api.Exceptions;
using AgsrTechTask.Api.Extensions.Patients;
using AgsrTechTask.Domain.Patients;

namespace AgsrTechTask.Api.Features.Patients.Commands.Update;

internal sealed class UpdatePatientCommandHandler : ICommandHandler<UpdatePatientCommand>
{
    private readonly IPatientRepository _patientRepository;

    public UpdatePatientCommandHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        _ = await _patientRepository.GetByIdOrThrowAsync(request.Request.Name.Id, withTracking: true);
        
        _patientRepository.Update(request.Request.FromDto());
        await _patientRepository.SaveChangesAsync(cancellationToken);
    }
}