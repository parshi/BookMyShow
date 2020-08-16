using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookMyShow.Controllers;
using BookMyShow.Models;

namespace BMSUnitTestProject
{
    [TestClass]
    public class BookingUnitTests
    {
        [TestMethod]
        public void CheckAvalibilityTest()
        {
            CheckAvalibilityRequest avalibityRequest = new CheckAvalibilityRequest()
            {
                MovieName = "KGF",
                Cinema = "Mega Multiplex",
                Location = "Marthalli",
                City = "Banglore",
                ShowTime = "11:00 AM",
            };
            MockDALLayer dllLayer = new MockDALLayer();
            var controller = new BookingController(dllLayer);
            CheckAvalibilityResponse result = controller.CheckAvalibility(avalibityRequest);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CheckAvalibilityTestForWrongMovie()
        {
            CheckAvalibilityRequest avalibityRequest = new CheckAvalibilityRequest()
            {
                MovieName = "KGF456",
                Cinema = "Mega Multiplex",
                Location = "Marthalli",
                City = "Banglore",
                ShowTime = "11:00 AM",
            };
            MockDALLayer dllLayer = new MockDALLayer();
            var controller = new BookingController(dllLayer);
            CheckAvalibilityResponse result = controller.CheckAvalibility(avalibityRequest);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void BookingTestPositive()
        {
            BookingRequest request = new BookingRequest()
            {
                MovieName = "KGF",
                Cinema = "Mega Multiplex",
                Location = "Marthalli",
                City = "Banglore",
                ShowTime = "11:00 AM",
                NumberOfTickets = 10,
                Class = "GoldClass"
            };
            MockDALLayer dllLayer = new MockDALLayer();
            var controller = new BookingController(dllLayer);
            var response = controller.Booking(request);
            Response expected = new Response { Status = "Success", Message = "Booking Successfull" };
            Assert.AreEqual(response,expected);
        }

        [TestMethod]
        public void BookingTestFroNumberOfTickets()
        {
            BookingRequest request = new BookingRequest()
            {
                MovieName = "KGF",
                Cinema = "Mega Multiplex",
                Location = "Marthalli",
                City = "Banglore",
                ShowTime = "11:00 AM",
                NumberOfTickets = 1000,
                Class = "GoldClass"
            };
            MockDALLayer dllLayer = new MockDALLayer();
            var controller = new BookingController(dllLayer);
            var response = controller.Booking(request);
            Response expected = new Response { Status = "Fail", Message = "Select proper seating class" };
            Assert.AreEqual(response, expected);
        }
    }
}
