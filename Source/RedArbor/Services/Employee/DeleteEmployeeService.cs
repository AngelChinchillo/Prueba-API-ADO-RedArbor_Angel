using RedArbor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedArbor.Services
{
    public class DeleteEmployeeService
    {
        private IEmployeeData EmployeeData;
        public DeleteEmployeeService(IEmployeeData EmployeeData)
        {
            this.EmployeeData = EmployeeData;
        }
        public void DeleteEmployee(int id)
        {
            EmployeeData.DeleteEmployee(id);
        }
    }
}
