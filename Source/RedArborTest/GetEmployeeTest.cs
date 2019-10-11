using NUnit.Framework;
using RedArbor.Helper;
using RedArbor.Models;
using RedArbor.Services;
using System;
using System.Linq;

namespace RedArborTest
{
    public class GetEmployeeTest
    {

        [TestCase(-3)]
        [TestCase(-4)]
        [TestCase(-5)]
        [Test]
        public void GetEmployeeRurnsNullIfNotFound(int id)
        {
            GetEmployeeService em = new GetEmployeeService(new EmployeeServiceMock());
            var result = em.GetEmployee(id);

            Assert.IsNull(result);
        }

        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [Test]
        public void GetEmployee(int id)
        {

            GetEmployeeService em = new GetEmployeeService(new EmployeeServiceMock());
            var result = em.GetEmployee(id);

            Assert.IsNotNull(result);
        }
    }
}