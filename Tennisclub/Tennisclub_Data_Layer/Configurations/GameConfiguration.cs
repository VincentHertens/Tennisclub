using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Configurations
{
    class GameConfiguration : IEntityTypeConfiguration<Game>
    {
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
