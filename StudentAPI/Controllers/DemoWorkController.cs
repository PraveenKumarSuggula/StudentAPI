using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentAPI.Controllers
{
    [RoutePrefix("Api/Students")]
    public class DemoWorkController : ApiController
    {
        //[Route("SaveEmployee")]
        [HttpGet]
        [Route("InsertStudentDetails1")]
        public HttpResponseMessage SaveEmployee(Employee employee)
        {
            string Result = "Name: " + employee.Name + " Age: " + employee.Age;

            return Request.CreateResponse(HttpStatusCode.OK, Result);
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}