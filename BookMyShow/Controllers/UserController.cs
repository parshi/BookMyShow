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
    public class UserController : ApiController
    {
        private IDALLayer _dALLayer;
        public UserController(IDALLayer dALLayer)
        {
            _dALLayer = dALLayer;
        }
        [HttpPost]
        [Route("api/user/register")]
        public Response UserRegistration([FromBody]Register details)
        {
            try
            {
                if (string.IsNullOrEmpty(details.Name) || string.IsNullOrEmpty(details.Email) || string.IsNullOrEmpty(details.Password))
                {
                    return new Response { Status = "Fail", Message = "Name,Email,Password are mandatory to register" };
                }
                _dALLayer.AddUser(details);
                return new Response { Status = "Success", Message = "Record SuccessFully Saved." };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
