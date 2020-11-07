using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public int DepartmentID { get; set; }
        public string EmployeeName { get; set; }
        public double Salary { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public char Gender { get; set; }
        public double BasicPay { get; set; }
        public double Deductions { get; set; }
        public double TaxablePay { get; set; }
        public double Tax { get; set; }
        public double NetPay { get; set; }
        public DateTime StartDate { get; set; }

        public void Display()
        {
            Console.WriteLine(EmployeeID + " " + EmployeeName + " " + Salary + " " + PhoneNumber + " " + Address + " " +
                Department + " " + Gender + " " + BasicPay + " " + Deductions + " " + TaxablePay + " " + Tax + " " + NetPay);
            Console.WriteLine();
        }

    }

}
