using BookMyShow.DAL;
using BookMyShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookMyShow.Controllers
{
    public class ScreeningController : ApiController
    {
        [HttpPost]
        [Route("api/screening/addmovietocinema")]
        public Response AddMovieToCinema([FromBody]ScreeingRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Movie) || string.IsNullOrEmpty(request.Cinema) || string.IsNullOrEmpty(request.ShowDate) || string.IsNullOrEmpty(request.ShowTime))
                {
                    return new Response { Status = "Fail", Message = "Movie,Cinema,ShowTime,ShowDate are mandatory to register" };
                }
                DBHelper dBHelper = new DBHelper();
                dBHelper.AddMovieToCinema(request);
                return new Response { Status = "Success", Message = "Added SuccessFully." };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
