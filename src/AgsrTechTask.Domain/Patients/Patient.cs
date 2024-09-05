namespace AgsrTechTask.Domain.Patients;

public sealed class Patient
{
    public Patient(
        string lastName,
        DateTimeOffset birthDate,
        string? firstName,
        string? patronymicName,
        PatientNameFormality? patientNameFormality,
        Gender? gender,
        bool? active)
    {
        Id = Guid.NewGuid();
        Name = new PatientName(lastName, firstName, patronymicName, patientNameFormality);
        Gender = gender ?? Gender.Unknown;
        BirthDate = birthDate;
        IsActive = active ?? true;
    }

    private Patient()
    {
    }
    
    public Guid Id { get; private set; }

    public PatientName Name { get; private set; }
    
    public Gender Gender { get; private set; }

    public DateTimeOffset BirthDate { get; private set; }

    public bool IsActive { get; private set; }
}