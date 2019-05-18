using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {
    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=aj_ancheta_test;";
    }

    public void Dispose()
    {
      Specialty.ClearAll();
      Client.ClearAll();
      Specialty.ClearAll();
    }

    [TestMethod]
    public void SpecialtyName_ReturnsSpecialtyName_String()
    {
      string name = "Test Specialty";
      Specialty newSpecialty = new Specialty(name);
      string result = newSpecialty.SpecialtyName;
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetAll_ReturnsObjectsOfSpecialties_SpecialtyList()
    {
      string nameOne = "Name1";
      string nameTwo = "Name2";

      Specialty newSpecialtyOne = new Specialty(nameOne);
      newSpecialtyOne.Save();
      Specialty newSpecialtyTwo = new Specialty(nameTwo);
      newSpecialtyTwo.Save();

      List<Specialty> newList = new List<Specialty> { newSpecialtyOne, newSpecialtyTwo };

      List<Specialty> result = Specialty.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Specialty()
    {
      Specialty stylistOne = new Specialty("Name");
      Specialty stylistTwo = new Specialty("Name");

      Assert.AreEqual(stylistOne, stylistTwo);
    }

    [TestMethod]
    public void Save_SavesSpecialtyToDatabase_SpecialtyList()
    {
      Specialty testSpecialty = new Specialty("Name");
      testSpecialty.Save();

      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty> {testSpecialty};

      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToSpecialty_Id()
    {
      Specialty testSpecialty = new Specialty("Name");
      testSpecialty.Save();

      Specialty savedSpecialty = Specialty.GetAll()[0];

      int result = savedSpecialty.GetId();
      int testId = testSpecialty.GetId();

      Assert.AreEqual(testId, result);
    }
  }
}
