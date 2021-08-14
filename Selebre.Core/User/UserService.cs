using selebre.Concerns.Models;
using selebre.Concerns.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Selebre.Core.User
{
    public class UserService : IUserService
    {

        private readonly AutoMapper.IMapper mapper;

        public UserService(AutoMapper.IMapper _mapper)
        {
            mapper = _mapper;
        }

        public void AddComment(int id, CommentView commentView)
        {
            using(var ctx = new selebreContext())
            {
                //Comment comment = mapper.Map<CommentView, Comment>(commentView);
                //comment.GivenByUserId = id;
                //comment.IsActive = true;

                //var commentDb = ctx.Comment.Find(new int[2] { id, (int)commentView.GivenToUserId });
                var commentDb = ctx.Comment.AsNoTracking().FirstOrDefault(comm => comm.GivenByUserId == id && comm.GivenToUserId == commentView.GivenToUserId);
                Comment comment = mapper.Map<CommentView, Comment>(commentView);
                if (commentDb == null)
                {
                    comment.GivenByUserId = id;
                    comment.IsActive = true;
                    ctx.Add(comment);

                }
                else
                {
                    commentDb.Comments = commentView.Comments;
                    ctx.Update(commentDb);
                }
                //else
                //{
                //    commentDb = mapper.Map<CommentView, Comment>(commentView);
                //    commentDb.GivenByUserId = id;
                //    commentDb.IsActive = true;
                //}

                ctx.SaveChanges();
            }
        }

        public List<CommentView> GetCurrentCelebrationComments(int givenToUserId)
        {
            List<CommentView> commentList = new List<CommentView>();
            CommentView commentView = new CommentView();
            using (var ctx = new selebreContext())
            { 
                //comments = (List<string>)ctx.Comment.Where(comment => comment.GivenToUserId == givenToUserId).SelectMany(comment => comment.Comments);
                var comments = ctx.Comment.Where(comment => comment.GivenToUserId == givenToUserId).ToList();
                
                foreach(var comm in comments)
                {
                    Employee emp = ctx.Employee.Find(comm.GivenByUserId);
                    commentView = mapper.Map<Comment, CommentView>(comm);
                    commentView.commentorName = emp.FirstName + " " + emp.LastName;
                    commentList.Add(commentView);
                }

            }


            return commentList;
        }

        public string GetMantra(int id)
        {
            string mantra;
            using(var ctx = new selebreContext())
            {
                mantra = ctx.AdminSettings.FirstOrDefault(adminSetting => adminSetting.UserId == id)?.Mantra;
            }

            return mantra;
        }

    }
}
