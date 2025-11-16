using Microsoft.EntityFrameworkCore;
using App.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repository.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.Mail).IsUnique();       //Her mail benzersiz olmalı
            builder.Property(x => x.Password).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Gender).IsRequired();

          

            // User (Bir) -> Reminder (Çok)
            builder.HasMany(user => user.reminders) // Bir User'ın ÇOK Reminder'ı vardır
                   .WithOne(reminder => reminder.User) // Her Reminder'ın BİR User'ı vardır
                   .HasForeignKey(reminder => reminder.UserId); 


            // ----- 3. Çoka-Çok (Many-to-Many) İlişkileri -----

            // User (Çok) -> Allergy (Çok)
            builder.HasMany(user => user.allergies)
                   .WithMany(allergy => allergy.Users)
                   .UsingEntity(j => j.ToTable("UserAllergies")); // Bağlantı tablosunun adı

            // User (Çok) -> Medicine (Çok)
            builder.HasMany(user => user.medicines)
                   .WithMany(medicine => medicine.Users)
                   .UsingEntity(j => j.ToTable("UserMedicines"));

            // User (Çok) -> ChronicDisease (Çok)
            builder.HasMany(user => user.chronicDiseasesses)
                   .WithMany(disease => disease.Users)
                   .UsingEntity(j => j.ToTable("UserChronicDiseases"));
        }
    }
}
