using App.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repository.Configs
{
    
    public class ReminderConfig : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
          
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Dosage).IsRequired().HasMaxLength(100);
            builder.Property(r => r.Start_date).IsRequired();
            builder.Property(r => r.Finish_date).IsRequired();
            builder.Property(r => r.IsTaked).IsRequired().HasDefaultValue(false);
            builder.Property(r => r.Note).HasMaxLength(1000);


           

            // --- User ile İlişki (Bire-Çok) ---
            // Bu, UserConfiguration'da başlattığımız ilişkinin diğer yarısıdır.
            builder.HasOne(reminder => reminder.User) // Reminder'ın BİR User'ı vardır
                   .WithMany(user => user.reminders) // User'ın ÇOK Reminder'ı vardır
                   .HasForeignKey(reminder => reminder.UserId); // Yabancı Anahtar: UserId


            // --- Medicine ile İlişki (Bire-Çok) ---
            // Bu ilişkiyi TEK YÖNLÜ olarak kuruyoruz.
            // (Medicine sınıfının içinde ICollection<Reminder> listesi olmasına GEREK YOK)
            builder.HasOne(reminder => reminder.Medicine) // Reminder'ın BİR Medicine'i vardır
                   .WithMany() // Medicine'in ÇOK Reminder'ı olabilir (ama listeyi tanımlamadık)
                   .HasForeignKey(reminder => reminder.MedicineId); // Yabancı Anahtar: MedicineId


            // --- Frequency_of_use ile İlişki (Bire-Çok) ---
            // Bu da aynı şekilde TEK YÖNLÜ bir ilişki.
            builder.HasOne(reminder => reminder.Frequency_of_use) // Reminder'ın BİR Frekansı vardır
                   .WithMany() // Frekansın ÇOK Reminder'ı olabilir
                   .HasForeignKey(reminder => reminder.Frequency_of_useId); // Yabancı Anahtar: FrequencyOfUseId
        }
    }
}
