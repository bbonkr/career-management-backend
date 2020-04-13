namespace CareerManagement.Entities
{
    /// <summary>
    /// 링크 기본 데이터 구조를 제공합니다.
    /// </summary>
    public abstract class LinkBase
    {
        /// <summary>
        /// 식별자
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 제목
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 아이콘
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 링크 주소
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// 링크 대상
        /// </summary>
        public string Target { get; set; }
    }
}
