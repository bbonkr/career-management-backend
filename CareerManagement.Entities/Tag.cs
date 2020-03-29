using System.Collections.Generic;

namespace CareerManagement.Entities
{
    /// <summary>
    /// 태그
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// 식별자
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 태그
        /// </summary>
        public string Name { get; set; }

        public virtual IList<PortfolioTag> Portfolios { get; set; }
    }
}
