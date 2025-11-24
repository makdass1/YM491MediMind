using App.Repository.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Configs
{
    public class AllergyConfig : IEntityTypeConfiguration<Allergy>
    {
        public void Configure(EntityTypeBuilder<Allergy> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
                


            //Buraya Alerjiler girilecek
            builder.HasData(
            new Allergy { Id = 1, Name = "Aspirin Alerjisi" },
            new Allergy { Id = 2, Name = "Çilek Alerjisi" },
            new Allergy { Id = 3, Name = "Fıstık Alerjisi" },
            new Allergy { Id = 4, Name = "Gluten Alerjisi" },
            new Allergy { Id = 5, Name = "İyot Alerjisi" },
            new Allergy { Id = 6, Name = "Kabuklu Deniz Ürünleri Alerjisi" },
            new Allergy { Id = 7, Name = "Kakao Alerjisi" },
            new Allergy { Id = 8, Name = "Küf Mantarı Alerjisi" },
            new Allergy { Id = 9, Name = "Lateks Alerjisi" },
            new Allergy { Id = 10, Name = "Mantar Alerjisi" },
            new Allergy { Id = 11, Name = "Morfin Alerjisi" },
            new Allergy { Id = 12, Name = "Nikel Alerjisi" },
            new Allergy { Id = 13, Name = "Penisilin Alerjisi" },
            new Allergy { Id = 14, Name = "Polen Alerjisi" },
            new Allergy { Id = 15, Name = "Süt Ürünleri Alerjisi" },
            new Allergy { Id = 16, Name = "Soya Alerjisi" },
            new Allergy { Id = 17, Name = "Şeftali Alerjisi" },
            new Allergy { Id = 18, Name = "Tuzlu Su Balıkları Alerjisi" },
            new Allergy { Id = 19, Name = "Vanilya Alerjisi" },
            new Allergy { Id = 20, Name = "Yumurta Alerjisi" },
            new Allergy { Id = 21, Name = "Yer Fıstığı Alerjisi" },
            new Allergy { Id = 22, Name = "Çam Pollen Alerjisi" },
            new Allergy { Id = 23, Name = "Fındık Alerjisi" },
            new Allergy { Id = 24, Name = "Kaju Alerjisi" },
            new Allergy { Id = 25, Name = "Keten Tohumu Alerjisi" },
            new Allergy { Id = 26, Name = "Kuruyemiş Karışımı Alerjisi" },
            new Allergy { Id = 27, Name = "Lavanta Alerjisi" },
            new Allergy { Id = 28, Name = "Mercimek Alerjisi" },
            new Allergy { Id = 29, Name = "Mısır Alerjisi" },
            new Allergy { Id = 30, Name = "Okyanus Balıkları Alerjisi" },
            new Allergy { Id = 31, Name = "Pirinç Alerjisi" },
            new Allergy { Id = 32, Name = "Sarımsak Alerjisi" },
            new Allergy { Id = 33, Name = "Sedef Hastalığına Bağlı Alerji" },
            new Allergy { Id = 34, Name = "Somon Balığı Alerjisi" },
            new Allergy { Id = 35, Name = "Susam Alerjisi" },
            new Allergy { Id = 36, Name = "Tuzlu Su Karidesi Alerjisi" },
            new Allergy { Id = 37, Name = "Un Alerjisi" },
            new Allergy { Id = 38, Name = "Vanilya Fasulyesi Alerjisi" },
            new Allergy { Id = 39, Name = "Vişne Alerjisi" },
            new Allergy { Id = 40, Name = "Yaban Mersini Alerjisi" },
            new Allergy { Id = 41, Name = "Yeşil Mercimek Alerjisi" },
            new Allergy { Id = 42, Name = "Yosun Alerjisi" },
            new Allergy { Id = 43, Name = "Zencefil Alerjisi" },
            new Allergy { Id = 44, Name = "Zeytin Alerjisi" },
            new Allergy { Id = 45, Name = "Ev Tozu Akarı Alerjisi" },
            new Allergy { Id = 46, Name = "Kedi Tüyü Alerjisi" },
            new Allergy { Id = 47, Name = "Köpek Tüyü Alerjisi" },
            new Allergy { Id = 48, Name = "Saman Alerjisi" },
            new Allergy { Id = 49, Name = "Meyve Karışımı Alerjisi" },
            new Allergy { Id = 50, Name = "Sebze Karışımı Alerjisi" }

        );
        }
    }
}
