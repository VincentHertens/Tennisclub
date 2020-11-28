using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennisclub_Common.GameResultDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Configurations
{
    public class GameResultConfiguration : Profile, IEntityTypeConfiguration<GameResult>
    {

        public GameResultConfiguration()
        {
            CreateMap<GameResult, GameResultReadDto>();

            CreateMap<GameResultCreateDto, GameResult>();

            CreateMap<GameResultUpdateDto, GameResult>();
        }

        public void Configure(EntityTypeBuilder<GameResult> g)
        {
            g.HasKey(c => c.Id);
            g.Property(c => c.SetNr).HasColumnType("tinyint").IsRequired();
            g.Property(c => c.ScoreTeamMember).HasColumnType("tinyint").IsRequired();
            g.Property(c => c.ScoreOpponent).HasColumnType("tinyint").IsRequired();
            g.HasIndex(c => new { c.SetNr, c.GameId}).IsUnique();
            g.HasOne(c => c.Game).WithMany().HasForeignKey(s => s.GameId).IsRequired();
        }
    }
}
