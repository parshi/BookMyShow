using BookMyShow.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSUnitTestProject
{
    class MockDALLayer:IDALLayer
    {
        public void AddMovie(BookMyShow.Models.Movie movie)
        {
            
        }

        public void GetMovies(BookMyShow.Models.Movie movie)
        {
           
        }

        public System.Data.DataTable GetMoviesByCity(string city)
        {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            return dt;
        }

        public System.Data.DataTable GetMoviesDetailsByName(string movieName)
        {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            return dt;
        }

        public void AddScreen(BookMyShow.Models.Screen screen)
        {
            
        }

        public void AddUser(BookMyShow.Models.Register details)
        {
            
        }

        public System.Data.DataTable ValidateUser(BookMyShow.Models.Login loginDetails)
        {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            return dt;
        }

        public System.Data.DataTable CheckAvalibility(BookMyShow.Models.CheckAvalibilityRequest request)
        {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            return dt;
        }

        public void BookTicket(BookMyShow.Models.BookingRequest request)
        {
            
        }

        public void AddMovieToCinema(BookMyShow.Models.ScreeingRequest request)
        {
           
        }
    }
}
