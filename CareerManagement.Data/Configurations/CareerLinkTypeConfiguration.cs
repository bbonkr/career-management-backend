using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class CareerLinkTypeConfiguration : IEntityTypeConfiguration<CareerLink>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<CareerLink> b)
        {
            b.ToTable("CareerLink");
            b.HasKey(x => x.Id);

            b.ConfigureLinkEntity();
           
            b
                .Property(x => x.CareerId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("경력 식별자")
                ;            

            b
                .HasOne(x => x.Career)
                .WithMany(x => x.Links)
                .HasForeignKey(x => x.CareerId);           
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
