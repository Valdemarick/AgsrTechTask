using AgsrTechTask.Api.Abstractions.Messaging;
using AgsrTechTask.Api.Dto.Responses;

namespace AgsrTechTask.Api.Features.Patients.Commands.Create;

internal sealed record CreatePatientCommand() : ICommand<PatientCreatedResponse>;