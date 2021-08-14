using Microsoft.AspNetCore.Mvc;
using selebre.Concerns.Models.ViewModels;
using Selebre.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace selebre_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;

        }

        //// GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UserController>/5
        [HttpGet("{id}/getMantra")]
        public ActionResult Get(int id)
        {

            string mantra = this.userService.GetMantra(id);
            if (mantra == null)
            {
                return StatusCode(404, "mantra not set for this user");
            }
            return StatusCode(200, mantra);
        }
        
        [Route("{id}/getComments")]
        [HttpGet]
        public List<CommentView> GetCommentsForUser(int id)
        {
            return this.userService.GetCurrentCelebrationComments(id);
        }

        // POST api/<UserController>
        [Route("{id}/addComment")]
        [HttpPost]
        public void AddComment(int id, [FromBody] CommentView commentView)
        {
            this.userService.AddComment(id, commentView);
        }

    }
}
