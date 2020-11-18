using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            //Assert.AreEqual(dataResponse.Count, 4);
            foreach (var employee in dataResponse)
                Console.WriteLine("Id : {0}, Name : {1}, Salary : {2}", employee.Id, employee.Name, employee.Salary);


        }
        [Test]
        public void GivenEmployee_OnPost_RetrunsTheAddedEmployee()
        {
            var request = new RestRequest("/employees", Method.POST);
            var employee = new Employee { Name = "Mr. Potato", Salary = "80000" };

            var jObjectBody = new JObject();
            jObjectBody.Add("name", employee.Name);
            jObjectBody.Add("salary", employee.Salary);
            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);

            var response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            var dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual(employee.Name, dataResponse.Name);
            Assert.AreEqual(employee.Salary, dataResponse.Salary);
        }
        [Test]
        public void GivenEmloyeeList_OnGet_ReturnsTheAddedEmployees()
        {
            var employees = new List<Employee> {new Employee { Name = "Mr. Tomato", Salary = "80000" },
                new Employee { Name = "Mr. Brinjal", Salary = "80000" } };
            foreach (var employee in employees)
            {


                var request = new RestRequest("/employees", Method.POST);


                var jObjectBody = new JObject();
                jObjectBody.Add("name", employee.Name);
                jObjectBody.Add("salary", employee.Salary);
                request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);

                var response = client.Execute(request);

                Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
                var dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
                Assert.AreEqual(employee.Name, dataResponse.Name);
                Assert.AreEqual(employee.Salary, dataResponse.Salary);
            }
        }
        [Test]
        public void GivenEmployee_OnUpdate_ReturnsTheUpdatedEmployee()
        {
            var request = new RestRequest("employees/5", Method.PUT);

            var jObjectBody = new JObject();
            jObjectBody.Add("name", "Lisa");
            jObjectBody.Add("salary", "0");
            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);

            var response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            var dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("0", dataResponse.Salary);
        }
        [Test]
        public void GivenID_OnDelete_ReturnsSuccessStatus()
        {
            var request = new RestRequest("employees/5", Method.DELETE);

            var response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }
    }
}
