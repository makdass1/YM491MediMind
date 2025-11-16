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
        }
    }
}
