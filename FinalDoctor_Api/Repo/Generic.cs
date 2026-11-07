
using FinalDoctor_Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace FinalDoctor_Api.Repo
{
    public class Generic<t> : IGeneric<t> where t : class

    {

        protected db_context _db;

        public Generic(db_context db)
        {
            _db = db;
        }

        public virtual async Task<IEnumerable<t>> Getall()
        {
            return await _db.Set<t>().ToListAsync();


        }

        public virtual async Task<t?> GetById(int id)
        {
            return await _db.Set<t>().FindAsync(id);


        }



        public async Task<bool> Delete(int id)
        {
            var result = await _db.Set<t>().FindAsync(id);

            if (result == null)

                return false;

            _db.Set<t>().Remove(result);
            await _db.SaveChangesAsync();
            return true;
        }

        public virtual async Task Add(t entity)
        {
             _db.Set<t>().Add(entity);
           await _db.SaveChangesAsync();
        }

        public async Task Update(t entity)
        {
            _db.Set<t>().Update(entity);
           await _db.SaveChangesAsync();

        }
    }
}
