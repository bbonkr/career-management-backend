using System;
using System.Collections.Generic;

namespace CareerManagement.Entities
{
    /// <summary>
    /// 링크
    /// </summary>
    public class Link
    {
        /// <summary>
        /// 식별자
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 제목
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 아이콘
        /// </summary>
        public string Icon { get; set; }
        
        /// <summary>
        /// 대상
        /// </summary>
        public string Target { get; set; }

        public virtual IList<CareerLink> Careers { get; set; }

        public virtual IList<EducationLink> Educations { get; set; }

        public virtual IList<ProfileLink> Profiles { get; set; }

        public virtual IList<PortfolioLink> Portfolios { get; set; }
    }
}
