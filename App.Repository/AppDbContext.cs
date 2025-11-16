using App.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext>options) : DbContext(options)

    {
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }  
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Frequency_of_use> Frequency_of_uses { get; set; }
        public DbSet<ChronicDiseasess> ChronicDiseasesses { get; set; }
        public DbSet<Allergy> Allergies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
