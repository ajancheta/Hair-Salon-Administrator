using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientControllerTest : IDisposable
  {

    public ClientControllerTest()
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
      ClientController controller = new ClientController();
      IActionResult view = controller.New(2);
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_ReturnsCorrectType_ActionResult()
    {
      ClientController controller = new ClientController();
      IActionResult view = controller.Show(2, 1);
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void Delete_ReturnsCorrectType_ActionResult()
    {
      ClientController controller = new ClientController();
      IActionResult view = controller.Delete(1);
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }


  }
}
