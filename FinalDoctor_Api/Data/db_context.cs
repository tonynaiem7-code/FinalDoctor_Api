using FinalDoctor_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FinalDoctor_Api.Data
{
    public class db_context:DbContext

    {
        public db_context(DbContextOptions<db_context> options) : base(options) { }

        public DbSet<Doctor> doctor { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<Patient> patient { get; set; }
        public DbSet<Devies> Devies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(db_context).Assembly);
        }
    }
}
