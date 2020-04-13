using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class EducationLinkTypeConfiguration : IEntityTypeConfiguration<EducationLink>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<EducationLink> b)
        {
            b.ToTable("EducationLink");
            b.HasKey(x => x.Id);

            b.Property(x => x.EducationId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("교육 식별자")
                ;

            b.ConfigureLinkEntity();

            b
                .HasOne(x => x.Education)
                .WithMany(x => x.Links)
                .HasForeignKey(x => x.EducationId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
