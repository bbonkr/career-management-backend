namespace CareerManagement.Entities
{
    /// <summary>
    /// 프로필 링크
    /// </summary>
    public class ProfileLink:LinkBase
    {
        /// <summary>
        /// 프로필 식별자
        /// </summary>
        public string ProfileId { get; set; }
        
        /// <summary>
        /// 프로필
        /// </summary>
        public virtual Profile Profile { get; set; }
        
    }
}
