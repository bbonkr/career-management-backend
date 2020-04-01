using System.Collections.Generic;

namespace CareerManagement.Entities
{
    /// <summary>
    /// 포트폴리오
    /// </summary>
    public class Portfolio
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
        /// 기간
        /// </summary>
        public string Period { get; set; }
        /// <summary>
        /// 설명
        /// </summary>
        public string Descriptoin { get; set; }
        /// <summary>
        /// 기능
        /// </summary>
        public virtual IList<PortfolioFeature> Features { get; set; }
        /// <summary>
        /// 태그
        /// </summary>
        public virtual IList<PortfolioTag> Tags { get; set; }

        public virtual IList<PortfolioLink> Links { get; set; }

        /// <summary>
        /// 사용자
        /// </summary>
        public virtual User User { get; set; }
    }
}
