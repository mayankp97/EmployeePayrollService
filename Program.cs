using System;
using System.Collections.Generic;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Service!");

            EmployeeRepo.GetAllEmployee();
            //var salaryUpdateModel = new SalaryUpdateModel { SalaryId = 1, EmployeeSalary = 30000000 };
            //var salaryObj = new Salary();
            //var salary = salaryObj.UpdateEmployeeSalary(salaryUpdateModel);
            //Console.WriteLine(salary);
            /*
            //Retreiving Employees In a date range
            var startDate = Convert.ToDateTime("01/01/2018");
            var endDate = Convert.ToDateTime("01/01/2019");

            EmployeeRepo.GetAllEmployeeInDateRange(startDate, endDate);
            */
            //EmployeeRepo.ExecuteAggregateFunctions();
            /*
            //Adding employee with stored procedure
            var empModel = new EmployeeModel { EmployeeName = "Iron Man", Salary = 1300,Gender='M',PhoneNumber="5454545",
                                                StartDate=Convert.ToDateTime("01/01/2019"),Address="In the sky full of starts",Department="Legal"};
            var employeePayroll = new EmployeePayroll { employeeModel = empModel};
            EmployeeRepo.AddEmployee(employeePayroll);
            */
            /*
            //Removing an employee
            EmployeeRepo.RemoveEmployee(5);
            */


            
            //Adding Multiple Employees
            var employees = new List<EmployeePayroll> {new EmployeePayroll { employeeModel = new EmployeeModel { EmployeeName = "Steel Man", Salary = 1000000,Gender='M',PhoneNumber="5454545",
                                                StartDate=Convert.ToDateTime("01/01/2019"),Address="In the sky full of starts",Department="Legal"} },
                                                new EmployeePayroll { employeeModel = new EmployeeModel { EmployeeName = "Copper Man", Salary = 1000000,Gender='M',PhoneNumber="5454545",
                                                StartDate=Convert.ToDateTime("01/01/2019"),Address="In the sky full of starts",Department="Legal"} },
                                                new EmployeePayroll { employeeModel = new EmployeeModel { EmployeeName = "Aluminium Man", Salary = 1000000,Gender='M',PhoneNumber="5454545",
                                                StartDate=Convert.ToDateTime("01/01/2019"),Address="In the sky full of starts",Department="Legal"} } };
            EmployeeRepo.AddMultipleEmployees(employees);
            EmployeeRepo.AddMultipleEmployeesUsingThreads(employees);
            

        }
    }
}
