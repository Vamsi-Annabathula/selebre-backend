using System;
using System.Collections.Generic;

namespace selebre.Concerns.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AdminSettings = new HashSet<AdminSettings>();
            Auth = new HashSet<Auth>();
            CommentGivenByUser = new HashSet<Comment>();
            CommentGivenToUser = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string JobRole { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsAdmin { get; set; }
        public int AdminId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<AdminSettings> AdminSettings { get; set; }
        public virtual ICollection<Auth> Auth { get; set; }
        public virtual ICollection<Comment> CommentGivenByUser { get; set; }
        public virtual ICollection<Comment> CommentGivenToUser { get; set; }
    }
}
