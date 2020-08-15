using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyShow.Models
{
    public class CheckAvalibilityRequest
    {
        public string MovieName { get; set; }
        public string Cinema { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string ShowTime { get; set; }
    }
     public class CheckAvalibilityResponse
     {
         public int SliverClass { get; set; }
         public int GoldClass { get; set; }
         public int PlatinumClass { get; set; }
         public int VIP { get; set; }
         public int Avaliable { get; set; }
     }
}