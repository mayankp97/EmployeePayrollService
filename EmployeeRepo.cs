using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayrollService
{
    class EmployeeRepo
    {
        
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static SqlConnection connection = new SqlConnection(connectionString);
        public static void GetAllEmployee()
        {
            //try
            //{
                var employeeModel = new EmployeeModel();
                using (connection)
                {
                    var query = @"Select * from employee_payroll";
                    var sqlCommand = new SqlCommand(query, connection);
                    connection.Open();
                    var dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            employeeModel.EmployeeID = dataReader.GetInt32(0);
                            employeeModel.EmployeeName = dataReader.GetString(1);
                            employeeModel.Salary = dataReader.GetInt32(2);
                            employeeModel.StartDate = dataReader.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dataReader.GetString(4));
                            employeeModel.PhoneNumber = dataReader.GetString(5);
                            employeeModel.Address = dataReader.GetString(6);
                            employeeModel.Department = dataReader.GetString(7);
                            employeeModel.BasicPay = dataReader.GetInt32(8);
                            employeeModel.TaxablePay = dataReader.GetInt32(9);
                            employeeModel.Tax = dataReader.GetInt32(10);
                            employeeModel.NetPay = dataReader.GetInt32(11);
                            employeeModel.Display();

                        }
                    }
                    else
                        Console.WriteLine("No Data Found");
                    
                }
            //}
            //catch(Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //finally
            //{
            //    connection.Close();
            //}
        }
    }
}
