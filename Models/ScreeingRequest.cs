using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyShow.Models
{
    public class ScreeingRequest
    {
        public string Movie { get; set; }
        public string Cinema { get; set; }
        public string ShowTime { get; set; }
        public string ShowDate { get; set; }
    }
}