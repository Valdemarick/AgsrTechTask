using AgsrTechTask.Api.Abstractions.Messaging;
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
        // TODO: поиск по Id
        var patient = await _patientRepository.GetByIdAsync(default, withTracking: true, cancellationToken);
        if (patient is null)
        {
            // TODO: throw an exception
        }
        
        _patientRepository.Update(request.Request.FromDto());
        await _patientRepository.SaveChangesAsync(cancellationToken);
    }
}