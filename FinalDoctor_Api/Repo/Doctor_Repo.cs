using FinalDoctor_Api.Data;
using FinalDoctor_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalDoctor_Api.Repo
{
    public class Doctor_Repo : Generic<Doctor>
    {
        public Doctor_Repo(db_context db) : base(db)
        {
        }


        public override async Task<IEnumerable<Doctor>> Getall()
        {
            return await _db.doctor.Include(x=>x.patients).Include(c=>c.department).ToListAsync();


        }

        public override async Task<Doctor?> GetById(int id)
        {
            return await _db.doctor.Include(x => x.patients).Include(c => c.department).FirstOrDefaultAsync(x => x.Id==id);


        }
        public override async Task Add(Doctor entity)
        {
            if (entity.department != null)
            {
                await _db.department.AddAsync(entity.department);

              await  _db.doctor.AddAsync(entity);
                await _db.SaveChangesAsync();

            }
        }
    }
}
