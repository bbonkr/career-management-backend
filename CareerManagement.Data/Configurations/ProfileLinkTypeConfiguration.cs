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
            b.HasKey(x => x.Id);

            b.ConfigureLinkEntity();

            b.Property(x => x.ProfileId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("프로필 식별자")
                ;

            b.HasOne(x => x.Profile).WithMany(x => x.Links)
                .HasForeignKey(x => x.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
