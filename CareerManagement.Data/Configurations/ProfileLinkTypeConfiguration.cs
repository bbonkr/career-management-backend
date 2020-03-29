using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class ProfileLinkTypeConfiguration : IEntityTypeConfiguration<ProfileLink>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<ProfileLink> b)
        {
            b.ToTable("ProfileLink");
            b.HasKey(x => new { x.ProfileId, x.LinkId });

            b.Property(x => x.ProfileId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("프로필 식별자")
                ;
            b.Property(x => x.LinkId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("링크 식별자")
                ;

            b.HasOne(x => x.Profile).WithMany(x => x.Links)
                .HasForeignKey(x => x.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.Link).WithMany(x => x.Profiles)
                .HasForeignKey(x => x.LinkId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
