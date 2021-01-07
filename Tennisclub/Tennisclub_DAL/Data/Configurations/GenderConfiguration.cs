using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennisclub_Common.GenderDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Configurations
{
    public class GenderConfiguration : Profile, IEntityTypeConfiguration<Gender>
    {
        public GenderConfiguration()
        {
            CreateMap<Gender, GenderReadDto>();
        }

        public void Configure(EntityTypeBuilder<Gender> g)
        {
            g.Property(c => c.Id).ValueGeneratedOnAdd();
            g.Property(c => c.Name).HasColumnType("varchar(10)").IsRequired();

            g.HasKey(c => c.Id);
            g.HasIndex(c => c.Name).IsUnique();

            g.HasData(
                new Gender { Id = 1, Name = "Man" },
                new Gender { Id = 2, Name = "Vrouw" }
                );
        }
    }
}
