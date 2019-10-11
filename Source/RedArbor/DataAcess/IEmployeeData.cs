using Microsoft.Data.SqlClient;
using RedArbor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedArbor.Services
{
    public interface IEmployeeData
    {
        public IEnumerable<GET_Employee> GetAllEmployees();
        public GET_Employee GetEmployee(int id);
        public int InsertEmployee(object serializedEployee);
        public void PutEmployee(int employeeID, object serializedEployee);
        public void DeleteEmployee(int employeeID);
    }
}
