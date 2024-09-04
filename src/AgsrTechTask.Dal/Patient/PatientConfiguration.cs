using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgsrTechTask.Dal.Patient;

internal sealed class PatientConfiguration : IEntityTypeConfiguration<Domain.Patients.Patient>
{
    public void Configure(EntityTypeBuilder<Domain.Patients.Patient> builder)
    {
        throw new NotImplementedException();
    }
}