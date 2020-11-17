using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Configurations
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> r)
        {
            r.HasKey(c => c.Id);
            r.Property(c => c.Id).ValueGeneratedOnAdd(); //Voorlopige oplossing
            r.Property(c => c.Name).HasColumnType("varchar(20)").IsRequired();
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
