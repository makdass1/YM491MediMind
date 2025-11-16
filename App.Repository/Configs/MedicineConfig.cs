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
    public class MedicineConfig : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x=>x.Name).IsUnique();

            builder.HasData(
            new Medicine { Id = 1, Name = "Parol" },
            new Medicine { Id = 2, Name = "Aspirin" },
            new Medicine { Id = 3, Name = "İbuprofen" },
            new Medicine { Id = 4, Name = "Nurofen" },
            new Medicine { Id = 5, Name = "Amoksisilin" }
            );
        }
    }
}
