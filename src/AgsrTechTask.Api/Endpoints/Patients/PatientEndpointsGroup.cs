using FastEndpoints;

namespace AgsrTechTask.Api.Endpoints.Patients;

internal sealed class PatientEndpointsGroup : Group
{
    public PatientEndpointsGroup()
    {
        Configure("patients", config => config.AllowAnonymous());
    }
}