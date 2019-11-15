using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieStore;
using MovieStore.Controllers;

namespace MovieStore.Tests.Controllers
{
   [TestClass]
   public class HomeControllerTest
   {
      //use debug - all tests to walk through each test. Will fail if there is a problem!

      [TestMethod]
      public void Index()
      {
         // Arrange; setup needed to operate
         HomeController controller = new HomeController();

         // Act; perform a test
         ViewResult result = controller.Index() as ViewResult;

         // Assert; checks results to what we expect
         Assert.IsNotNull(result);
      }

      [TestMethod]
      public void About()
      {
         // Arrange
         HomeController controller = new HomeController();

         // Act
         ViewResult result = controller.About() as ViewResult;

         // Assert
         Assert.AreEqual("Your application description page.", result.ViewBag.Message);
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
