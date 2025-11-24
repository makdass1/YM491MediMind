using App.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Configs
{
    public class ChronicDiseasessConfig : IEntityTypeConfiguration<ChronicDiseasess>
    {
        public void Configure(EntityTypeBuilder<ChronicDiseasess> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(name => name.Id).IsUnique();

            builder.HasData(
            new ChronicDiseasess { Id = 1, Name = "Alzheimer" },
            new ChronicDiseasess { Id = 2, Name = "Akciğer Kanseri" },
            new ChronicDiseasess { Id = 3, Name = "Anemi (Kronik)" },
            new ChronicDiseasess { Id = 4, Name = "Astım" },
            new ChronicDiseasess { Id = 5, Name = "Böbrek Yetmezliği" },
            new ChronicDiseasess { Id = 6, Name = "Crohn Hastalığı" },
            new ChronicDiseasess { Id = 7, Name = "Diyabet" },
            new ChronicDiseasess { Id = 8, Name = "Epilepsi" },
            new ChronicDiseasess { Id = 9, Name = "Fibromiyalji" },
            new ChronicDiseasess { Id = 10, Name = "Hiperkolesterolemi" },
            new ChronicDiseasess { Id = 11, Name = "Hipertansiyon" },
            new ChronicDiseasess { Id = 12, Name = "Hipotiroidi" },
            new ChronicDiseasess { Id = 13, Name = "Hipertiroidi" },
            new ChronicDiseasess { Id = 14, Name = "Kalp Yetmezliği" },
            new ChronicDiseasess { Id = 15, Name = "Kanser" },
            new ChronicDiseasess { Id = 16, Name = "Kolorektal Kanser" },
            new ChronicDiseasess { Id = 17, Name = "KOAH" },
            new ChronicDiseasess { Id = 18, Name = "Koroner Arter Hastalığı" },
            new ChronicDiseasess { Id = 19, Name = "Kronik Akciğer Hastalığı" },
            new ChronicDiseasess { Id = 20, Name = "Kronik Böbrek Hastalığı" },
            new ChronicDiseasess { Id = 21, Name = "Kronik Depresyon" },
            new ChronicDiseasess { Id = 22, Name = "Kronik Enfeksiyonlar (HIV, Hepatit B/C)" },
            new ChronicDiseasess { Id = 23, Name = "Kronik Göz Hastalıkları (Glokom, Katarakt)" },
            new ChronicDiseasess { Id = 24, Name = "Kronik Karaciğer Hastalığı" },
            new ChronicDiseasess { Id = 25, Name = "Kronik Migren" },
            new ChronicDiseasess { Id = 26, Name = "Kronik Pancreatit" },
            new ChronicDiseasess { Id = 27, Name = "Kronik Sinüzit" },
            new ChronicDiseasess { Id = 28, Name = "Kronik Yorgunluk Sendromu" },
            new ChronicDiseasess { Id = 29, Name = "Kronik Dermatolojik Hastalıklar" },
            new ChronicDiseasess { Id = 30, Name = "Lupus" },
            new ChronicDiseasess { Id = 31, Name = "Meme Kanseri" },
            new ChronicDiseasess { Id = 32, Name = "Migren" },
            new ChronicDiseasess { Id = 33, Name = "Multipl Skleroz (MS)" },
            new ChronicDiseasess { Id = 34, Name = "Multiple Myeloma" },
            new ChronicDiseasess { Id = 35, Name = "Obezite" },
            new ChronicDiseasess { Id = 36, Name = "Osteoartrit" },
            new ChronicDiseasess { Id = 37, Name = "Parkinson" },
            new ChronicDiseasess { Id = 38, Name = "Prostat Kanseri" },
            new ChronicDiseasess { Id = 39, Name = "Psoriatik Artrit" },
            new ChronicDiseasess { Id = 40, Name = "Romatoid Artrit" },
            new ChronicDiseasess { Id = 41, Name = "Siroz" },
            new ChronicDiseasess { Id = 42, Name = "Uyku Apnesi" },
            new ChronicDiseasess { Id = 43, Name = "Pulmoner Fibroz" },
            new ChronicDiseasess { Id = 44, Name = "Kronik Anksiyete" },
            new ChronicDiseasess { Id = 45, Name = "Kronik Böbrek Yetmezliği" },
            new ChronicDiseasess { Id = 46, Name = "Kronik Karaciğer Yetmezliği" },
            new ChronicDiseasess { Id = 47, Name = "Kronik Panik Bozukluğu" },
            new ChronicDiseasess { Id = 48, Name = "Kronik Romatizmal Hastalıklar" }

        );
        }
    }
}
