using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRS.Web.Models
{
    public class Lookup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }
}