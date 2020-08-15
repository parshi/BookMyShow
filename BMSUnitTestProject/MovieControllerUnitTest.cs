using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookMyShow.Controllers;
using System.Collections.Generic;
using BookMyShow.Models;
using System.Data;

namespace BookMyShowUnitTest
{
    [TestClass]
    public class BookingControllerUnitTest
    {
        [TestMethod]
        public void GetMoviesByCity()
        {
            string cityName = "Banglore";
            var controller = new MovieController();
            var result = controller.GetMoviesByCity(cityName);
            Assert.IsNotNull(result.Rows);
        }

        [TestMethod]
        public void AddMovie()
        {
            Movie movieDetails = new Movie();
            movieDetails.Name = "KGF";
            var controller = new MovieController();
            controller.AddMovie(movieDetails);
            DataTable result = controller.GetMovieDetails(movieDetails.Name);
            Assert.IsTrue(result.Rows.Count == 1);
        }

        [TestMethod]
        public void GetMovieDetails()
        {
            string name = "KGF";
            var controller = new MovieController();
            DataTable result = controller.GetMovieDetails(name);
            Assert.IsTrue(result.Rows.Count == 1);
        }
    }
}
