using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerManagement.Data.Configurations
{
    public class CareerTypeConfiguration : IEntityTypeConfiguration<Career>
    {
        public void Configure(EntityTypeBuilder<Career> b)
        {
            b.ToTable("Career");
            b.HasKey(x => x.Id);

            b
                .Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("식별자")
                .ValueGeneratedOnAdd()
                ;
            b
                .Property(x => x.UserId)
                .IsRequired()
               .HasMaxLength(StringLength.Identifier)
               .HasComment("사용자 식별자")
               ;

            b
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(StringLength.Note)
                .HasComment("제목; 직장명")
                ;
            b
                .Property(x => x.State)
                .IsRequired()
                .HasMaxLength(StringLength.Name)
                .HasComment("상태")
                ;

            b
                .Property(x => x.Description)
                .HasMaxLength(StringLength.Note)
                .HasComment("설명")
                ;

            b
                .HasMany(x => x.Links)
                .WithOne(x => x.Career)
                .OnDelete(DeleteBehavior.Cascade)
           ;

            b
                .HasOne(x => x.User)
                .WithMany(x => x.Careers)
                .HasForeignKey(x => x.UserId);

        }
    }
}
