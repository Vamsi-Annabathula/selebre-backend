using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selebre.Concerns.Models
{
    public partial class Comment
    {
        [Key, Column(Order = 0)]
        public int? GivenByUserId { get; set; }
        [Key, Column(Order = 1)]
        public int? GivenToUserId { get; set; }
        public string Comments { get; set; }
        public string? mediaLocation { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Employee GivenByUser { get; set; }
        public virtual Employee GivenToUser { get; set; }
    }
}
