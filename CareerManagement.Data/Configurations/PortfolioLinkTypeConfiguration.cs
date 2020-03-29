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
            b.HasKey(x => new { x.PortfolioId, x.LinkId });

            b.Property(x => x.PortfolioId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("포트폴리오 식별자")
                ;
            b.Property(x => x.LinkId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("링크 식별자")
                ;

            b.HasOne(x => x.Portfolio)
                .WithMany(x => x.Links)
                .HasForeignKey(x => x.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.Link)
                .WithMany(x => x.Portfolios)
                .HasForeignKey(x => x.LinkId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
