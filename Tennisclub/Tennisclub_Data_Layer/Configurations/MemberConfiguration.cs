using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Configurations
{
    class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> m)
        {
            m.HasKey(c => c.Id);
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

            //Test
            m.Property(c => c.Active).HasColumnType("bit").IsRequired().HasDefaultValue(true);

            m.HasIndex(c => c.FederationNr).IsUnique();
            m.HasOne(c => c.Gender).WithMany().HasForeignKey(s => s.GenderId).IsRequired();
        }
    }
}
