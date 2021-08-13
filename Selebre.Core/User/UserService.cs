using selebre.Concerns.Models;
using selebre.Concerns.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Selebre.Core.User
{
    public class UserService : IUserService
    {

        private readonly AutoMapper.IMapper mapper;

        public UserService(AutoMapper.IMapper _mapper)
        {
            mapper = _mapper;
        }

        public void AddComment(CommentView commentView)
        {
            using(var ctx = new selebreContext())
            {
                Comment comment = mapper.Map<CommentView, Comment>(commentView);
                comment.IsActive = true;
                ctx.Add(comment);
                ctx.SaveChanges();
            }
        }

        public List<string> GetCurrentCelebrationComments(int givenToUserId)
        {
            List<string> comments = new List<string>();
            using (var ctx = new selebreContext())
            { 
                comments = (List<string>)ctx.Comment.Where(comment => comment.GivenToUserId == givenToUserId).SelectMany(comment => comment.Comments);
            }

            return comments;
        }

        public string GetMantra(int id)
        {
            string mantra;
            using(var ctx = new selebreContext())
            {
                mantra = ctx.AdminSettings.FirstOrDefault(adminSetting => adminSetting.UserId == id).Mantra;
            }

            return mantra;
        }

    }
}
