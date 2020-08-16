using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookMyShow.Controllers;
using System.Collections.Generic;
using BookMyShow.Models;
using System.Data;
using BMSUnitTestProject;

namespace BookMyShowUnitTest
{
    [TestClass]
    public class BookingControllerUnitTest
    {
        [TestMethod]
        public void GetMoviesByCity()
        {
            string cityName = "Banglore";
            MockDALLayer dllLayer = new MockDALLayer();
            var controller = new MovieController(dllLayer);
            var result = controller.GetMoviesByCity(cityName);
            Assert.IsNotNull(result.Rows);
        }

        [TestMethod]
        public void AddMovie()
        {
            Movie movieDetails = new Movie();
            movieDetails.Name = "KGF";
            MockDALLayer dllLayer = new MockDALLayer();
            var controller = new MovieController(dllLayer);
            controller.AddMovie(movieDetails);
            DataTable result = controller.GetMovieDetails(movieDetails.Name);
            Assert.IsTrue(result.Rows.Count == 1);
        }

        [TestMethod]
        public void GetMovieDetails()
        {
            string name = "KGF";
            MockDALLayer dllLayer = new MockDALLayer();
            var controller = new MovieController(dllLayer);
            DataTable result = controller.GetMovieDetails(name);
            Assert.IsTrue(result.Rows.Count == 1);
        }
    }
}
