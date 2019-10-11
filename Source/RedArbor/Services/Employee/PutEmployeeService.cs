using RedArbor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedArbor.Services
{
    public class PutEmployeeService
    {
        private IEmployeeData EmployeeData;
        public PutEmployeeService(IEmployeeData EmployeeData)
        {
            this.EmployeeData = EmployeeData;
        }
        public void PutEmployee(int employeeID, object serializedEployee)
        {
            EmployeeData.PutEmployee(employeeID,serializedEployee);
        }
    }
}
