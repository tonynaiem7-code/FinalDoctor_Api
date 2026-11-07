using FinalDoctor_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalDoctor_Api.Data.Configeration
{
    public class Conf_Patient : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
          builder.HasKey(x=>x.Id);

            builder.HasOne(c=>c.dvies).WithOne(p=>p.patient).HasForeignKey<Devies>(x=>x.PatientId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

