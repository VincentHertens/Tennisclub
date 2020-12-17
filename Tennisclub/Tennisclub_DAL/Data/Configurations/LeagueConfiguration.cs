using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennisclub_Common.LeagueDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Configurations
{
    public class LeagueConfiguration : Profile, IEntityTypeConfiguration<League>
    {

        public LeagueConfiguration()
        {
            CreateMap<League, LeagueReadDto>();
        }

        public void Configure(EntityTypeBuilder<League> l)
        {
            l.Property(c => c.Id).ValueGeneratedOnAdd();
            l.Property(c => c.Name).HasColumnType("varchar(20)").IsRequired();

            l.HasKey(c => c.Id);
            l.HasIndex(c => c.Name).IsUnique();

            l.HasData(
                 new League { Id = 1, Name = "Competitie" },
                 new League { Id = 2, Name = "Recreatief" },
                 new League { Id = 3, Name = "Toptennis" }
                );
        }
    }
}
