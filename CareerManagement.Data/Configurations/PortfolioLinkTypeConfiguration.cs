using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class PortfolioLinkTypeConfiguration : IEntityTypeConfiguration<PortfolioLink>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<PortfolioLink> b)
        {
            b.ToTable("PortfolioLink");
            b.HasKey(x => x.Id);

            b.ConfigureLinkEntity();

            b.Property(x => x.PortfolioId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("포트폴리오 식별자")
                ;

            b.HasOne(x => x.Portfolio)
                .WithMany(x => x.Links)
                .HasForeignKey(x => x.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
