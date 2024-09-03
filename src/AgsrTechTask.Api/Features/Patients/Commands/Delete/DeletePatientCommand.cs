using AgsrTechTask.Api.Abstractions.Messaging;

namespace AgsrTechTask.Api.Features.Patients.Commands.Delete;

internal sealed record DeletePatientCommand(Guid Id) : ICommand;
