using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Configurations
{
    class MemberRoleConfiguration : IEntityTypeConfiguration<MemberRole>
    {
        public void Configure(EntityTypeBuilder<MemberRole> m)
        {
            m.HasKey(c => c.Id);
            m.Property(c => c.StartDate).HasColumnType("date").IsRequired();
            m.Property(c => c.EndDate).HasColumnType("date");
            m.HasIndex(c => new { c.MemberId, c.RoleId, c.StartDate, c.EndDate}).IsUnique();
            m.HasOne(c => c.Member).WithMany().HasForeignKey(s => s.MemberId).IsRequired();
            m.HasOne(c => c.Role).WithMany().HasForeignKey(s => s.RoleId).IsRequired();
        }
    }
}
