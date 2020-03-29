using System;
using System.Collections.Generic;
using System.Text;

namespace CareerManagement.Entities
{
    public class User
    {
        /// <summary>
        /// 식별자
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 계정이름
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 사용자 이름 (출력)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 전자우편주소
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 이미지 파일 Uri
        /// </summary>
        public string ImageUri { get; set; }

        /// <summary>
        /// 로그인
        /// </summary>
        public virtual IList<UserLogin> Logins { get; set; }

        /// <summary>
        /// 프로필
        /// </summary>
        public virtual Profile Profile { get; set; }
        /// <summary>
        /// 경력사항
        /// </summary>
        public virtual IList<Career> Careers { get; set; }
        /// <summary>
        /// 학력사항
        /// </summary>
        public virtual IList<Education> Educations { get; set; }
        /// <summary>
        /// 포트폴리오
        /// </summary>
        public virtual IList<Portfolio> Portfolios { get; set; }
        /// <summary>
        /// 기술
        /// </summary>
        public virtual IList<Skill> Skills { get; set; }

    }
}
