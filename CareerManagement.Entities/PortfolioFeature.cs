namespace CareerManagement.Entities
{
    /// <summary>
    /// 포트폴리오 기능
    /// </summary>
    public class PortfolioFeature
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
        /// 내용
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 포트폴리오
        /// </summary>
        public virtual Portfolio Portfolio { get; set; }
    }
}
