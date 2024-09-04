namespace AgsrTechTask.Api.Dto.Requests;

/// <summary>
/// Request to delete a patient by an identifier
/// </summary>
internal sealed record DeletePatientRequest
{
    /// <summary>
    /// Patient's identifier
    /// </summary>
    public Guid Id { get; init; }
}
