using System.Collections.Generic;

namespace CareerManagement.Entities
{
    /// <summary>
    /// 경력
    /// </summary>
    public class Career
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
        /// 제목
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 상태
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 설명
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 링크
        /// </summary>
        public virtual IList<CareerLink> Links { get; set; }

        /// <summary>
        /// 사용자
        /// </summary>
        public User User { get; set; }
    }
}
