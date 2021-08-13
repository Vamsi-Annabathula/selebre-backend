using Microsoft.AspNetCore.Mvc;
using selebre.Concerns.Models.ViewModels;
using Selebre.Core.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace selebre_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IAdminService adminService;
        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public IEnumerable<EmployeeView> Get(int id)
        {
            return this.adminService.GetAllEmployees(id);
        }

        // POST api/<AdminController>
        [Route("addEmployee")]
        [HttpPost]
        public void AddEmployee(int adminId, [FromBody] EmployeeView employeeView)
        {
            //non-admin employee
            this.adminService.AddEmployee(adminId, employeeView);
        }
        [Route("addAdmin")]
        [HttpPost]
        public void AddAdmin(AdminView adminView)
        {
            this.adminService.AddAdmin(adminView);
        }
        // POST api/<AdminController>
        [Route("addMantra")]
        [HttpPost]
        public void AddMantraAndTime([FromBody] AdminSettingsView adminSettingsView)
        {
            this.adminService.AddMantraAndTime(adminSettingsView);
        }

    }
}
