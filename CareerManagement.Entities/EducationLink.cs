namespace CareerManagement.Entities
{
    /// <summary>
    /// 교육 링크
    /// </summary>
    public class EducationLink
    {
        /// <summary>
        /// 교육 식별자
        /// </summary>
        public string EducationId { get; set; }
        /// <summary>
        /// 링크 식별자
        /// </summary>
        public string LinkId { get; set; }
        /// <summary>
        /// 교육
        /// </summary>
        public virtual Education Education { get; set; }
        /// <summary>
        /// 링크
        /// </summary>
        public virtual Link Link { get; set; }
    }
}
