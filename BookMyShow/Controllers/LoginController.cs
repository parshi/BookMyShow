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
