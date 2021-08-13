using selebre.Concerns.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selebre.Core.User
{
    public interface IUserService
    {
        public void AddComment(CommentView commentView);
        public List<string> GetCurrentCelebrationComments(int givenToUserId);
        public string GetMantra(int id);


    }
}
