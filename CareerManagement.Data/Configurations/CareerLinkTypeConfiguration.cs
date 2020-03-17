using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class CareerLinkTypeConfiguration : IEntityTypeConfiguration<CareerLink>
    {
        public void Configure(EntityTypeBuilder<CareerLink> b)
        {
            b.ToTable("CareerLink");
            b.HasKey(x => new { x.CareerId, x.LinkId });

            b
                .Property(x => x.CareerId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("경력 식별자")
                ;

            b
                .Property(x => x.LinkId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("링크 식별자")
                ;

            b
                .HasOne(x => x.Career)
                .WithMany(x => x.Links)
                .HasForeignKey(x => x.CareerId);

            b
                .HasOne(x => x.Link)
                .WithMany(x => x.Careers)
                .HasForeignKey(x => x.LinkId);
        }
    }
}
