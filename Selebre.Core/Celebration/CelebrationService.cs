using selebre.Concerns.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace Selebre.Core.Celebration
{
    public class CelebrationService : ICelebrationService
    {
        public bool IsCelebrationTodayForUser(int id)
        {
            DateTime currentDate = DateTime.Now.Date;
            string currentDateAsString = currentDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
            bool status = false;
            using (var ctx = new DbContext())
            {
                DateTime empBday = ctx.Employee.FirstOrDefault(emp => emp.Id == id).Birthday.Date;
                var empBdayAsString = empBday.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                status = currentDateAsString == empBdayAsString;
            }

            return status;
        }
    }
}
