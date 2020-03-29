using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class SkillTypeConfiguration : IEntityTypeConfiguration<Skill>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<Skill> b)
        {
            b.ToTable("Skill");
            b.HasKey(x => x.Id);

            b.Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("식별자")
                ;
            b.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("사용자 식별자")
                ;
            b.Property(x => x.Icon)
                .IsRequired(false)
                .HasMaxLength(StringLength.Name)
                .HasComment("아이콘")
                ;

            b.HasMany(x => x.Items).WithOne(x => x.Skill);
            b.HasOne(x => x.User).WithMany(x => x.Skills);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
