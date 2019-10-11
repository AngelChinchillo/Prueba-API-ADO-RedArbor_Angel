using Newtonsoft.Json;
using RedArbor.Helper;
using RedArbor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedArbor.Services
{
    public class PostEmployeeService
    {
        private IEmployeeData EmployeeData;
        public PostEmployeeService(IEmployeeData EmployeeData)
        {
            this.EmployeeData = EmployeeData;
        }
        public int InsertEmployee(object serializedEployee)
        {
            return EmployeeData.InsertEmployee(serializedEployee);
        }
    }
}
