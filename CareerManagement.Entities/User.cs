using System;
using System.Collections.Generic;
using System.Text;

namespace CareerManagement.Entities
{
    public class User
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ImageId { get; set; }

        public virtual IList<UserLogin> Logins { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual IList<Career> Careers { get; set; }
        public virtual IList<Education> Educations { get; set; }

        public virtual IList<Portfolio> Portfolios { get; set; }

        public virtual Tech Tech { get; set; }

    }
}
