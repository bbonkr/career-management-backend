namespace CareerManagement.Entities
{
    /// <summary>
    /// 기술 항목
    /// </summary>
    public class SkillItem
    {
        /// <summary>
        /// 식별자
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 기술 식별자
        /// </summary>
        public string SkillId { get; set; }
        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 점수
        /// </summary>
        public float Score { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
