using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Repository.Entities;
namespace App.Repository.Configs
{
    public class FrequencyOfUseConfig : IEntityTypeConfiguration<Frequency_of_use>
    {
        public void Configure(EntityTypeBuilder<Frequency_of_use> builder)
        {
            builder.HasKey(f => f.Id);
            builder.HasIndex(f => f.Name).IsUnique();
                   

            // Buraya kullanım sıklıkları girilecek
            builder.HasData(
                new Frequency_of_use { Id = 1, Name = "Günde 1 kez" },
                new Frequency_of_use { Id = 2, Name = "Günde 2 kez" },
                new Frequency_of_use { Id = 3, Name = "Günde 3 kez" },
                new Frequency_of_use { Id = 4, Name = "Haftada 1 kez" },
                new Frequency_of_use { Id = 5, Name = "Haftada 2 kez" },
                new Frequency_of_use { Id = 6, Name = "Ayda 1 kez" },
                new Frequency_of_use { Id = 7, Name = "İhtiyaç halinde" }
            
            );
        }
    }
}
