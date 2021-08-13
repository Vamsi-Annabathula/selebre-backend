using selebre.Concerns.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selebre.Core.Admin
{
    public interface IAdminService
    {
        public void AddAdmin(AdminView adminView);
        public List<EmployeeView> GetAllEmployees(int id);
        public void AddEmployee(int adminId, EmployeeView employeeView);
        public void AddMantraAndTime(AdminSettingsView adminSettingsView);

    }
}
