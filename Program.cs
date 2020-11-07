using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Service!");

            //EmployeeRepo.GetAllEmployee();
            //var salaryUpdateModel = new SalaryUpdateModel { SalaryId = 1, EmployeeSalary = 30000000 };
            //var salaryObj = new Salary();
            //var salary = salaryObj.UpdateEmployeeSalary(salaryUpdateModel);
            //Console.WriteLine(salary);
            /*
            var startDate = Convert.ToDateTime("01/01/2018");
            var endDate = Convert.ToDateTime("01/01/2019");

            EmployeeRepo.GetAllEmployeeInDateRange(startDate, endDate);
            */
            //EmployeeRepo.ExecuteAggregateFunctions();
            var empModel = new EmployeeModel { EmployeeName = "Iron Man", Salary = 1000000,Gender='M',PhoneNumber="5454545",
                                                StartDate=Convert.ToDateTime("01/01/2019"),Address="In the sky full of starts",Department="Legal"};
            var employeePayroll = new EmployeePayroll { employeeModel = empModel};
            EmployeeRepo.AddEmployee(employeePayroll);
        }
    }
}
