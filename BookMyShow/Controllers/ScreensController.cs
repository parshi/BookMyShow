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
    public class ScreensController : ApiController
    {
        private IDALLayer _dALLayer;
        public ScreensController(IDALLayer dALLayer)
        {
            _dALLayer = dALLayer;
        }
        [HttpPost]
        [Route("api/screens/addscreen")]
        public Response AddScreen([FromBody]Screen screen)
        {
            try
            {
                if (string.IsNullOrEmpty(screen.Name) || string.IsNullOrEmpty(screen.Location) || string.IsNullOrEmpty(screen.City) || screen.Capacity <= 0 )
                {
                    return new Response { Status = "Fail", Message = "Name,Location,City,Capacity are mandatory to addscreen" };
                }
                if(screen.GoldClass + screen.SliverClass +screen.Platinum+screen.VIP !=screen.Capacity )
                    return new Response { Status = "Fail", Message = "Capacity is not matching with seats count in classes" };
               _dALLayer.AddScreen(screen);
                return new Response { Status = "Success", Message = "SuccessFully Added." };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
