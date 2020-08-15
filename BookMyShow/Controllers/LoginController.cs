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
        [HttpPost]
        [Route("UserRegistration")]
        public Response UserRegistration([FromBody]Register details)
        {
            try
            {
                if (string.IsNullOrEmpty(details.Name) || string.IsNullOrEmpty(details.Email) || string.IsNullOrEmpty(details.Password))
                {
                    return new Response { Status = "Fail", Message = "Name,Email,Password are mandatory to register" };
                }
                DBHelper dBHelper = new DBHelper();
                dBHelper.AddUser(details);
                return new Response { Status = "Success", Message = "Record SuccessFully Saved." };
            }
            catch (Exception)
            {                
                throw;
            }
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
                DBHelper dBHelper = new DBHelper();
                DataTable dt = dBHelper.ValidateUser(loginDetails);
                if (dt.Rows.Count ==0)
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
