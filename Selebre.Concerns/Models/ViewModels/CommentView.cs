using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace selebre.Concerns.Models.ViewModels
{
    public class CommentView
    {
        //public int? GivenByUserId { get; set; }
        public int? GivenToUserId { get; set; }
        public  string Comments { get; set; }
        public string? mediaLink { get; set; }
        //commentor name
        public string? commentorName { get; set; }
      
        //public virtual Employee GivenByUser { get; set; }
        //public virtual Employee GivenToUser { get; set; }
    }
}
