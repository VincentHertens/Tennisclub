using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennisclub_Common.RoleDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Configurations
{
    public class RoleConfiguration : Profile, IEntityTypeConfiguration<Role>
    {

        public RoleConfiguration()
        {
            CreateMap<Role, RoleReadDto>();
            CreateMap<RoleCreateDto, Role>();
            CreateMap<RoleUpdateDto, Role>();
        }

        public void Configure(EntityTypeBuilder<Role> r)
        {
            r.Property(c => c.Id).ValueGeneratedOnAdd();
            r.Property(c => c.Name).HasColumnType("varchar(20)").IsRequired();

            r.HasKey(c => c.Id);
            r.HasIndex(c => c.Name).IsUnique();

            r.HasData(
                new Role { Id = 1, Name = "Bestuurslid" },
                new Role { Id = 2, Name = "Penningmeester" },
                new Role { Id = 3, Name = "Secretaris" },
                new Role { Id = 4, Name = "Speler" },
                new Role { Id = 5, Name = "Voorzitter" }
                );
        }
    }
}
