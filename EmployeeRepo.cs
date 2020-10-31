using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayrollService
{
    class EmployeeRepo
    {
        
        public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static SqlConnection connection = new SqlConnection(connectionString);
        public static DataSet GetAllEmployee()
        {
            try
            {
                var dataSet = new DataSet();
                using (connection)
                {
                    connection.Open();
                    var adapter = new SqlDataAdapter("GetEmployeeList", connection);
                    adapter.Fill(dataSet);
                    Console.WriteLine("Done");
                    connection.Close();
                    return dataSet;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
