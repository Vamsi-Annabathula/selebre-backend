using selebre.Concerns.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selebre.Core.User
{
    public interface IUserService
    {
        public void AddComment(int id, CommentView commentView);
        public List<CommentView> GetCurrentCelebrationComments(int givenToUserId);
        public string GetMantra(int id);


    }
}
