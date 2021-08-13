using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace selebre.Concerns.Models
{
    public partial class Auth
    {
        [Key]
        public int? UserId { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Employee User { get; set; }
    }
}
