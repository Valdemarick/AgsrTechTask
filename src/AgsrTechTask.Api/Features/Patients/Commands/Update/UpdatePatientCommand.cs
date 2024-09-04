using AgsrTechTask.Api.Abstractions.Messaging;
using AgsrTechTask.Api.Dto.Requests;

namespace AgsrTechTask.Api.Features.Patients.Commands.Update;

internal sealed record UpdatePatientCommand(UpdatePatientRequest Request) : ICommand;