namespace CareerManagement.Entities
{
    /// <summary>
    /// 교육 링크
    /// </summary>
    public class EducationLink:LinkBase
    {
        /// <summary>
        /// 교육 식별자
        /// </summary>
        public string EducationId { get; set; }
        
        public virtual Education Education { get; set; }
    }
}
