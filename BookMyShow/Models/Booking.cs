using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyShow.Models
{
    public class BookingRequest
    {
        public string MovieName { get; set; }
        public string Cinema { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string ShowTime { get; set; }
        public int NumberOfTickets { get; set; }
        public string Class { get; set; }
    }
}