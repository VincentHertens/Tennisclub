using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Configurations
{
    class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> l)
        {
            l.HasKey(c => c.Id);
            l.Property(c => c.Id).ValueGeneratedOnAdd(); //Voorlopige oplossing
            l.Property(c => c.Name).HasColumnType("varchar(20)").IsRequired();
            l.HasIndex(c => c.Name).IsUnique();

            l.HasData(
                 new League { Id = 1, Name = "Competitie" },
                 new League { Id = 2, Name = "Recreatief" },
                 new League { Id = 3, Name = "Toptennis" }
                );
        }
    }
}
