using NUnit.Framework;
using RedArbor.Services;
using System.Linq;

namespace RedArborTest
{
    public class GetAllEmployeesTest
    {
        //Este metodo solo podría fallar si la base de datos tuviese problema        
        [Test]
        public void GetAllEmployee()
        {
            GetAllEmployeeService em = new GetAllEmployeeService(new EmployeeServiceMock());
            var result = em.GetAllEmployees();
            Assert.IsTrue(result.ToList().Count > 0);
        }
    }
}