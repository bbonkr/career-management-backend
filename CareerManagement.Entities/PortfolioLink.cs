namespace CareerManagement.Entities
{
    /// <summary>
    /// 포트폴리오 링크
    /// </summary>
    public class PortfolioLink:LinkBase
    {
        /// <summary>
        /// 포트폴리오 식별자
        /// </summary>
        public string PortfolioId { get; set; }

        /// <summary>
        /// 포트폴리오
        /// </summary>
        public virtual Portfolio Portfolio { get; set; }
    }
}
