using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennisclub_Common.MemberRoleDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Configurations
{
    public class MemberRoleConfiguration : Profile, IEntityTypeConfiguration<MemberRole>
    {

        public MemberRoleConfiguration()
        {
            CreateMap<MemberRole, MemberRoleReadDto>();
            CreateMap<MemberRoleCreateDto, MemberRole>();
            CreateMap<MemberRoleUpdateDto, MemberRole>();
        }

        public void Configure(EntityTypeBuilder<MemberRole> m)
        {
            m.Property(c => c.Id).ValueGeneratedOnAdd();
            m.Property(c => c.StartDate).HasColumnType("date").IsRequired();
            m.Property(c => c.EndDate).HasColumnType("date");          
            m.HasOne(c => c.Member).WithMany().HasForeignKey(s => s.MemberId).IsRequired();
            m.HasOne(c => c.Role).WithMany().HasForeignKey(s => s.RoleId).IsRequired();

            m.HasKey(c => c.Id);
            m.HasIndex(c => new { c.MemberId, c.RoleId, c.StartDate, c.EndDate }).IsUnique();
        }
    }
}
