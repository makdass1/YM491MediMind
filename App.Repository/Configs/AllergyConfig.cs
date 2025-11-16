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
    public class AllergyCongi : IEntityTypeConfiguration<Allergy>
    {
        public void Configure(EntityTypeBuilder<Allergy> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
                


            //Buraya Alerjiler girilecek
            builder.HasData(
            new Allergy { Id = 1, Name = "Fıstık Alerjisi" },
            new Allergy { Id = 2, Name = "Gluten Alerjisi" },
            new Allergy { Id = 3, Name = "Süt Ürünleri Alerjisi" },
            new Allergy { Id = 4, Name = "Çilek Alerjisi" },
            new Allergy { Id = 5, Name = "Yumurta Alerjisi" },
            new Allergy { Id = 6, Name = "Polen Alerjisi" },
            new Allergy {Id=7, Name = "Kakao" }

        );
        }
    }
}
