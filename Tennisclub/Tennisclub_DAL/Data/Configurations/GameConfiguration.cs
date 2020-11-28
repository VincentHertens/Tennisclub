using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennisclub_Common.GameDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Configurations
{
    public class GameConfiguration : Profile, IEntityTypeConfiguration<Game>
    {

        public GameConfiguration()
        {
            CreateMap<Game, GameReadDto>();

            CreateMap<GameCreateDto, Game>();

            CreateMap<GameUpdateDto, Game>();
        }

        public void Configure(EntityTypeBuilder<Game> g)
        {
            g.HasKey(c => c.Id);
            g.Property(c => c.GameNumber).HasColumnType("varchar(10)").IsRequired();
            g.Property(c => c.Date).HasColumnType("date").IsRequired();
            g.HasIndex(c => c.GameNumber).IsUnique();
            g.HasOne(c => c.Member).WithMany().HasForeignKey(s => s.MemberId).IsRequired();
            g.HasOne(c => c.League).WithMany().HasForeignKey(s => s.LeagueId).IsRequired();
        }
    }
}
