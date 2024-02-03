using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTests
    {
        [TestMethod]
        public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
        {
            // Arrange
            Stylist newStylist = new Stylist();

            // Act

            // Assert
            Assert.AreEqual(typeof(Stylist), newStylist.GetType());
        }
    }
}