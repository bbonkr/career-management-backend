namespace CareerManagement.Entities
{
    /// <summary>
    /// 포트폴리오 태그
    /// </summary>
    public class PortfolioTag
    {
        /// <summary>
        /// 식별자
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 포트폴리오 식별자
        /// </summary>
        public string PortfolioId { get; set; }
      
        /// <summary>
        /// 태그
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 포트폴리오
        /// </summary>
        public virtual Portfolio Portfolio { get; set; }
        
    }
}
