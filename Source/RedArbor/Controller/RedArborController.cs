using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RedArbor.Helper;
using RedArbor.Models;
using RedArbor.Services;

namespace RedArbor.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedArborController : ControllerBase
    {
        // GET: api/RedArbor
        [HttpGet]
        public IEnumerable<GET_Employee> Get()
        {
            GetAllEmployeeService getAllEmployeeService = new GetAllEmployeeService(new EmployeeData());
            return getAllEmployeeService.GetAllEmployees();
        }     

        //todos los datas son service, pasar por la capa intermedia
        // GET: api/RedArbor/5
        [HttpGet("{id}", Name = "Get")]
        public GET_Employee Get(int id)
        {
            GetEmployeeService getEmployeeService = new GetEmployeeService(new EmployeeData());
            return getEmployeeService.GetEmployee(id);
        }

        // POST: api/RedArbor
        [HttpPost]
        public GET_Employee Post([FromBody] object serializedEployee)
        {
            PostEmployeeService postEmployeeService = new PostEmployeeService(new EmployeeData());
            int id = postEmployeeService.InsertEmployee(serializedEployee);
            return Get(id);
        }

        // PUT: api/RedArbor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] object serializedEployee)
        {
            PutEmployeeService putEmployeeService = new PutEmployeeService(new EmployeeData());
            putEmployeeService.PutEmployee(id,serializedEployee);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DeleteEmployeeService deleteEmployeeService = new DeleteEmployeeService(new EmployeeData());
            deleteEmployeeService.DeleteEmployee(id);            
        }
    }
}
