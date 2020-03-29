using System;
using System.Collections.Generic;
using System.Text;

namespace CareerManagement.Entities
{
    public class UserLogin
    {
        /// <summary>
        /// 사용자 식별자
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 제공자
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// 비밀번호
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 만료시각
        /// </summary>
        public DateTimeOffset ExpiredAt { get; set; }

        /// <summary>
        /// 재시도 횟수
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// 로그인 잠김
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// 로그인 잠김 시각
        /// </summary>
        public DateTimeOffset? LockedAt { get; set; }

        /// <summary>
        /// 사용자
        /// </summary>
        public virtual User User { get; set; }
    }
}
