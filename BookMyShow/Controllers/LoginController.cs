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
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private IDALLayer _dALLayer;
        public LoginController(IDALLayer dALLayer)
        {
            _dALLayer = dALLayer;
        }

        [HttpPost]
        [Route("UserLogin")]
        public Response UserLogin([FromBody]Login loginDetails)
        {
            try
            {
                if (string.IsNullOrEmpty(loginDetails.Email) || string.IsNullOrEmpty(loginDetails.Password))
                {
                    return new Response { Status = "Fail", Message = "Email,Password are mandatory to login" };
                }
                DataTable dt = _dALLayer.ValidateUser(loginDetails);
                if (dt.Rows.Count == 0)
                {
                    return new Response { Status = "Invalid", Message = "Invalid User." };
                }
                else
                    return new Response { Status = "Success", Message = "Login Successfully" };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
