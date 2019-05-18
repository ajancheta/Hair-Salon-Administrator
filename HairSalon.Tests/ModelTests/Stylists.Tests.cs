using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {

    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
      Specialty.ClearAll();
    }

    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=aj_ancheta_test;";
    }

    [TestMethod]
    public void StylistName_ReturnsStylistName_String()
    {
      //Arrange
      string name = "Test Stylist";
      Stylist newStylist = new Stylist(name);

      //Act
      string result = newStylist.StylistName;

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetAll_ReturnsObjectsOfStylists_StylistList()
    {
      string nameOne = "Name1";
      string nameTwo = "Name2";

      Stylist newStylistOne = new Stylist(nameOne);
      newStylistOne.Save();
      Stylist newStylistTwo = new Stylist(nameTwo);
      newStylistTwo.Save();

      List<Stylist> newList = new List<Stylist> { newStylistOne, newStylistTwo };

      List<Stylist> result = Stylist.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Stylist()
    {
      Stylist stylistOne = new Stylist("Name");
      Stylist stylistTwo = new Stylist("Name");

      Assert.AreEqual(stylistOne, stylistTwo);
    }

    [TestMethod]
    public void Save_SavesStylistToDatabase_StylistList()
    {
      Stylist testStylist = new Stylist("Name");
      testStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist> {testStylist};

      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToStylist_Id()
    {
      Stylist testStylist = new Stylist("Name");
      testStylist.Save();

      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void GetClients_RetrievesAllClientsWithStylist_ClientList()
    {
      Stylist testStylist = new Stylist("Stylist Name");
      testStylist.Save();

      Client firstClient = new Client(testStylist.GetId(), "NameOne", "1");
      firstClient.Save();

      Client secondClient = new Client(testStylist.GetId(), "Name2", "1");
      secondClient.Save();
      List<Client> testClientList = new List<Client> {firstClient, secondClient};

      List<Client> resultClientList = testStylist.GetClients();

      CollectionAssert.AreEqual(testClientList, resultClientList);
    }
  }
}
