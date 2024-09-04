namespace AgsrTechTask.Domain.Patients;

public sealed class Patient
{
    public Patient(
        string lastName,
        DateTime birthDate,
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
        Active = active ?? true;
    }
    
    public Guid Id { get; private set; }

    public PatientName Name { get; private set; }
    
    public Gender Gender { get; private set; }

    public DateTime BirthDate { get; private set; }

    public bool Active { get; private set; }
}