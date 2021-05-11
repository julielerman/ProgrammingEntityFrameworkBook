﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1;
using MvcApplication1.Controllers;

namespace MvcApplication1.Tests.Controllers
{
  [TestClass]
  public class HomeControllerTest
  {
    [TestMethod]
    public void Index()
    {
      // Arrange
      HomeController controller = new HomeController();

      // Act
      ViewResult result = controller.Index() as ViewResult;

      // Assert
      ViewDataDictionary viewData = result.ViewData;
      Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
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
  }
}
