using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True");
        }

        public int UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection SalaryConnection = ConnectionSetup();
            int salary = 0;
            try
            {
                using (SalaryConnection)
                {
                    SalaryDetailModel displayModel = new SalaryDetailModel();
                    SqlCommand command = new SqlCommand("spUpdateEmployeeSalary", SalaryConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    var cmd = new SqlCommand("Select Id from Employee where Name='Terissa'", SalaryConnection);
                    SalaryConnection.Open();

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                        salaryUpdateModel.SalaryId = Convert.ToInt32(reader.GetInt32(0));
                reader.Close();
                    command.Parameters.AddWithValue("@id", salaryUpdateModel.SalaryId);
                    command.Parameters.AddWithValue("@salary", salaryUpdateModel.EmployeeSalary);
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModel.EmployeeId = Convert.ToInt32(dr["Id"]);
                            displayModel.EmployeeName = dr["Name"].ToString();
                            displayModel.EmployeeSalary = Convert.ToInt32(dr["Salary"]);
                            Console.WriteLine( displayModel.EmployeeId+" "+displayModel.EmployeeName + " " + displayModel.EmployeeSalary);
                            Console.WriteLine("\n");
                            salary = displayModel.EmployeeSalary;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                }
            return salary;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
        }
    }

}
