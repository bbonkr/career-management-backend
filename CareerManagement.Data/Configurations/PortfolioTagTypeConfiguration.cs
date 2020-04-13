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

            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(StringLength.Name)
                .HasComment("태그")
                ;
            

            b.HasOne(x => x.Portfolio).WithMany(x => x.PortfolioTags)
                .HasForeignKey(x => x.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
