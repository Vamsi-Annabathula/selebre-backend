using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using selebre.Concerns.Models.ViewModels;
using selebre.Concerns.Models;
using Selebre.Core.Admin;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace selebre_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAdminService adminService;
        public AuthController(IAdminService adminService)
        {
            this.adminService = adminService;
        }


        // POST api/<AuthController>
        [Route("signup")]
        [HttpPost]
        public IActionResult Signup([FromBody] AuthView authView)
        {
            using(var ctx = new DbContext())
            {
                var emp = ctx.Employee.FirstOrDefault(emp => emp.Email == authView.Email);
                if(emp == null)
                {
                    return NotFound("User does not exist. Please contact your administrator to add you.");
                }
                Auth auth = new Auth
                {
                    UserId = emp.Id,
                    Password = authView.Password,
                    IsActive = true,
                };
                ctx.Add<Auth>(auth);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] AuthView authView)
        {
            using (var ctx = new DbContext())
            {
                Employee emp = ctx.Employee.FirstOrDefault((emp) => emp.Email == authView.Email);
                if (emp == null)
                {
                    // send employee not found
                    return NotFound("User does not exist");
                }

                else
                {
                    Auth auth = ctx.Auth.FirstOrDefault(auth => auth.UserId == emp.Id);

                    if (auth.Password != authView.Password)
                    {
                        //send response saying password/email wrong
                        return StatusCode( 403, "Email or password is incorrect");
                    }
                    else
                    {
                        //send emp in response body
                        return Ok(emp.Id);
                    }
                }
            }
        }


        //// PUT api/<AuthController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AuthController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
