using System;

using ExpWebApp.Controllers;

using NUnit.Framework;

namespace ExpNUnitTests
{
    public class CalculateTests
    {
        private CalculateController calcController;
        private DateTime myOriginalDate;

        [SetUp]
        public void Setup()
        {
            // ARRANGE
            calcController = new CalculateController();

        }

        [Test]
        public void Adding_Days_To_Date_Returns_New_Date()

        {
            // ARRANGE
            myOriginalDate = new DateTime(2021, 11, 16);

            // ACT
            DateTime myNewDate = calcController.CalcNewDate(myOriginalDate, 15);

            // ASSERT
            Assert.AreEqual(myOriginalDate.AddDays(15), myNewDate);
        }

    }
}