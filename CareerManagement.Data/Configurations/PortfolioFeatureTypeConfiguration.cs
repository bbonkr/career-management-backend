using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class PortfolioFeatureTypeConfiguration : IEntityTypeConfiguration<PortfolioFeature>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<PortfolioFeature>  b)
        {
            b.ToTable("PortfolioFeature");
            b.HasKey(x => x.Id);

            b.Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("식별자")
                .ValueGeneratedOnAdd()
                ;
            b.Property(x => x.PortfolioId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("포트폴리오 식별자")
                ;
            b.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(StringLength.Note)
                .HasComment("내용")
                ;

            b.HasOne(x => x.Portfolio).WithMany(x => x.Features)
                .HasForeignKey(x => x.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade)
                ;
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
