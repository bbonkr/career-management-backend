using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class PortfolioTypeConfiguration : IEntityTypeConfiguration<Portfolio>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<Portfolio> b)
        {
            b.ToTable("Portfolio");

            b.Ignore(x => x.Tags);

            b.HasKey(x => x.Id);

            b.Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("식별자")
                .ValueGeneratedOnAdd()
                ;
            b.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("사용자 식별자")
                ;
            b.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(StringLength.Name)
                .HasComment("제목")
                ;
            b.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(StringLength.Name)
                .HasComment("상태")
                ;
            b.Property(x => x.Period)
                .IsRequired(false)
                .HasMaxLength(StringLength.Name)
                .HasComment("기간")
                ;
            b.Property(x => x.Descriptoin)
                .IsRequired(false)
                .HasMaxLength(StringLength.Note)
                .HasComment("설명")
                ;
            
            b.HasMany(x => x.Features).WithOne(x => x.Portfolio);
            b.HasMany(x => x.PortfolioTags).WithOne(x => x.Portfolio);
            b.HasMany(x => x.Links).WithOne(x => x.Portfolio);
            b.HasOne(x => x.User).WithMany(x => x.Portfolios)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);                
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
