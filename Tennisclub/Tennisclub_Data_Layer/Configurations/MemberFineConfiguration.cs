using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Configurations
{
    class MemberFineConfiguration : IEntityTypeConfiguration<MemberFine>
    {
        public void Configure(EntityTypeBuilder<MemberFine> m)
        {
            m.HasKey(c => c.Id);
            m.Property(c => c.FineNumber).HasColumnType("integer").IsRequired();
            m.Property(c => c.Amount).HasColumnType("decimal(7,2)").IsRequired();
            m.Property(c => c.HandoutDate).HasColumnType("date").IsRequired();
            m.Property(c => c.PaymentDate).HasColumnType("date");
            m.HasIndex(c => c.FineNumber).IsUnique();
            m.HasOne(c => c.Member).WithMany().HasForeignKey(s => s.MemberId).IsRequired();
        }
    }
}
