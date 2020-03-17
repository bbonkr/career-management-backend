namespace CareerManagement.Entities
{
    /// <summary>
    /// 프로필 링크
    /// </summary>
    public class ProfileLink
    {
        /// <summary>
        /// 프로필 식별자
        /// </summary>
        public string ProfileId { get; set; }
        /// <summary>
        /// 링크 식별자
        /// </summary>
        public string LinkId { get; set; }
        /// <summary>
        /// 프로필
        /// </summary>
        public virtual Profile Profile { get; set; }
        /// <summary>
        /// 링크
        /// </summary>
        public virtual Link Link { get; set; }
    }
}
