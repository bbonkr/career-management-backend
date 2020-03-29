using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class TagTypeConfiguration : IEntityTypeConfiguration<Tag>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<Tag> b)
        {
            b.ToTable("Tag");
            b.HasKey(x => x.Id);

            b.Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("식별자")
                ;
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(StringLength.Name)
                .HasComment("태그")
                ;

            b.HasMany(x => x.Portfolios).WithOne(x => x.Tag);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
