using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {

    public void Dispose()
    {
      Client.ClearAll();
      Stylist.ClearAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=aj_ancheta_test;";
    }

    [TestMethod]
    public void ClientName_ReturnsName_String()
    {
      //Arrange
      string name = "Name";
      Client newClient = new Client(1, name, 808-239-0499);

      //Act
      string result = newClient.ClientName;

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      //Arrange
      string nameOne = "Name1";
      string nameTwo = "Name2";
      Client newClient1 = new Client(1, nameOne, 971-000-1212);
      newClient1.Save();
      Client newClient2 = new Client(1, nameTwo, 808-000-0000);
      newClient2.Save();
      List<Client> newList = new List<Client> { newClient1, newClient2 };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnCorrectClientFromDatabase_Client()
    {
      //Arrange
      Client testClient = new Client(1, "Name", 808-000-0000);
      testClient.Save();

      //Act
      Client selectClient = Client.Find(testClient.GetId());

      //Assert
      Assert.AreEqual(testClient, selectClient);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfClientNamesAreEqual_Client()
    {
      // Arrange, Act
      Client clientOne = new Client(1, "Name2", 808-000-0000);
      Client clientTwo = new Client(1, "Name2", 808-000-0000);

      // Assert
      Assert.AreEqual(clientOne, clientTwo);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      //Arrange
      Client testClient = new Client(1, "Name3", 808-000-0000);

      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client> {testClient};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Client testClient = new Client(1, "Name", 808-000-0000);

      //Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }
  }
}
