using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class LinkTypeConfiguration : IEntityTypeConfiguration<Link>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<Link> b)
        {
            b.ToTable("Link");
            b.HasKey(x => x.Id);

            b.Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("식별자")
                ;
            b.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(StringLength.Name)
                .HasComment("제목")
                ;
            b.Property(x => x.Icon)
                .IsRequired(false)
                .HasMaxLength(StringLength.Name)
                .HasComment("아이콘")
                ;
            b.Property(x => x.Target)
                .IsRequired(false)
                .HasMaxLength(StringLength.Name)
                .HasComment("링크 대상")
                ;

            b.HasMany(x => x.Careers).WithOne(x => x.Link);
            b.HasMany(x => x.Educations).WithOne(x => x.Link);
            b.HasMany(x => x.Profiles).WithOne(x => x.Link);
            b.HasMany(x => x.Portfolios).WithOne(x => x.Link);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
