using selebre.Concerns.Models.ViewModels;
using selebre.Concerns.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;

namespace Selebre.Core.Admin
{
    public class AdminService : IAdminService
    {
        private readonly AutoMapper.IMapper mapper;

        public AdminService(AutoMapper.IMapper _mapper)
        {
            mapper = _mapper;
        }

        // adding admin employee
        public void AddAdmin(AdminView adminView)
        {
            using (var ctx = new selebreContext())
            {

                Employee emp = ctx.Employee.FirstOrDefault(emp => emp.Email == adminView.Email);
                if (emp != null)
                {
                    return;
                }
                emp = mapper.Map<AdminView, Employee>(adminView);
                emp.IsActive = true;
                emp.IsAdmin = true;
                emp.AdminId = -1;
                ctx.Add(emp);
                ctx.SaveChanges();
                emp.AdminId = emp.Id;
                ctx.Employee.Update(emp);

                Auth auth = new Auth
                {
                    UserId = emp.Id,
                    Password = adminView.password,
                    IsActive = true,
                };
                ctx.Add(auth);
                ctx.SaveChanges();
            }
        }

        public List<EmployeeView> GetAllEmployees(int id)
        {
            List<EmployeeView> employees = new List<EmployeeView>();
            using(var ctx = new selebreContext())
            {
                employees = (List<EmployeeView>)ctx.Employee.Where(emp => emp.AdminId == id);
            }

            return employees;
        }

        // adding non-admin employee
        public void AddEmployee(int adminId, EmployeeView employeeView)
        {
            using (var ctx = new selebreContext())
            {
                Employee empdb = mapper.Map<EmployeeView, Employee>(employeeView);
                empdb.IsActive = true;
                empdb.IsAdmin = false;
                empdb.AdminId = adminId;
                ctx.Add(empdb);
                ctx.SaveChanges();
            }
        }

        public void AddMantraAndTime(AdminSettingsView adminSettingsView)
        {
            using(var ctx = new selebreContext())
            {
                AdminSettings adminSettings = mapper.Map<AdminSettingsView, AdminSettings>(adminSettingsView);
                adminSettings.IsActive = true;
                ctx.Add(adminSettings);
                ctx.SaveChanges();
            }
        }

    }
}
