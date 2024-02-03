using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Linq;

[TestClass]
public class StylistTests : DbFixture
{
    [TestMethod]
    public void CanAddStylistToDatabase()
    {
        // Arrange
        var stylist = new Stylist { Name = "Test Stylist", Specialty = "Test Specialty" };

        // Act
        DbContext.Stylists.Add(stylist);
        DbContext.SaveChanges();

        // Assert
        Assert.AreEqual(1, DbContext.Stylists.Count());
        Assert.AreEqual("Test Stylist", DbContext.Stylists.Single().Name);
    }
}