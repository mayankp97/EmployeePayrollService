using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Service!");

            //EmployeeRepo.GetAllEmployee();
            var salaryUpdateModel = new SalaryUpdateModel { SalaryId = 1, EmployeeSalary = 75001 };
            var salaryObj = new Salary();
            var salary = salaryObj.UpdateEmployeeSalary(salaryUpdateModel);
            Console.WriteLine(salary);
        }
    }
}
