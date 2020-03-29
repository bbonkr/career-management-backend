using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public class UserTypeConfiguratoin : IEntityTypeConfiguration<User>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<User> b)
        {
            b.ToTable("User");
            b.HasKey(x => x.Id);

            b.Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("식별자")
                ;
            b.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(StringLength.Name)
                .HasComment("계정이름")
                ;
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(StringLength.Name)
                .HasComment("사용자 이름 (출력)")
                ;
            b.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(StringLength.Email)
                .HasComment("전자우편주소")
                ;
            b.Property(x => x.ImageUri)
                .IsRequired(false)
                .HasMaxLength(StringLength.Url)
                .HasComment("사용자 이미지 URI")
                ;

            b.HasMany(x => x.Logins).WithOne(x => x.User);
            b.HasOne(x => x.Profile).WithOne(x => x.User);
            b.HasMany(x => x.Careers).WithOne(x => x.User);
            b.HasMany(x => x.Educations).WithOne(x => x.User);
            b.HasMany(x => x.Portfolios).WithOne(x => x.User);
            b.HasMany(x => x.Skills).WithOne(x => x.User);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
