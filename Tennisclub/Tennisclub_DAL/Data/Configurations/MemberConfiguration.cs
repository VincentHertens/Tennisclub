using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennisclub_Common.MemberDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Configurations
{
    public class MemberConfiguration : Profile, IEntityTypeConfiguration<Member>
    {
        public MemberConfiguration()
        {
            CreateMap<Member, MemberReadDto>();
            CreateMap<MemberCreateDto, Member>();
            CreateMap<MemberUpdateDto, Member>();
        }

        public void Configure(EntityTypeBuilder<Member> m)
        {
            m.Property(c => c.Id).ValueGeneratedOnAdd();
            m.Property(c => c.FederationNr).HasColumnType("varchar(10)").IsRequired();
            m.Property(c => c.FirstName).HasColumnType("varchar(25)").IsRequired();
            m.Property(c => c.LastName).HasColumnType("varchar(35)").IsRequired();
            m.Property(c => c.BirthDate).HasColumnType("date").IsRequired();
            m.Property(c => c.Address).HasColumnType("varchar(70)").IsRequired();
            m.Property(c => c.Number).HasColumnType("varchar(6)").IsRequired();
            m.Property(c => c.Addition).HasColumnType("varchar(2)");
            m.Property(c => c.Zipcode).HasColumnType("varchar(6)").IsRequired();
            m.Property(c => c.City).HasColumnType("varchar(30)").IsRequired();
            m.Property(c => c.PhoneNr).HasColumnType("varchar(15)");
            m.Property(c => c.Active).HasColumnType("bit").IsRequired().HasDefaultValue(true);

            m.HasKey(c => c.Id);
            m.HasIndex(c => c.FederationNr).IsUnique();
            m.HasOne(c => c.Gender).WithMany().HasForeignKey(s => s.GenderId).IsRequired();
        }
    }
}
