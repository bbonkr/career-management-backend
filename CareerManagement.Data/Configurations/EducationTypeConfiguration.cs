using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class EducationTypeConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> b)
        {
            b.ToTable("Education");

            b.HasKey(x => x.Id);

            b.Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("식별자")
                ;

            b
                .Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("사용자 식별자")
                ;

            b.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(StringLength.Name)
                .HasComment("제목")
                ;

            b.Property(x => x.State)
                .IsRequired(false)
                .HasMaxLength(StringLength.Name)
                .HasComment("상태")
                ;

            b.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(StringLength.Note)
                .HasComment("설명")
                ;

            b.HasOne(x => x.User).WithMany(x => x.Educations).HasForeignKey(x => x.UserId);
            b.HasMany(x => x.Links).WithOne(x => x.Education);
        }
    }
}
