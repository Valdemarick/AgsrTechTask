namespace AgsrTechTask.Domain.Patients;

public record PatientName
{
    public PatientName(
        string lastName,
        string? firstName,
        string? patronymicName,
        PatientNameFormality? patientNameFormality)
    {
        LastName = lastName;
        FirstName = firstName;
        PatronymicName = patronymicName;
        Formality = patientNameFormality;
    }

    private PatientName()
    {
    }

    public string LastName { get; private set; } = string.Empty;

    public string? FirstName { get; private set; }

    public string? PatronymicName { get; private set; }

    public PatientNameFormality? Formality { get; private set; }
}