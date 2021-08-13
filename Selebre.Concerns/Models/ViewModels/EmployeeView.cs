using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace selebre.Concerns.Models.ViewModels
{
    public class EmployeeView
    {
        public EmployeeView()
        {
            //AdminSettings = new HashSet<AdminSettingsView>();
            //Auth = new HashSet<AuthView>();
            //CommentGivenByUser = new HashSet<CommentView>();
            //CommentGivenToUser = new HashSet<CommentView>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string JobRole { get; set; }
        public DateTime Birthday { get; set; }

        //public virtual ICollection<AdminSettingsView> AdminSettings { get; set; }
        //public virtual ICollection<AuthView> Auth { get; set; }
        //public virtual ICollection<CommentView> CommentGivenByUser { get; set; }
        //public virtual ICollection<CommentView> CommentGivenToUser { get; set; }
    }
}
