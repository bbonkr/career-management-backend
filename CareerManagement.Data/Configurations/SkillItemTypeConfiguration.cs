using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class SkillItemTypeConfiguration : IEntityTypeConfiguration<SkillItem>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<SkillItem> b)
        {
            b.ToTable("SkillItem");
            b.HasKey(x => x.Id);

            b.Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("식별자")
                ;
            b.Property(x => x.SkillId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("기술 식별자")
                ;
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(StringLength.Name)
                .HasComment("이름")
                ;
            b.Property(x => x.Score)
                .IsRequired()
                .HasDefaultValue(0)
                .HasComment("점수")
                ;

            b.HasOne(x => x.Skill).WithMany(x => x.Items)
                .HasForeignKey(x => x.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
