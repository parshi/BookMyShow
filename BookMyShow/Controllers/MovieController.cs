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
        [Route("api/movie/getmoviebycity/{city}")]
        public List<string> GetMoviesByCity(string city)
        {
            DBHelper dBHelper = new DBHelper();
            List<string> movies = new List<string>();
            DataTable dt = dBHelper.GetMoviesByCity(city);
            movies = dt.AsEnumerable().Select(x => Convert.ToString(x["Name"])).ToList();
            return movies;
        }

        [HttpGet]
        [Route("api/movie/getmoviedetails/{movie}")]
        public DataTable GetMovieDetails(string movie)
        {
            DBHelper dBHelper = new DBHelper();
            DataTable dt = dBHelper.GetMoviesDetailsByName(movie);
            return dt;
        }

        // POST api/movie
        public void Post([FromBody]Movie movie)
        {
            DBHelper dBHelper = new DBHelper();
            dBHelper.AddMovie(movie);
        }

        // PUT api/movie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/movie/5
        public void Delete(int id)
        {
        }
    }
}
