using System;
using System.Collections.Generic;
using System.Text;

namespace CareerManagement.Entities
{
    /// <summary>
    /// 프로필
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// 식별자
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 사용자 식별자
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 상태
        /// </summary>
        public string Bio { get; set; }
        /// <summary>
        /// 사용자
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// 링크
        /// </summary>
        public virtual IList<ProfileLink> Links { get; set; }
    }
}
