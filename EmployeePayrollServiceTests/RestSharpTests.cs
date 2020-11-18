using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace EmployeePayrollServiceTests
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
    }
    [TestFixture]
    class RestSharpTests
    {
        RestClient client;
        [SetUp]
        public void SetUp()
        {
            client = new RestClient("http://localhost:4000");
        }
        private IRestResponse GetAllEmployees()
        {
            var request = new RestRequest("/employees", Method.GET);

            var response = client.Execute(request);

            return response;
        }

        [Test]
        public void GivenUrl_OnGet_ReturnsEmployees()
        {
            var response = GetAllEmployees();

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            var dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(dataResponse.Count, 4);
            foreach (var employee in dataResponse)
                Console.WriteLine("Id : {0}, Name : {1}, Salary : {2}", employee.Id, employee.Name, employee.Salary);


        }
    }
}
