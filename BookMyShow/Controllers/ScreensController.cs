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
        // GET api/screens
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/screens/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/screens
        public void Post([FromBody]Screen screen)
        {
            DBHelper dBHelper = new DBHelper();
            dBHelper.AddScreen(screen);
        }

        // PUT api/screens/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/screens/5
        public void Delete(int id)
        {
        }
    }
}
