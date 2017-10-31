
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.Data.Entities;
using ChinookSystem.DAL;

namespace ChinookSystem.BLL
{
    public class EmployeeController
    {
        public Employee Employee_Get(int employeeid)
        {
            using (var context = new ChinookContext())
            {
                return context.Employees.Find(employeeid);
            }
        }
    }
}
