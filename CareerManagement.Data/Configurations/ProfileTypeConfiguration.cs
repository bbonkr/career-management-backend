using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class ProfileTypeConfiguration : IEntityTypeConfiguration<Profile>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<Profile>  b)
        {
            b.ToTable("Profile");
            b.HasKey(x => x.Id);

            b.Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("식별자")
                ;
            b.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("사용자 식별자")
                ;
            b.Property(x => x.Bio)
                .IsRequired()
                .HasMaxLength(StringLength.Note)
                .HasComment("상태")
                ;

            b.HasOne(x => x.User).WithOne(x => x.Profile)
                .HasForeignKey<Profile>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasMany(x => x.Links).WithOne(x => x.Profile);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
