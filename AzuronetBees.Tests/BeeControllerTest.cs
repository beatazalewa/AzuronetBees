using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AzuronetBees.Web.Controllers;
using AzuronetBees.Web.Models;
using AzuronetBees.Web.Repositories;
using AzuronetBees.Tests.FakeRepositories;

namespace AzuronetBees.Tests
{
    [TestClass]
    public class BeeControllerTest
    {
        [TestMethod]
        public void IndexModelShouldContainAllBees()
        {
            // Arrange
            IBeeRepository fakeBeeRepository = new FakeBeeRepository();
            BeeController beeController = new BeeController(fakeBeeRepository);
            // Act
            ViewResult viewResult = beeController.Index() as ViewResult;
            List<Bee> bees = viewResult.Model as List<Bee>;
            // Assert
            Assert.AreEqual(bees.Count, 4);
        }
    }
}
