using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFSCarbonAppMvc4;
using NFSCarbonAppMvc4.Controllers;
using NFSCarbonAppMvc4.Models;
using NFSCarbonAppMvc4.Tests.Fakes;

namespace NFSCarbonAppMvc4.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            
            // Here's my "Message in the bottle" for the future, if I decide to 
            // come back to .NET programming
            // I Think that the problem now why this test is failing is in IQueryable using Linq in the controller code Index action
            // I believe when time comes, You will be able to fix this. 
            // For now I have other things to do with greater priorities, like styding stuff for BI.
            // Good luck! :)

            // Arrange
            var db = new FakeNFSCarbonDb();
            db.AddSet(TestData.Cars);
            HomeController controller = new HomeController(db);
 
            // Act
            ViewResult result = controller.Index() as ViewResult;
            IEnumerable<CarlistViewModel> model = result.Model as IEnumerable<CarlistViewModel>;

            // Assert
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
