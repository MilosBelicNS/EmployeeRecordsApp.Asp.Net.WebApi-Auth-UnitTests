using EmployeeRecordsApp.Asp.NetWebApi.Controllers;
using EmployeeRecordsApp.Asp.NetWebApi.Interfaces;
using EmployeeRecordsApp.Asp.NetWebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace EmployeeRecordsApp.Asp.NetWebApi.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void GetReturnsEmploedWithSameId()
        {
            // Arrange
            var mockRepository = new Mock<IEmployedRepository>();
            mockRepository.Setup(x => x.GetById(42)).Returns(new Employed { Id = 42 });

            var controller = new EmployeeController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.GetById(42);
            var contentResult = actionResult as OkNegotiatedContentResult<Employed>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(42, contentResult.Content.Id);
        }

        [TestMethod]
        public void PutReturnsBadRequest()
        {
            // Arrange
            var mockRepository = new Mock<IEmployedRepository>();
            var controller = new EmployeeController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Put(10, new Employed { Id = 9, Name = "Employed2" });

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }


        [TestMethod]
        public void GetReturnsMultipleObjects()
        {
            // Arrange
            List<Employed> employee = new List<Employed>();
            employee.Add(new Employed { Id = 1, Name = "Employed1" });
            employee.Add(new Employed { Id = 2, Name = "Employed2" });

            var mockRepository = new Mock<IEmployedRepository>();
            mockRepository.Setup(x => x.GetAll()).Returns(employee.AsEnumerable());
            var controller = new EmployeeController(mockRepository.Object);

            // Act
            IEnumerable<Employed> result = controller.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employee.Count, result.ToList().Count);
            Assert.AreEqual(employee.ElementAt(0), result.ElementAt(0));
            Assert.AreEqual(employee.ElementAt(1), result.ElementAt(1));
        }
    }
}
