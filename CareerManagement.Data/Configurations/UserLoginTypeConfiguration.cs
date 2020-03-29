using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CareerManagement.Data.Configurations
{
    public class UserLoginTypeConfiguration : IEntityTypeConfiguration<UserLogin>, IEntityTypeConfigurationProvider
    {
        public void Configure(EntityTypeBuilder<UserLogin> b)
        {
            b.ToTable("UserLogin");
            b.HasKey(x => x.UserId);

            b.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("사용자 식별자")
                ;
            b.Property(x => x.Provider)
                .IsRequired()
                .HasMaxLength(StringLength.Name)
                .HasDefaultValue("Local")
                .HasComment("사용자 로그인 제공자")
                ;
            b.Property(x => x.Secret)
                .IsRequired()
                .HasMaxLength(StringLength.Note)
                .HasComment("비밀키; 비밀번호 해시")
                ;
            b.Property(x => x.ExpiredAt)
                .IsRequired()
                .HasDefaultValue(DateTimeOffset.UtcNow.AddMonths(3))
                .HasComment("만료시각")
                ;
            b.Property(x => x.RetryCount)
                .IsRequired()
                .HasDefaultValue(0)
                .HasComment("로그인 재시도 횟수")
                ;
            b.Property(x => x.IsLocked)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("로그인 잠김");
            b.Property(x => x.LockedAt)
                .IsRequired(false)
                .HasComment("로그인 잠김 시각")
                ;

            b.HasOne(x => x.User).WithMany(x => x.Logins)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
