using EmployeePayrollService;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollServiceTests
{
    [TestFixture]
    public class SalaryTest
    {
        [Test]
        public void GivenSalaryDataAbleToUpdateSalaryDetails()
        {
            Salary salary = new Salary();
            SalaryUpdateModel updateModel = new SalaryUpdateModel()
            {
                SalaryId = 2,
                Month = "Jan",
                EmployeeSalary = 1300,
                EmployeeId = 5
            };

            int EmpSalary = salary.UpdateEmployeeSalary(updateModel);

            Assert.AreEqual(updateModel.EmployeeSalary, EmpSalary);
        }
    }

}
