using System;
using System.Collections.Generic;
using System.Text;

namespace selebre.Concerns.Models.ViewModels
{
    public class AdminView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string JobRole { get; set; }
        public DateTime Birthday { get; set; }
    }
}
