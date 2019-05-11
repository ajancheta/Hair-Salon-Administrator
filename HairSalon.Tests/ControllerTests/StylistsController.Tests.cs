using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistControllerTest : IDisposable
  {

    public StylistControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=aj_ancheta_test;";
    }

    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
    }

    [TestMethod]
    public void New_ReturnsCorrectType_True()
    {
      StylistController controller = new StylistController();
      IActionResult view = controller.New();
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      StylistController controller = new StylistController();

      IActionResult view = controller.New();

      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }
  }
}
