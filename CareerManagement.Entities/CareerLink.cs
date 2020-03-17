namespace CareerManagement.Entities
{
    /// <summary>
    /// 경력 링크
    /// </summary>
    public class CareerLink
    {
        /// <summary>
        /// 경력 식별자
        /// </summary>
        public string CareerId { get; set; }
        /// <summary>
        /// 링크 식별자
        /// </summary>
        public string LinkId { get; set; }
        /// <summary>
        /// 경력
        /// </summary>
        public Career Career { get; set; }
        /// <summary>
        /// 링크
        /// </summary>
        public Link Link { get; set; }
    }
}
