using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EmployeePayrollService
{
	class EmployeeRepo
	{

		public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		public static SqlConnection connection = new SqlConnection(connectionString);

		public static void SetConnection()
		{
			connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			connection = new SqlConnection(connectionString);
		}

		public static List<EmployeePayroll> employeePayrolls;
		public static void GetAllEmployee()
		{
			employeePayrolls = new List<EmployeePayroll>();
			try
			{
				
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
							var employeePayroll = new EmployeePayroll();
							var employeeModel = employeePayroll.employeeModel;
							employeeModel.EmployeeID = dataReader.GetInt32(0);
							employeeModel.EmployeeName = dataReader.GetString(1);
							employeeModel.StartDate = dataReader.GetDateTime(6);
							employeeModel.Gender = Convert.ToChar(dataReader.GetString(5));
							employeeModel.PhoneNumber = dataReader.GetString(3);
							employeeModel.Address = dataReader.GetString(2);
							employeeModel.Salary = dataReader.GetDouble(10);
							employeeModel.BasicPay = dataReader.GetDouble(11);
							employeeModel.TaxablePay = dataReader.GetDouble(13);
							employeeModel.Tax = dataReader.GetDouble(14);
							employeeModel.NetPay = dataReader.GetDouble(14);

							employeeModel.Display();
							employeePayrolls.Add(employeePayroll);
						}
					}
					else
						Console.WriteLine("No Data Found");
					dataReader.Close();
					connection.Close();

				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
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
					var query = @"Select * from Employee Inner Join Payroll On Employee.Id = Payroll.Id where StartDate > @startDate AND StartDate < @endDate";
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

		public static void ExecuteAggregateFunctions()
		{
			try
			{
				var employeeModel = new EmployeeModel();
				var query = @"SELECT  COUNT(*) AS number_of_males,
									AVG(salary) AS avg_salary,
									MIN(salary) AS min_salary,
									MAX(salary) AS max_salary
									from Employee Inner Join Payroll On Employee.Id = Payroll.Id
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
						Console.WriteLine("Average Salary : {0}", reader.GetDouble(1));
						Console.WriteLine("Minimum Salary : {0}", reader.GetDouble(2));
						Console.WriteLine("Maximum Salary : {0}", reader.GetDouble(3));

					}
				}

				else
					Console.WriteLine("Data Not Found");
				connection.Close();
			}
			catch (Exception e)
			{

				Console.WriteLine(e.StackTrace);
				throw new Exception(e.Message);
			}
			finally
			{
				connection.Close();
			}
		}

		public static void AddMultipleEmployees(List<EmployeePayroll> employeePayrolls)
		{
			var startTime = DateTime.Now;
			foreach (var employeePayroll in employeePayrolls)
				AddEmployee(employeePayroll);
			var endTime = DateTime.Now;
			Console.WriteLine("Time taken : {0}", endTime - startTime);
		}

		public static void AddEmployee(EmployeePayroll employeePayroll)
		{
			var updatedEmployeePayroll = new EmployeePayroll();
			try
			{
				SetConnection();
				var sqlCommand = new SqlCommand("SpAddEmployeeDetails", connection);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.AddWithValue("@EmployeeName", employeePayroll.employeeModel.EmployeeName);
				sqlCommand.Parameters.AddWithValue("@Salary", (float)employeePayroll.employeeModel.Salary);
				sqlCommand.Parameters.AddWithValue("@StartDate", employeePayroll.employeeModel.StartDate);
				sqlCommand.Parameters.AddWithValue("@Gender", employeePayroll.employeeModel.Gender);
				sqlCommand.Parameters.AddWithValue("@PhoneNumber", employeePayroll.employeeModel.PhoneNumber);
				sqlCommand.Parameters.AddWithValue("@Address", employeePayroll.employeeModel.Address);
				sqlCommand.Parameters.AddWithValue("@Department", employeePayroll.employeeModel.Department);
				connection.Open();
				var reader = sqlCommand.ExecuteReader();
				if (reader.Read())
				{

					var model = new EmployeeModel { EmployeeName = reader.GetString(1) };
					updatedEmployeePayroll.employeeModel = model;
					Console.WriteLine("Employee {0} Added Successfully.", updatedEmployeePayroll.employeeModel.EmployeeName);
				}

			}
			catch (Exception e)
			{

				Console.WriteLine(e.StackTrace);
				throw new Exception(e.Message);
			}
			finally
			{
				connection.Close();
			}
		}
		public static void RemoveEmployee(int Id)
		{
			SetConnection();
			var emp = employeePayrolls.Where(e => e.employeeModel.EmployeeID==Id).ToList()[0];
			employeePayrolls.Remove(emp);
			try
			{
				using (connection)
				{
					var query = @"Update Employee Set Is_Active = 0 where Id = @Id";
					var sqlCommand = new SqlCommand(query, connection);
					sqlCommand.Parameters.AddWithValue("@Id", Id);
					connection.Open();
					sqlCommand.ExecuteNonQuery();
					Console.WriteLine("Employee Deleted");
					connection.Close();
				}
			}
			catch (Exception e)
			{

				Console.WriteLine(e.StackTrace);
				throw new Exception(e.Message);
			}
		}

	}
}
