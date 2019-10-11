using RedArbor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedArbor.Services
{
    public class GetEmployeeService
    {
        private IEmployeeData EmployeeData;
        public GetEmployeeService(IEmployeeData EmployeeData)
        {
            this.EmployeeData = EmployeeData;
        }
        public GET_Employee GetEmployee(int id)
        {
            return EmployeeData.GetEmployee(id);
        }
    }
}
