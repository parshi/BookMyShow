using BookMyShow.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.DAL
{
    public interface IDALLayer
    {
        void AddMovie(Movie movie);
        void GetMovies(Movie movie);
        DataTable GetMoviesByCity(string city);
        DataTable GetMoviesDetailsByName(string movieName);
        void AddScreen(Screen screen);
        void AddUser(Register details);
        DataTable ValidateUser(Login loginDetails);
        DataTable CheckAvalibility(CheckAvalibilityRequest request);
        void BookTicket(BookingRequest request);
        void AddMovieToCinema(ScreeingRequest request);
    }
}
