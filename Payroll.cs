using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    class Payroll
    {
        public int Id { get; set; }
        public float salary { get; set; }
        public float basicPay { get; set; }
        public float TaxablePay { get; set; }
        public float Tax { get; set; }
        public float NetPay { get; set; }
    }
}
