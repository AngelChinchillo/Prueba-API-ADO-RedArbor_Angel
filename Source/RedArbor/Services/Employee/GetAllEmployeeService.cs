using RedArbor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedArbor.Services
{
    public class GetAllEmployeeService
    {
        private IEmployeeData EmployeeData;
        public GetAllEmployeeService(IEmployeeData EmployeeData)
        {
            this.EmployeeData = EmployeeData;
        }
        public IEnumerable<GET_Employee> GetAllEmployees()
        {
            return EmployeeData.GetAllEmployees();
        }
    }
}
