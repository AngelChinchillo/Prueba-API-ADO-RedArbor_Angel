using NUnit.Framework;
using RedArbor.Helper;
using RedArbor.Services;
using System;
using System.Linq;

namespace RedArborTest
{
    public class PostEmployeeTest
    {

        [TestCase(
            "{\"" +
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
        public void PostEmployeeSuccesfully(object serializedEployee)
        {
            Exception exceptionToTest = null;
            try
            {
                PostEmployeeService em = new PostEmployeeService(new EmployeeServiceMock());
                var result = em.InsertEmployee(serializedEployee);
            }
            catch (Exception ex)
            {
                exceptionToTest = ex;

            }
            Assert.IsNull(exceptionToTest);
        }
        
        [Test]
        [TestCase(
            "{\"" +
            "CompanyId\":1" +
            ",\"CreatedOn\":\"2000-01-01 00:00:00\"," +
            "\"DeletedOn\":\"2000-01-01 00:00:00\"" +
            ",\"Email\":\"test1@test.test.tmp\"" +
            ",\"Fax\":\"000.000.000\"" +
            ",\"Name\":\"test1\"" +
            ",\"Password\":\"test\"" +
            ",\"PortalId\":1" +
            ",\"RoleId\":1" +
            ",\"StatusId\":1" +
            ",\"Telephone\":\"000.000.000\"" +
            ",\"UpdatedOn\":\"2000-01-01 00:00:00\"" +
            ",\"Username\":\"test1" +
            "\"}"
        )]
        public void PostEmployeeTestRequiredProperty(object serializedEployee)
        {
            Exception exceptionToTest = null;
            try
            {
                PostEmployeeService em = new PostEmployeeService(new EmployeeServiceMock());
                var result = em.InsertEmployee(serializedEployee);
            }
            catch (Exception ex)
            {
                exceptionToTest = ex;

            }
            Assert.That(exceptionToTest.Message, Does.Contain("Required property"));
        }
    }
}