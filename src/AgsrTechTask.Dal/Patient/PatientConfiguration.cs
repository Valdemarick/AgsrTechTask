using AgsrTechTask.Domain.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgsrTechTask.Dal.Patient;

internal sealed class PatientConfiguration : IEntityTypeConfiguration<Domain.Patients.Patient>
{
    public void Configure(EntityTypeBuilder<Domain.Patients.Patient> builder)
    {
        builder.ToTable("patients");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.Property(x => x.BirthDate)
            .IsRequired()
            .HasColumnName("birth_date");

        builder.Property(x => x.Gender)
            .IsRequired()
            .HasDefaultValue(Gender.Unknown)
            .HasColumnName("gender");

        builder.OwnsOne(x => x.Name,
            patientNameBuilder =>
            {
                patientNameBuilder.Property(x => x.LastName)
                    .IsRequired()
                    .HasColumnName("last_name");

                patientNameBuilder.Property(x => x.FirstName)
                    .HasColumnName("first_name");
                
                patientNameBuilder.Property(x => x.PatronymicName)
                    .HasColumnName("patronymic_name");

                patientNameBuilder.Property(x => x.Formality)
                    .HasColumnName("formality");
            });

        builder.Property(x => x.IsActive)
            .HasColumnName("is_active");
    }
}