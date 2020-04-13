using System.Collections.Generic;
using System.Linq;

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
        /// 태그 (관리용)
        /// </summary>
        public virtual IList<PortfolioTag> PortfolioTags { get; set; }

        /// <summary>
        /// 링크
        /// </summary>
        public virtual IList<PortfolioLink> Links { get; set; }

        /// <summary>
        /// 태그 (출력용)
        /// </summary>
        public virtual IList<string> Tags { get; set; }

        /// <summary>
        /// 사용자
        /// </summary>
        public virtual User User { get; set; }
    }
}
