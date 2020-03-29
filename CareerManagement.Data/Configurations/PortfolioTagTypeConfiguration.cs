using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class PortfolioTagTypeConfiguration : IEntityTypeConfiguration<PortfolioTag>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<PortfolioTag> b)
        {
            b.ToTable("PortfolioTag");
            b.HasKey(x => new { x.PortfolioId, x.TagId });

            b.Property(x => x.PortfolioId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("포트폴리오 식별자")
                ;
            b.Property(x => x.TagId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("태그 식별자")
                ;

            b.HasOne(x => x.Portfolio).WithMany(x => x.Tags)
                .HasForeignKey(x => x.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.Tag).WithMany(x => x.Portfolios)
                .HasForeignKey(x => x.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
