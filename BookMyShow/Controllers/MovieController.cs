using BookMyShow.DAL;
using BookMyShow.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookMyShow.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        [Route("api/movie/getmoviesbycity/{city}")]
        public DataTable GetMoviesByCity(string city)
        {
            try
            {
                ValidateParamPassedInURL(city);
                List<string> movies = new List<string>();
                DBHelper dBHelper = new DBHelper();               
                DataTable dt = dBHelper.GetMoviesByCity(city);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateParamPassedInURL(string city)
        {
            string Invalid = "(ALTER|CREATE|DELETE|DROP|EXEC(UTE){0,1}|INSERT( +INTO){0,1}|MERGE|SELECT|UPDATE|UNION( +ALL){0,1})";
            if (Invalid.Contains(city))
                throw new Exception("provide proper search key");
        }

        [HttpGet]
        [Route("api/movie/getmoviedetails/{movie}")]
        public DataTable GetMovieDetails(string movie)
        {
            try
            {
                ValidateParamPassedInURL(movie);
                DBHelper dBHelper = new DBHelper();
                DataTable dt = dBHelper.GetMoviesDetailsByName(movie);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/movie/addmovie")]
        public void AddMovie([FromBody]Movie movie)
        {
            try
            {
                if (string.IsNullOrEmpty(movie.Name))
                {
                    throw new Exception("movie name is mandatory to addmovie");
                }
                DBHelper dBHelper = new DBHelper();
                dBHelper.AddMovie(movie);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
