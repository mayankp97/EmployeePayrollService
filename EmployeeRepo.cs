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
            try
            {
                var employeeModel = new EmployeeModel();
                using (connection)
                {
                    var query = @"SELECT *
                                    FROM [dbo].[Employee] AS emp INNER JOIN [dbo].[Payroll] AS pay
                                    ON emp.Id = pay.Id";
                    var sqlCommand = new SqlCommand(query, connection);
                    connection.Open();
                    var dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            employeeModel.EmployeeID = dataReader.GetInt32(0);
                            employeeModel.EmployeeName = dataReader.GetString(1);
                            employeeModel.StartDate = dataReader.GetDateTime(6);
                            employeeModel.Gender = Convert.ToChar(dataReader.GetString(5));
                            employeeModel.PhoneNumber = dataReader.GetString(3);
                            employeeModel.Address = dataReader.GetString(2);
                            employeeModel.Salary = dataReader.GetDouble(8);
                            employeeModel.BasicPay = dataReader.GetDouble(9);
                            employeeModel.TaxablePay = dataReader.GetDouble(11);
                            employeeModel.Tax = dataReader.GetDouble(12);
                            employeeModel.NetPay = dataReader.GetDouble(13);
                            employeeModel.Display();

                        }
                    }
                    else
                        Console.WriteLine("No Data Found");

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void GetAllEmployeeInDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                var employeeModel = new EmployeeModel();
                using (connection)
                {
                    var query = @"Select * from employee_payroll where start_date > @startDate AND start_date < @endDate";
                    var sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@startDate", startDate);
                    sqlCommand.Parameters.AddWithValue("@endDate", endDate);

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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void ExecuteAggregateFunctions()
        {
            try
            {
                var employeeModel = new EmployeeModel();
                var query = @"SELECT  COUNT(*) AS number_of_males,
		                            AVG(salary) AS avg_salary,
		                            MIN(salary) AS min_salary,
		                            MAX(salary) AS max_salary
                                    FROM [dbo].[employee_payroll]
                                    WHERE [gender] = 'M' 
                                    GROUP BY [gender]";
                var sqlCommand = new SqlCommand(query, connection);
                connection.Open();
                var reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Number of males : {0}", reader.GetInt32(0));
                        Console.WriteLine("Average Salary : {0}", reader.GetInt32(1));
                        Console.WriteLine("Minimum Salary : {0}", reader.GetInt32(2));
                        Console.WriteLine("Maximum Salary : {0}", reader.GetInt32(3));

                    }
                }

                else
                    Console.WriteLine("Data Not Found");
                connection.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
