using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRS.Web.Models
{
    public class LocationInfo
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string LocationName { get; set; }
        public string LocationHistory { get; set; }
        public string HowToGo { get; set; }
        public string Image { get; set; }
    }
}