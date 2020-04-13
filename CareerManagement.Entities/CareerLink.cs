namespace CareerManagement.Entities
{
    /// <summary>
    /// 경력 링크
    /// </summary>
    public class CareerLink: LinkBase
    {
        /// <summary>
        /// 경력 식별자
        /// </summary>
        public string CareerId { get; set; }

        public virtual Career Career { get; set; }
    }
}
