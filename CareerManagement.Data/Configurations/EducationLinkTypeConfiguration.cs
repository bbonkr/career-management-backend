using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class EducationLinkTypeConfiguration : IEntityTypeConfiguration<EducationLink>
    {
        public void Configure(EntityTypeBuilder<EducationLink> b)
        {
            b.ToTable("EducationLink");
            b.HasKey(x => new { x.EducationId, x.LinkId });

            b.Property(x => x.EducationId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("교육 식별자")
                ;

            b.Property(x => x.LinkId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("링크 식별자");

            b
                .HasOne(x => x.Education)
                .WithMany(x => x.Links)
                .HasForeignKey(x => x.EducationId)
                .OnDelete(DeleteBehavior.Cascade);
            b
                .HasOne(x => x.Link)
                .WithMany(x => x.Educations)
                .HasForeignKey(x => x.LinkId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
