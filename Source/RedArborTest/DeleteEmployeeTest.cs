using NUnit.Framework;
using RedArbor.Helper;
using RedArbor.Services;
using System;
using System.Linq;

namespace RedArborTest
{
    public class DeleteEmployeeTest
    {

        [Test]
        [TestCase(20)]
        public void DeleteEmployeeSuccessfully(int employeeID)
        {
            Exception exceptionToTest = null;
            try
            {
                DeleteEmployeeService em = new DeleteEmployeeService(new EmployeeServiceMock());
                em.DeleteEmployee(employeeID);
            }
            catch (Exception ex)
            {
                exceptionToTest = ex;

            }
            Assert.IsNull(exceptionToTest);
        }

        [Test]
        [TestCase(-1)]
        public void DeleteEmployeeNotFoundThrowException(int employeeID)
        {
            Exception exceptionToTest = null;
            try
            {
                DeleteEmployeeService em = new DeleteEmployeeService(new EmployeeServiceMock());
                em.DeleteEmployee(employeeID);
            }
            catch (Exception ex)
            {
                exceptionToTest = ex;

            }
            Assert.That(exceptionToTest.Message, Is.EqualTo(string.Format(TAG.EMPLOYEE_NOT_FOUND, -1)));
        }
    }
}