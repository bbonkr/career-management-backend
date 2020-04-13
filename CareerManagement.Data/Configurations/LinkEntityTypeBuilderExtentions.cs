using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerManagement.Data.Configurations
{
    public static class LinkEntityTypeBuilderExtentions
    {
        /// <summary>
        /// 링크 엔티티 타입을 구성합니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b"></param>
        public static void ConfigureLinkEntity<T>(this EntityTypeBuilder<T> b) where T : LinkBase
        {
            b.Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(StringLength.Identifier)
                .HasComment("식별자")
                .ValueGeneratedOnAdd();

            b.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(StringLength.Name)
                .HasComment("링크 제목")
                ;
            b.Property(x => x.Href)
                .IsRequired()
                .HasMaxLength(StringLength.Url)
                .HasComment("링크 주소")
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
        }
    }
}
