using NUnit.Framework;
using RedArbor.Services;
using System;
using System.Linq;

namespace RedArborTest
{
    public class PutEmployeeTest
    {

        [TestCase(1,"{\"" +
                    "CompanyId\":1" +
                    ",\"CreatedOn\":\"2000-01-01 00:00:00\"," +
                    "\"DeletedOn\":\"2000-01-01 00:00:00\"" +
                    ",\"Email\":\"test1@test.test.tmp\"" +
                    ",\"Fax\":\"000.000.000\"" +
                    ",\"Name\":\"test1\"" +
                    ",\"Lastlogin\":\"2000-01-01 00:00:00\"" +
                    ",\"Password\":\"test\"" +
                    ",\"PortalId\":1" +
                    ",\"RoleId\":1" +
                    ",\"StatusId\":1" +
                    ",\"Telephone\":\"000.000.000\"" +
                    ",\"UpdatedOn\":\"2000-01-01 00:00:00\"" +
                    ",\"Username\":\"test1" +
                    "\"}"
        )]
        [Test]
        public void PutEmployee(int employeeID, object serializedEployee)
        {
            Exception exceptionToTest = null;
            try
            {
                PutEmployeeService em = new PutEmployeeService(new EmployeeServiceMock());
            em.PutEmployee(employeeID, serializedEployee);
            }
            catch (Exception ex)
            {
                exceptionToTest = ex;

            }
            Assert.IsNull(exceptionToTest);
        }

        [TestCase(1, "{" +
             "\"CreatedOn\":\"2000-01-01 00:00:00\"," +
             "\"DeletedOn\":\"2000-01-01 00:00:00\"" +
             ",\"Email\":\"test1@test.test.tmp\"" +
             ",\"Fax\":\"000.000.000\"" +
             ",\"Name\":\"test1\"" +
             ",\"Lastlogin\":\"2000-01-01 00:00:00\"" +
             ",\"Password\":\"test\"" +
             ",\"PortalId\":1" +
             ",\"RoleId\":1" +
             ",\"StatusId\":1" +
             ",\"Telephone\":\"000.000.000\"" +
             ",\"UpdatedOn\":\"2000-01-01 00:00:00\"" +
             ",\"Username\":\"test1" +
             "\"}"
            )]
        [Test]
        public void PutEmployeePropertyRequired(int employeeID, object serializedEployee)
        {
            Exception exceptionToTest = null;
            try
            {
                PutEmployeeService em = new PutEmployeeService(new EmployeeServiceMock());
                em.PutEmployee(employeeID, serializedEployee);
            }
            catch (Exception ex)
            {
                exceptionToTest = ex;
            }
            Assert.That(exceptionToTest.Message, Does.Contain("Required property"));
        }
    }
}