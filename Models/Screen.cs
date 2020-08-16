using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyShow.Models
{
    public class Screen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public int SliverClass { get; set; }
        public int GoldClass { get; set; }
        public int Platinum { get; set; }
        public int VIP { get; set; }
        public int Capacity { get; set; }
    }
}