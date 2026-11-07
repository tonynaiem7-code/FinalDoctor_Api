using FinalDoctor_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalDoctor_Api.Data.Configeration
{
    public class Conf_Doctor : IEntityTypeConfiguration<Doctor>

    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.HasMany(c => c.patients).WithMany(d => d.doctors);
            builder.HasOne(v=>v.department).WithMany(z=>z.doctors).HasForeignKey(v=>v.DepartmentId).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
