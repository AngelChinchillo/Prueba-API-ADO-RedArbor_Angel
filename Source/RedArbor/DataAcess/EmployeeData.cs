using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using RedArbor.Helper;
using RedArbor.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedArbor.Services
{
    public class EmployeeData : CheckData, IEmployeeData
    {

        #region GET
        public IEnumerable<GET_Employee> GetAllEmployees()
        {
            List<GET_Employee> employees = new List<GET_Employee>();
            using (SqlConnection conn = new SqlConnection(Startup.ConnectionString))
            {
                var query = GET_Employee.QUERY_SELECT;
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employees.Add(Helper.Helper.ReflectType<GET_Employee>(reader));
                }
                cmd.Dispose();
            }
            return employees.Count() == 0 ? null : employees;
        }
        public GET_Employee GetEmployee(int id)
        {
            var employee = new GET_Employee();
            using (SqlConnection conn = new SqlConnection(Startup.ConnectionString))
            {
                var query = GET_Employee.QUERY_SELECT +
                            GET_Employee.WHERE_IDENTITY;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@intID", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employee = (Helper.Helper.ReflectType<GET_Employee>(reader));
                }
                cmd.Dispose();
            }
            return employee.Id == 0 ? null : employee;
        }
        #endregion
        #region POST
        public int InsertEmployee(object serializedEployee)
        {
            var json = serializedEployee.ToString();
            var newEmployee = JsonConvert.DeserializeObject<POST_Employee>(json);

            int id = -1;
            using (SqlConnection cn = new SqlConnection(Startup.ConnectionString))
            {
                var ConsultaSql = POST_Employee.QUERY_INSERT_ALL_RETURN_IDENTITY;
                SqlCommand cmd = new SqlCommand(ConsultaSql, cn);
                SetPostParameters(newEmployee, cmd);
                cn.Open();
                id = (int)cmd.ExecuteScalar();
                cmd.Dispose();
                cn.Dispose();
            }
            return id;
        }

        private void SetPostParameters(POST_Employee newEmployee, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@intCompanyID", newEmployee.CompanyId);
            cmd.Parameters.AddWithValue("@dtCreatedOn", CheckDatetimeRange(newEmployee.CreatedOn));
            cmd.Parameters.AddWithValue("@dtDeletedOn", CheckDatetimeRange(newEmployee.DeletedOn));
            cmd.Parameters.AddWithValue("@vcEmail", newEmployee.Email);
            cmd.Parameters.AddWithValue("@vcFax", newEmployee.Fax);
            cmd.Parameters.AddWithValue("@vcName", newEmployee.Name);
            cmd.Parameters.AddWithValue("@dtLastLogin", CheckDatetimeRange(newEmployee.Lastlogin));
            cmd.Parameters.AddWithValue("@vcPassword", newEmployee.Password);
            cmd.Parameters.AddWithValue("@intPortalID", newEmployee.PortalId);
            cmd.Parameters.AddWithValue("@intRoleID", newEmployee.RoleId);
            cmd.Parameters.AddWithValue("@intStatusID", newEmployee.StatusId);
            cmd.Parameters.AddWithValue("@vcTelephone", newEmployee.Telephone);
            cmd.Parameters.AddWithValue("@vcUpdatedOn", newEmployee.UpdatedOn);
            cmd.Parameters.AddWithValue("@vcUsername", newEmployee.Username);
        }
        #endregion
        #region PUT
        public void PutEmployee(int employeeID, object serializedEployee)
        {
            CheckEmployeeID(employeeID);
            var json = serializedEployee.ToString();
            var newEmployee = JsonConvert.DeserializeObject<PUT_Employee>(json);
            newEmployee.Id = employeeID;
            using (SqlConnection cn = new SqlConnection(Startup.ConnectionString))
            {
                var ConsultaSql = PUT_Employee.UPDATE_ALL_WHERE_IDENTITY;
                SqlCommand cmd = new SqlCommand(ConsultaSql, cn);
                SetPutParameters(newEmployee, cmd);
                cn.Open();
                cmd.ExecuteScalar();
                cmd.Dispose();
                cn.Dispose();
            }
        }
        private void SetPutParameters(PUT_Employee newEmployee, SqlCommand cmd)
        {
            SetPostParameters(newEmployee.Cast<POST_Employee>(), cmd);
            cmd.Parameters.AddWithValue("@intID", newEmployee.Id);
        }
        #endregion
        #region DELETE
        public void DeleteEmployee(int employeeID)
        {
            CheckEmployeeID(employeeID);
            using (SqlConnection cn = new SqlConnection(Startup.ConnectionString))
            {
                var ConsultaSql = DELETE_Employee.DELETE_WHERE_IDENTITY;
                SqlCommand cmd = new SqlCommand(ConsultaSql, cn);
                cmd.Parameters.AddWithValue("@intID", employeeID);
                cn.Open();
                cmd.ExecuteScalar();
                cmd.Dispose();
                cn.Dispose();
            }
        }
        #endregion
        private void CheckEmployeeID(int employeeID)
        {
            if (GetEmployee(employeeID) == null)
            {
                throw new Exception(string.Format(TAG.EMPLOYEE_NOT_FOUND, employeeID));
            }
        }
    }
}
