using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedArbor.Helper;
using RedArbor.Models;

namespace RedArbor.Services
{
    public class EmployeeServiceMock : CheckData, IEmployeeData
    {
        private void CheckEmployeeID(int employeeID)
        {
            if (GetEmployee(employeeID) == null)
            {
                throw new Exception(string.Format(TAG.EMPLOYEE_NOT_FOUND, employeeID));
            }
        }
        private GET_Employee CreateRandomEmployee()
        {            
            Random random = new Random();

            DateTime getRandomDateTime()
            {
                return DateTime.Now.AddDays(random.Next(-500, 500));
            }
            string getRandomString()
            {
                return $"test{ random.Next(0, 1000) }";
            }
            int getRandomInt()
            {
                return random.Next(0, 1000);
            }
            return new GET_Employee
            {
                CompanyId = getRandomInt(),
                CreatedOn = getRandomDateTime(),
                DeletedOn = getRandomDateTime(),
                Email = getRandomString(),
                Fax = getRandomString(),
                Name = getRandomString(),
                Lastlogin = getRandomDateTime(),
                Password = getRandomString(),
                PortalId = getRandomInt(),
                RoleId = getRandomInt(),
                StatusId = getRandomInt(),
                Telephone = getRandomString(),
                UpdatedOn = getRandomDateTime(),
                Username = getRandomString()
            };
        }
        public void DeleteEmployee(int employeeID)
        {
            CheckEmployeeID(employeeID);
        }

        public IEnumerable<GET_Employee> GetAllEmployees()
        {
            var result = new List<GET_Employee>();
            result.Add(CreateRandomEmployee());
            return result;
        }

        public GET_Employee GetEmployee(int id)
        {
            return id > 0 ? CreateRandomEmployee() : null;
        }

        public void PutEmployee(int employeeID, object serializedEployee)
        {
            CheckEmployeeID(employeeID);
            JsonConvert.DeserializeObject<POST_Employee>(serializedEployee.ToString());            
        }

        public int InsertEmployee(object serializedEployee)
        {
            //la conversion prueba los requeridos del json definidos en el modelo
            JsonConvert.DeserializeObject<POST_Employee>(serializedEployee.ToString());
            return new Random().Next(0, int.MaxValue);
        }
    }
}
